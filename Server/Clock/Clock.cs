using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Clock
    {
        public static string GetTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
