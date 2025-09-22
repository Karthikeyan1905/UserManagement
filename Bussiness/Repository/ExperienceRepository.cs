using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        MySqldbConnection connection;

        public ExperienceRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Experience request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_companyname", request.companyName },
                { "p_companyaddress", request.companyAddress },
                { "p_workingexperainceinMonths", request.workingExperienceInMonths },
                { "p_contactpersonname", request.contactPersonName },
                { "p_ContactPersonDesignation", request.contactPersonDesignation },
                { "p_ContactPersonPhone", request.contactPersonPhone },
                { "p_ContactPersonEmail", request.contactPersonEmail },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_experience_insert", parameters));
        }

        public bool Update(Experience request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_experianceid", request.experienceID },
                { "p_userid", request.userID },
                { "p_companyname", request.companyName },
                { "p_companyaddress", request.companyAddress },
                { "p_workingexperainceinMonths", request.workingExperienceInMonths },
                { "p_contactpersonname", request.contactPersonName },
                { "p_ContactPersonDesignation", request.contactPersonDesignation },
                { "p_ContactPersonPhone", request.contactPersonPhone },
                { "p_ContactPersonEmail", request.contactPersonEmail },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_experience_update", parameters));
        }

        public bool ChangeStatus(Experience request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_experianceid", request.experienceID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_experience_changestatus", parameters));
        }

        public List<Experience> Select(Experience request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_experianceid", (request.experienceID !=null && request.experienceID>0)? request.experienceID:DBNull.Value },
                { "p_userid",  (request.userID !=null && request.userID>0)? request.userID:DBNull.Value },
                 { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_experience_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Experience>(result);

            return new List<Experience>();
        }
    }
}
