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
    public partial class PageAnimalDiaryNew : ClientPage
    {
        int animalID;
        int serviceID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AnimalIDParam();
            ServiceIDParam();

                if (animalID < 1)
                    Response.Redirect("PageAnimalDashboard.aspx");
                else
                    if (!Ctrl.isOwnerOfAnimal(animalID))
                        Response.Redirect("PageAnimalDashboard.aspx");
                if (!IsPostBack)
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

                    calendarDateDiaryStart.SelectedDate = DateTime.Now;
                    calendarDateDiaryEnd.SelectedDate = DateTime.Now;

                    animalData.Close();
                }
        }

        protected bool DateValidation(DateTime start, DateTime end)
        {
            DateTime fakeDate = new DateTime(0001, 01, 01);
            if (start.Equals(fakeDate))
                return false;

            if (end.Equals(fakeDate))
                return false;

            if (start > end)
                return false;

            return true;
        }


        public void AnimalIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }

        public void ServiceIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ServiceID"]))
                int.TryParse(Request.QueryString["ServiceID"], out serviceID);
            else
                serviceID = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAnimalDiary.aspx?AnimalID=" + animalID);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int recordID;

            int diaryTypeID = Convert.ToInt32(ddlDiaryType.SelectedValue);
            DateTime start = calendarDateDiaryStart.SelectedDate;
            DateTime end = calendarDateDiaryEnd.SelectedDate;
            DateTime created = DateTime.Now;
            Decimal value = Convert.ToDecimal(boxDiaryValue.Text);
            string obs = Convert.ToString(boxDiaryObs.Text);

            if (DateValidation(start, end))
            {
                if (serviceID > 0 && Ctrl.isOwnerOfService(serviceID))
                {
                    recordID = Ctrl.insertDiary(animalID, diaryTypeID, start, end, created, value, obs, serviceID);
                    if (FileUpload.HasFile)
                        uploadFile(recordID);
                    Response.Redirect("PageAnimalHistoryItem.aspx?ServiceID=" + serviceID);
                }
                else
                {
                    recordID = Ctrl.insertDiary(animalID, diaryTypeID, start, end, created, value, obs, 0);
                    if (FileUpload.HasFile)
                        uploadFile(recordID);
                    Response.Redirect("PageAnimalDiary.aspx?AnimalID=" + animalID);
                }
            }
            else
                pnlError.Visible = true;
        }

        protected void uploadFile(int diaryID)
        {
                /* Folder Structure: ImagesDiary/.. */
                string path = Request.PhysicalApplicationPath + "ImagesDiary\\";
                path += diaryID + "\\";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                else
                    if (Directory.Exists(path + "diary.jpg")) /* There is a diary photo */
                        Directory.Delete(path + "diary.jpg");

                if (FileUpload.PostedFile.ContentType == "image/jpeg")
                {
                    if (FileUpload.PostedFile.ContentLength < 2048000)
                    {
                        string extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                        FileUpload.SaveAs(path + "diary" + extension);
                    }

                }
        }
    }
}