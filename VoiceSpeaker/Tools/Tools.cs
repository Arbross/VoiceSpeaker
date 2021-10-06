using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceSpeaker
{
    public class Tools
    {
        public static void ToLower(ref string text)
        {
            string result = null;
            foreach (char item in text)
            {
                result += Char.ToLower(item);
            }

            text = result;
        }

        public static void ErrorLogSave(string message)
        {
            if (!File.Exists(@"..\..\error-log.txt"))
            {
                message += '\n' + "-------------------------------------------------------\n";
                File.WriteAllText(@"..\..\error-log.txt", message);
            }
            else
            {
                message += File.ReadAllText(@"..\..\error-log.txt");
                message += '\n' + "-------------------------------------------------------\n";
                File.WriteAllText(@"..\..\error-log.txt", message);
            }
        }
    }
}
