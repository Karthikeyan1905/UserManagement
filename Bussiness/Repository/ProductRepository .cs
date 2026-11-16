using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;

using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{
    public class ProductRepository : IProductRepository
    {
        MySqldbConnection connection;

        public ProductRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public List<Product> Select(Product request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_productid", (request.productId != null && request.productId > 0) ? request.productId : DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status) ? request.status : DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_product_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Product>(result);

            return new List<Product>();
        }
    }
}
