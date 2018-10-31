using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using BookSharp.Classes;
namespace BookSharp
{
    /// <summary>
    /// Interaction logic for TourDetailsWindow.xaml
    /// </summary>
    public partial class TourDetailsWindow : Window
    {
    
        public TourDetailsWindow(Color color)
        {
            InitializeComponent(); 
            Border.Background = new SolidColorBrush(color);
            //var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window win in App.Current.Windows)
            {
                if (!win.IsActive)
                {
                    win.Show();
                    win.Top = this.Top;
                    win.Left = this.Left;
                }
            }
            this.Close();


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window win in App.Current.Windows)
            {
                if (!win.IsActive)
                {
                    win.Show();
                    win.Top = this.Top;
                    win.Left = this.Left;
                }
            }
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.IsActive)
                {
                    window.Hide();
                }
            }
            DragMove();
        }


        private void MinimizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Minimise.Opacity = 0.4;
        }

        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Close.Opacity = 0.8;
        }

        private void Minimise_MouseLeave(object sender, MouseEventArgs e)
        {
            Minimise.Opacity = 0.3;
        }

        private void Close_MouseLeave(object sender, MouseEventArgs e)
        {
            Close.Opacity = 0.7;
        }
    }
}
