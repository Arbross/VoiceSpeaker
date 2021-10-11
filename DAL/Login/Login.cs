using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Login
    {
        public static void StartLogin(string Login, string Password)
        {
            Account p1;
            SpeakerModel md1 = new SpeakerModel();
            SMTPCreating smtpc = new SMTPCreating();

            string mailT = null;

            //Search for mail via login from the database
            using (SpeakerModel model = new SpeakerModel())
            {
                p1 = model.Accounts.Where(c => c.Login == Login).FirstOrDefault();

                if (p1 != null)
                {
                    model.Accounts.Attach(p1);
                    mailT = p1.Mail;
                }
                else
                {
                    Tools.ErrorLogSave("This account does not have mail");
                }
            }

            //Checking for compatibility of login and password with the same topic as in the database
            var Logi = Task.Run(() => { md1.Accounts.FirstOrDefault(t => t.Login == Login); });
            var Passw = Task.Run(() => { md1.Accounts.FirstOrDefault(t => t.Password == Password); });

            //Checking for compatibility of login and password with the same topic as in the database
            Logi.Wait();
            if (Logi != null)
            {
                SMTPCreating.SetSMTP();
                Passw.Wait();
                if (Passw != null)
                {
                    //Sending a notification to the user about the entry into a person's account for safety
                    SMTPCreating.client.SendMailAsync("ronnieplayyt@gmail.com", mailT, "Notification", "Your account has been logged in!");
                }
                else
                {
                    Tools.ErrorLogSave("You entered an incorrect password");

                    //Sending a notification to the user about an attempt to log into a person's account for safety
                    SMTPCreating.client.SendMailAsync("ronnieplayyt@gmail.com", mailT, "Notification", "An attempt was made to enter your personal account!");
                }
            }
            else
            {
                Tools.ErrorLogSave("You entered an invalid login");
            }
        }
    }
}
