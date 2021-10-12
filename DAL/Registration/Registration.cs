using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Registration
    {
        public async static Task StartRegistration(string Login, string Password, string RepeatPassword, string Phone, string Mail, string Name, string Surname, DateTime PublishDate)
        {
            string Code;
            SpeakerModel md1 = new SpeakerModel();

            //Checking for the presence of "@gmail.com" in the text
            int z = 0;
            if (Mail.Contains("@gmail.com"))
            {
                z = 1;
            }
            else
            {
                z = 0;
            }

            //Checking for compatibility of login and password with the same topic as in the database
            var mod1 = Task.Run(() => { md1.Accounts.FirstOrDefault(s => s.Login == Login); });
            var mod2 = Task.Run(() => { md1.Accounts.FirstOrDefault(s => s.Mail == Mail); });

            //Checking the compatibility of the written login with the one in the database
            //Needed to avoid duplicate login
            mod1.Wait();
            if (mod1 == null)
            {
                //Checking the compatibility of the written mail with the one in the database
                //Needed to avoid duplicate mail
                mod2.Wait();
                if (mod2 == null)
                {
                    //Checking for the presence of "@gmail.com" in the text
                    if (z == 1)
                    {
                        //Checking to avoid creating empty data fields in the database
                        if (Phone != string.Empty && Name != string.Empty && Password != string.Empty && Surname != string.Empty)
                        {
                            //Checking whether a password contains six or more characters
                            if (Password.Length >= 6)
                            {
                                //Checking if the entered password matches the repeated password
                                if (Password == RepeatPassword)
                                {
                                    //Checking to avoid an empty data field in the date of birth of a new account
                                    if (PublishDate != null)
                                    {
                                        //CodeIdentityWindow.Phone = Phone;
                                        //CodeIdentityWindow.Password = Password;
                                        //CodeIdentityWindow.Name = Name;
                                        //CodeIdentityWindow.Surname = Surname;
                                        //CodeIdentityWindow.Date = PublishDate;
                                        //CodeIdentityWindow.Mail = Mail;
                                        //CodeIdentityWindow.Login = Login;

                                        Code = GeneratingCode.RandomString();
                                        //CodeIdentityWindow.CodeR = Code;

                                        //Creating a new SMTP
                                        SMTPCreating.SetSMTP();
                                        
                                        //Sending a code to the mail to confirm registration
                                        await Task.Run(() => SMTPCreating.client.SendMailAsync("ronnieplayyt@gmail.com", Mail, "Confirmation of registration", $"Confirm your registration with the code - {Code}!"));
                                    }
                                    else
                                    {
                                        Tools.ErrorLogSave("You have not chosen your date of birth!");
                                    }
                                }
                                else
                                {
                                    Tools.ErrorLogSave("The repeated password does not match the first sentence!");
                                }
                            }
                            else
                            {
                                Tools.ErrorLogSave("Your password has no more than 6 characters!");
                            }
                        }
                        else
                        {
                            Tools.ErrorLogSave("Some row was not filled!");
                        }
                    }
                    else
                    {
                        Tools.ErrorLogSave("The entered mail is not correct!");
                    }
                }
                else
                {
                    Tools.ErrorLogSave("The mail entered already exists!");
                }
            }
            else
            {
                Tools.ErrorLogSave("The login you entered already exists!");
            }
        }
    }
}
