﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalDiaryEdit : ClientPage
    {
        int itemID;
        int animalID;
        int serviceID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ItemDiaryParam();

            if (itemID > 0)
            {
                if (!IsPostBack)
                {
                    LoadItemInfo();

                    if (Ctrl.isOwnerOfAnimal(animalID))
                    {
                        getAnimalInfo();
                        setDiaryImage();
                    }
                }
                else
                {
                    SqlDataReader diaryData = Ctrl.getDiaryInfo(itemID).ExecuteReader();

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
                Response.Redirect("PageAnimalDashboard.aspx");
        }


        public void LoadItemInfo()
        {
            SqlDataReader diaryData = Ctrl.getDiaryInfo(itemID).ExecuteReader();

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

            if (!diaryData.IsDBNull(7))
                boxObs.Text = diaryData.GetString(7);

            if (!diaryData.IsDBNull(8))
                boxComment.Text = diaryData.GetString(8);

            if (!diaryData.IsDBNull(3))
                lblDateDiaryStart.Text = Convert.ToString(diaryData.GetDateTime(3));

            if (!diaryData.IsDBNull(4))
                lblDateDiaryEnd.Text = Convert.ToString(diaryData.GetDateTime(4));

            lblValue.Text = Convert.ToString(diaryData.GetDecimal(6));


            if (!diaryData.IsDBNull(9))
                serviceID = diaryData.GetInt32(9);

            diaryData.Close();
        }

        protected void setDiaryImage()
        {
            // Check if there is a diary image
            string path = Request.PhysicalApplicationPath + "ImagesDiary\\" + itemID;
            if (Directory.Exists(path))
            {
                itemImage.Attributes["src"] = "../ImagesDiary/" + itemID + "/diary.jpg";
                linkImage.Visible = true;
                linkImage.Attributes["href"] = "../ImagesDiary/" + itemID + "/diary.jpg";
            }
            else
                itemImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";

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

            if (!animalData.IsDBNull(0))
                lblAnimalName.Text = animalData.GetString(0);

            if (!animalData.IsDBNull(3))
                lblAnimalRace.Text = animalData.GetString(3);

            if (!animalData.IsDBNull(4))
                lblAnimalSpecie.Text = animalData.GetString(4);

            animalData.Close();
        }

        public void ItemDiaryParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["DiaryItem"]))
                int.TryParse(Request.QueryString["DiaryItem"], out itemID);
            else
                itemID = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (itemID <= 0) return;

            Ctrl.updateObservationOfDiary(itemID, boxObs.Text.Trim());

            Response.Redirect("PageAnimalHistoryItem.aspx?ServiceID=" + serviceID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAnimalHistoryItem.aspx?ServiceID=" + serviceID);
        }
    }
}