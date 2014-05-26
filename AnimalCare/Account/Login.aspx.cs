using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/");
            }
            RegisterHyperLink.NavigateUrl = "Register.aspx";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(Login1.UserName, "Client"))
                Response.Redirect("/Client/PageClientDashboard.aspx");
            else if (Roles.IsUserInRole(Login1.UserName, "Admin"))
                Response.Redirect("/Admin/PageAdminDashboard.aspx");
            else if (Roles.IsUserInRole(Login1.UserName, "Employee"))
                Response.Redirect("/Employee/PageEmployeeDashboard.aspx");
            else if (Roles.IsUserInRole(Login1.UserName, "Doctor"))
                Response.Redirect("/Doctor/PageDoctorDashboard.aspx");
            else
                Response.Redirect("/");
        }
    }
}