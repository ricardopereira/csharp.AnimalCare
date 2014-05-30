using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientLocalEdit : ClientPage
    {
        private int ownerLocalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            OwnerLocalIDParam();

            if (ownerLocalID > 0)
            {
                if (Ctrl.isOwnerOfLocal(ownerLocalID))
                {
                    if (!IsPostBack)
                    {

                        SqlDataReader localsData = Ctrl.getLocalByID(ownerLocalID).ExecuteReader();
                        if (!localsData.HasRows)
                        {
                            localsData.Close();
                            Ctrl.Database.Connection.Close();
                            return;
                        }

                        localsData.Read();

                        // Set Buffer
                        if (!localsData.IsDBNull(2))
                            boxName.Text = localsData.GetString(2);
                        if (!localsData.IsDBNull(3))
                            boxAddress.Text = localsData.GetString(3);
                        if (!localsData.IsDBNull(4))
                            boxZipCode.Text = localsData.GetString(4);
                        if (!localsData.IsDBNull(5))
                            boxGPS.Text = localsData.GetString(5);
                        if (!localsData.IsDBNull(6))
                            listCountry.SelectedValue = Convert.ToString(localsData.GetInt32(6));
                        if (!localsData.IsDBNull(7))
                            listCity.SelectedValue = Convert.ToString(localsData.GetInt32(7));
                        if (!localsData.IsDBNull(8))
                            chkIsMain.Checked = localsData.GetBoolean(8);

                        localsData.Close();
                    }
                }
                else
                    Response.Redirect("PageClientLocals.aspx");
            }
            else
                Response.Redirect("PageClientLocals.aspx");
        }

        public void OwnerLocalIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OwnerLocalID"]))
            {
                /* LocalID Get Param Specified */
                int.TryParse(Request.QueryString["OwnerLocalID"], out ownerLocalID);
            }
            else
                ownerLocalID = 0;
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

            if(chkIsMain.Checked)
                main=true;
            else
                main=false;

            Ctrl.updateLocalInfo(ownerLocalID, name, address, zipCode, GPS, country, city, main);

            Response.Redirect("PageClientLocals.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientLocals.aspx");
        }
    }
}