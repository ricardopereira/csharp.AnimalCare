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
        private int profissionalID;
        private String name;
        private string email;
        private String codeWorker;
        private String workNumber;
        private String personalNumber;

        public int ProfissionalID
        {
            get { return profissionalID; }
            set { profissionalID = value; }
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
            return Bf.ProfissionalID;
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
                    Bf.ProfissionalID = dados.GetInt32(0);
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

        public void updateEmployeeInfo(String name, String codeWorker, String workNumber, String personalNumber)
        {
            String str = "UPDATE Profissionals SET" +
                         "  Name = @name," +
                         "  CodeWorker = @codeWorker," +
                         "  WorkNumber = @workNumber," +
                         "  PersonalNumber = @personalNumber" +
                         " WHERE ProfissionalID = @profissionalID";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            cmd.Parameters.AddWithValue("@profissionalID", Bf.ProfissionalID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@codeWorker", codeWorker);
            cmd.Parameters.AddWithValue("@workNumber", workNumber);
            cmd.Parameters.AddWithValue("@personalNumber", personalNumber);

            cmd.ExecuteNonQuery();
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

        public void createEvent(int appointmentID)
        {
              /*[ScheduleID] INT NOT NULL IDENTITY,
              [Description] VARCHAR(50) NULL,
              [DateEvent] DATETIME NOT NULL,
              [Notified] BIT NULL,
              [Present] BIT NULL,
              [DateCreated] BIT NOT NULL,
              [CreatedBy] UNIQUEIDENTIFIER NOT NULL,
              [ServiceKindID] INT NOT NULL,
              [OwnerID] INT NOT NULL,
              [AnimalID] INT NULL,
              [AnimalGroupID] INT NULL,
              [ProfessionalID] INT NOT NULL,
              [Priority] SMALLINT NULL,*/

            return;

            String str = "INSERT INTO Schedule(UserID)";
            str += "VALUES(@UserID)";

            SqlCommand cmd = new SqlCommand(str, Database.Connection);
            //cmd.Parameters.AddWithValue("@UserID", );

            cmd.ExecuteNonQuery();

            saveAppointment(appointmentID, (int)AppointmentState.astAccepted, "Verifique a agenda");
        }
    }
}