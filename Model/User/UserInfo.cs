using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.User
{
    [Serializable]
    public class UserInfo: Base
    {
        


        public int userRoleID { get; set; }
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

        //public object departments;
        //public object Experiance;
    }
}
