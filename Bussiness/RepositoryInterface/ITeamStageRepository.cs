using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.Model.Team;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface ITeamStageRepository
    {
        bool Insert(TeamStage request);
        bool Update(TeamStage request);
        bool ChangeStatus(TeamStage request);
        List<TeamStage> Select(TeamStage request);
    }
}
