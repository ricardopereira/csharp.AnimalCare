using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AnimalCare
{
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
                loadCurrentUser(currentUser);
            }
        }

        public abstract void loadCurrentUser(IIdentity currentUser);
    }
}