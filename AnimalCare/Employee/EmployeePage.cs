using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace AnimalCare.Employee
{
    public class EmployeePage : System.Web.UI.Page
    {
        private ControllerEmployee ctrl;

        public ControllerEmployee Ctrl
        {
            get
            {
                if (ctrl == null)
                    ctrl = new ControllerEmployee(User.Identity);
                return ctrl;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            MasterPageEmployee master = (MasterPageEmployee)Master;

            // Verificar se esta autenticado
            if (!User.Identity.IsAuthenticated)
                logIn();
        }

        protected void logIn()
        {
            // Redirecciona para a pagina de inicio de sessao
            FormsAuthentication.RedirectToLoginPage();
        }

        public void refreshController()
        {
            ctrl = null;
        }

        public void refreshPage()
        {
            Response.Redirect(System.IO.Path.GetFileName(Request.Url.AbsolutePath));
        }
    }
}