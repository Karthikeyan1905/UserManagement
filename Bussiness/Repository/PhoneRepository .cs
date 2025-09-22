using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        MySqldbConnection connection;

        public PhoneRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Phone request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_phoneno", request.phoneNumber },
                { "p_phonetype", request.phoneType },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_phone_insert", parameters));
        }

        public bool Update(Phone request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_phoneid", request.phoneID },
                { "p_userid", request.userID },
                { "p_phoneno", request.phoneNumber },
                { "p_phonetype", request.phoneType },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_phone_update", parameters));
        }

        public bool ChangeStatus(Phone request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_phoneid", request.phoneID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_phone_changestatus", parameters));
        }

        public List<Phone> Select(Phone request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_phoneid",(request.phoneID !=null && request.phoneID>0)? request.phoneID:DBNull.Value },
                { "p_userid",  (request.userID !=null && request.userID>0)? request.userID:DBNull.Value },
                 { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_phone_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Phone>(result);

            return new List<Phone>();
        }
    }
}
