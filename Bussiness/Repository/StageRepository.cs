using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;
using UserManagementModel.Model.Team;

namespace UserManagement.Bussiness.Repository
{
    public class StageRepository : IStageRepository
    {
        MySqldbConnection connection;

        public StageRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Stage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_stagename", request.stagename },
                { "p_status", request.status },
                { "p_createdby", request.createdby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_stage_insert", parameters));
        }

        public bool Update(Stage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_stageid", request.stageid },
                { "p_stagename", request.stagename },
                { "p_status", request.status },
                { "p_updatedby", request.updatedby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_stage_update", parameters));
        }

        public bool ChangeStatus(Stage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_stageid", request.stageid },
                { "p_status", request.status },
                { "p_updatedby", request.updatedby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_stage_changestatus", parameters));
        }

        public List<Stage> Select(Stage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_stageid", request.stageid > 0 ? request.stageid : DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status) ? request.status : DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_stage_select", parameters);

            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Stage>(result);

            return new List<Stage>();
        }
    }
}
