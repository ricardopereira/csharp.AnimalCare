using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorEdit : DoctorPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                setProfileImage();

                boxName.Text = Ctrl.Bf.Name;
                boxCodeWorker.Text = Ctrl.Bf.CodeWorker;
                boxWorkNumber.Text = Ctrl.Bf.WorkNumber;
                boxPersonalNumber.Text = Ctrl.Bf.PersonalNumber;
                if (Ctrl.Bf.ProfessionalID > 0)
                    uploadImage.Visible = true;
            }
        }

        protected void setProfileImage()
        {
            // Check if there is a profile image
            string path = Request.PhysicalApplicationPath + "ImagesProfessionals\\" + Ctrl.Bf.ProfessionalID;
            if (Directory.Exists(path))
                profileImage.Attributes["src"] = "../ImagesProfessionals/" + Ctrl.Bf.ProfessionalID + "/profile.jpg";
            else
                profileImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = boxName.Text.Trim();
            string codeWorker = boxCodeWorker.Text.Trim();
            string workNumber = boxWorkNumber.Text.Trim();
            string personalNumber = boxPersonalNumber.Text.Trim();

            if (Ctrl.Bf.ProfessionalID > 0)
                Ctrl.updateDoctorInfo(name, codeWorker, workNumber, personalNumber);
            else
                Ctrl.insertDoctorInfo(name, codeWorker, workNumber, personalNumber);

            Response.Redirect("PageDoctor.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageDoctor.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    /* Folder Structure: Images/OwnerID/.. */
                    string path = Request.PhysicalApplicationPath + "ImagesProfessionals\\";
                    path += Ctrl.Bf.ProfessionalID + "\\";

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