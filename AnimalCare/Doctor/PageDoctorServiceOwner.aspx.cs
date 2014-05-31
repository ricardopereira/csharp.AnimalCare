using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorServiceOwner : DoctorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Ctrl.Bf.ProfessionalID < 1)
                Response.Redirect("PageDoctorEdit.aspx");

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
            Response.Redirect("PageDoctorDashboard.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageDoctorServiceAnimal.aspx");
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