using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace AnimalCare.Doctor
{
    public class ControllerDoctor : Controller
    {
        private int profissionalID;

        public int ProfissionalID
        {
            get { return profissionalID; }
            set { profissionalID = value; }
        }

        public ControllerDoctor(IIdentity currentUser) : base(currentUser)
        {
 
        }

        public override void loadCurrentUser(IIdentity currentUser)
        {
            // Current User
            Guid userGuid = (Guid)Membership.GetUser(currentUser.Name).ProviderUserKey;
            // Load from Owners
            SqlCommand cmd = new SqlCommand("SELECT ProfissionalID FROM Professionals WHERE [UserId] = @id", Database.Connection);
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
                    ProfissionalID = dados.GetInt32(0);
            }
            dados.Close();
        }
    }
}