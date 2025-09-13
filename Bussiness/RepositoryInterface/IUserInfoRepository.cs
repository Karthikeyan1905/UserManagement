using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IUserInfoRepository
    {
        public bool Insert(UserInfo request);
        public bool Update(UserInfo request);
        public bool ChangeStatus(UserInfo request);
        public List<UserInfo> Select(UserInfo request);
    }
}
