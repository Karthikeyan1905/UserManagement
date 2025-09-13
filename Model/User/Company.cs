using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.User
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int WorkingExperienceInMonths { get; set; }

        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
    }  
}
