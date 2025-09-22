using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    
    public class DepartmentRepository : IDepartmentRepository
    {
        MySqldbConnection connection;

        public DepartmentRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }
        public bool Insert(Department request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_deptname", request.deptName },
            { "p_deptShortName", request.deptShortName },
            { "p_status", request.status },
            { "p_createdby", request.createdBy }
            

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_department_insert", parameters));

        }
        public bool Update(Department request)
        {

            var parameters = new Dictionary<string, object>
        {
          { "p_deptid", request.deptID },
            { "p_deptname", request.deptName},
            { "p_deptShortName", request.deptShortName },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy },
            
        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_department_update", parameters));

        }
        public bool ChangeStatus(Department request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_deptid", request.deptID },
            { "p_status", request.status },
            { "p_updatedby", request.updatedBy }

        };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_department_changestatus", parameters));

        }

        public List<Department> Select(Department request)
        {

            var parameters = new Dictionary<string, object>
        {
            { "p_deptid",(request.deptID!= null && request.deptID>0)? request.deptID:DBNull.Value },
            { "p_status",!string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }

        };

            DataTable result = connection.ExecuteQuery("sp_department_select", parameters);
            if (Verification.HasRecord(result))

                return Convertor.ConvertTableToList<Department>(result);


            return new List<Department>();

        }
    }
}

