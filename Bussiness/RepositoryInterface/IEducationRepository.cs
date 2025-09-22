using System.Collections.Generic;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IEducationRepository
    {
        bool Insert(Education request);
        bool Update(Education request);
        bool ChangeStatus(Education request);
        List<Education> Select(Education request);
    }
}
