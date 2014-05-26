using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientEdit : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listBusinessSector.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (User.Identity.IsAuthenticated)
            {
                boxNome.Text = Ctrl.Bf.Name;
            }
        }

        protected void chkBusiness_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBusiness.Checked)
                listBusinessSector.Enabled = true;
            else
                listBusinessSector.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClient.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClient.aspx");
        }
    }
}