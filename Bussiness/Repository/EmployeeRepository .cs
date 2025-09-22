using System;
using System.Collections.Generic;
using System.Data;
using UserManagement.Bussiness.RepositoryInterface;
using UserManagement.dataAccess;
using UserManagement.Helper;
using UserManagement.Model.Department;
using UserManagement.Model.User;

namespace UserManagement.Bussiness.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MySqldbConnection connection;

        public EmployeeRepository(string connectionString)
        {
            connection = new MySqldbConnection(connectionString);
        }

        public bool Insert(Employee request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_userid", request.userID },
                { "p_deptid", request.deptID },
                { "p_designationid", request.designationID },
                { "p_status", request.status },
                { "p_createdby", request.createdBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_employee_insert", parameters));
        }

        public bool Update(Employee request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_employeeid", request.employeeID },
                { "p_userid", request.userID },
                { "p_deptid", request.deptID },
                { "p_designationid", request.designationID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_employee_update", parameters));
        }

        public bool ChangeStatus(Employee request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_employeeid", request.employeeID },
                { "p_status", request.status },
                { "p_updatedby", request.updatedBy }
            };

            return Verification.IsSuccess(connection.ExecuteQuery("sp_employee_changestatus", parameters));
        }

        public List<Employee> Select(Employee request)
        {
            var parameters = new Dictionary<string, object>
            {
                { "p_employeeid", (request.employeeID!= null && request.employeeID>0)? request.employeeID:DBNull.Value },
                { "p_userid", (request.userID!= null && request.userID>0)? request.userID:DBNull.Value },
                { "p_status", !string.IsNullOrEmpty(request.status)? request.status:DBNull.Value }
            };

            DataTable result = connection.ExecuteQuery("sp_employee_select", parameters);
            if (Verification.HasRecord(result))
                return Convertor.ConvertTableToList<Employee>(result);

            return new List<Employee>();
        }
    }
}
