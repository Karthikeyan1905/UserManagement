using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public static class Verification
    {
        public static bool IsSuccess(DataTable input)
        {

            if (input!= null && input.Rows.Count > 0 )
            
               return input.Rows[0]["code"].Equals(200);
               return false;
                
            
        }
        public static bool HasRecord(DataTable input) 
        {
            return (input != null && input.Rows.Count > 0);

        }
    }
}
