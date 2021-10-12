using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /*
    Login
    Password
    */

    [Serializable]
    public class LoginInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
