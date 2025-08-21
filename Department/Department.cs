using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Department
{
    public class Department : Base
    {
        public int deptID {  get; set; }

        public string? Name { get; set; }
        public string? ShortName { get; set; }
    }
}
