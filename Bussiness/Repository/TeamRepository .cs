using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.Team;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class TeamRepository : ITeamRepository
    {
        MySqldbConnection connection;

        public TeamRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Team request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamname", request.teamName },
                { "p_teamcode", request.teamCode },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_team_insert", parameters));
        }

        public bool Update(Team request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamid", request.teamID },
                { "p_teamname", request.teamName },
                { "p_teamcode", request.teamCode },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_team_update", parameters));
        }

        public bool ChangeStatus(Team request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamid", request.teamID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_team_changestatus", parameters));
        }

        public List<Team> Select(Team request)
        {
            var parameters = new Dictionary<string, object>
            {
                 { "p_teamid",  (request.teamID !=null && request.teamID>0)? request.teamID:DBNull.Value },
                 { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_team_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Team>(result);

            return new List<Team>();
        }
    }
}
