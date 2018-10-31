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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookSharp.Pages
{
    /// <summary>
    /// Interaction logic for HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        private string username;
        private Color color;

        public HelpPage(string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;

        }

        private void ContactUs_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow fb = new FeedbackWindow(color);
            fb.Top = Window.GetWindow(this).Top;
            fb.Left = Window.GetWindow(this).Left;
            fb.Main.Content = new FeedbackPage(username);
            fb.Show();
        }
    }
}
