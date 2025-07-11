using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.User;


namespace UserManagement.User
{
    public class UserInfo
    {
        public object departments;
        public object Experiance;
        public LoginCredential? loginCredential { get; set; }
        public int? userID { set; get; }
        public string? email { set; get; }
        public string? userName { set; get; }
        public string? fatherName { set; get; }
        public string? motherName { set; get; }
        public long AadhaarNumber { set; get; }
        public string? panCardNo { set; get; }
        public string? panCardNumber
        {
            get => panCardNo;
            set
            {
                if (HasPanCard)
                    panCardNumber = value;
            }
        }
        public bool HasPanCard { set; get; }

        public string? passportNo { set; get; }
        public string? passportNumber
        {
            get => passportNo;
            set
            {
                if (HasPassport)
                    passportNumber = value;
            }
        }
        public bool HasPassport { get; set; }
         
        public List<Phone> phone { get; set; }

        


        public List<Education> educations { get; set; }
        public List<Address> addresses { get; set; }

        public bool HasExperience { get; set; }
        public List<Company> experiance { get; set; }
        public static List<UserInfo> RegisteredUsers { get; } = new();
        public List<UserManagement.Department.Department> department { get; set; }
        public List<UserManagement.Department.Designation> designation { get; set; }
        public List<UserManagement.Department.Employee> employee { get; set; }
        public List<UserManagement.Team.Team> team { get; set; }

        public List<UserManagement.Team.TeamUser> teamUser { get; set; }
    }
}
