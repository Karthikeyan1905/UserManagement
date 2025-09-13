using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.Department
{
    public class Designation : Base
    {
        public int DesignationID { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
    }
}
