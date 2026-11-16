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
using UserManagementModel.Model;
using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{
    public class OrderRepository : IOrderRepository
    {
        MySqldbConnection connection;

        public OrderRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }
        public ResponseResult Insert(Order request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_userid", request.userid},
            { "p_stageid", request.stageid},
            { "p_status", request.status},
            { "p_createdby", request.createdby }


        };

            var response = Convertor.ConvertTableToList<ResponseResult>(connection.ExecuteQuery("sp_orderp_insert", parameters));
            if (response != null)
                return response[0];
            return null;
        }
    }
}