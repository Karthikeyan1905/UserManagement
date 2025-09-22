using System.Collections.Generic;
using UserManagement.Model.History;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface ILoginHistoryRepository
    {
        bool Insert(LoginHistory request);
        bool Update(LoginHistory request);
        bool ChangeStatus(LoginHistory request);
        List<LoginHistory> Select(LoginHistory request);
    }
}
