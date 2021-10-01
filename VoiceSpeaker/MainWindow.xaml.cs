using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VoiceSpeaker
{
    public partial class MainWindow : Window
    {
        private bool isFullMaximized = false; // Is Maximized
        private bool clicado = false; // Is Clicked
        private Point lm = new Point(); // Point
        public MainWindow()
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
    }
}