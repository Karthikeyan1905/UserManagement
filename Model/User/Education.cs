using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.User
{
    public class Education
    {
        public string? instituteName { set; get; }
        public string? instituteAddress { set; get; }
        public string? board {  set; get; }
        public string? courseName {  set; get; }
        public float percentage {  set; get; }
        public int startYear {  set; get; }

    }
}
