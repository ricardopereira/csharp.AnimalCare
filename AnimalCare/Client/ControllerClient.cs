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
    public class ClientBuffer
    {
        private int ownerID;

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private bool business;

        public bool Business
        {
            get { return business; }
            set { business = value; }
        }
        private String taxNumber;

        public String TaxNumber
        {
            get { return taxNumber; }
            set { taxNumber = value; }
        }
        private String mobileNumber;

        public String MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }
        private String faxNumber;

        public String FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }
        private bool inactive;

        public bool Inactive
        {
            get { return inactive; }
            set { inactive = value; }
        }
        private int countryID;

        public int CountryID
        {
            get { return countryID; }
            set { countryID = value; }
        }
        private int businessSectorID;

        public int BusinessSectorID
        {
            get { return businessSectorID; }
            set { businessSectorID = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }

    public class ControllerClient : Controller
    {
        private ClientBuffer bf;

        public ClientBuffer Bf
        {
            get
            {
                if (bf == null)
                    bf = new ClientBuffer();
                return bf;
            }
        }

        public ControllerClient(IIdentity currentUser) : base(currentUser)
        {
 
        }

        public override void loadCurrentUser()
        {
            // Current User
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            MembershipUser ms = Membership.GetUser(); /* Load user email */
            Bf.Email = ms.Email;

            // Load from Owners
            SqlCommand cmd = new SqlCommand("SELECT * FROM Owners WHERE [UserId] = @id", Database.Connection);
            cmd.Parameters.AddWithValue("@id", userGuid);
            // Abre a base de dados
            Database.Connection.Open();
            // Executa e extrai informação
            SqlDataReader dados = cmd.ExecuteReader();
            if (dados.HasRows)
            {
                // Ler primeira e unica linha
                dados.Read();
                // Retornar o OwnerID
                if (!dados.IsDBNull(0))
                    Bf.OwnerID = dados.GetInt32(0);
                if (!dados.IsDBNull(2))
                    Bf.Name = dados.GetString(2);
                if (!dados.IsDBNull(3))
                    Bf.Business = dados.GetBoolean(3);
                if (!dados.IsDBNull(4))
                    Bf.BusinessSectorID = dados.GetInt32(4);
                if (!dados.IsDBNull(5))
                    Bf.TaxNumber = dados.GetString(5);
                if (!dados.IsDBNull(6))
                    Bf.MobileNumber = dados.GetString(6);
                if (!dados.IsDBNull(7))
                    Bf.FaxNumber = dados.GetString(7);
                if (!dados.IsDBNull(8))
                    Bf.Inactive = dados.GetBoolean(8);
                if (!dados.IsDBNull(9))
                {
                    Bf.CountryID = dados.GetInt32(9);
                }
            }
            dados.Close();
            setCountryById();
        }

        private void setCountryById()
        {
            if (Bf.CountryID != 0)
            {
                SqlCommand cmdCountry = new SqlCommand("SELECT Name FROM Countries WHERE [CountryID] = @countryID", Database.Connection);
                cmdCountry.Parameters.AddWithValue("@countryID", Bf.CountryID);
                SqlDataReader data = cmdCountry.ExecuteReader();
                data.Read();
                Bf.Country = data.GetString(0);
                data.Close();
            }
        }

        public void insertOwner()
        {
            // Current User
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

            String str = "INSERT INTO Owners(UserID)";
            str += "VALUES(@UserID)";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@UserID", userGuid);

            cmd.ExecuteNonQuery();
        }

        public void updateUserInfo(string name, string taxNumber, int country, int business, int businessID, string mobileNumber, string faxNumber)
        {
            String str = "UPDATE Owners SET Name = @name";
            str += ",Business = @business";
            str += ",BusinessSectorID = @businessID";
            str += ",TaxNumber = @taxNumber";
            str += ",MobileNumber = @mobileNumber";
            str += ",FaxNumber = @faxNumber";
            str += ",CountryID = @countryID";
            str += " WHERE OwnerID = @ownerID";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@OwnerID", Bf.OwnerID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@taxNumber", taxNumber);
            cmd.Parameters.AddWithValue("@countryID", country);
            cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            if(business != 0)
                cmd.Parameters.AddWithValue("@business", business);
            else
                cmd.Parameters.AddWithValue("@business", DBNull.Value);
            if (businessID != 0)
                cmd.Parameters.AddWithValue("@businessID", businessID);
            else
                cmd.Parameters.AddWithValue("@businessID", DBNull.Value);
            if (faxNumber != "")
                cmd.Parameters.AddWithValue("@faxNumber", faxNumber);
            else
                cmd.Parameters.AddWithValue("@faxNumber", DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public SqlCommand getOwnerLocals()
        {
            String str = "SELECT l.*, co.Name Country, ci.Name City FROM OwnerLocals l" +
                " INNER JOIN Countries co ON co.CountryID = l.CountryID" +
                " INNER JOIN Cities ci ON ci.CityID = l.CityID" +
                " WHERE [OwnerID] = @id";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", Bf.OwnerID);

            return cmd;
        }

        public SqlCommand getOwnerAnimals()
        {

            return null;
        }
    }
}