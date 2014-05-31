using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientHistoryItem : ClientPage
    {
        int serviceID;
        int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ServiceIDParam();

            if (serviceID > 0)
            {
                if (!IsPostBack)
                {
                    if (Ctrl.isOwnerOfService(serviceID))
                    {
                        LoadServiceInfo();
                        getAnimalInfo();
                        linkDiary.Attributes["href"] = "PageAnimalDiaryNew.aspx?AnimalID=" + animalID + "&ServiceID=" + serviceID;

                        SqlDataReader dr;

                        dr = Ctrl.getAnimalDiaryByService(animalID, serviceID).ExecuteReader();
                        tblDiary.DataSource = dr;
                        tblDiary.DataBind();
                        dr.Close();
                    }
                    else
                        Response.Redirect("PageAnimalHistory.aspx");
                }
                else
                {
                    SqlDataReader serviceData = Ctrl.getServiceInfo(serviceID).ExecuteReader();

                    if (!serviceData.HasRows)
                    {
                        serviceData.Close();
                        Ctrl.Database.Connection.Close();
                        return;
                    }

                    serviceData.Read();

                    animalID = serviceData.GetInt32(5);

                    serviceData.Close();
                }
            }
            else
                Response.Redirect("PageAnimalHistory.aspx");
        }

        public void LoadServiceInfo()
        {
            SqlDataReader serviceData = Ctrl.getServiceInfo(serviceID).ExecuteReader();

            if (!serviceData.HasRows)
            {
                serviceData.Close();
                Ctrl.Database.Connection.Close();
                return;
            }

            serviceData.Read();

            animalID = serviceData.GetInt32(5);

            if (!serviceData.IsDBNull(0))
                lblServiceKind.Text = serviceData.GetString(0);

            if (!serviceData.IsDBNull(1))
                lblServiceDescription.Text = serviceData.GetString(1);

            if (!serviceData.IsDBNull(2))
                lblDateService.Text = Convert.ToString(serviceData.GetDateTime(2));

            if(!serviceData.IsDBNull(3))
                lblDateConclusion.Text = Convert.ToString(serviceData.GetDateTime(3));
            else
                lblDateConclusion.Text = "--";

            if (!serviceData.IsDBNull(4))
                lblObservation.Text = serviceData.GetString(4);

            if (!serviceData.IsDBNull(6))
                lblProfessional.Text = serviceData.GetString(6);

            if (!serviceData.IsDBNull(7))
                lblClinic.Text = serviceData.GetString(7);

            serviceData.Close();
        }

        public void getAnimalInfo()
        {
            SqlDataReader animalData = Ctrl.getAnimalInfo(animalID).ExecuteReader();

            if (!animalData.HasRows)
            {
                animalData.Close();
                Ctrl.Database.Connection.Close();
                return;
            }

            animalData.Read();

            lblAnimalName.Text = animalData.GetString(0);
            lblAnimalRace.Text = animalData.GetString(3);
            lblAnimalSpecie.Text = animalData.GetString(4);

            animalData.Close();
        }

        public void ServiceIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ServiceID"]))
                int.TryParse(Request.QueryString["ServiceID"], out serviceID);
            else
                serviceID = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client/PageAnimalHistory.aspx?AnimalID=" + Convert.ToString(animalID));
        }
    }
}