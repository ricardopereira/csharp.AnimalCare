using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace AnimalCare.Doctor
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }

    public class DoctorBuffer
    {
        private int professionalID;
        private String name;
        private string email;
        private String codeWorker;
        private String workNumber;
        private String personalNumber;

        public int ProfessionalID
        {
            get { return professionalID; }
            set { professionalID = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public String CodeWorker
        {
            get { return codeWorker; }
            set { codeWorker = value; }
        }

        public String WorkNumber
        {
            get { return workNumber; }
            set { workNumber = value; }
        }

        public String PersonalNumber
        {
            get { return personalNumber; }
            set { personalNumber = value; }
        }
    }

    public class ControllerDoctor : Controller
    {
        private DoctorBuffer bf;

        public DoctorBuffer Bf
        {
            get
            {
                if (bf == null)
                    bf = new DoctorBuffer();
                return bf;
            }
        }

        public ControllerDoctor(IIdentity currentUser) : base(currentUser)
        {
 
        }

        public override int getUniqueID()
        {
            return Bf.ProfessionalID;
        }

        public override void loadCurrentUser()
        {
            // Current User
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            MembershipUser ms = Membership.GetUser(); /* Load user email */
            Bf.Email = ms.Email;

            String sql = "SELECT * FROM Professionals WHERE [UserId] = @id";

            // Load from Owners
            SqlCommand cmd = new SqlCommand(sql, Database.Connection);
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
                    Bf.ProfessionalID = dados.GetInt32(0);
                if (!dados.IsDBNull(2))
                    Bf.Name = dados.GetString(2);
                if (!dados.IsDBNull(3))
                    Bf.CodeWorker = dados.GetString(3);
                if (!dados.IsDBNull(4))
                    Bf.WorkNumber = dados.GetString(4);
                if (!dados.IsDBNull(5))
                    Bf.PersonalNumber = dados.GetString(5);
            }
            else
            {

            }
            dados.Close();
        }

        public void insertDoctorInfo(String name, String codeWorker, String workNumber, String personalNumber)
        {
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            String str = "INSERT INTO Professionals VALUES (@userID, @name, @codeWorker, @workNumber, @personalNumber)";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@userID", userGuid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@codeWorker", codeWorker);
            cmd.Parameters.AddWithValue("@workNumber", workNumber);
            cmd.Parameters.AddWithValue("@personalNumber", personalNumber);

            cmd.ExecuteNonQuery();
        }

        public void updateDoctorInfo(String name, String codeWorker, String workNumber, String personalNumber)
        {
            String str = "UPDATE Professionals SET" +
                         "  Name = @name," +
                         "  CodeWorker = @codeWorker," +
                         "  WorkNumber = @workNumber," +
                         "  PersonalNumber = @personalNumber" +
                         " WHERE ProfessionalID = @professionalID";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@professionalID", Bf.ProfessionalID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@codeWorker", codeWorker);
            cmd.Parameters.AddWithValue("@workNumber", workNumber);
            cmd.Parameters.AddWithValue("@personalNumber", personalNumber);

            cmd.ExecuteNonQuery();
        }

        public SqlCommand getSchedules()
        {
            return getAllSchedule(getMinDate(), getMaxDate());
        }

        public SqlCommand getScheduleToday()
        {
            return getAllSchedule(DateTime.Today, DateTime.Today.AddDays(1));
        }

        public SqlCommand getScheduleWeek()
        {
            DateTime monday = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime sunday = monday.AddDays(6);

            return getAllSchedule(monday, sunday);
        }

        public SqlCommand getScheduleMonth()
        {
            var today = DateTime.Today;
            var first = new DateTime(today.Year, today.Month, 1);
            var month = first.AddMonths(1);
            var last = month.AddDays(-1).AddHours(22);

            return getAllSchedule(first, last);
        }

        public SqlCommand getLastServices()
        {
            return getAllServices(getMinDate(), getMaxDate(), Bf.ProfessionalID, 5);
        }

        public SqlCommand getSchedule(int scheduleID)
        {
            String str = getAllScheduleSQL() + " WHERE sh.ScheduleID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", scheduleID);
            return cmd;
        }

        public SqlCommand getService(int serviceID)
        {
            String str = getAllServiceSQL() + " WHERE sr.ServiceID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", serviceID);
            return cmd;
        }

        public void insertServiceEvent(int ownerID, int animalID, String description, String observation,
            int serviceKindID, int professionalID, int clinicID, DateTime dateService)
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
            10-[AnimalGroupID] INT NULL,
            11-[ProfessionalID] INT NOT NULL,
            12-[ClinicID] INT NULL,
             */

            String str = "INSERT INTO Services " +
                " VALUES (@ownerID,@name,@description,@dateService,NULL,CURRENT_TIMESTAMP," +
                        " @observation,@serviceKindID,@animalID,NULL,@professionalID,@clinicID)";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@ownerID", ownerID);
            cmd.Parameters.AddWithValue("@name", "Serviço criado");
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateService", dateService);
            cmd.Parameters.AddWithValue("@observation", observation);
            cmd.Parameters.AddWithValue("@serviceKindID", serviceKindID);
            cmd.Parameters.AddWithValue("@animalID", animalID);
            cmd.Parameters.AddWithValue("@professionalID", professionalID);
            cmd.Parameters.AddWithValue("@clinicID", clinicID);

            cmd.ExecuteNonQuery();
        }

        public void updateServiceEvent(int serviceID, String description, int serviceKindID, 
            DateTime dateService, DateTime dateConclusion, String obs, int clinicID)
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
            10-[AnimalGroupID] INT NULL,
            11-[ProfessionalID] INT NOT NULL,
            12-[ClinicID] INT NULL,
             */

            if (serviceID <= 0) return;

            String str = "UPDATE Services SET " +
                "  Description = @description," +
                "  DateService = @dateService," +
                "  DateConclusion = @dateConclusion," +
                "  Observation = @observation," +
                "  ServiceKindID = @serviceKindID," +
                "  ClinicID = @clinicID" +
                " WHERE ServiceID = @id ";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", serviceID);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateService", dateService);
            cmd.Parameters.AddWithValue("@observation", obs);
            cmd.Parameters.AddWithValue("@serviceKindID", serviceKindID);
            cmd.Parameters.AddWithValue("@clinicID", clinicID);
            if (!dateConclusion.Equals(DateTime.MinValue))
                cmd.Parameters.AddWithValue("@dateConclusion", dateConclusion);
            else
                cmd.Parameters.AddWithValue("@dateConclusion", DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public void updateSchedule_Done(int scheduleID)
        {
            if (scheduleID <= 0) return;

            String str = "UPDATE Schedule SET " +
                "  state = @state" +
                " WHERE ScheduleID = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", scheduleID);
            cmd.Parameters.AddWithValue("@state", (int)ScheduleState.shtDone);

            cmd.ExecuteNonQuery();
        }
    }
}