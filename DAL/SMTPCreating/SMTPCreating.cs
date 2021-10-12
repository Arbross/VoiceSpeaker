using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SMTPCreating
    {
        public static SmtpClient client;

        //SMTP creation
        public static void SetSMTP()
        {
            client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ronnieplayyt@gmail.com", "romap310103")
            };
        }
    }
}
