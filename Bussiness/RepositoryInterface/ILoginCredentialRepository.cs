using System.Collections.Generic;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface ILoginCredentialRepository
    {
        bool Insert(LoginCredential request);
        bool Update(LoginCredential request);
        bool ChangeStatus(LoginCredential request);
        List<LoginCredential> Select(LoginCredential request);
    }
}
