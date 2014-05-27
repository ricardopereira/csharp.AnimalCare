using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                boxName.Text = Ctrl.Bf.Name;
                boxTaxNumber.Text = Ctrl.Bf.TaxNumber;

                if(Ctrl.Bf.CountryID != 0) /* Country previously selected */
                    listCountry.SelectedValue = Convert.ToString(Ctrl.Bf.CountryID);

                if (Ctrl.Bf.Business)
                {
                    chkBusiness.Checked = true;
                    if (Ctrl.Bf.BusinessSectorID != 0)
                        listBusinessSector.SelectedValue = Convert.ToString(Ctrl.Bf.BusinessSectorID);
                }
                else
                {
                    listBusinessSector.Enabled = false;
                }
                
                boxMobileNumber.Text = Ctrl.Bf.MobileNumber;
                boxFaxNumber.Text = Ctrl.Bf.FaxNumber;
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
            string name = boxName.Text;
            string taxNumber = boxTaxNumber.Text;
            int country = Convert.ToInt16(listCountry.SelectedValue);
            int business;
            int businessID;
            string mobileNumber = boxMobileNumber.Text;
            string faxNumber = boxFaxNumber.Text;

            if(chkBusiness.Checked)
            {
                business = 1;
                businessID = Convert.ToInt16(listBusinessSector.SelectedValue);
            }
            else
            {
                business = 0;
                businessID = 0;
            }

            Ctrl.updateUserInfo(name, taxNumber, country, business, businessID, mobileNumber, faxNumber);
            Response.Redirect("PageClient.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClient.aspx");
        }
    }
}