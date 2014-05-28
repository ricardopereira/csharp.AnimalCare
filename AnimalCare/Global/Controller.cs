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
        astCanceled
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
            return DateTime.Now.AddYears(200);
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
                "  INNER JOIN Animals a ON a.AnimalID = rel.AnimalID" +
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
    }
}