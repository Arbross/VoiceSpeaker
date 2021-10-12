using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum CommandType
    {
        WAIT,
        REGISTER,
        LOGIN,
        EXIT,
    }

    [Serializable]
    public class ClientCommand
    {
        public CommandType Type { get; set; }
        public RegistrationInfo RegistrationInfo { get; set; }
        public LoginInfo LoginInfo { get; set; }
    }
}
