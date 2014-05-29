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

            loadAppointmentID();

            if (User.Identity.IsAuthenticated)
            {
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

                        if (!data.IsDBNull(8)) {
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
            if (!btnSave.CausesValidation)
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

            Response.Redirect(String.Format("PageEmployeeScheduleNew.aspx&AppointmentID={0}", appointmentID));
        }
    }
}