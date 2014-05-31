using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Admin
{
    public partial class PageAnimalConditions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert(object sender, EventArgs e)
        {
            DBConn Database = new DBConn();

            String str = "INSERT INTO AnimalConditions VALUES (@Condition)";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Condition", Convert.ToString(boxCondition.Text));

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            GridView1.DataBind();
        }
    }
}