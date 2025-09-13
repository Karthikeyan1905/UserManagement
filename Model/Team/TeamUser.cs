using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Department;

namespace UserManagement.Model.Team
{
    public class TeamUser : Base
    {
        public int Userid { get; set; }
        public int TeamID { get; set; }
        public int EmployeeID { get; set; }

        
    }
}
