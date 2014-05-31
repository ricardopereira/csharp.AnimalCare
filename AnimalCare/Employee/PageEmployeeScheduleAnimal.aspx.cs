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

            if (Ctrl.Bf.ProfessionalID < 1)
                Response.Redirect("PageEmployeeEdit.aspx");

            loadParameters();

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                refreshController();

                if (ownerID > 0)
                {
                    lblOwner.Text = Ctrl.getOwnerName(ownerID);
                    lblOwnerName.Text = lblOwner.Text;

                    SqlDataReader dr;
                    // Marcacoes
                    dr = Ctrl.getAllAnimals(ownerID).ExecuteReader();

                    if (!dr.HasRows)
                        pnlError.Visible = true;

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
    }
}