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
    public partial class PageClientEdit : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listBusinessSector.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                setProfileImage();

                boxName.Text = Ctrl.Bf.Name;
                boxTaxNumber.Text = Ctrl.Bf.TaxNumber;

                if (Ctrl.Bf.CountryID != 0) /* Country previously selected */
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


        protected void setProfileImage()
         {
             // Check if there is a profile image
             string path = Request.PhysicalApplicationPath + "Images\\" + Ctrl.Bf.OwnerID;
             if (Directory.Exists(path))
                 profileImage.Attributes["src"] = "../Images/" + Ctrl.Bf.OwnerID + "/profile.jpg";
             else
                 profileImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";
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
            string name = boxName.Text.Trim();
            string taxNumber = boxTaxNumber.Text.Trim();
            int country = Convert.ToInt16(listCountry.SelectedValue);
            int business;
            int businessID;
            string mobileNumber = boxMobileNumber.Text.Trim();
            string faxNumber = boxFaxNumber.Text.Trim();

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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    /* Folder Structure: Images/OwnerID/.. */
                    string path = Request.PhysicalApplicationPath + "Images\\";
                    path += Ctrl.Bf.OwnerID + "\\";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    else
                        if (Directory.Exists(path + "profile.jpg")) /* There is a profile photo */
                            Directory.Delete(path + "profile.jpg");

                    if (FileUpload.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUpload.PostedFile.ContentLength < 2048000)
                        {
                            string extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                            FileUpload.SaveAs(path + "profile" + extension);
                            uploadMessage.Text = "Imagem carregada!";
                        }
                        else
                            uploadMessage.Text = "Tamanho máximo: 2Mb";
                    }
                    else
                        uploadMessage.Text = "Tipo de ficheiro inválido";
                }
                catch (Exception ex)
                {
                    uploadMessage.Text = "Ocorreu um erro: " + ex; ;
                }
            }
        }
    }
}