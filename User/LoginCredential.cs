using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.User
{
    public class LoginCredential
    {
        
        //public long LoginID { get; set; }
        public string? loginUsername {  get; set; }
        private string _loginPassword = "1234";
        public string? loginPassword
        {
            get { return _loginPassword; }
            set { _loginPassword = value ?? "1234"; }
        }
        //public string? status { get; set; }

    }
}
