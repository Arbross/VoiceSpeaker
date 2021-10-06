using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VoiceSpeaker
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized
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

        // Move
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnEnterRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinRegistration.Visibility = Visibility.Hidden;
            WinLogin.Visibility = Visibility.Visible;
        }

        private void btnEnterLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin.Visibility = Visibility.Hidden;
            WinRegistration.Visibility = Visibility.Visible;
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
