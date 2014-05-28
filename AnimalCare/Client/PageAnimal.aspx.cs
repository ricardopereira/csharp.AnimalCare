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

            if (User.Identity.IsAuthenticated)
            {
                if (animalID > 0) /* #16 - Verificar dono */
                {
                    if (!IsPostBack)
                    {
                        SetProfileImage();

                        String str = "SELECT a.Name, a.IdentityNumber, a.Quantity, ar.Name, ans.Name, ac.Description, a.Sex, a.DateBorn, oc.Name";
                        str += " FROM Animals a";
                        str += " INNER JOIN AnimalRaces ar ON ar.AnimalRaceID = a.AnimalRaceID";
                        str += " INNER JOIN AnimalSpecies ans ON ans.AnimalSpecieID = ar.AnimalSpecieID";
                        str += " INNER JOIN AnimalConditions ac ON a.AnimalConditionID = ac.AnimalConditionID";
                        str += " INNER JOIN OwnerLocals oc ON oc.OwnerLocalID = a.OwnerLocalID";
                        str += " WHERE [AnimalID] = @id";

                        SqlCommand cmd = new SqlCommand(str, Ctrl.Database.Connection);
                        cmd.Parameters.AddWithValue("@id", animalID);

                        SqlDataReader data = cmd.ExecuteReader();

                        if (!data.HasRows)
                        {
                            data.Close();
                            Ctrl.Database.Connection.Close();
                            return;
                        }

                        data.Read();
                        editLink.HRef = String.Format("/Client/PageAnimalEdit.aspx?AnimalID={0}", animalID);

                        if (!data.IsDBNull(0))
                        {
                            lblMainName.Text = data.GetString(0);
                            lblName.Text = data.GetString(0);
                        }
                        if (!data.IsDBNull(1))
                            lblIdentityNumber.Text = data.GetString(1);
                        if (!data.IsDBNull(2))
                        {
                            int numberOfAnimals = data.GetInt32(2);
                            if (numberOfAnimals > 1)
                                lblMainName.Text += " [GRUPO]";
                        }
                        if (!data.IsDBNull(3))
                            lblRace.Text = data.GetString(3);
                        if (!data.IsDBNull(4))
                            lblSpecie.Text = data.GetString(4);
                        if (!data.IsDBNull(5))
                            lblCondition.Text = data.GetString(5);
                        if (!data.IsDBNull(6))
                        {
                            int sex = data.GetInt16(6);
                            if (sex == 1)
                                lblSex.Text = "Masculino";
                            else
                                if (sex == 2)
                                    lblSex.Text = "Feminino";
                        }
                        if (!data.IsDBNull(7))
                            lblBornDate.Text = Convert.ToString(data.GetDateTime(7));
                        if (!data.IsDBNull(8))
                            lblPlace.Text = data.GetString(8);
                    }
                }
                else
                    Response.Redirect("PageAnimalDashboard.aspx");
            }
            else
                Response.Redirect("/");
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