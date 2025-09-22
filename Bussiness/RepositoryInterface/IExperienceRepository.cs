using System.Collections.Generic;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IExperienceRepository
    {
        bool Insert(Experience request);
        bool Update(Experience request);
        bool ChangeStatus(Experience request);
        List<Experience> Select(Experience request);
    }
}
