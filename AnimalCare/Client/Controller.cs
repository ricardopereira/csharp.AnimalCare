using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace AnimalCare.Client
{
    public class Controller
    {
        private int ownerID;
        private int profissionalID;
        private DBConn db;

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }

        public int ProfissionalID
        {
            get { return profissionalID; }
            set { profissionalID = value; }
        }

        public DBConn Database
        {
            get { return db; }
            set { db = value; }
        }

        public Controller(IIdentity currentUser)
        {
            if (currentUser.IsAuthenticated)
            {
                loadCurrentUser();
            }
        }

        public void loadCurrentUser()
        {
            db = new DBConn();
            // Current User
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            // Load from Owners
            SqlCommand cmd = new SqlCommand("SELECT OwnerID FROM Owners WHERE [UserId] = @id", db.Connection);
            cmd.Parameters.AddWithValue("@id", userGuid);
            // Executa
            db.Connection.Open();
            SqlDataReader dados = cmd.ExecuteReader();

            if (dados.HasRows)
            {
                // Ler primeira e unica linha
                dados.Read();
                // Retornar o OwnerID
                if (!dados.IsDBNull(0))
                    OwnerID = dados.GetInt32(0);
            }
            dados.Close();
        }

        public SqlCommand getOwnerLocals()
        {
            if (db == null) return null;
            //db.Connection.Open();

            String str = "SELECT l.*, co.Name Country, ci.Name City FROM OwnerLocals l" +
                " INNER JOIN Countries co ON co.CountryID = l.CountryID" +
                " INNER JOIN Cities ci ON ci.CityID = l.CityID" +
                " WHERE [OwnerID] = @id";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", OwnerID);

            return cmd;
        }

        public SqlCommand getOwnerAnimals()
        {

            return null;
        }
    }
}