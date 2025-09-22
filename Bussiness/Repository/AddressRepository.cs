using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class AddressRepository : IAddressRepository
    {
        MySqldbConnection connection;

        public AddressRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }
        public bool Insert(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userid},
            { "p_addresstype", request.addressType},
            { "p_permdoorno", request.permDoorNo},
            { "p_street", request.street },
            { "p_town", request.town },
            { "p_district", request.district },
            { "p_state", request.state },
            { "p_country", request.country },
            { "p_pincode", request.pincode },
            { "p_status", request.status  },
            { "p_createdby", request.createdBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_insert", parameters));

        }
        public bool Update(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
                { "p_userid", request.userid },
            { "p_addressid", request.addressid },
            {"p_addresstype", request.addressType },
            
            { "p_permdoorno", request.permDoorNo},
            { "p_street", request.street },
            { "p_town", request.town },
            { "p_district", request.district },
            { "p_state", request.state },
            { "p_country", request.country },
            { "p_pincode", request.pincode },
            { "p_status", request.status  },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_update", parameters));

        }
        public bool ChangeStatus(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_addressid", request.addressid},
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_changestatus", parameters));

        }

        public List<Address> Select(Address request)
        {

            var parameters = new Dictionary<string, object>
        {

            { "p_userid", (request.userid !=null && request.userid>0)? request.userid:DBNull.Value},
            { "p_addressid", (request.addressid!=null && request.addressid> 0)? request.addressid:DBNull.Value   },
            { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value  }

        };

            DataTable result = connection.ExecuteQuery("sp_address_select", parameters);
            if (Verification.HasRecord(result))

                return Convertor.ConvertTableToList<Address>(result);


            return new List<Address>();

        }
    }
}
