using System;
using System.Collections.Generic;
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

namespace BookSharp
{
    /// <summary>
    /// Interaction logic for CartSelectionWindow.xaml
    /// </summary>
    public partial class CartSelectionWindow : Window
    {

        public CartSelectionWindow(Color color)
        {
            InitializeComponent();
            Border.Background = new SolidColorBrush(color);
        }

        
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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
