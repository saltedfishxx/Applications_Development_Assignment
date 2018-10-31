using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        AccountValidation av = new AccountValidation();
        Bookmarks bm = new Bookmarks();
        Cart ct = new Cart();
        Collection cl = new Collection();

        private Color BorderColor = (Color)(ColorConverter.ConvertFromString("#FFECEAE2"));
        public LoginPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("./Pages/WelcomePage.xaml", UriKind.Relative));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string UsernameTxt = txtBoxLoginUsername.Text.ToLower();
            string PasswordTxt = txtBoxLoginPW.Password.ToString().ToLower();
            if (UsernameTxt == "username" || PasswordTxt == "") { txtBlockError1.Visibility = Visibility.Visible; txtBlockError1.Text = "Please fill all boxes"; }
            else if (validateLoginUsername(UsernameTxt))
            {
                if (validateLoginPassword(UsernameTxt, PasswordTxt))
                {
                    txtBlockError1.Visibility = Visibility.Hidden;
                    txtBlockError2.Visibility = Visibility.Hidden;
                    string line = getLoginUsernameLine(UsernameTxt);
                    string[] elements = line.Split('*');
                    bm.populateUserBookmarks(UsernameTxt);
                    MessageBox.Show("Welcome back, " + elements[0] + "!", "Welcome"); //show msg box like "Welcome, John!"

                    
                    var newWindow = new MainWindow(UsernameTxt, BorderColor); //create new window (Open all-tour page)
                    newWindow.Top = Window.GetWindow(this).Top;
                    newWindow.Left = Window.GetWindow(this).Left;
                    newWindow.Main.Content = new BrowseToursPage(elements[10], BorderColor);
                    newWindow.Show(); //Show the new window
                    Window.GetWindow(this).Close();

                }
                else
                {
                    txtBlockError2.Visibility = Visibility.Visible;
                    txtBlockError1.Visibility = Visibility.Hidden;
                    txtBoxLoginPW.Password = string.Empty;
                    PW.Visibility = Visibility.Visible;
                    txtBoxLoginPW.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFD1CDBC")));
                }
            }
            else
            {
                txtBlockError1.Visibility = Visibility.Visible;
                txtBlockError1.Text = "Username does not exist";
                txtBlockError2.Visibility = Visibility.Hidden;
                txtBoxLoginPW.Password = string.Empty;
                PW.Visibility = Visibility.Visible;
                txtBoxLoginPW.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFD1CDBC")));
            }

        }

        private void txtBoxLoginUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockError1.Visibility = Visibility.Hidden;
            txtBlockError2.Visibility = Visibility.Hidden;
            if (txtBoxLoginUsername.Text == "Username")
            {
                txtBoxLoginUsername.Foreground = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FF2e2e2e")));
                txtBoxLoginUsername.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FF2e2e2e")));
                txtBoxLoginUsername.FontStyle = FontStyles.Normal;
                txtBoxLoginUsername.Text = "";
            }
        }

        private void txtBoxLoginUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxLoginUsername.Text == "")
            {
                txtBoxLoginUsername.Foreground = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFD1CDBC")));
                txtBoxLoginUsername.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFD1CDBC")));
                txtBoxLoginUsername.FontStyle = FontStyles.Italic;
                txtBoxLoginUsername.Text = "Username";
            }
        }

        private void txtBoxLoginPW_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockError1.Visibility = Visibility.Hidden;
            txtBlockError2.Visibility = Visibility.Hidden;
            PW.Visibility = Visibility.Hidden;
            txtBoxLoginPW.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FF2e2e2e")));
        }

        private void txtBoxLoginPW_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxLoginPW.Password == "")
            {
                PW.Visibility = Visibility.Visible;
                txtBoxLoginPW.BorderBrush = new SolidColorBrush((Color)(ColorConverter.ConvertFromString("#FFD1CDBC")));
            }
        }
        private Boolean validateLoginUsername(string LoginUsername) //Validates Login Username
        {

            Boolean usernameExists = false;
            List<string> customerlines = cl.getTextFileList("customerInfo");
            int count = 0, lineNo = -1;
            foreach (var customerline in customerlines)
            {
                String[] elements = customerline.Split('*');
                if (elements[10] == LoginUsername)
                {
                    lineNo = count;
                }
                count++;
            }
            if (lineNo != -1)
            {
                usernameExists = true;
            }

            return usernameExists;
        }


        private Boolean validateLoginPassword(string LoginUsername, string LoginPassword) //Validates Login Password
        {
            Boolean passwordIsValid = false;
            string line = getLoginUsernameLine(LoginUsername);
            String[] elements = line.Split('*');
            if (elements[11] == LoginPassword)
            {
                passwordIsValid = true;
            }

            return passwordIsValid;
        }

        private string getLoginUsernameLine(string LoginUsername) // get line from customerInfo text file containing the valid username inputted
        {
            List<string> customerlines = cl.getTextFileList("customerInfo");
            int count = 0, lineNo = -1;
            foreach (var customerline in customerlines)
            {
                String[] elements = customerline.Split('*');
                if (elements[10] == LoginUsername)
                {
                    lineNo = count;
                }
                count++;
            }
            string line = cl.getTextFileLine("customerInfo", lineNo);
            return line;
        }

    }
}
