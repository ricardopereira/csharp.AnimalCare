using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class MasterPageClient : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler logOutClick;

        public void logout_Click(object sender, EventArgs e)
        {
            // Executa o custom event handler
            if (logOutClick != null)
                logOutClick(sender, e);
        }
    }
}