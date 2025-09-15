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
    public class AddressRepository
    {
        MySqldbConnection connection;

        public AddressRepository()
        {
            connection = new MySqldbConnection(Connection.GetConnectionString);
        }
        public bool Insert(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userid },
            { "p_permdoorno", request.permDoorNo},
            { "p_street", request.street },
            { "p_town", request.town },
            { "p_district", request.district },
            { "p_state", request.state },
            { "p_country", request.country },
            { "p_pincode", request.pincode },
            { "p_status", request.Status  },
            { "p_createdby", request.createdBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_insert", parameters));

        }
        public bool Update(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
          { "p_userid", request.userid },
            { "p_permdoorno", request.permDoorNo},
            { "p_street", request.street },
            { "p_town", request.town },
            { "p_district", request.district },
            { "p_state", request.state },
            { "p_country", request.country },
            { "p_pincode", request.pincode },
            { "p_status", request.Status  },
            { "p_createdby", request.createdBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_update", parameters));

        }
        public bool ChangeStatus(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userid },
            { "p_status", request.Status },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_address_changestatus", parameters));

        }
        public List<Address> Select(Address request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userid },
            { "p_status", request.Status }

        };

            DataTable result = connection.ExecuteQuery("sp_address_select", parameters);
            if (Verification.HasRecord(result))

                return Convertor.ConvertTableToList<Address>(result);


            return new List<Address>();

        }
    }
}
