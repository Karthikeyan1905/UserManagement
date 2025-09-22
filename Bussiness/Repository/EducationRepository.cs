using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class EducationRepository : IEducationRepository
    {
        MySqldbConnection connection;

        public EducationRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Education request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_institutename", request.instituteName },
                { "p_instituteAddress", request.instituteAddress },
                { "p_board", request.board },
                { "p_courseName", request.courseName },
                { "p_percentage", request.percentage },
                { "p_startyear", request.startYear },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_education_insert", parameters));
        }

        public bool Update(Education request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_educationid", request.educationID },
                { "p_userid", request.userID },
                { "p_institutename", request.instituteName },
                { "p_instituteAddress", request.instituteAddress },
                { "p_board", request.board },
                { "p_courseName", request.courseName },
                { "p_percentage", request.percentage },
                { "p_startyear", request.startYear },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_education_update", parameters));
        }

        public bool ChangeStatus(Education request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_educationid", request.educationID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_education_changestatus", parameters));
        }

        public List<Education> Select(Education request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_educationid", (request.educationID !=null && request.educationID>0)? request.educationID:DBNull.Value },
                { "p_userid",  (request.userID !=null && request.userID>0)? request.userID:DBNull.Value },

                { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_education_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Education>(result);

            return new List<Education>();
        }
    }
}
