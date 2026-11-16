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
using UserManagementModel.Model;


namespace UserManagement.Bussiness.Repository
{
    public class UserInfoRepository: IUserInfoRepository
    {
        MySqldbConnection connection;

        public UserInfoRepository(string connectionString) 
        {
            connection = new MySqldbConnection(connectionString);
        }
        public ResponseResult Insert(UserInfo request)
        {
            var parameters = new Dictionary<string, object>
        {
            { "p_username", request.userName },
            { "p_email", request.email },
            { "p_fathername", request.fatherName },
            { "p_mothername", request.motherName },
            { "p_aadhaarnumber", request.aadhaarNumber },
            { "p_pancardno", request.panCardNo },
            { "p_passportno", request.passportNo },
            { "p_status", request.status },
            { "p_createdby", request.createdBy }
            
        };
            var response =  Convertor.ConvertTableToList<ResponseResult>(connection.ExecuteQuery("sp_userinfo_insert", parameters));
            if (response != null)
            return response[0];
            return null;

        }
        public ResponseResult Update(UserInfo request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userID },
            { "p_username", request.userName },
            { "p_email", request.email },
            { "p_fathername", request.fatherName },
            { "p_mothername", request.motherName },
            { "p_aadhaarnumber", request.aadhaarNumber },
            { "p_pancardno", request.panCardNo },
            { "p_passportno", request.passportNo },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };

            var response = Convertor.ConvertTableToList<ResponseResult>(connection.ExecuteQuery("sp_userinfo_update", parameters));
            if(response != null) 
                return response[0];

            return null;
        }
        public ResponseResult ChangeStatus(UserInfo request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userID },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };
            var response = Convertor.ConvertTableToList<ResponseResult>(connection.ExecuteQuery("sp_userinfo_changestatus", parameters));
            if (response != null)
                return response[0];

            return null;
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
            {

                var users = Convertor.ConvertTableToList<UserInfo>(result);
                foreach(var user in users)
                {
                    user.addresses = new AddressRepository(connection.ConnectionString).Select(new Address() { userid = user.userID });
                    user.phone = new PhoneRepository(connection.ConnectionString).Select(new Phone() { userID = user.userID }); 
                    user.educations = new EducationRepository(connection.ConnectionString).Select(new Education() { userID = user.userID });
                    user.experiance = new ExperienceRepository(connection.ConnectionString).Select(new Experience() { userID = user.userID });
                }
                return users;

            }
            return new List<UserInfo>();

        }
    }
}
