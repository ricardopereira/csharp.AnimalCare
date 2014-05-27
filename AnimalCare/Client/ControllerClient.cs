using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace AnimalCare.Client
{
    public enum AppointmentState {
        [Description("Em espera")] astNone, 
        [Description("Aceite")] astAccepted,
        [Description("Rejeitado")] astRejected,
        [Description("Cancelado")] astCanceled
    };

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
            String str = "SELECT o.*, c.Name as Country FROM Owners o" +
                " LEFT OUTER JOIN Countries c ON c.CountryID = o.CountryID" +
                " WHERE [UserId] = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
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
                    Bf.CountryID = dados.GetInt32(9);
                if (!dados.IsDBNull(10))
                    Bf.Country = dados.GetString(10);
            }
            dados.Close();
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

        public void deleteOwnerLocal(int ownerLocalID)
        {
            if (ownerLocalID <= 0)
                return;

            // ToDo - Verificar relações

            String str = "DELETE FROM OwnerLocals WHERE [OwnerLocalID] = @id";
            // SQL Query
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", ownerLocalID);

            // Executa
            int count = cmd.ExecuteNonQuery();
        }

        public String getOwnerAnimalsSQL()
        {
            return "SELECT a.* FROM OwnerAnimalsRelation rel" +
                " INNER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
                " WHERE rel.OwnerID = " + Bf.OwnerID + " AND rel.Active = 1";
        }

        public SqlCommand getOwnerAnimals()
        {
            // Executar comando
            SqlCommand cmd = new SqlCommand(getOwnerAnimalsSQL(), Database.Connection);
            return cmd;
        }

        public SqlCommand getAppointments(DateTime dateFrom, DateTime dateTo, int animalID=0)
        {
            String str = "SELECT * FROM Appointments" +
                " WHERE DateAppointment >  @dateFrom AND DateAppointment < @dateTo" +
                "  AND OwnerID = @id";

            if (animalID > 0)
                str += " AND AnimalID = @animalID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@id", Bf.OwnerID);

            if (animalID > 0)
                cmd.Parameters.AddWithValue("@animalID", animalID);

            return cmd;
        }

        public void insertAppointment(int animalID, 
            int appointmentTypeID, DateTime dateAppointment, String reason, Boolean urgent=false, int state=0)
        {
            if (dateAppointment == null || dateAppointment.ToBinary() == 0)
                return;

            String str = "INSERT INTO Appointments VALUES " +
                "(@ownerID,@animalID,NULL,@appointmentTypeID,@dateAppointment,CURRENT_TIMESTAMP,@reason,@urgent,@state)";

            // SQL Query
            SqlCommand cmd = new SqlCommand(str, Database.Connection);

            // Buffer
            cmd.Parameters.AddWithValue("@ownerID", Bf.OwnerID);
            cmd.Parameters.AddWithValue("@animalID", animalID);
            //cmd.Parameters.AddWithValue("@animalGroupID", null);
            cmd.Parameters.AddWithValue("@appointmentTypeID", appointmentTypeID);
            cmd.Parameters.AddWithValue("@dateAppointment", dateAppointment);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.Parameters.AddWithValue("@urgent", urgent);
            cmd.Parameters.AddWithValue("@state", state);

            // Executa
            cmd.ExecuteNonQuery();
        }

        public void deleteAppointment(int appointmentID)
        {
            if (appointmentID <= 0)
                return;

            // ToDo - Verificar relações

            String str = "DELETE FROM Appointments WHERE [AppointmentID] = @id";
            // SQL Query
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);

            // Executa
            int count = cmd.ExecuteNonQuery();
        }

        public SqlCommand getScheduleEvents(DateTime dateFrom, DateTime dateTo, int animalID = 0)
        {
            String str = "SELECT s.*, k.Description as ServiceKind, a.Name as Animal FROM Schedule s" +
                " INNER JOIN ServiceKinds k ON k.ServiceKindID = s.ServiceKindID" +
                " INNER JOIN Animals a ON a.AnimalID = s.AnimalID" +
                " WHERE DateEvent >= @dateFrom AND DateEvent <= @dateTo" +
                "  AND OwnerID = @id";

            if (animalID > 0)
                str += " AND AnimalID = @animalID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@id", Bf.OwnerID);

            if (animalID > 0)
                cmd.Parameters.AddWithValue("@animalID", animalID);

            return cmd;
        }
    }
}