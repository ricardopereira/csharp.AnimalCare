using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalCare.Client
{
    public class ClientPage : System.Web.UI.Page
    {
        private int userID;

        protected int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            userID = 0;

            // Verifica sessão activa
            if (Session["userId"] == null)
                Response.Redirect("../Account/Login.aspx");


        }
    }
}