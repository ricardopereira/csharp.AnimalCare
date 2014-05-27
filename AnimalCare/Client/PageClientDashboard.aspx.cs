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

                SqlDataReader dr;
                DateTime dateFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime dateLast = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

                // Marcacoes
                dr = Ctrl.getAppointments(dateFirst, dateLast).ExecuteReader();
                // Efectuar o data binding
                tblAppointments.DataSource = dr;
                tblAppointments.DataBind();
                dr.Close();

                // Agenda
                dr = Ctrl.getScheduleEvents(dateFirst, dateLast).ExecuteReader();
                // Efectuar o data binding
                tblSchedule.DataSource = dr;
                tblSchedule.DataBind();
                dr.Close();
            }
        }

        protected void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            // ToDo - Cancelar marcação
        }
    }
}