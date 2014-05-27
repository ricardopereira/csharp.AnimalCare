using System;
using System.Collections.Generic;
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

            if (User.Identity.IsAuthenticated)
            {
                refreshController();

                DateTime dateFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime dateLast = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

                SqlDataReader dr = Ctrl.getAppointments(dateFirst, dateLast).ExecuteReader();

                // Efectuar o data binding
                tblAppointments.DataSource = dr;
                tblAppointments.DataBind();

                dr.Close();
            }
        }
    }
}