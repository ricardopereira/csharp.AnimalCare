using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;

namespace AnimalCare
{
    public enum AppointmentState
    {
        [Description("Em espera")]
        astWaiting,

        [Description("Aceite")]
        astAccepted,

        [Description("Rejeitado")]
        astRejected,

        [Description("Cancelado")]
        astCanceled,

        [Description("Tratado")]
        astDone
    };

    public abstract class Controller
    {
        private DBConn db;

        public DBConn Database
        {
            get 
            { 
                if (db == null) 
                    db = new DBConn();
                return db;
            }
        }

        public Controller(IIdentity currentUser)
        {
            if (currentUser.IsAuthenticated)
            {
                loadCurrentUser();
            }
        }

        public abstract void loadCurrentUser();

        public abstract int getUniqueID();

        public DateTime getDefaultDateFrom()
        {
            return DateTime.Now.AddDays(-15);
        }

        public DateTime getDefaultDateTo()
        {
            return DateTime.Now.AddDays(+15);
        }

        public DateTime getMinDate()
        {
            return DateTime.Now.AddYears(-200);
        }

        public DateTime getMaxDate()
        {
            return DateTime.Now.AddYears(200);
        }

        public static string getEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public SqlCommand getAllOwners(string filter = "")
        {
            String sql = "SELECT o.*, co.Name Country, b.Name Sector, " +
                " CASE" +
                "  WHEN Business = 0 THEN 'Particular'" +
                "  WHEN Business = 1 THEN 'Empresa'" +
                " END as Kind" +
                " FROM Owners o" +
                " LEFT OUTER JOIN Countries co ON co.CountryID = o.CountryID" +
                " LEFT OUTER JOIN BusinessSector b ON b.BusinessSectorID = o.BusinessSectorID" +
                " WHERE (o.Inactive = 0 OR o.Inactive IS NULL) ";

            if (!filter.Trim().Equals(""))
            {
                sql += " AND (" +
                       " o.Name LIKE '%'+@filter+'%' OR" +
                       " TaxNumber LIKE '%'+@filter+'%' " +
                       ")";
            }

            sql += " ORDER BY o.Name";

            // Executar comando
            SqlCommand cmd = new SqlCommand(sql, Database.Connection);

            if (!filter.Trim().Equals(""))
                cmd.Parameters.AddWithValue("@filter", filter);

            return cmd;
        }

        public String getOwnerName(int ownerID)
        {
            String result = "";
            if (ownerID <= 0) return result;
            String str = "SELECT Name FROM Owners WHERE OwnerID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", ownerID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (!dr.IsDBNull(0))
                    result = dr.GetString(0);
            }
            dr.Close();
            return result;
        }

        public SqlCommand getAnimal(int animalID)
        {
            String str = getAnimalsSQL() + " WHERE a.AnimalID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            return cmd;
        }

