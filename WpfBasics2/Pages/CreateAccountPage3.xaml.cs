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
    /// Interaction logic for CreateAccountPage3.xaml
    /// </summary>
    public partial class CreateAccountPage3 : Page
    {
        Customer cs = new Customer();
        Collection cl = new Collection();
        private Color BorderColor = (Color)(ColorConverter.ConvertFromString("#FFECEAE2"));

        public CreateAccountPage3(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password, string cardtype, string cardno, string cardexpirationdate, string cardholdername, string ccv)
        {
            InitializeComponent();
            txtBlockTNC.Text = File.ReadAllText(cl.getFilePath("termsAndConditions"), Encoding.UTF8);

            cs.FirstName = firstname;
            cs.LastName = lastname;
            cs.Email = email;
            cs.Phone = phone;
            cs.DOB = dob;
            cs.Country = country;
            cs.TownOrCity = townorcity;  
            cs.Nationality = nationality;
            cs.Address = address;
            cs.PostalCd = postalcd;
            cs.Username = username;
            cs.Password = password;
            cs.CardType = cardtype;
            cs.CardNo = cardno;
            cs.CardExpirationDate = cardexpirationdate;
            cs.CardHolderName = cardholdername;
            cs.CCV = ccv;

        }
        
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (chkBox1.IsChecked == false)
            {
                MessageBox.Show("Please read and agree to the terms and conditions, and check the checkbox to proceed.");
            }
            else if (chkBox1.IsChecked == true)
            {
                if (rbYes.IsChecked == true)
                {
                    cs.Membership = "Premium";

                    PremiumCustomer pcs = new PremiumCustomer(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV, cs.Membership, 0.9);

                     pcs.addNewCustomer();

                }
                else if (rbNo.IsChecked == true)
                {
                    cs.Membership = "Free";

                    MessageBox.Show("Please note that your account will be automatically deleted at " + (DateTime.Now).AddDays(30), "Note", MessageBoxButton.OK, MessageBoxImage.Information);
                    FreeCustomer fcs = new FreeCustomer(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV, cs.Membership, (DateTime.Now).AddDays(30));

                    fcs.addNewCustomer();

                }

                MessageBox.Show("Welcome, " + cs.FirstName + " " + cs.LastName + "!", "Welcome"); //show msg box to welcome firstname, like: "Welcome, John!"
                var newWindow = new MainWindow(cs.Username, BorderColor); //create new window (Open all-tour page)
                newWindow.Top = Window.GetWindow(this).Top;
                newWindow.Left = Window.GetWindow(this).Left;
                newWindow.Main.Content = new BrowseToursPage(cs.Username, BorderColor);
                newWindow.Show(); //Show the new window

                var currentWindow = Application.Current.Windows[0]; //Set current window to variable
                currentWindow.Close();//Close the current window
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateAccountPage2(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV));
        }
    }
}
