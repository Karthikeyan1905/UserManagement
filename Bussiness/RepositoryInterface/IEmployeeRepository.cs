using System.Collections.Generic;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IEmployeeRepository
    {
        bool Insert(Employee request);
        bool Update(Employee request);
        bool ChangeStatus(Employee request);
        List<Employee> Select(Employee request);
    }
}
