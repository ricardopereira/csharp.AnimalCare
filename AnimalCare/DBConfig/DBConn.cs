using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AnimalCare
{
    public class DBConn
    {
        SqlConnection conn;

        public SqlConnection Connection
        {
            get { return conn; }
            set { conn = value; }
        }

        public DBConn()
        {
            string CnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(CnnString);
        }
    }
}