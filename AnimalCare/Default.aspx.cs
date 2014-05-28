using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                string link = "";
                pnlLogin.Visible = false;
                pnlLoggedIn.Visible = true;
                Lit1.Text = User.Identity.Name;

                if (Roles.IsUserInRole(User.Identity.Name, "Client"))
                    link = "/Client/PageClientDashboard";
                else if (Roles.IsUserInRole(User.Identity.Name, "Admin"))
                    link = "/Admin/PageAdminDashboard";
                else if (Roles.IsUserInRole(User.Identity.Name, "Employee"))
                    link = "/Employee/PageEmployeeDashboard";
                else if (Roles.IsUserInRole(User.Identity.Name, "Doctor"))
                    link = "/Doctor/PageDoctorDashboard";

                profileId.HRef = String.Format("{0}.aspx",link);
            }
            else
            {
                pnlLoggedIn.Visible = false;
            }
        }
    }
}