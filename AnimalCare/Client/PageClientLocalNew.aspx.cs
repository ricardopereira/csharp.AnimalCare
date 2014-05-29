using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientLocalNew : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = boxName.Text;
            string address = boxAddress.Text;
            string zipCode = boxZipCode.Text;
            string GPS = boxGPS.Text;
            int country = Convert.ToInt32(listCountry.SelectedValue);
            int city = Convert.ToInt32(listCity.SelectedValue);
            bool main;

            if (chkIsMain.Checked)
                main = true;
            else
                main = false;

            Ctrl.insertLocalInfo(name, address, zipCode, GPS, country, city, main);

            Response.Redirect("PageClientLocals.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientLocals.aspx");
        }
    }
}