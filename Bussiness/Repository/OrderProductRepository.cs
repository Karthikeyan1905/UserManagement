using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{

    public class OrderProductRepository:IOrderProductRepository
    {
        MySqldbConnection connection;

        public OrderProductRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }
        public bool Insert(OrderProduct request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_orderid", request.orderid},
            { "p_categoryid", request.categoryid},
            { "p_subcategoryid", request.subcategoryid},
            { "p_productid", request.productid },
            {"p_quantity",request.quantity},
            { "p_orderproductprice", request.orderproductprice },
            { "p_orderproductdiscount", request.orderproductdiscount },
            { "p_orderproductactualprice", request.orderproductactualprice },
            { "p_status", request.status },
            { "p_createdby", request.createdby }


        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_orderproduct_insert", parameters));

        }
    }
}
