using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IProductRepository
    {
        public List<Product> Select(Product request);
    }
}
