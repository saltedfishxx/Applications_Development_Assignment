using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using BookSharp.Pages;
using BookSharp.Classes;

namespace BookSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string username { get; set; }
        public Color color { get; set; }
        Bookmarks bm = new Bookmarks();
        Cart ct = new Cart();

        public MainWindow(string username)
        {
            InitializeComponent();
            this.username = username;
            this.color = (Color)(ColorConverter.ConvertFromString("#FFECEAE2"));
            Border.Background = new SolidColorBrush(color);
            txtBlockUsername.Text = "Hello,  " + username;
        }

        public MainWindow(string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;
            Border.Background = new SolidColorBrush(color);
            txtBlockUsername.Text = "Hello,  " + username;
        }


        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bm.storeUserBookmarks(username);
                App.Current.Shutdown();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Log Out?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bm.storeUserBookmarks(username);
                StartupWindow sw = new StartupWindow();
                sw.Show();
                this.Close();
            }
        }

        //Menu bar buttons
        private void BrowseTourButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BrowseToursPage(username, color);
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CartPage(username, color);
        }

        private void BookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BookmarksPage(username, color);
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new FeedbackWindow(color); //create new window 
            newWindow.Top = this.Top;
            newWindow.Left = this.Left;
            newWindow.Main.Content = new FeedbackPage(username);
            newWindow.Show(); //Show the new window
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage(username, color);
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReviewPage(username, color);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow newWindow = new HelpWindow(color); //create new window 
            newWindow.Top = this.Top;
            newWindow.Left = this.Left;
            newWindow.Main.Content = new HelpPage(username, color);
            newWindow.Show(); //Show the new window
           
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            bm.storeUserBookmarks(username);
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
