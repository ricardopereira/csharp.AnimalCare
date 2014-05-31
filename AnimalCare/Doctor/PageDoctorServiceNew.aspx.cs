using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorServiceNew : DoctorPage
    {
        private int scheduleID;
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
                loadDefault();

                if (scheduleID > 0)
                {
                    pnlSchedule.Visible = true;
                    loadSchedule();
                }
                else if (ownerID <= 0)
                {
                    // Pesquisa de Proprietário
                    Response.Redirect("PageDoctorServiceOwner.aspx");
                    return;
                }
                else if (animalID <= 0)
                {
                    // Pesquisa de Animal
                    Response.Redirect("PageDoctorServiceAnimal.aspx");
                    return;
                }

                if (lblOwner.Text.Trim().Equals(""))
                {
                    lblOwner.Text = Ctrl.getOwnerName(ownerID);
                }

                if (lblAnimal.Text.Trim().Equals(""))
                {
                    loadAnimal();
                }
            }
        }

        private void loadDefault()
        {
            // Horas
            listHourService.Items.Clear();
            for (int i = 0; i < 24; i++)
                listHourService.Items.Add(Convert.ToString(i));

            // Minutos
            listMinutesService.Items.Clear();
            for (int i = 0; i < 60; i++)
                if (i % 5 == 0)
                    listMinutesService.Items.Add(Convert.ToString(i));

            calDateService.SelectedDate = DateTime.Today;

            listHourService.SelectedValue = Convert.ToString(DateTime.Now.Hour);
        }

        private void loadAnimal()
        {
            SqlDataReader dr = Ctrl.getAnimal(animalID).ExecuteReader();
            if (!dr.HasRows) return;

            dr.Read();

            if (!dr.IsDBNull(2))
                lblAnimal.Text = dr.GetString(2);
            if (!dr.IsDBNull(14))
                lblRace.Text = dr.GetString(14);
            if (!dr.IsDBNull(15))
                lblSpecie.Text = dr.GetString(15);

            dr.Close();
        }

        private void loadSchedule()
        {
            SqlDataReader dr = Ctrl.getSchedule(scheduleID).ExecuteReader();
            if (!dr.HasRows) return;

            dr.Read();

            if (!dr.IsDBNull(8))
                ownerID = dr.GetInt32(8);
            if (!dr.IsDBNull(9))
                animalID = dr.GetInt32(9);

            if (!dr.IsDBNull(14))
                lblAnimal.Text = dr.GetString(14);
            if (!dr.IsDBNull(18))
                lblRace.Text = dr.GetString(18);
            if (!dr.IsDBNull(17))
                lblSpecie.Text = dr.GetString(17);

            if (!dr.IsDBNull(1))
                lblScheduleDescription.Text = dr.GetString(1);
            if (!dr.IsDBNull(16))
                lblScheduleServiceKind.Text = dr.GetString(16);

            if (!dr.IsDBNull(7))
                listServiceKind.SelectedValue = Convert.ToString(dr.GetInt32(7));

            dr.Close();
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ScheduleID"]))
                int.TryParse(Request.QueryString["ScheduleID"], out scheduleID);
            else
                scheduleID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["OwnerID"]))
                int.TryParse(Request.QueryString["OwnerID"], out ownerID);
            else
                ownerID = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ownerID <= 0) return;
            if (animalID <= 0) return;
            if (listServiceKind.SelectedValue.Equals("")) return;
            if (listClinic.SelectedValue.Equals("")) return;

            DateTime dateAux = calDateService.SelectedDate;

            dateAux = dateAux.AddHours(Convert.ToInt16(listHourService.SelectedItem.Text));
            dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutesService.SelectedItem.Text));

            Ctrl.insertServiceEvent(ownerID, animalID, boxDescription.Text.Trim(), "",
                Convert.ToInt32(listServiceKind.SelectedValue),
                Ctrl.Bf.ProfessionalID, Convert.ToInt32(listClinic.SelectedValue),
                dateAux);

            if (scheduleID > 0)
                Ctrl.updateSchedule_Done(scheduleID);

            Response.Redirect("~/Doctor/PageDoctorDashboard.aspx");
        }
    }
}