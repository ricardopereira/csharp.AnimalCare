using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace AnimalCare.Client
{
    public class ClientPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            MasterPageClient master = (MasterPageClient)Master;

            // Verificar se esta autenticado
            if (!User.Identity.IsAuthenticated)
                logIn();
        }

        protected void logIn()
        {
            // Redirecciona para a pagina de inicio de sessao
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}