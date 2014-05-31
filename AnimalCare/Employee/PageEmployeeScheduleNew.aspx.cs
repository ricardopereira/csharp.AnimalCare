using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeScheduleNew : EmployeePage
    {
        private int appointmentID;
        private int ownerID;
        private int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            loadParameters();

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                // Horas
                listHour.Items.Clear();
                for (int i = 0; i < 24; i++)
                    listHour.Items.Add(Convert.ToString(i));

                // Minutos
                listMinutes.Items.Clear();
                for (int i = 0; i < 60; i++)
                    if (i % 5 == 0)
                        listMinutes.Items.Add(Convert.ToString(i));

                calDateEvent.SelectedDate = DateTime.Today;

                ownerID = Ctrl.getOwnerByAnimalID(animalID);

                if (appointmentID > 0)
                {
                    pnlAppointment.Visible = true;
                    loadAppointment();
                }
                else if (ownerID <= 0)
                {
                    // Pesquisa de Proprietário
                    Response.Redirect("PageEmployeeScheduleOwner.aspx");
                    return;
                }
                else if (animalID <= 0)
                {
                    // Pesquisa de Animal
                    Response.Redirect("PageEmployeeScheduleAnimal.aspx");
                    return;
                }

                if (lblOwner.Text.Trim().Equals(""))
                {
                    lblOwnerID.Text = Convert.ToString(ownerID);
                    lblOwner.Text = Ctrl.getOwnerName(ownerID);
                }

                if (lblAnimal.Text.Trim().Equals(""))
                {
                    lblAnimalID.Text = Convert.ToString(animalID);
                    loadAnimal();
                }
            }
        }

        private void loadAnimal()
        {
            SqlDataReader dr = Ctrl.getAnimal(animalID).ExecuteReader();
            if (!dr.HasRows) return;

            dr.Read();

            if (!dr.IsDBNull(2))
                lblAnimal.Text = dr.GetString(2);
            if (!dr.IsDBNull(13))
                lblRace.Text = dr.GetString(14);
            if (!dr.IsDBNull(14))
                lblSpecie.Text = dr.GetString(15);

            dr.Close();
        }

        private void loadAppointment()
        {
            AppointmentState currentState;

            String sql = Ctrl.getAllAppointmentsSQL() +
                " WHERE [AppointmentID] = @id";

            SqlCommand cmd = new SqlCommand(sql, Ctrl.Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            SqlDataReader data = cmd.ExecuteReader();

            if (!data.HasRows)
            {
                data.Close();
                Ctrl.Database.Connection.Close();
                return;
            }

            data.Read();

            if (!data.IsDBNull(0))
            {
                lblAppointmentID.Text = Convert.ToString(data.GetInt32(0));
            }

            if (!data.IsDBNull(1))
            {
                lblOwnerID.Text = Convert.ToString(data.GetInt32(1));
                ownerID = data.GetInt32(1); //Owner
            }

            if (!data.IsDBNull(2))
            {
                lblAnimalID.Text = Convert.ToString(data.GetInt32(2));
                animalID = data.GetInt32(2); //Animal
            }

            if (!data.IsDBNull(4)) {
                lblDate.Text = Convert.ToString(data.GetDateTime(4)); //Date
                calDateEvent.SelectedDate = data.GetDateTime(4);
            }

            if (!data.IsDBNull(7))
                lblDetail.Text = data.GetString(7); //Detail

            if (!data.IsDBNull(8))
            {
                if (!data.GetBoolean(8)) //Urgent
                    lblUrgent.Visible = false;
            }
            else
                lblUrgent.Visible = false;

            if (!data.IsDBNull(9))
                currentState = (AppointmentState)data.GetInt16(9); //State
            else
                currentState = AppointmentState.astRejected;

            if (!data.IsDBNull(10))
                lblAnimal.Text = data.GetString(10); //Animal

            if (!data.IsDBNull(11))
                lblOwner.Text = data.GetString(11); //Owner

            if (!data.IsDBNull(12))
                lblAppointmentType.Text = data.GetString(12); //AppointmentType

            if (!data.IsDBNull(13))
                lblSpecie.Text = data.GetString(13); //Specie

            if (!data.IsDBNull(14))
                lblRace.Text = data.GetString(14); //Race

            data.Close();
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AppointmentID"]))
                int.TryParse(Request.QueryString["AppointmentID"], out appointmentID);
            else
                appointmentID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (lblOwnerID.Text.Equals("")) return;
            if (lblAnimalID.Text.Equals("")) return;
            if (listProfessional.SelectedValue.Equals("")) return;
            if (listServiceKind.SelectedValue.Equals("")) return;

            int _ownerID = Convert.ToInt32(lblOwnerID.Text.Trim());
            int _animalID = Convert.ToInt32(lblAnimalID.Text.Trim());

            DateTime dateAux = calDateEvent.SelectedDate;

            dateAux = dateAux.AddHours(Convert.ToInt16(listHour.SelectedItem.Text));
            dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutes.SelectedItem.Text));

            Ctrl.insertScheduleEvent(_ownerID, _animalID, boxDescription.Text.Trim(), Convert.ToInt32(listServiceKind.SelectedValue), Convert.ToInt32(listProfessional.SelectedValue), dateAux);

            if (!lblAppointmentID.Text.Equals(""))
                Ctrl.saveAppointment(Convert.ToInt32(lblAppointmentID.Text.Trim()), (int)AppointmentState.astAccepted, "Agendado para " + Convert.ToString(calDateEvent.SelectedDate));

            Response.Redirect("~/Employee/PageEmployeeDashboard.aspx");
        }
    }
}