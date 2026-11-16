using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model.User;
using UserManagementModel.Model;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IUserInfoRepository
    {
        public ResponseResult Insert(UserInfo request);
        public ResponseResult Update(UserInfo request);
        public ResponseResult ChangeStatus(UserInfo request);
        public List<UserInfo> Select(UserInfo request);
    }
}
