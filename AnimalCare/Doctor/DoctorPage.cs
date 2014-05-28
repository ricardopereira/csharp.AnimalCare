using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace AnimalCare.Doctor
{
    public class DoctorPage : System.Web.UI.Page
    {
        private ControllerDoctor ctrl;

        public ControllerDoctor Ctrl
        {
            get
            {
                if (ctrl == null)
                    ctrl = new ControllerDoctor(User.Identity);
                return ctrl;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            MasterPageDoctor master = (MasterPageDoctor)Master;

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