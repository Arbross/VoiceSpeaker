using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VoiceSpeaker
{
    public partial class SendEmailWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized
        private SpeakerModel model;

        //Generates random symbols to generate a confirmation code
        public string Code = null;
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public SendEmailWindow()
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

        // Move
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //The first step is to change your password
        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {

            model = new SpeakerModel();

            //Checking for entered mail in databases
            var mailFOD = model.Accounts.FirstOrDefault(t => t.Mail == tbEmail.Text);
            if (mailFOD != null)
            {
                Code = RandomString(6);

                //Creates SMTP for sending mail
                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("ronnieplayyt@gmail.com", "romap310103")
                };

                //Sending emails via SMTP along with streams
                client.SendMailAsync("ronnieplayyt@gmail.com", tbEmail.Text, "Password renewal", $"Enter the code - {Code} - in the password recovery field");
                MessageBox.Show("A confirmation email has been sent to your email!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                ResetPasswordWindow.Mail = tbEmail.Text;
                CodeIdentityWindow.CodeCP = Code;

                CodeIdentityWindow ciw = new CodeIdentityWindow();
                ciw.Show();

                Close();
            }
        }
    }
}
