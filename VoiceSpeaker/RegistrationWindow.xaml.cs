using DAL;
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
        public static RegistrationWindow registrationWindow;

        private bool isFullMaximized = false; // Is Maximized

        public RegistrationWindow()
        {
            InitializeComponent();

            registrationWindow = this;
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
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //Registering a new account
        private void btnEnterRegistration_Click(object sender, RoutedEventArgs e)
        {
            CodeIdentityWindow ciw = new CodeIdentityWindow();
            ciw.Show();
        }

        private void btnEnterLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Hide();
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
