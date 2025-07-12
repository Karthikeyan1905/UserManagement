using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.History
{
    public class LoginHistory
    {
        public long LoginID { get; set; }
        public string? status { get; set; }
        public DateTime loginTime { get; set; } = DateTime.Now;
        public DateTime loginOut { get; set; } = DateTime.Now;
    }
}
