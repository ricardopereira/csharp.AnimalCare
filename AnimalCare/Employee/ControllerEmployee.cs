using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace AnimalCare.Employee
{
    public class EmployeeBuffer
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

    public class ControllerEmployee : Controller
    {
        private EmployeeBuffer bf;

        public EmployeeBuffer Bf
        {
            get
            {
                if (bf == null)
                    bf = new EmployeeBuffer();
                return bf;
            }
        }

        public ControllerEmployee(IIdentity currentUser) : base(currentUser)
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

        public void insertEmployeeInfo(String name, String codeWorker, String workNumber, String personalNumber)
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

        public void updateEmployeeInfo(String name, String codeWorker, String workNumber, String personalNumber)
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

        public SqlCommand getSchedule()
        {
            return getAllSchedule(getMinDate(), getMaxDate());
        }

        public SqlCommand getAppointments()
        {
            AppointmentState[] states = new AppointmentState[3];
            // Lista dos estados a carregar
            states[0] = AppointmentState.astWaiting;
            states[1] = AppointmentState.astAccepted;
            states[2] = AppointmentState.astCanceled;

            return getAllAppointments(getMinDate(), getMaxDate(), states);
        }

        public bool hasWaitingAppointments()
        {
            return existsAppointments(AppointmentState.astWaiting, getMinDate(), getMaxDate());
        }

        public void ignoreAppointment(int appointmentID)
        {
            String str = "UPDATE Appointments SET" +
                         "  State = @state" +
                         " WHERE AppointmentID = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            cmd.Parameters.AddWithValue("@state", (int)AppointmentState.astDone);

            cmd.ExecuteNonQuery();
        }

        public void saveAppointment(int appointmentID, int newState, String reason)
        {
            String str = "UPDATE Appointments SET" +
                         "  State = @state," +
                         "  Reason = @reason" +
                         " WHERE AppointmentID = @id";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", appointmentID);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.Parameters.AddWithValue("@state", newState);

            cmd.ExecuteNonQuery();
        }

        public void insertScheduleEvent(int ownerID, int animalID, String description, int serviceKindID, int professionalID, DateTime dateEvent)
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
            13-[State] SMALLINT NULL
             */

            String str = "INSERT INTO Schedule (Description,DateEvent,Notified,Present,DateCreated,CreatedBy,ServiceKindID,OwnerID,AnimalID,ProfessionalID,State)";

            str += " VALUES (@description,@dateEvent,@notified,@present,CURRENT_TIMESTAMP,@createdBy,@serviceKindID,@ownerID,@animalID,@professionalID,0)";

            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateEvent", dateEvent);
            cmd.Parameters.AddWithValue("@notified", false);
            cmd.Parameters.AddWithValue("@present", false);
            cmd.Parameters.AddWithValue("@createdBy", userGuid);
            cmd.Parameters.AddWithValue("@serviceKindID", serviceKindID);
            cmd.Parameters.AddWithValue("@ownerID", ownerID);
            cmd.Parameters.AddWithValue("@animalID", animalID);
            cmd.Parameters.AddWithValue("@professionalID", professionalID);

            cmd.ExecuteNonQuery();
        }

        public void updateScheduleEvent(int scheduleID, String description, bool notified, bool present, int serviceKindID, int professionalID, DateTime dateEvent, int state = 0)
        {
            if (scheduleID <= 0) return;

            String str = "UPDATE Schedule SET " +
                "  Description = @description," +
                "  DateEvent = @dateEvent," +
                "  Notified = @notified," +
                "  Present = @present," +
                "  ServiceKindID = @serviceKindID," +
                "  ProfessionalID = @professionalID," +
                "  state = @state" +
                " WHERE ScheduleID = @id ";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", scheduleID);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateEvent", dateEvent);
            cmd.Parameters.AddWithValue("@notified", notified);
            cmd.Parameters.AddWithValue("@present", present);
            cmd.Parameters.AddWithValue("@serviceKindID", serviceKindID);
            cmd.Parameters.AddWithValue("@professionalID", professionalID);
            cmd.Parameters.AddWithValue("@state", state);

            cmd.ExecuteNonQuery();
        }

        public void deleteScheduleEvent(int scheduleID)
        {
            if (scheduleID <= 0) return;

            String str = "DELETE FROM Schedule " +
                " WHERE ScheduleID = @id ";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", scheduleID);

            cmd.ExecuteNonQuery();
        }

        public SqlCommand getSchedule(int scheduleID)
        {
            String str = getAllScheduleSQL() + " WHERE sh.ScheduleID = @id";
            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@id", scheduleID);
            return cmd;
        }
    }
}