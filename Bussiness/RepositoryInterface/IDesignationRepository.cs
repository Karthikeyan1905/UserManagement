using System.Collections.Generic;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IDesignationRepository
    {
        bool Insert(Designation request);
        bool Update(Designation request);
        bool ChangeStatus(Designation request);
        List<Designation> Select(Designation request);
    }
}
