using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Admin
{
    public partial class PageAdminUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/Register.aspx?Admin=true");
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/Register.aspx?Employee=true");
        }

        protected void btnAddDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/Register.aspx?Doctor=true");
        }
    }
}