        public String getAnimalName(int animalID)
        {
            String result = "";
            if (animalID <= 0) return result;
            String str = "SELECT Name FROM Animals WHERE AnimalID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (!dr.IsDBNull(0))
                    result = dr.GetString(0);
            }
            dr.Close();
            return result;
        }

        public int getOwnerByAnimalID(int animalID)
        {
            int ownerID = 0;
            if (animalID <= 0) return ownerID;
            String str = "SELECT OwnerID FROM OwnerAnimalsRelation WHERE AnimalID = @id AND Active = 1";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (!dr.IsDBNull(0))
                    ownerID = dr.GetInt32(0);
            }
            dr.Close();
            return ownerID;
        }

        public int getOwnerByAppointmentID(int appointmentID)
        {
            int ownerID = 0;
            if (appointmentID <= 0) return ownerID;
            String str = "SELECT OwnerID FROM Appointments WHERE AppointmentID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (!dr.IsDBNull(0))
                    ownerID = dr.GetInt32(0);
            }
            dr.Close();
            return ownerID;
        }

        public int getAnimalByAppointmentID(int appointmentID)
        {
            int animalID = 0;
            if (appointmentID <= 0) return animalID;
            String str = "SELECT AnimalID FROM Appointments WHERE AppointmentID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (!dr.IsDBNull(0))
                    animalID = dr.GetInt32(0);
            }
            dr.Close();
            return animalID;
        }

        public String getAnimalsSQL()
        {
            /*
            0-AnimalID
            1-OwnerLocalID
            2-Name
            3-IdentityNumber
            4-Quantity
            5-AnimalRaceID
            6-AnimalConditionID
            7-AnimalHabitatID
            8-DateBorn
            9-DateDeath
            10-Sex
            11-ProfileImageID
            12-OwnerID
            13-Owner
            14-Race
            15-Specie
            16-Condition
            17-Habitat
            */

            return "SELECT a.*, rel.OwnerID OwnerID, o.Name Owner, r.Name Race, s.Name Specie, c.Description Condition, h.Description Habitat " +
                " FROM Animals a" +
                " INNER JOIN OwnerAnimalsRelation rel ON rel.AnimalID = a.AnimalID AND rel.Active = 1" +
                " LEFT OUTER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                " LEFT OUTER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                " LEFT OUTER JOIN AnimalConditions c ON c.AnimalConditionID = a.AnimalConditionID" +
                " LEFT OUTER JOIN AnimalHabitats h ON h.AnimalHabitatID = a.AnimalHabitatID" +
                " LEFT OUTER JOIN Owners o ON o.OwnerID = rel.OwnerID";
        }

        public SqlCommand getAllAnimals(int ownerID)
        {
            String str = "SELECT a.*, rel.OwnerID OwnerID, o.Name Owner, r.Name Race, s.Name Specie, c.Description Condition, h.Description Habitat " +
                " FROM OwnerAnimalsRelation rel" +
                " INNER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
                " LEFT OUTER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                " LEFT OUTER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                " LEFT OUTER JOIN AnimalConditions c ON c.AnimalConditionID = a.AnimalConditionID" +
                " LEFT OUTER JOIN AnimalHabitats h ON h.AnimalHabitatID = a.AnimalHabitatID" +
                " LEFT OUTER JOIN Owners o ON o.OwnerID = rel.OwnerID" +
                " WHERE rel.OwnerID = @id AND rel.Active = 1";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", ownerID);

            return cmd;
        }

        public SqlCommand getAppointments(DateTime dateFrom, DateTime dateTo, AppointmentState[] states = null, int animalID = 0)
        {
            String str = "SELECT ap.*, a.Name as Animal, apt.Description as AppointmentType, " +
                " CASE" +
                "  WHEN State = 0 THEN 'Em espera'" +
                "  WHEN State = 1 THEN 'Aceite'" +
                "  WHEN State = 2 THEN 'Rejeitado'" +
                "  WHEN State = 3 THEN 'Cancelado'" +
                " END as StateStr" +
                " FROM Appointments ap" +
                "  INNER JOIN OwnerAnimalsRelation rel ON rel.OwnerID = " + getUniqueID() + " AND rel.Active = 1" +
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
                "  LEFT OUTER JOIN AppointmentTypes apt ON apt.AppointmentTypeID = ap.AppointmentTypeID" +
                " WHERE DateAppointment > @dateFrom AND DateAppointment < @dateTo" +
                "  AND ap.OwnerID = @id";

            if (states != null) {
                str += " AND ";
                // Lista de estados
                for (int i = 0; i < states.Length; i++)
                {
                    if (i == 0)
                        str += " State = " + (int)states[i];
                    else
                        str += " OR State = " + (int)states[i];
                }
            }

            if (animalID > 0)
                str += " AND ap.AnimalID = @animalID";

            // Ordenação
            str += " ORDER BY DateAppointment";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@id", getUniqueID());

            if (animalID > 0)
                cmd.Parameters.AddWithValue("@animalID", animalID);

            return cmd;
        }

        public bool hasAppointments(AppointmentState state, DateTime dateFrom, DateTime dateTo, int animalID = 0)
        {
            String str = "SELECT *" +
                " FROM Appointments" +
                " WHERE DateAppointment > @dateFrom AND DateAppointment < @dateTo" +
                "  AND OwnerID = @id AND State = " + (int)state;

            if (animalID > 0)
                str += " AND AnimalID = @animalID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@id", getUniqueID());

            if (animalID > 0)
                cmd.Parameters.AddWithValue("@animalID", animalID);

            SqlDataReader dr = cmd.ExecuteReader();
            bool has = dr.HasRows;
            dr.Close();
            return has;
        }

        public String getAllAppointmentsSQL()
        {
            /*
            0-[AppointmentID] INT NOT NULL IDENTITY,
            1-[OwnerID] INT NOT NULL,
            2-[AnimalID] INT NULL,
            3-[AnimalGroupID] INT NULL,
            4-[AppointmentTypeID] INT NOT NULL,
            5-[DateAppointment] DATETIME NOT NULL,
            6-[DateCreated] DATETIME NOT NULL,
            7-[Reason] VARCHAR(45) NULL,
            8-[Detail] VARCHAR(45) NULL,
            9-[Urgent] BIT NULL,
            10-[State] SMALLINT NULL,
            11-Animal
            12-Owner
            13-AppointmentType
            14-Specie
            15-Race
            16-StateStr
             */

            String sql = "SELECT ap.*, a.Name as Animal, o.Name as Owner," +
                " apt.Description as AppointmentType, species.Name as Specie, races.Name as Race, " +
                " CASE" +
                "  WHEN State = 0 THEN 'Em espera'" +
                "  WHEN State = 1 THEN 'Aceite'" +
                "  WHEN State = 2 THEN 'Rejeitado'" +
                "  WHEN State = 3 THEN 'Cancelado'" +
                " END as StateStr" +
                " FROM Appointments ap" +
                "  INNER JOIN OwnerAnimalsRelation rel ON ap.AnimalID = rel.AnimalID AND rel.Active = 1" +
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
                "  LEFT OUTER JOIN AnimalRaces races ON races.AnimalRaceID = a.AnimalRaceID" +
                "  LEFT OUTER JOIN AnimalSpecies species ON species.AnimalSpecieID = races.AnimalSpecieID" +
                "  LEFT OUTER JOIN Owners o ON o.OwnerID = rel.OwnerID" +
                "  LEFT OUTER JOIN AppointmentTypes apt ON apt.AppointmentTypeID = ap.AppointmentTypeID";
            return sql;
        }

        public SqlCommand getAllAppointments(DateTime dateFrom, DateTime dateTo, AppointmentState[] states = null, int ownerID = 0)
        {
            String str = getAllAppointmentsSQL() +
                " WHERE DateAppointment > @dateFrom AND DateAppointment < @dateTo";

            if (ownerID > 0)
                str += " AND OwnerID = @ownerID";

            if (states != null)
            {
                str += " AND ";
                // Lista de estados
                for (int i = 0; i < states.Length; i++)
                {
                    if (i == 0)
                        str += " State = " + (int)states[i];
                    else
                        str += " OR State = " + (int)states[i];
                }
            }

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);

            if (ownerID > 0)
                cmd.Parameters.AddWithValue("@ownerID", ownerID);

            return cmd;
        }

        public bool existsAppointments(AppointmentState state, DateTime dateFrom, DateTime dateTo, int ownerID = 0)
        {
            String str = "SELECT *" +
                " FROM Appointments" +
                " WHERE DateAppointment > @dateFrom AND DateAppointment < @dateTo" +
                "  AND State = " + (int)state;

            if (ownerID > 0)
                str += " AND OwnerID = @ownerID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);

            if (ownerID > 0)
                cmd.Parameters.AddWithValue("@ownerID", ownerID);

            SqlDataReader dr = cmd.ExecuteReader();
            bool has = dr.HasRows;
            dr.Close();
            return has;
        }

        public String getAllScheduleSQL()
        {
            /*
            0-[ScheduleID] INT NOT NULL IDENTITY,
            1-[Description] VARCHAR(50) NULL,
            2-[DateEvent] DATETIME NOT NULL,
            3-[Notified] BIT NULL,
            4-[Present] BIT NULL,
            5-[DateCreated] BIT NOT NULL,
            6-[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
            7-[ServiceKindID] INT NOT NULL,
            8-[OwnerID] INT NOT NULL,
            9-[AnimalID] INT NULL,
            10-[AnimalGroupID] INT NULL,
            11-[ProfessionalID] INT NOT NULL,
            12-[Priority] SMALLINT NULL
            13-Owner
            14-Animal
            15-Professional
            16-ServiceKind
             */

            String sql = "SELECT sh.*, o.Name Owner, a.Name Animal, p.Name Professional, sk.Description ServiceKind" +
                " FROM Schedule sh" +
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = sh.AnimalID" +
                "  LEFT OUTER JOIN Owners o ON o.OwnerID = sh.OwnerID" +
                "  LEFT OUTER JOIN Professionals p ON p.ProfessionalID = sh.ProfessionalID" +
                "  LEFT OUTER JOIN ServiceKinds sk ON sk.ServiceKindID = sh.ServiceKindID";
            return sql;
        }

        public SqlCommand getAllSchedule(DateTime dateFrom, DateTime dateTo, bool present = false, bool notified = false, int professionalID = 0)
        {
            String str = getAllScheduleSQL() +
                " WHERE DateEvent > @dateFrom AND DateEvent < @dateTo" +
                "   AND Present = @present AND Notified = @notified";

            if (professionalID > 0)
                str += " AND ProfessionalID = @professionalID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@present", present);
            cmd.Parameters.AddWithValue("@notified", notified);

            if (professionalID > 0)
                cmd.Parameters.AddWithValue("@professionalID", professionalID);

            return cmd;
        }
    }
}