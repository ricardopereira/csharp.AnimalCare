using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Admin
{
    public partial class PageAdminClinics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert(object sender, EventArgs e)
        {
            DBConn Database = new DBConn();
            string Name = boxName.Text;
            int KinD = Convert.ToInt32(boxKind.Text);
            string Address = boxAddress.Text;
            string ZipCode = boxZipCode.Text;
            string gps = boxGPS.Text;
            string Phone = boxPhone.Text;
            string Fax = boxFax.Text;
            string Mail = boxMail.Text;

            String str = "INSERT INTO Clinics (Name,KinD,Address,ZipCode";
            
            if (gps != "")
                str += ",GPS";

            str += ",CityID,PhoneNumber";

            if (Fax != "")
                str += ",FaxNumber";

            if (Mail != "")
                str += ",Email";

            str += ") VALUES (@Name,@KinD,@Address,@ZipCode";

            if (gps != "")
                str += ",@GPS";

            str += ",@CityID,@PhoneNumber";

            if (Fax != "")
                str += ",@FaxNumber";

            if (Mail != "")
                str += ",@Email";

            str += ")";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Name",Name);
            cmd.Parameters.AddWithValue("@KinD", KinD);
            cmd.Parameters.AddWithValue("@Address",Address);
            cmd.Parameters.AddWithValue("@ZipCode", ZipCode);
            cmd.Parameters.AddWithValue("@CityID", Convert.ToInt16(ddlCities.SelectedValue));
            cmd.Parameters.AddWithValue("@PhoneNumber", Phone);

            if (gps != "")
                cmd.Parameters.AddWithValue("@GPS", gps);

            if (Fax != "")
                cmd.Parameters.AddWithValue("@FaxNumber", Fax);

            if (Mail != "")
                cmd.Parameters.AddWithValue("@Email", Mail);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            boxName.Text= "";
            boxKind.Text = "";
            boxAddress.Text = "";
            boxZipCode.Text = "";
            boxGPS.Text = "";
            boxPhone.Text = "";
            boxFax.Text = "";
            boxMail.Text = "";
            GridView1.DataBind();
        }
    }
}