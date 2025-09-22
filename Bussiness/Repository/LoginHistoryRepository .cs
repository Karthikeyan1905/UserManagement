using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.History;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class LoginHistoryRepository : ILoginHistoryRepository
    {
        MySqldbConnection connection;

        public LoginHistoryRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(LoginHistory request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_status", request.status },
                { "p_logintime", request.loginTime },
                { "p_logouttime", request.loginOut },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginhistory_insert", parameters));
        }

        public bool Update(LoginHistory request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginid", request.loginID },
                { "p_userid", request.userID },
                { "p_status", request.status },
                { "p_logintime", request.loginTime },
                { "p_logouttime", request.loginOut },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginhistory_update", parameters));
        }

        public bool ChangeStatus(LoginHistory request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginid", request.loginID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_loginhistory_changestatus", parameters));
        }

        public List<LoginHistory> Select(LoginHistory request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_loginid",(request.loginID !=null && request.loginID>0)? request.loginID:DBNull.Value },
                 { "p_userid",  (request.userID !=null && request.userID>0)? request.userID:DBNull.Value },
                 { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_loginhistory_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<LoginHistory>(result);

            return new List<LoginHistory>();
        }
    }
}
