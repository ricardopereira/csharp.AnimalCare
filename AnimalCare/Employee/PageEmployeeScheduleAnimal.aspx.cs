using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeScheduleAnimal : EmployeePage
    {
        private int ownerID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            loadParameters();

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                refreshController();

                if (ownerID > 0)
                {
                    lblOwner.Text = Ctrl.getOwnerName(ownerID);

                    SqlDataReader dr;
                    // Marcacoes
                    dr = Ctrl.getAllAnimals(ownerID).ExecuteReader();

                    // Efectuar o data binding
                    tblAnimals.DataSource = dr;
                    tblAnimals.DataBind();

                    dr.Close();
                }
                else
                {
                    Response.Redirect("PageEmployeeScheduleOwner.aspx");
                }
            }
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OwnerID"]))
                int.TryParse(Request.QueryString["OwnerID"], out ownerID);
            else
                ownerID = 0;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEmployeeScheduleNew.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEmployeeDashboard.aspx");
        }
    }
}