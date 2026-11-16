using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;

using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MySqldbConnection connection;

        public CategoryRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public List<Category> Select(Category request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_categoryid", (request.categoryId != null && request.categoryId > 0) ? request.categoryId : DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status) ? request.status : DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_category_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Category>(result);

            return new List<Category>();
        }
    }
}
