using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /*
    Name
    Surname
    Login
    Password
    PublishDate
    Mail
    Phone
    */

    [Serializable]
    public class RegistrationInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PublishDate { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
