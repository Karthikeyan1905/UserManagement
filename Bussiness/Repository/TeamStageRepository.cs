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
    public class TeamStageRepository : ITeamStageRepository
    {
        MySqldbConnection connection;

        public TeamStageRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(TeamStage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_stageid", request.stageid },
                { "p_teamid", request.teamid },
                { "p_status", request.status },
                { "p_createdby", request.createdby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamstage_insert", parameters));
        }

        public bool Update(TeamStage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamstageid", request.teamstageid },
                { "p_stageid", request.stageid },
                { "p_teamid", request.teamid },
                { "p_status", request.status },
                { "p_updatedby", request.updatedby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamstage_update", parameters));
        }

        public bool ChangeStatus(TeamStage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamstageid", request.teamstageid },
                { "p_status", request.status },
                { "p_updatedby", request.updatedby }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamstage_changestatus", parameters));
        }

        public List<TeamStage> Select(TeamStage request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamstageid", request.teamstageid > 0 ? request.teamstageid : DBNull.Value },
                { "p_stageid", request.stageid > 0 ? request.stageid : DBNull.Value },
                { "p_teamid", request.teamid > 0 ? request.teamid : DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status) ? request.status : DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_teamstage_select", parameters);

            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<TeamStage>(result);

            return new List<TeamStage>();
        }
    }
}
