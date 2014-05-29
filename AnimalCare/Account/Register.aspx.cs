using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using AnimalCare.Client;

namespace AnimalCare.Account
{
    public partial class Register : Page
    {
        bool isLogged;
        bool isAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if(User.Identity.IsAuthenticated)
                isLogged = true;
            else
                isLogged = false;

            if (Roles.IsUserInRole(User.Identity.Name, "Admin"))
                isAdmin = true;
            else
                isAdmin = false;

        }

        private bool DoctorParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Doctor"]))
                return true;
            else
                return false;
        }

        private bool EmployeeParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Employee"]))
                return true;
            else
                return false;
        }

        private bool AdminParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Admin"]))
                return true;
            else
                return false;
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            if (isLogged)
            {
                if (isAdmin)
                    if (DoctorParam())
                        Roles.AddUserToRole(RegisterUser.UserName, "Doctor");
                    else
                        if (EmployeeParam())
                            Roles.AddUserToRole(RegisterUser.UserName, "Employee");
                        else
                            if (AdminParam())
                                Roles.AddUserToRole(RegisterUser.UserName, "Admin");
                Response.Redirect("../Admin/PageAdminUsers.aspx");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);
                Roles.AddUserToRole(RegisterUser.UserName, "Client");
            }

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "/Account/RegistrationFinalStep.aspx";
            }
            
            Response.Redirect(continueUrl);
        }
    }
}