using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeDashboard : EmployeePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Ctrl.Bf.ProfessionalID < 1)
                Response.Redirect("PageEmployeeEdit.aspx");

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                refreshController();

                SqlDataReader dr;

                // Marcacoes
                dr = Ctrl.getAppointments().ExecuteReader();
                tblAppointments.DataSource = dr;
                tblAppointments.DataBind();
                dr.Close();

                // Eventos
                dr = Ctrl.getSchedule().ExecuteReader();
                tblSchedule.DataSource = dr;
                tblSchedule.DataBind();
                dr.Close();
            }
        }
    }
}