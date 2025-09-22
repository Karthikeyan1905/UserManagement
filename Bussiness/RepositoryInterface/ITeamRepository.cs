using System.Collections.Generic;
using UserManagement.Model.Team;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface ITeamRepository
    {
        bool Insert(Team request);
        bool Update(Team request);
        bool ChangeStatus(Team request);
        List<Team> Select(Team request);
    }
}
