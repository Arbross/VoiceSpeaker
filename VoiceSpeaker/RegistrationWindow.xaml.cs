﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VoiceSpeaker
{
    public partial class RegistrationWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized
        private bool clicado = false; // Is Clicked
        private Point lm = new Point(); // Point
        Accaunt p1;
        VoiceSpeakerModel md1;
        public string Code { get; set; }

        //Generates random symbols to generate a confirmation code
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //SMTP creation
        SmtpClient client = new SmtpClient()
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("ronnieplayyt@gmail.com", "romap310103")
        };

        public RegistrationWindow()
        {
            InitializeComponent();

        }
        // Close window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Is change window size
        private void btnFullSize_Click(object sender, RoutedEventArgs e)
        {
            if (isFullMaximized == false)
            {
                isFullMaximized = true;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                isFullMaximized = false;
                this.WindowState = WindowState.Normal;
            }
        }

        // Hide to tray
        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Move (fix later)
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clicado = true;
            this.lm = Mouse.GetPosition(this);
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicado)
            {
                this.Left += (Mouse.GetPosition(this).X - this.lm.X);
                this.Top += (Mouse.GetPosition(this).Y - this.lm.Y);
                this.lm = Mouse.GetPosition(this);
            }
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            clicado = false;
        }

        private void btnEnterRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinRegistration.Visibility = Visibility.Hidden;
            WinLogin.Visibility = Visibility.Visible;

            //Registering a new account


            //Checking for the presence of "@gmail.com" in the text
            int z = 0;
            if (tbMailRegistration.Text.Contains("@gmail.com"))
            {
                z = 1;
            }
            else
            {
                z = 0;
            }

            md1 = new VoiceSpeakerModel();

            //Checking for compatibility of login and password with the same topic as in the database
            var mod1 = md1.Accaunts.FirstOrDefault(c => c.Login == tbLoginRegistration.Text);
            var mod2 = md1.Accaunts.FirstOrDefault(s => s.Mail == tbMailRegistration.Text);

            //Checking the compatibility of the written login with the one in the database
            //Needed to avoid duplicate login
            if (mod1 == null)
            {

                //Checking the compatibility of the written mail with the one in the database
                //Needed to avoid duplicate mail
                if (mod2 == null)
                {

                    //Checking for the presence of "@gmail.com" in the text
                    if (z == 1)
                    {

                        //Checking to avoid creating empty data fields in the database
                        if (tbPhoneRegistration.Text != " " && tbNameRegistration.Text != " " && tbPasswordRegistration.Text != " " && tbPasswordRepeatRegistration.Text != " " && tbSurnameRegistration.Text != " ")
                        {

                            //Checking whether a password contains six or more characters
                            if (tbPasswordRegistration.Text.Length >= 6)
                            {

                                //Checking if the entered password matches the repeated password
                                if (tbPasswordRegistration.Text == tbPasswordRepeatRegistration.Text)
                                {

                                    //Checking to avoid an empty data field in the date of birth of a new account
                                    if (cBirthDateRegistration.SelectedDate != null)
                                    {
                                        CodeIdentityWindow.Phones = tbPhoneRegistration.Text;
                                        CodeIdentityWindow.Passw = tbPasswordRegistration.Text;
                                        CodeIdentityWindow.Names = tbNameRegistration.Text;
                                        CodeIdentityWindow.SurNames = tbSurnameRegistration.Text;
                                        CodeIdentityWindow.Dataes = (DateTime)cBirthDateRegistration.SelectedDate;
                                        CodeIdentityWindow.Maile = tbMailRegistration.Text;
                                        CodeIdentityWindow.Logi = tbLoginRegistration.Text;

                                        Code = RandomString(6);
                                        CodeIdentityWindow.CodeR = Code;

                                        //Sending a code to the mail to confirm registration
                                        client.SendMailAsync("ronnieplayyt@gmail.com", tbMailRegistration.Text, "Confirmation of registration", $"Confirm your registration with the code - {Code}!");

                                        this.Close();

                                        CodeIdentityWindow ciw = new CodeIdentityWindow();
                                        ciw.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("You have not chosen your date of birth!", "Error Date of Birth", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The repeated password does not match the first sentence!", "Error repeat password", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your password has no more than 6 characters!", "Error Password", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Some row was not filled!", "Error in filling lines", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The entered mail is not correct!", "Error Mail", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The mail entered already exists!", "Error Mail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The login you entered already exists!", "Error Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEnterLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin.Visibility = Visibility.Hidden;
            WinRegistration.Visibility = Visibility.Visible;

            md1 = new VoiceSpeakerModel();
            string mailT = null;

            //Search for mail via login from the database
            using (VoiceSpeakerModel model = new VoiceSpeakerModel())
            {
                p1 = model.Accaunts.Where(c => c.Login == tbLoginLogin.Text).FirstOrDefault();

                if (p1 != null)
                {
                    model.Accaunts.Attach(p1);
                    mailT = p1.Mail;
                }
                else
                {
                    MessageBox.Show("This account does not have mail", "Error Mail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //Checking for compatibility of login and password with the same topic as in the database
            var Logi = md1.Accaunts.FirstOrDefault(t => t.Login == tbLoginLogin.Text);
            var Passw = md1.Accaunts.FirstOrDefault(t => t.Password == tbPasswordLogin.Text);

            //Checking for compatibility of login and password with the same topic as in the database
            if (Logi != null)
            {
                if (Passw != null)
                {
                    MessageBox.Show("You are logged into your account.", "Successful login", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Sending a notification to the user about the entry into a person's account for safety
                    client.SendMailAsync("ronnieplayyt@gmail.com", mailT, "Notification", "Your account has been logged in!");

                    this.Close();

                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("You entered an incorrect password", "Error Password", MessageBoxButton.OK, MessageBoxImage.Error);

                    //Sending a notification to the user about an attempt to log into a person's account for safety
                    client.SendMailAsync("ronnieplayyt@gmail.com", mailT, "Notification", "An attempt was made to enter your personal account!");
                }
            }
            else
            {
                MessageBox.Show("You entered an invalid login", "Error Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMenuLogin_Click(object sender, RoutedEventArgs e)
        {
            WinChoose.Visibility = Visibility.Hidden;
            WinLogin.Visibility = Visibility.Visible;
        }

        private void btnMenuRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinChoose.Visibility = Visibility.Hidden;
            WinRegistration.Visibility = Visibility.Visible;
        }
    }
}
