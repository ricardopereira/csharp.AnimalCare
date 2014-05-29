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

        public override int getUniqueID()
        {
            return Bf.OwnerID;
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
            cmd.Parameters.AddWithValue("@ownerID", Bf.OwnerID);
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

        public void insertAnimalInfo(int localID, string name, string identityNumber, int quantity, int animalRace, int animalCondition, int animalHabitat, DateTime birth, int sex)
         {
             String str = "INSERT INTO Animals (OwnerLocalID, Name,IdentityNumber,Quantity,AnimalRaceID,AnimalConditionID,AnimalHabitatID,Sex";
             if (!birth.Equals(new DateTime(0001, 01, 01)))
                 str += ",DateBorn)";
             else
                 str += ")";
             str += " VALUES(@localID,@name,@identityNumber,@quantity,@animalRace,@animalCondition,@animalHabitatID,@sex";
             if (!birth.Equals(new DateTime(0001, 01, 01)))
                 str += ",@birth);";
             else
                 str += ");";
 
             SqlCommand cmd = new SqlCommand(str, Database.Connection);
             cmd.Parameters.AddWithValue("@localID", localID);
             cmd.Parameters.AddWithValue("@name", name);
             cmd.Parameters.AddWithValue("@identityNumber", identityNumber);
             cmd.Parameters.AddWithValue("@quantity", quantity);
             cmd.Parameters.AddWithValue("@animalRace", animalRace);
             cmd.Parameters.AddWithValue("@animalCondition", animalCondition);
             cmd.Parameters.AddWithValue("@animalHabitatID", animalHabitat);
             cmd.Parameters.AddWithValue("@sex", sex);
             if (!birth.Equals(new DateTime(0001, 01, 01)))
                 cmd.Parameters.AddWithValue("@birth", birth);
 
             cmd.ExecuteNonQuery();
         }
 
         public void updateAnimalInfo(int localID, int animalID, string name, string identityNumber, int quantity,int animalRace,int animalCondition,int animalHabitat,DateTime birth, DateTime death, int sex)
         {
             String str = "UPDATE Animals SET Name = @name";
             str += ",OwnerLocalID = @ownerLocalID";
             str += ",IdentityNumber = @identityNumber";
             str += ",Quantity = @quantity";
             str += ",AnimalRaceID = @animalRace";
             str += ",AnimalConditionID = @animalCondition";
             str += ",AnimalHabitatID = @animalHabitatID";
             str += ",Sex = @sex";
             if(!birth.Equals(new DateTime(0001,01,01)))
                 str += ",DateBorn = @birth";
             if (!death.Equals(new DateTime(0001,01,01)))
                 str += ",DateDeath = @death";
             str += " WHERE AnimalID = @animalID";
 
              SqlCommand cmd = new SqlCommand(str, Database.Connection);
             cmd.Parameters.AddWithValue("@animalID", animalID);
             cmd.Parameters.AddWithValue("@ownerLocalID", localID);
             cmd.Parameters.AddWithValue("@name", name);
             cmd.Parameters.AddWithValue("@identityNumber", identityNumber);
             cmd.Parameters.AddWithValue("@quantity", quantity);
             cmd.Parameters.AddWithValue("@animalRace", animalRace);
             cmd.Parameters.AddWithValue("@animalCondition", animalCondition);
             cmd.Parameters.AddWithValue("@animalHabitatID", animalHabitat);
             cmd.Parameters.AddWithValue("@sex", sex);
             if (!birth.Equals(new DateTime(0001,01,01)))
                 cmd.Parameters.AddWithValue("@birth", birth);
             if (!death.Equals(new DateTime(0001,01,01)))
                 cmd.Parameters.AddWithValue("@death", death);
 
             cmd.ExecuteNonQuery();
         }

        public void updateLocalInfo(int ownerLocalID, string name, string address, string zipCode, string gps, int country, int city, bool main)
        {
             String str = "UPDATE OwnerLocals SET Name = @name";
             str += ",Address = @address";
             str += ",ZipCode = @zipCode";
             str += ",GPS = @gps";
             str += ",CountryID = @country";
             str += ",CityID = @city";
             str += ",Main = @main";
             str += " WHERE OwnerLocalID = @ownerLocalID";

             SqlCommand cmd = new SqlCommand(str, Database.Connection);
             cmd.Parameters.AddWithValue("@ownerLocalID", ownerLocalID);
             cmd.Parameters.AddWithValue("@name", name);
             cmd.Parameters.AddWithValue("@address", address);
             cmd.Parameters.AddWithValue("@zipCode", zipCode);
             cmd.Parameters.AddWithValue("@gps", gps);
             cmd.Parameters.AddWithValue("@country", country);
             cmd.Parameters.AddWithValue("@city", city);
             cmd.Parameters.AddWithValue("@main", main);

             cmd.ExecuteNonQuery();
        }

        public void insertLocalInfo(string name, string address, string zipCode, string gps, int country, int city, bool main)
        {
            String str = "INSERT INTO OwnerLocals (OwnerID,Name,Address,ZipCode,GPS,CountryID,CityID,Main) VALUES (@ownerID,@name,@address,@zipCode,@gps,@country,@city,@main)";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@ownerID", Bf.OwnerID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@zipCode", zipCode);
            cmd.Parameters.AddWithValue("@gps", gps);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@main", main);

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

        public SqlCommand getLocalByID(int localID)
        {
            String str = "SELECT * FROM OwnerLocals WHERE [OwnerLocalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", localID);
            return cmd;            
        }

        public SqlCommand getAnimalByID(int animalID)
        {
            String str = "SELECT * FROM Animals WHERE [AnimalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            return cmd;
        }

        public SqlCommand getAnimalInfo(int animalID)
        {
            String str = "SELECT a.Name, a.IdentityNumber, a.Quantity, ar.Name, ans.Name, ac.Description, a.Sex, a.DateBorn, oc.Name";
            str += " FROM Animals a";
            str += " INNER JOIN AnimalRaces ar ON ar.AnimalRaceID = a.AnimalRaceID";
            str += " INNER JOIN AnimalSpecies ans ON ans.AnimalSpecieID = ar.AnimalSpecieID";
            str += " INNER JOIN AnimalConditions ac ON a.AnimalConditionID = ac.AnimalConditionID";
            str += " INNER JOIN OwnerLocals oc ON oc.OwnerLocalID = a.OwnerLocalID";
            str += " WHERE [AnimalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            return cmd;
        }

        public SqlCommand getSpecieByRace(int raceID)
        {
            String str = "SELECT AnimalSpecieID FROM AnimalRaces WHERE [AnimalRaceID] = @sid";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@sid", raceID);
            return cmd;
        }

        public SqlCommand getRaceInfo(int specieID) {
            String str = "SELECT AnimalRaceId, Name FROM AnimalRaces WHERE [AnimalSpecieID] = @sid";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@sid", specieID);
            return cmd;
        }

        public bool isOwnerOfAnimal(int animalID)
        {
            int dbOwnerID;

            String str = "SELECT ol.OwnerID FROM Animals a";
            str += " INNER JOIN OwnerLocals ol ON a.OwnerLocalID = ol.OwnerLocalID";
            str += " WHERE [AnimalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            
            SqlDataReader animalData = cmd.ExecuteReader();
            if (!animalData.HasRows)
            {
                animalData.Close();
                return false;
            }
            else
            {
                animalData.Read();
                dbOwnerID = animalData.GetInt32(0);
                animalData.Close();
                if (dbOwnerID != Bf.OwnerID)
                    return false;
                else
                    return true;
            }
        }

        public bool isOwnerOfLocal(int ownerLocalID)
        {
            int dbOwnerID;

            String str = "SELECT OwnerID FROM OwnerLocals";
            str += " WHERE [OwnerLocalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", ownerLocalID);

            SqlDataReader localData = cmd.ExecuteReader();
            if (!localData.HasRows)
            {
                localData.Close();
                return false;
            }
            else
            {
                localData.Read();
                dbOwnerID = localData.GetInt32(0);
                localData.Close();
                if (dbOwnerID != Bf.OwnerID)
                    return false;
                else
                    return true;
            }
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
            return "SELECT a.*, r.Name Race, s.Name Specie FROM OwnerAnimalsRelation rel" +
                " INNER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
                " INNER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                " INNER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                " WHERE rel.OwnerID = " + Bf.OwnerID + " AND rel.Active = 1";
        }

        public int getOwnerAnimalsCount()
        {
            return (int)getOwnerAnimals().ExecuteScalar();
        }

        public SqlCommand getOwnerAnimals(String filter="")
        {
            String sql = getOwnerAnimalsSQL();

            if (!filter.Trim().Equals("")) {
                sql += " AND (" + 
                       " a.Name LIKE '%'+@filter+'%' OR" + 
                       " a.IdentityNumber LIKE '%'+@filter+'%' OR"+
                       " s.Name LIKE '%'+@filter+'%' OR" +
                       " r.Name LIKE '%'+@filter+'%' " +
                       ")";
                //WHERE CONTAINS((Author, Title, PostContent), @userInput);
            }

            // Executar comando
            SqlCommand cmd = new SqlCommand(sql, Database.Connection);

            if (!filter.Trim().Equals("")) {
                cmd.Parameters.AddWithValue("@filter", filter);
            }

            return cmd;
        }

        public SqlCommand getAppointments()
        {
            AppointmentState[] states = new AppointmentState[3];
            // Lista dos estados a carregar
            states[0] = AppointmentState.astWaiting;
            states[1] = AppointmentState.astAccepted;
            states[2] = AppointmentState.astRejected;

            return getAppointments(getDefaultDateFrom(), getDefaultDateTo(), states);
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

        public void cancelAppointment(int appointmentID)
        {
            if (appointmentID <= 0)
                return;

            String str = "UPDATE Appointments SET State = " + (int)AppointmentState.astCanceled + " WHERE [AppointmentID] = @id";
            // SQL Query
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);

            // Executa
            int count = cmd.ExecuteNonQuery();
        }

        public bool hasAcceptedAppointments()
        {
            return hasAppointments(AppointmentState.astAccepted, getDefaultDateFrom(), getDefaultDateTo());
        }

        public SqlCommand getScheduleEvents()
        {
            return getScheduleEvents(getDefaultDateFrom(),getDefaultDateTo());
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