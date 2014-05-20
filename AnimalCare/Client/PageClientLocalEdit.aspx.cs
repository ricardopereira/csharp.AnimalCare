using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientLocalEdit : System.Web.UI.Page
    {
        private int ownerLocalID;

        public void loadOwnerLocalID()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OwnerLocalID"]))
            {
                // Modo edição
                int.TryParse(Request.QueryString["OwnerLocalID"], out ownerLocalID);
            }
            else
                ownerLocalID = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ownerLocalID = 0;

                if (!string.IsNullOrEmpty(Request.QueryString["OwnerLocalID"]))
                {
                    // Modo edição
                    int.TryParse(Request.QueryString["OwnerLocalID"], out ownerLocalID);

                    DBConn db = new DBConn();
                    // Carregar os dados
                    String str = "SELECT * FROM OwnerLocals WHERE [OwnerLocalID] = @id";

                    SqlCommand cmd = new SqlCommand(str, db.SqlCnn);

                    // Preenche ID
                    cmd.Parameters.AddWithValue("@id", ownerLocalID);
                    db.SqlCnn.Open();

                    // Executa
                    SqlDataReader dados = cmd.ExecuteReader();

                    if (!dados.HasRows)
                    {
                        dados.Close();
                        db.SqlCnn.Close();
                        return;
                    }

                    dados.Read();
                    //string.Format("{0}"

                    // Set Buffer
                    if (!dados.IsDBNull(2))
                        boxNome.Text = dados.GetString(2);
                    if (!dados.IsDBNull(3))
                        boxAddress.Text = dados.GetString(3);
                    if (!dados.IsDBNull(4))
                        boxZipCode.Text = dados.GetString(4);
                    if (!dados.IsDBNull(5))
                        boxGPS.Text = dados.GetString(5);
                    if (!dados.IsDBNull(6))
                        listCountry.SelectedValue = Convert.ToString(dados.GetInt32(6));
                    if (!dados.IsDBNull(7))
                        listCity.SelectedValue = Convert.ToString(dados.GetInt32(7));
                    if (!dados.IsDBNull(8))
                        chkIsMain.Checked = dados.GetBoolean(8);

                    dados.Close();
                    db.SqlCnn.Close();

                }
                if (ownerLocalID == 0)
                {
                    // OwnerLocalID a zero

                }
                else
                {
                    // Sem OwnerLocalID

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            loadOwnerLocalID();

            DBConn db = new DBConn();

            String str = "";
            if (ownerLocalID == 0)
            {
                str = "INSERT INTO OwnerLocals VALUES (@ownerid,@name,@address,@zipcode,@gps,@country,@city,@ismain)";
            }
            else
            {
                str = "UPDATE OwnerLocals SET [Name] = @name, [Address] = @address, [ZipCode] = @zipcode, [gps] = @gps, [CountryID] = @country, [CityID] = @city, [Main] = @ismain  WHERE [OwnerLocalID] = @id";
            }

            if (str == "") return;
            // SQL Query
            SqlCommand cmd = new SqlCommand(str, db.SqlCnn);

            if (ownerLocalID > 0)
            {
                // Preenche ID para UPDATE
                cmd.Parameters.AddWithValue("@id", ownerLocalID);
            }
            else
            {
                // Preenche o proprietário para um NOVO registo
                cmd.Parameters.AddWithValue("@ownerid", 1); //Teste - ir à sessão
            }

            // Buffer
            cmd.Parameters.AddWithValue("@name", boxNome.Text);
            cmd.Parameters.AddWithValue("@address", boxAddress.Text);
            cmd.Parameters.AddWithValue("@gps", boxGPS.Text);
            cmd.Parameters.AddWithValue("@zipcode", boxZipCode.Text);
            cmd.Parameters.AddWithValue("@country", Convert.ToInt32(listCountry.SelectedValue));
            cmd.Parameters.AddWithValue("@city", Convert.ToInt32(listCity.SelectedValue));
            cmd.Parameters.AddWithValue("@ismain", Convert.ToInt32(chkIsMain.Checked));

            db.SqlCnn.Open();

            // Executa
            int count = cmd.ExecuteNonQuery();

            db.SqlCnn.Close();

            Response.Redirect("PageClientLocals.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientLocals.aspx");
        }
    }
}