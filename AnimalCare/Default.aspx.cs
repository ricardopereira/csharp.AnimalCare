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
            if (Session["userName"] != null && Session["userType"] != null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Lit1.Text = Session["userName"].ToString();
                

                dLink.HRef = String.Format("{1}.aspx?userID={0}",Session["userId"],linkByUserType(Convert.ToInt32(Session["userType"])));
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }

        private String linkByUserType(int userType)
        {
            switch (userType)
            {
                case 1: return "Admin/PageAdmin";
                case 2: return "Doctor/PageDoctor";
                case 3: return "Employee/PageEmployee";
                case 4: return "Client/PageClient";
                default: break;
            }
            return "0";
        }
    }
}