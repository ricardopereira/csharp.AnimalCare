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

        public SqlCommand getAllOwners()
        {
            String str = "SELECT o.*, co.Name Country, b.Name Sector, " +
                " CASE" +
                "  WHEN Business = 0 THEN 'Particular'" +
                "  WHEN Business = 1 THEN 'Empresa'" +
                " END as Kind" +
                " FROM Owners o" +
                " LEFT OUTER JOIN Countries co ON co.CountryID = o.CountryID" +
                " LEFT OUTER JOIN BusinessSector b ON b.BusinessSectorID = o.BusinessSectorID" +
                " WHERE o.Inactive = 0 OR o.Inactive IS NULL ORDER BY o.Name";

            // Executar comando
            SqlCommand cmd = new SqlCommand(str, Database.Connection);

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
    }
}