using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        MySqldbConnection connection;

        public DesignationRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Designation request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_designationname", request.designationName },
                { "p_designationShortName", request.designationShortName },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_designation_insert", parameters));
        }

        public bool Update(Designation request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_designationid", request.designationID },
                { "p_designationname", request.designationName },
                { "p_designationShortName", request.designationShortName },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_designation_update", parameters));
        }

        public bool ChangeStatus(Designation request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_designationid", request.designationID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_designation_changestatus", parameters));
        }

        public List<Designation> Select(Designation request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_designationid", (request.designationID!= null && request.designationID>0)? request.designationID:DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_designation_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Designation>(result);

            return new List<Designation>();
        }
    }
}
