using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.Security;


namespace AnimalCare.Admin
{
    public partial class PageAdminRaces : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void insert(object sender, EventArgs e)
        {
                DBConn Database = new DBConn();

                String str = "INSERT INTO AnimalRaces VALUES (@AnimalSpecieID,@Name)";
                SqlCommand cmd = new SqlCommand(str, Database.Connection);
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@AnimalSpecieID", Convert.ToInt32(ddlSpecies.SelectedValue));
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(boxSpecieName.Text));

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                GridView1.DataBind();
        }

        public SqlConnection ConnectionString { get; set; }
    }
}