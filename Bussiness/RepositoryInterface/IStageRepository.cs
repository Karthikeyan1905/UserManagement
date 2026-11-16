using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.Model.Team;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IStageRepository
    {
        bool Insert(Stage request);
        bool Update(Stage request);
        bool ChangeStatus(Stage request);
        List<Stage> Select(Stage request);
    }
}
