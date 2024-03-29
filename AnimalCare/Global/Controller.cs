﻿using System;
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

    public enum ScheduleState
    {
        [Description("Agendado")]
        shtAgended,

        [Description("Efectuado")]
        shtDone,

        [Description("Cancelado")]
        shtCancelado
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

        public SqlCommand getAnimalInfo(int animalID)
        {
            String str = "SELECT a.Name, a.IdentityNumber, a.Quantity, ar.Name, ans.Name, ac.Description, a.Sex, a.DateBorn, oc.Name,a.DateDeath";
            str += " FROM Animals a";
            str += " LEFT OUTER JOIN AnimalRaces ar ON ar.AnimalRaceID = a.AnimalRaceID";
            str += " LEFT OUTER JOIN AnimalSpecies ans ON ans.AnimalSpecieID = ar.AnimalSpecieID";
            str += " LEFT OUTER JOIN AnimalConditions ac ON a.AnimalConditionID = ac.AnimalConditionID";
            str += " LEFT OUTER JOIN OwnerLocals oc ON oc.OwnerLocalID = a.OwnerLocalID";
            str += " WHERE [AnimalID] = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalID);
            return cmd;
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
            11-OwnerID
            12-Owner
            13-Race
            14-Specie
            15-Condition
            16-Habitat
            17-Local
            */

            return "SELECT a.*, rel.OwnerID OwnerID, o.Name Owner, r.Name Race, s.Name Specie, c.Description Condition, h.Description Habitat, lo.Name Local " +
                " FROM Animals a" +
                " INNER JOIN OwnerAnimalsRelation rel ON rel.AnimalID = a.AnimalID AND rel.Active = 1" +
                " LEFT OUTER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                " LEFT OUTER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                " LEFT OUTER JOIN AnimalConditions c ON c.AnimalConditionID = a.AnimalConditionID" +
                " LEFT OUTER JOIN AnimalHabitats h ON h.AnimalHabitatID = a.AnimalHabitatID" +
                " LEFT OUTER JOIN OwnerLocals lo ON lo.OwnerLocalID = a.OwnerLocalID" +
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
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = ap.AnimalID" +
                "  LEFT OUTER JOIN Owners o ON o.OwnerID = ap.OwnerID" +
                "  LEFT OUTER JOIN AppointmentTypes apt ON apt.AppointmentTypeID = ap.AppointmentTypeID" +
                " WHERE DateAppointment > @dateFrom AND DateAppointment < @dateTo" +
                "  AND ap.OwnerID = @id";

            if (states != null) {
                str += " AND (";
                // Lista de estados
                for (int i = 0; i < states.Length; i++)
                {
                    if (i == 0)
                        str += " State = " + (int)states[i];
                    else
                        str += " OR State = " + (int)states[i];
                }
                str += ")";
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
            3-[AppointmentTypeID] INT NOT NULL,
            4-[DateAppointment] DATETIME NOT NULL,
            5-[DateCreated] DATETIME NOT NULL,
            6-[Reason] VARCHAR(45) NULL,
            7-[Detail] VARCHAR(45) NULL,
            8-[Urgent] BIT NULL,
            9-[State] SMALLINT NULL,
            10-Animal
            11-Owner
            12-AppointmentType
            13-Specie
            14-Race
            15-StateStr
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
            10-[ProfessionalID] INT NOT NULL,
            11-[Priority] SMALLINT NULL
            12-[State] SMALLINT NULL
            13-Owner
            14-Animal
            15-Professional
            16-ServiceKind
            17-Specie
            18-Race
            19-Local
            20-LocalGPS
            21-LocalName
             */

            String sql = "SELECT sh.*, o.Name Owner, a.Name Animal, p.Name Professional, sk.Description ServiceKind,"+
                "   s.Name Specie, r.Name Race, l.ZipCode Local, l.GPS LocalGPS, l.Name LocalName" +
                " FROM Schedule sh" +
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = sh.AnimalID" +
                "  LEFT OUTER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                "  LEFT OUTER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                "  LEFT OUTER JOIN Owners o ON o.OwnerID = sh.OwnerID" +
                "  LEFT OUTER JOIN Professionals p ON p.ProfessionalID = sh.ProfessionalID" +
                "  LEFT OUTER JOIN OwnerLocals l ON l.OwnerLocalID = a.OwnerLocalID" +
                "  LEFT OUTER JOIN ServiceKinds sk ON sk.ServiceKindID = sh.ServiceKindID";
            return sql;
        }

        public SqlCommand getAllSchedule(DateTime dateFrom, DateTime dateTo, bool present = false, int professionalID = 0)
        {
            String str = getAllScheduleSQL() +
                " WHERE DateEvent > @dateFrom AND DateEvent < @dateTo" +
                "   AND Present = @present AND State = @state";

            if (professionalID > 0)
                str += " AND sh.ProfessionalID = @professionalID";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@present", present);
            cmd.Parameters.AddWithValue("@state", (int)ScheduleState.shtAgended);

            if (professionalID > 0)
                cmd.Parameters.AddWithValue("@professionalID", professionalID);

            return cmd;
        }

        public String getAllServiceSQL()
        {
            /*
            0-[ServiceID] INT NOT NULL IDENTITY,
            1-[OwnerID] INT NOT NULL,
            2-[Name] VARCHAR(40) NOT NULL,
            3-[Description] VARCHAR(100) NULL,
            4-[DateService] DATETIME NULL,
            5-[DateConclusion] DATETIME NULL,
            6-[DateCreated] DATETIME NOT NULL,
            7-[Observation] VARCHAR(150) NULL,
            8-[ServiceKindID] INT NOT NULL,
            9-[AnimalID] INT NULL,
            10-[ProfessionalID] INT NOT NULL,
            11-[ClinicID] INT NULL,
            12-Owner
            13-Animal
            14-Professional
            15-ServiceKind
            16-Specie
            17-Race
            18-Clinic
            19-Done
             */

            String sql = "SELECT sr.*, o.Name Owner, a.Name Animal, p.Name Professional, " +
                "   sk.Description ServiceKind, s.Name Specie, r.Name Race, cl.Name Clinic," +
                " CASE" +
                "  WHEN DateConclusion IS NULL THEN 0" +
                "  WHEN DateConclusion IS NOT NULL THEN 1" +
                " END as Done" +
                " FROM Services sr" +
                "  LEFT OUTER JOIN Animals a ON a.AnimalID = sr.AnimalID" +
                "  LEFT OUTER JOIN AnimalRaces r ON r.AnimalRaceID = a.AnimalRaceID" +
                "  LEFT OUTER JOIN AnimalSpecies s ON s.AnimalSpecieID = r.AnimalSpecieID" +
                "  LEFT OUTER JOIN Owners o ON o.OwnerID = sr.OwnerID" +
                "  LEFT OUTER JOIN Professionals p ON p.ProfessionalID = sr.ProfessionalID" +
                "  LEFT OUTER JOIN ServiceKinds sk ON sk.ServiceKindID = sr.ServiceKindID" +
                "  LEFT OUTER JOIN Clinics cl ON cl.ClinicID = sr.ClinicID";
            return sql;
        }

        public SqlCommand getAllServices(DateTime dateFrom, DateTime dateTo, int professionalID = 0, int limit = 0)
        {
            String str = getAllServiceSQL() +
                " WHERE DateService > @dateFrom AND DateService < @dateTo";

            if (professionalID > 0)
                str += " AND sr.ProfessionalID = @professionalID";

            str += " ORDER BY DateService DESC";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);

            if (professionalID > 0)
                cmd.Parameters.AddWithValue("@professionalID", professionalID);

            if (limit > 0)
                cmd.Parameters.AddWithValue("@limit", limit);

            return cmd;
        }

        public SqlCommand getAnimalDiary(int animalID)
        {
            String str = "SELECT ad.AnimalDiaryID, ad.DateDiaryStart, ad.DateDiaryEnd, adt.Description, ad.Value, ad.Observation FROM AnimalDiary ad";
            str += " INNER JOIN AnimalDiaryTypes adt ON adt.AnimalDiaryTypeID = ad.AnimalDiaryTypeID";
            str += " WHERE AnimalID = @animalID AND ServiceID IS NULL";
            str += " ORDER BY ad.DateCreated DESC";


            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@animalID", animalID);
            return cmd;
        }

        public SqlCommand getAnimalDiaryByService(int animalID, int serviceID)
        {
            String str = "SELECT ad.AnimalDiaryID, ad.DateDiaryStart, ad.DateDiaryEnd, ad.Observation, ad.Comment FROM AnimalDiary ad";
            str += " WHERE AnimalID = @animalID AND ServiceID = @serviceID";
            str += " ORDER BY ad.DateCreated DESC";


            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@animalID", animalID);
            cmd.Parameters.AddWithValue("@serviceID", serviceID);

            return cmd;
        }

        public SqlCommand getDiaryInfo(int diaryID)
        {
            String str = "SELECT ad.*, adt.Description FROM AnimalDiary ad";
            str += " LEFT OUTER JOIN AnimalDiaryTypes adt ON ad.AnimalDiaryTypeID = adt.AnimalDiaryTypeID";
            str += " WHERE [AnimalDiaryID] = @did";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@did", diaryID);
            return cmd;
        }

        public void updateCommentOfDiary(int animalDiaryID, String comment)
        {
            if (animalDiaryID <= 0) return;

            String str = "UPDATE AnimalDiary SET " +
                "  Comment = @comment" +
                " WHERE AnimalDiaryID = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalDiaryID);
            cmd.Parameters.AddWithValue("@comment", comment);

            cmd.ExecuteNonQuery();
        }

        public void updateObservationOfDiary(int animalDiaryID, String obs)
        {
            if (animalDiaryID <= 0) return;

            String str = "UPDATE AnimalDiary SET " +
                "  Observation = @obs" +
                " WHERE AnimalDiaryID = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", animalDiaryID);
            cmd.Parameters.AddWithValue("@obs", obs);

            cmd.ExecuteNonQuery();
        }
    }
}