using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientDashboard : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                refreshController();

                lblAnimalsCount.Text += Convert.ToString(Ctrl.getOwnerAnimalsCount());

                SqlDataReader dr;

                // Marcacoes
                dr = Ctrl.getAppointments().ExecuteReader();
                // Efectuar o data binding
                tblAppointments.DataSource = dr;
                tblAppointments.DataBind();
                dr.Close();

                // Agenda
                dr = Ctrl.getScheduleEvents().ExecuteReader();
                // Efectuar o data binding
                tblSchedule.DataSource = dr;
                tblSchedule.DataBind();
                dr.Close();
            }
        }

        protected void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            //Ctrl.cancelAppointment();
        }

        protected void tblAppointments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("CancelAppointment"))
            {
                int AppointmentID = Convert.ToInt32(e.CommandArgument);
                Ctrl.cancelAppointment(AppointmentID);
                refreshPage();
            }
            //((Button)e.CommandSource).Text
        }
    }
}