using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;

namespace VoiceSpeaker
{
    public partial class ResetPasswordWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized
        private Account p1;
        public static string Mail { get; set; }

        public ResetPasswordWindow()
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

        //Change Password
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            //Password validation check
            if (tbNewPassword.Text == tbReEnterNewPassword.Text)
            {
                if (tbNewPassword.Text.Length == 6)
                {
                    //Connecting to the database, finding and changing the user's password
                    using (SpeakerModel model = new SpeakerModel())
                    {
                        p1 = model.Accounts.Where(c => c.Mail == Mail).FirstOrDefault();

                        if (p1 != null)
                        {
                            model.Accounts.Attach(p1);
                            p1.Password = tbNewPassword.Text;
                            model.SaveChangesAsync();

                            MessageBox.Show("Password change was successful", "Change Password", MessageBoxButton.OK, MessageBoxImage.Information);

                            this.Close();

                            RegistrationWindow rw = new RegistrationWindow();
                            rw.Show();
                        }
                        else
                        {
                            MessageBox.Show("Mail is not tied to any account", "Mail error", MessageBoxButton.OK, MessageBoxImage.Error);
                            Tools.ErrorLogSave("Mail is not tied to any account");
                        }
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Your password has no more than 6 characters!", "Change your password", MessageBoxButton.OK, MessageBoxImage.Error);
                    Tools.ErrorLogSave("Your password has no more than 6 characters!");
                }
            }
            else
            {
                MessageBox.Show("You entered the wrong password again!", "Change your password", MessageBoxButton.OK, MessageBoxImage.Error);
                Tools.ErrorLogSave("You entered the wrong password again!");
            }
        }
    }
}
