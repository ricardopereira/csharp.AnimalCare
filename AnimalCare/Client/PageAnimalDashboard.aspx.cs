using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalDashboard : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                DBConn db = new DBConn();
                String str = "SELECT a.*, r.Name Race, s.Name Specie FROM Animals a" + 
                    " INNER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID"+
                    " INNER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID";

                // Executar comando
                SqlCommand cmd = new SqlCommand(str, db.Connection);

                db.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                // Efectuar o data binding
                tabelaAnimais.DataSource = dr;
                tabelaAnimais.DataBind();

                dr.Close();
                db.Connection.Close();
            }
        }
    }
}