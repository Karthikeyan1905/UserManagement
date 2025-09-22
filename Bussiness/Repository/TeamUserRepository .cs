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
    public class TeamUserRepository : ITeamUserRepository
    {
        MySqldbConnection connection;

        public TeamUserRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(TeamUser request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userid },
                { "p_teamid", request.teamID },
                { "p_employeeid", request.employeeID },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamUser_insert", parameters));
        }

        public bool Update(TeamUser request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamUserid", request.teamuserID },
                { "p_userid", request.userid },
                { "p_teamid", request.teamID },
                { "p_employeeid", request.employeeID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamUser_update", parameters));
        }

        public bool ChangeStatus(TeamUser request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_teamUserid", request.teamuserID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_teamUser_changestatus", parameters));
        }

        public List<TeamUser> Select(TeamUser request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"p_teamUserid",  (request.teamuserID !=null && request.teamuserID>0)? request.teamuserID:DBNull.Value },
                 { "p_userid",  (request.userid !=null && request.userid>0)? request.userid:DBNull.Value },
                 { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_teamUser_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<TeamUser>(result);

            return new List<TeamUser>();
        }
    }
}
