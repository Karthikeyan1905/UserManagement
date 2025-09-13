using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public static class Connection
    {
        public static string GetConnectionString { get 
            {
                if(HasConnectionString) 
                    return System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
                throw new Exception("Missing Connection String ERROR: connstr");
            } 
            private set { } }

        public static bool HasConnectionString
        {
            get
            {
                return (System.Configuration.ConfigurationManager.ConnectionStrings["connstr"] != null);
                   
            }
            private set { }
        }

    }
}
