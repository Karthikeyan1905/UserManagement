using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.User;

namespace UserManagement.Department
{
    public class Employee : Base
    {
        
        public int deptID { get;set }
        public int designationID { get; set; }
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public UserInfo user { get; set; }

    }
}
