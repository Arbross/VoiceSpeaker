using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VoiceSpeaker
{
    public partial class CodeIdentityWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized

        public static string Logi { get; set; }
        public static string Maile { get; set; }
        public static string Passw { get; set; }
        public static string Phones { get; set; }
        public static string Names { get; set; }
        public static string SurNames { get; set; }
        public static DateTime Dataes { get; set; }

        public static string CodeCP { get; set; }
        public static string CodeR { get; set; }

        VoiceSpeakerModel model;

        public CodeIdentityWindow()
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

        private void btnCodeConfirm_Click(object sender, RoutedEventArgs e)
        {

            if (tbCodeIdentity.Text == CodeCP)
            {
                //Code confirmation to change user password

                MessageBox.Show("The code is correct and you can change your password.", "Successful code", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();

                //Opens a new form to change password
                ResetPasswordWindow rpw = new ResetPasswordWindow();
                rpw.Show();
            }
            else if (tbCodeIdentity.Text == CodeR)
            {
                //Code confirmation of registration

                model = new VoiceSpeakerModel();
                //Writing all data to database
                model.Accaunts.Add(new Accaunt() { Login = Logi, Mail = Maile, Password = Passw, Phone = Phones, Name = Names, Surname = SurNames, PublishDate = Dataes });
                model.SaveChangesAsync();

                MessageBox.Show("The code is correct and your account has been created.", "Successful code", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();

                RegistrationWindow rw = new RegistrationWindow();
                rw.Show();
            }
            else
            {
                MessageBox.Show("The code is not correct", "Incorrect code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
