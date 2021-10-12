using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerInfo
    {
        private int port;
        public int Port
        {
            get => port;
            set
            {
                if (value >= 1 && value <= 65535)
                {
                    port = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR][{DateTime.UtcNow}] Can't load port value.");
                    Tools.ErrorLogSave($"[ERROR][{DateTime.UtcNow}] Can't load port value.");
                }
            }
        }

        private string address;
        public IPAddress Address
        {
            get => IPAddress.Parse(address);
            set
            {
                address = value.ToString();
            }
        }
    }
}
