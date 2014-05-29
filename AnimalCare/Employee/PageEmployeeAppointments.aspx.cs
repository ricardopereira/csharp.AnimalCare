using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeAppointments : EmployeePage
    {
        private int appointmentID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (User.Identity.IsAuthenticated)
            {
                loadAppointmentID();

                if (appointmentID > 0) /* #16 - Verificar dono */
                {
                    if (!IsPostBack)
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

                        if (!data.IsDBNull(5))
                            lblDate.Text = Convert.ToString(data.GetDateTime(5)); //Date

                        if (!data.IsDBNull(7))
                            boxReason.Text = data.GetString(7); //Reason

                        if (!data.IsDBNull(8))
                            lblDetail.Text = data.GetString(8); //Detail

                        if (!data.IsDBNull(9)) {
                            if (!data.GetBoolean(9)) //Urgent
                                lblUrgent.Visible = false;
                        }
                        else
                            lblUrgent.Visible = false;

                        if (!data.IsDBNull(10))
                            currentState = (AppointmentState)data.GetInt16(10); //State
                        else
                            currentState = AppointmentState.astRejected;

                        if (!data.IsDBNull(11))
                            lblAnimal.Text = data.GetString(11); //Animal

                        if (!data.IsDBNull(12))
                            lblOwner.Text = data.GetString(12); //Owner

                        if (!data.IsDBNull(13))
                            lblAppointmentType.Text = data.GetString(13); //AppointmentType

                        if (!data.IsDBNull(14))
                            lblSpecie.Text = data.GetString(14); //Specie

                        if (!data.IsDBNull(15))
                            lblRace.Text = data.GetString(15); //Race

                        data.Close();

                        // Verificar os dados
                        if (currentState == AppointmentState.astCanceled) {
                            btnCreateAndSave.Visible = false;
                            btnSave.Text = "Ignorar";
                            btnSave.CausesValidation = false;
                            lblCanceled.Visible = true;
                            boxReason.ReadOnly = true;
                            rdbState.Enabled = false;
                        }
                        else if (currentState == AppointmentState.astAccepted) {
                            rdbState.SelectedIndex = 0;
                        }

                        // Verificar o estado
                        if (rdbState.SelectedIndex >= 0)
                            rdbState_SelectedIndexChanged(null, null);
                    }
                }
                else
                    Response.Redirect("PageEmployeeDashboard.aspx");
            }
            else
                Response.Redirect("/");
        }

        private void loadAppointmentID()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AppointmentID"]))
                int.TryParse(Request.QueryString["AppointmentID"], out appointmentID);
            else
                appointmentID = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEmployeeDashboard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Ignorar"))
            {
                // Ignorar
                Ctrl.ignoreAppointment(appointmentID);
            }
            else
            {
                // Gravar
                Ctrl.saveAppointment(appointmentID, Convert.ToInt16(rdbState.SelectedValue), boxReason.Text);
            }
            Response.Redirect("PageEmployeeDashboard.aspx");
        }

        protected void btnCreateAndSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(rdbState.SelectedValue) == (int)AppointmentState.astRejected) 
                return;

            Response.Redirect(String.Format("PageEmployeeScheduleNew.aspx/?AppointmentID={0}", appointmentID));
        }

        protected void rdbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbState.SelectedIndex == 1)
            {
                boxReason.Visible = true;
            }
            else
            {
                boxReason.Visible = false;
            }
            lblReason.Visible = boxReason.Visible;
            btnSave.CausesValidation = boxReason.Visible;
        }
    }
}