using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeScheduleEdit : EmployeePage
    {
        private int scheduleID;

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

                if (scheduleID > 0)
                {
                    loadSchedule();
                }
                else
                    Response.Redirect("~/Employee/PageEmployeeDashboard.aspx");
            }
        }

        private void loadSchedule()
        {
            SqlDataReader data = Ctrl.getSchedule(scheduleID).ExecuteReader();
            if (!data.HasRows) return;

            data.Read();

            
            if (!data.IsDBNull(0))
                lblScheduleID.Text = Convert.ToString(data.GetInt32(0)); //ScheduleID

            if (!data.IsDBNull(2))
            {
                DateTime dateAux = data.GetDateTime(2);
                calDateEvent.SelectedDate = dateAux.Date;
                listHour.SelectedValue = Convert.ToString(dateAux.Hour);
                listMinutes.SelectedValue = Convert.ToString(dateAux.Minute);
            }

            if (!data.IsDBNull(14))
                lblOwner.Text = data.GetString(14);

            if (!data.IsDBNull(15))
                lblAnimal.Text = data.GetString(15);

            if (!data.IsDBNull(19))
                lblRace.Text = data.GetString(19);

            if (!data.IsDBNull(18))
                lblSpecie.Text = data.GetString(18);

            if (!data.IsDBNull(7))
                listServiceKind.SelectedValue = Convert.ToString(data.GetInt32(7));

            if (!data.IsDBNull(11))
                listProfessional.SelectedValue = Convert.ToString(data.GetInt32(11));

            if (!data.IsDBNull(3))
                chkNotified.Checked = data.GetBoolean(3);

            if (!data.IsDBNull(4))
                chkPresent.Checked = data.GetBoolean(4);

            if (!data.IsDBNull(1))
                boxDescription.Text = data.GetString(1);

            data.Close();
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ScheduleID"]))
                int.TryParse(Request.QueryString["ScheduleID"], out scheduleID);
            else
                scheduleID = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblScheduleID.Text.Equals("")) return;
            if (listProfessional.SelectedValue.Equals("")) return;
            if (listServiceKind.SelectedValue.Equals("")) return;

            int _scheduleID = Convert.ToInt32(lblScheduleID.Text.Trim());

            DateTime dateAux = calDateEvent.SelectedDate;

            dateAux = dateAux.AddHours(Convert.ToInt16(listHour.SelectedItem.Text));
            dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutes.SelectedItem.Text));

            Ctrl.updateScheduleEvent(_scheduleID, boxDescription.Text.Trim(), chkNotified.Checked, chkPresent.Checked, Convert.ToInt32(listServiceKind.SelectedValue), Convert.ToInt32(listProfessional.SelectedValue), dateAux);

            Response.Redirect("~/Employee/PageEmployeeDashboard.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblScheduleID.Text.Equals("")) return;
            int _scheduleID = Convert.ToInt32(lblScheduleID.Text.Trim());
            Ctrl.deleteScheduleEvent(_scheduleID);
            Response.Redirect("~/Employee/PageEmployeeDashboard.aspx");
        }
    }
}