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
        SqlConnection sqlCon;

        public SqlConnection SqlCnn
        {
            get { return sqlCon; }
            set { sqlCon = value; }
        }

        public DBConn()
        {
            string CnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            sqlCon = new SqlConnection(CnnString);
        }
    }
}