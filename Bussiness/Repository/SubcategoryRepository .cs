using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;

using UserManagementModel.Model.Orders;

namespace UserManagement.Bussiness.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        MySqldbConnection connection;

        public SubcategoryRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public List<SubCategory> Select(SubCategory request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_subcategoryid", (request.subcategoryId != null && request.subcategoryId > 0) ? request.subcategoryId : DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status) ? request.status : DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_subcategory_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<SubCategory>(result);

            return new List<SubCategory>();
        }
    }
}
