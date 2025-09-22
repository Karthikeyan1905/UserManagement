using System.Collections.Generic;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IPhoneRepository
    {
        bool Insert(Phone request);
        bool Update(Phone request);
        bool ChangeStatus(Phone request);
        List<Phone> Select(Phone request);
    }
}
