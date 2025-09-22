using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;


namespace UserManagement.Bussiness.Repository
{
    public class UserInfoRepository: IUserInfoRepository
    {
        MySqldbConnection connection;

        public UserInfoRepository(string connectionString) 
        {
            connection = new MySqldbConnection(connectionString);
        }
        public bool Insert(UserInfo request)
        {
            var parameters = new Dictionary<string, object>
        {
            { "p_username", request.userName },
            { "p_email", request.email },
            { "p_fathername", request.fatherName },
            { "p_mothername", request.motherName },
            { "p_aadhaarnumber", request.aadhaarNumber },
            { "p_pancarno", request.panCardNo },
            { "p_passport", request.passportNo },
            { "p_status", request.status },
            { "p_createdby", request.createdBy }
            
        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_userinfo_insert", parameters));

        }
        public bool Update(UserInfo request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userID },
            { "p_username", request.userName },
            { "p_email", request.email },
            { "p_fathername", request.fatherName },
            { "p_mothername", request.motherName },
            { "p_aadhaarnumber", request.aadhaarNumber },
            { "p_pancarno", request.panCardNo },
            { "p_passport", request.passportNo },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_userinfo_update", parameters));

        }
        public bool ChangeStatus(UserInfo request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userID },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_userinfo_changestatus", parameters));

        }
        public List<UserInfo> Select(UserInfo request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", (request.userID!= null && request.userID>0)? request.userID:DBNull.Value },
            { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value}

        };

            DataTable result = connection.ExecuteQuery("sp_userinfo_select", parameters);
            if (Verification.HasRecord(result))
            
                return Convertor.ConvertTableToList<UserInfo>(result);


            return new List<UserInfo>();

        }
    }
}
