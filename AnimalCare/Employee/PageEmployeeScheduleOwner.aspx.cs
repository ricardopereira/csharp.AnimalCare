using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeScheduleOwner : EmployeePage
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
                // Marcacoes
                dr = Ctrl.getAllOwners().ExecuteReader();
                // Efectuar o data binding
                tblOwners.DataSource = dr;
                tblOwners.DataBind();
                dr.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEmployeeDashboard.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEmployeeScheduleAnimal.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = Ctrl.getAllOwners(boxFilter.Text.Trim()).ExecuteReader();
            // Efectuar o data binding
            tblOwners.DataSource = dr;
            tblOwners.DataBind();
            dr.Close();
        }
    }
}