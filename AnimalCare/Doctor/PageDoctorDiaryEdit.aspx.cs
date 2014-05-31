using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorDiaryEdit : DoctorPage
    {
        int animalDiaryID;
        int animalID;
        int serviceID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            loadParameters();

            if (animalDiaryID > 0)
            {
                if (!IsPostBack)
                {
                    loadDiary();
                }
                else
                {
                    SqlDataReader diaryData = Ctrl.getDiaryInfo(animalDiaryID).ExecuteReader();

                    if (!diaryData.HasRows)
                    {
                        diaryData.Close();
                        Ctrl.Database.Connection.Close();
                        return;
                    }

                    diaryData.Read();

                    if (!diaryData.IsDBNull(9))
                        serviceID = diaryData.GetInt32(9);

                    diaryData.Close();
                }
            }
            else
                Response.Redirect("PageDoctorDashboard.aspx");
        }

        private void loadDiary()
        {
            SqlDataReader diaryData = Ctrl.getDiaryInfo(animalDiaryID).ExecuteReader();

            if (!diaryData.HasRows)
            {
                diaryData.Close();
                Ctrl.Database.Connection.Close();
                return;
            }

            diaryData.Read();

            animalID = diaryData.GetInt32(1);

            if (!diaryData.IsDBNull(10))
                lblDiaryType.Text = diaryData.GetString(10);

            if (!diaryData.IsDBNull(3))
                lblDateDiaryStart.Text = Convert.ToString(diaryData.GetDateTime(3));

            if (!diaryData.IsDBNull(4))
                lblDateDiaryEnd.Text = Convert.ToString(diaryData.GetDateTime(4));

            lblValue.Text = Convert.ToString(diaryData.GetDecimal(6));

            if (!diaryData.IsDBNull(7))
                lblDiaryObs.Text = diaryData.GetString(7);

            if (!diaryData.IsDBNull(8))
                boxComment.Text = diaryData.GetString(8);

            if (!diaryData.IsDBNull(9))
                serviceID = diaryData.GetInt32(9);

            diaryData.Close();

            loadService();
        }

        private void loadService()
        {
            if (serviceID <= 0) return;

            SqlDataReader data = Ctrl.getService(serviceID).ExecuteReader();
            if (!data.HasRows) return;

            data.Read();

            if (!data.IsDBNull(12))
                lblOwner.Text = data.GetString(12);

            if (!data.IsDBNull(13))
                lblAnimal.Text = data.GetString(13);

            if (!data.IsDBNull(17))
                lblRace.Text = data.GetString(17);

            if (!data.IsDBNull(16))
                lblSpecie.Text = data.GetString(16);

            data.Close();
        }

        protected void setDiaryImage()
        {
            // Check if there is a diary image
            string path = Request.PhysicalApplicationPath + "ImagesDiary\\" + animalDiaryID;
            if (Directory.Exists(path))
            {
                itemImage.Attributes["src"] = "../ImagesDiary/" + animalDiaryID + "/diary.jpg";
                linkImage.Visible = true;
                linkImage.Attributes["href"] = "../ImagesDiary/" + animalDiaryID + "/diary.jpg";
            }
            else
                itemImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";

        }

        public void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalDiaryID"]))
                int.TryParse(Request.QueryString["AnimalDiaryID"], out animalDiaryID);
            else
                animalDiaryID = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Doctor/PageDoctorServiceEdit.aspx?ServiceID="+Convert.ToString(serviceID));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (animalDiaryID <= 0) return;

            Ctrl.updateCommentOfDiary(animalDiaryID, boxComment.Text.Trim());

            Response.Redirect("~/Doctor/PageDoctorServiceEdit.aspx?ServiceID=" + Convert.ToString(serviceID));
        }
    }
}