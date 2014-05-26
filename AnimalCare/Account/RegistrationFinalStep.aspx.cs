using AnimalCare.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Account
{
    public partial class RegistrationFinalStep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
                if (Request.UrlReferrer != null)
                    if (Request.UrlReferrer.AbsolutePath.ToString() == "/Account/Register.aspx")
                    {
                        ControllerClient ctrl = new ControllerClient(User.Identity);
                        ctrl.insertOwner();
                        Response.Redirect("/Client/PageClientEdit.aspx");
                    }
                    else
                        Response.Redirect("/");
                else
                    Response.Redirect("/");
            else
                Response.Redirect("/");
        }
    }
}