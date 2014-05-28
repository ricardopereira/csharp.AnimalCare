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
    public partial class PageAnimalEdit : ClientPage
    {
        private int animalID;
        private int numberOfAnimals;
        private int raceID;
        private int specieID;

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
                        PopulateDDLLocals();

                        String str = "SELECT * FROM Animals WHERE [AnimalID] = @id";
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

                        if (!data.IsDBNull(1))
                        {
                            ddlLocals.SelectedValue = Convert.ToString(data.GetInt32(1));
                        }
                        if (!data.IsDBNull(2))
                        {
                            animalName.Text = data.GetString(2);
                            boxName.Text = data.GetString(2);
                        }
                        if (!data.IsDBNull(3))
                            boxIdentity.Text = data.GetString(3);
                        if (!data.IsDBNull(4))
                        {
                            numberOfAnimals = data.GetInt32(4);
                            if (numberOfAnimals > 1)
                            {
                                chkGroup.Checked = true;
                                boxNumberAnimals.Text = Convert.ToString(numberOfAnimals);
                            }
                            else
                                chkGroup.Checked = false;
                        }
                        if (!data.IsDBNull(5))
                        {
                            raceID = data.GetInt32(5);
                        }
                        if (!data.IsDBNull(6))
                            ddlCondition.SelectedValue = Convert.ToString(data.GetInt32(6));
                        if (!data.IsDBNull(7))
                            ddlHabitat.SelectedValue = Convert.ToString(data.GetInt32(7));
                        if (!data.IsDBNull(8))
                            CalendarBirth.SelectedDate = data.GetDateTime(8);
                        if (!data.IsDBNull(9))
                        {
                            CalendarDeath.SelectedDate = Convert.ToDateTime(data.GetString(9));
                            chkDeceased.Checked = true;
                        }
                        if (!data.IsDBNull(10))
                            ddlSex.SelectedValue = Convert.ToString(data.GetInt16(10));
                        data.Close();

                         //Get Specie by Race
                        String strSpecie = "SELECT AnimalSpecieID FROM AnimalRaces WHERE [AnimalRaceID] = @sid";
                        SqlCommand cmdSpecie = new SqlCommand(strSpecie, Ctrl.Database.Connection);
                        cmdSpecie.Parameters.AddWithValue("@sid", raceID);
                        SqlDataReader dataSpecie = cmdSpecie.ExecuteReader();
                        dataSpecie.Read();
                        specieID = dataSpecie.GetInt32(0);
                        ddlSpecies.SelectedValue = Convert.ToString(specieID);
                        dataSpecie.Close();
                        PopulateDDLRaces(specieID);
                        ddlRaces.SelectedValue = Convert.ToString(raceID);
                    }
                } else
                    Response.Redirect("PageAnimalDashboard.aspx");
            }
            else
                Response.Redirect("/");
        }

        private void PopulateDDLRaces(int specieID)
        {
            String strRaces = "SELECT AnimalRaceId, Name FROM AnimalRaces WHERE [AnimalSpecieID] = @sid";
            SqlCommand cmdRaces = new SqlCommand(strRaces, Ctrl.Database.Connection);
            cmdRaces.Parameters.AddWithValue("@sid", specieID);
            SqlDataReader dataRaces = cmdRaces.ExecuteReader();

            ddlRaces.Items.Clear();

            if (dataRaces.HasRows)
                while (dataRaces.Read())
                    ddlRaces.Items.Add(new ListItem(dataRaces.GetString(1), Convert.ToString(dataRaces.GetInt32(0))));

            dataRaces.Close();
        }

        private void PopulateDDLLocals()
        {
            SqlDataReader dataLocals = Ctrl.getOwnerLocals().ExecuteReader();

            while (dataLocals.Read())
                ddlLocals.Items.Add(new ListItem(dataLocals.GetString(2), Convert.ToString(dataLocals.GetInt32(0))));
            dataLocals.Close();
        }

        private void AnimalIDParam() {
            /* AnimalID Get Param Specified */
            if(!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }

        private void SetProfileImage()
        {
            // Check if there is a profile image
            string path = Request.PhysicalApplicationPath + "ImagesAnimals\\" + animalID;
            if (Directory.Exists(path))
                animalImage.Attributes["src"] = "../ImagesAnimals/"  + animalID + "/profile.jpg";
            else
                animalImage.Attributes["src"] = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = boxName.Text;
            string identityNumber = boxIdentity.Text;
            int localID = Convert.ToInt32(ddlLocals.SelectedValue);
            int quantity;
            int animalRace = Convert.ToInt32(ddlRaces.SelectedValue);
            int animalCondition = Convert.ToInt32(ddlCondition.SelectedValue);
            int animalHabitat = Convert.ToInt32(ddlHabitat.SelectedValue);
            DateTime birth = CalendarBirth.SelectedDate;
            DateTime death;
            int sex = Convert.ToInt16(ddlSex.SelectedValue);

            if (chkGroup.Checked)
                quantity = Convert.ToInt16(boxNumberAnimals.Text);
            else
                quantity = 1;

            if (chkDeceased.Checked)
                death = CalendarDeath.SelectedDate;
            else
                death = new DateTime(0001,01,01); /* Fake data for Serialization */

            Ctrl.updateAnimalInfo(localID,animalID,name,identityNumber,quantity,animalRace,animalCondition,animalHabitat,birth,death,sex);
            
            Response.Redirect("PageAnimal.aspx?AnimalID=" + animalID);
        }

        protected void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroup.Checked)
            {
                boxNumberAnimals.Visible = true;
                lblNGroup.Visible = true;
            }
            else
            {
                boxNumberAnimals.Visible = false;
                lblNGroup.Visible = false;
            }
        }

        protected void chkDeceased_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeceased.Checked)
                CalendarDeath.Visible = true;
            else
                CalendarDeath.Visible = false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    /* Folder Structure: Images/OwnerID/.. */
                    string path = Request.PhysicalApplicationPath + "ImagesAnimals\\";
                    path +=  animalID + "\\";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    else
                        if(Directory.Exists(path + "profile.jpg")) /* There is a profile photo */
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAnimal.aspx");
        }

        protected void ddlSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDDLRaces(Convert.ToInt32(ddlSpecies.SelectedValue));
        }
    }
}