using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IDepartmentRepository
    {
        public bool Insert(Department request);
        public bool Update(Department request);
        public bool ChangeStatus(Department request);
        public List<Department> Select(Department request);
    }
}