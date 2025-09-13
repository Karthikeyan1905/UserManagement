using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.Team
{
    public class Team : Base
    {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? TeamCode { get; set; }
    }
}
