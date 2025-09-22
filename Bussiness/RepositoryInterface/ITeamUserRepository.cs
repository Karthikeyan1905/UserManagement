using System.Collections.Generic;
using UserManagement.Model.Team;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface ITeamUserRepository
    {
        bool Insert(TeamUser request);
        bool Update(TeamUser request);
        bool ChangeStatus(TeamUser request);
        List<TeamUser> Select(TeamUser request);
    }
}
