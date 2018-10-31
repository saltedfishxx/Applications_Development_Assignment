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
using BookSharp.Classes;
namespace BookSharp.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        Bookmarks bm = new Bookmarks();
        Cart ct = new Cart();
        public WelcomePage()
        {
            InitializeComponent();
        }
      
        private void BtnClickLogin(object sender, RoutedEventArgs e)
        {
            bm.deleteAllBookmarks();
            ct.deleteAllCartItems();
            this.NavigationService.Navigate(new Uri("./Pages/LoginPage.xaml", UriKind.Relative));
        }

        private void BtnClickCreate(object sender, RoutedEventArgs e)
        {
            bm.deleteAllBookmarks();
            ct.deleteAllCartItems();
            this.NavigationService.Navigate(new CreateAccountPage1());

        }

        private void LoginButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Border2.Background = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FF94C771")));
            login1.Visibility = Visibility.Hidden;
            login2.Visibility = Visibility.Visible;
        }

        private void LoginButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Border2.Background = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFE0FFCB")));
            login2.Visibility = Visibility.Hidden;
            login1.Visibility = Visibility.Visible;
        }

        private void CreateButton_MouseLeave(object sender, MouseEventArgs e)
        {
            //Border1.Background = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFECEAE2"))); ;
            Border1.Background = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFE0FFCB")));
            create2.Visibility = Visibility.Hidden;
            create1.Visibility = Visibility.Visible;
        }

        private void CreateButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Border1.Background = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FF94C771")));
            create1.Visibility = Visibility.Hidden;
            create2.Visibility = Visibility.Visible;
        }
    }
}
