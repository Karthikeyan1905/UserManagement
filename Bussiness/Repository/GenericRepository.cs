using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public  class GenericRepository<T>
    {
        MySqldbConnection connection;
        public GenericRepository()
        {
            connection = new MySqldbConnection(Connection.GetConnectionString);
        }
        
        public bool Insert(string procedureName, Dictionary<string, object> parameters)
        {
            return Verification.IsSuccess(connection.ExecuteQuery(procedureName, parameters));
        }

    }
}
