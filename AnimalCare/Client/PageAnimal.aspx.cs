using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimal : ClientPage
    {
        private int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AnimalIDParam();
            lblDeath.Visible = false;

                if (animalID > 0)
                {
                    if (!IsPostBack)
                    {
                        SetProfileImage();

                        SqlDataReader animalData = Ctrl.getAnimalInfo(animalID).ExecuteReader();

                        if (!animalData.HasRows)
                        {
                            animalData.Close();
                            Ctrl.Database.Connection.Close();
                            return;
                        }

                        animalData.Read();
                        editLink.HRef = String.Format("/Client/PageAnimalEdit.aspx?AnimalID={0}", animalID);

                        if (!animalData.IsDBNull(0))
                        {
                            lblMainName.Text = animalData.GetString(0);
                            lblName.Text = animalData.GetString(0);
                        }
                        if (!animalData.IsDBNull(1))
                            lblIdentityNumber.Text = animalData.GetString(1);
                        if (!animalData.IsDBNull(2))
                        {
                            int numberOfAnimals = animalData.GetInt32(2);
                            if (numberOfAnimals > 1)
                                lblMainName.Text += " [GRUPO]";
                        }
                        if (!animalData.IsDBNull(3))
                            lblRace.Text = animalData.GetString(3);
                        if (!animalData.IsDBNull(4))
                            lblSpecie.Text = animalData.GetString(4);
                        if (!animalData.IsDBNull(5))
                            lblCondition.Text = animalData.GetString(5);
                        if (!animalData.IsDBNull(6))
                        {
                            int sex = animalData.GetInt16(6);
                            if (sex == 1)
                                lblSex.Text = "Masculino";
                            else
                                if (sex == 2)
                                    lblSex.Text = "Feminino";
                        }
                        if (!animalData.IsDBNull(7))
                            lblBornDate.Text = Convert.ToString(animalData.GetDateTime(7));
                        if (!animalData.IsDBNull(8))
                            lblPlace.Text = animalData.GetString(8);
                        if (!animalData.IsDBNull(9))
                            lblDeath.Visible = true;
                    }
                }
                else
                    Response.Redirect("PageAnimalDashboard.aspx");
        }

        private void AnimalIDParam()
        {
            /* AnimalID Get Param Specified */
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }

        private void SetProfileImage()
        {
            // Check if there is a profile image
            string path = Request.PhysicalApplicationPath + "ImagesAnimals\\" + animalID;
            if (Directory.Exists(path))
                animalImage.Attributes["src"] = "../ImagesAnimals/" + animalID + "/profile.jpg";
            else
                animalImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";
        }
    }
}