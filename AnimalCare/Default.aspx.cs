using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                pnlLogin.Visible = false;
                pnlLoggedIn.Visible = true;
                Lit1.Text = User.Identity.Name;
                //dLink.HRef = String.Format("{1}.aspx?userID={0}", Session["userId"], linkByUserType(Convert.ToInt32(Session["userType"])));
            }
            else
            {
                pnlLoggedIn.Visible = false;
            }
        }
    }
}