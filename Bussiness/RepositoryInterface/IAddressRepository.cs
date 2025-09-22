using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.RepositoryInterface
{
    public interface IAddressRepository
    {
        public bool Insert(Address request);
        public bool Update(Address request);
        public bool ChangeStatus(Address request);
        public List<Address> Select(Address request);
    }
}
