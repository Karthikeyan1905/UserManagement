using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{
    public interface ISubcategoryRepository
    {
        public List<SubCategory> Select(SubCategory request);
    }
}
