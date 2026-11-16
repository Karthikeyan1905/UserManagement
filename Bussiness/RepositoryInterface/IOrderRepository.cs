using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model.User;
using UserManagementModel.Model;
using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IOrderRepository
    {
        public ResponseResult Insert(Order request);
        
    }
}
