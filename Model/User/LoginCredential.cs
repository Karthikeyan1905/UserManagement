using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model.User
{
    public class LoginCredential
    {
        
        
        public string? loginUsername {  get; set; }
        public string loginPassword = "1234";
        public string? login_Password
        {
            get { return loginPassword; }
            set { loginPassword = value ?? "1234"; }
        }
        

    }
}
