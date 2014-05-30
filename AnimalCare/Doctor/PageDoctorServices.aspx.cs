using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorServices : DoctorPage
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

                // Serviços
                dr = Ctrl.getAllServices(Ctrl.getMinDate(), Ctrl.getMaxDate(), Ctrl.Bf.ProfessionalID, 5).ExecuteReader();
                tblServices.DataSource = dr;
                tblServices.DataBind();
                dr.Close();
            }
        }
    }
}