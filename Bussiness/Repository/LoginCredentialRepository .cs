using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class LoginCredentialRepository : ILoginCredentialRepository
    {
        MySqldbConnection connection;

        public LoginCredentialRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(LoginCredential request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_loginusername", request.loginUsername },
                { "p_loginpassword", request.login_Password },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginCredential_insert", parameters));
        }

        public bool Update(LoginCredential request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginCredentialid", request.loginCredentialid },
                { "p_userid", request.userID },
                { "p_loginusername", request.loginUsername },
                { "p_loginpassword", request.login_Password },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginCredential_update", parameters));
        }

        public bool ChangeStatus(LoginCredential request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginCredentialid", request.loginCredentialid },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginCredential_changestatus", parameters));
        }

        public List<LoginCredential> Select(LoginCredential request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginCredentialid ", (request.loginCredentialid !=null && request.loginCredentialid>0)? request.loginCredentialid:DBNull.Value },
                { "p_userid",  (request.userID !=null && request.userID>0)? request.userID:DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_loginCredential_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<LoginCredential>(result);

            return new List<LoginCredential>();
        }
    }
}
