using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Admin
{
    public partial class PageAdminBusinessSector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert(object sender, EventArgs e)
        {
            DBConn Database = new DBConn();

            String str = "INSERT INTO BusinessSector VALUES (@BizSector)";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@BizSector", Convert.ToString(boxBusinessSector.Text));

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            GridView1.DataBind();
        }
    }
}