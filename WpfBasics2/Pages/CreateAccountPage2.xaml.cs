using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BookSharp.Classes;

namespace BookSharp.Pages
{
    /// <summary>
    /// Interaction logic for CreateAccountPage2.xaml
    /// </summary>
    public partial class CreateAccountPage2 : Page
    {

        Customer cs = new Customer();
        AccountValidation av = new AccountValidation();

        public CreateAccountPage2(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password)
        {
            InitializeComponent();
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
        }

        public CreateAccountPage2(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password, string cardtype, string cardno, string expdate, string chname, string ccv)
        {
            InitializeComponent();
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
            cs.CardExpirationDate = expdate;
            cs.CardHolderName = chname;
            cs.CCV = ccv;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (cs.CardType != null && cs.CardNo != null && cs.CardExpirationDate != null && cs.CardHolderName != null && cs.CCV != null)
            {
                comboBoxCardType.Text = cs.CardType;
                txtBoxCardNo.Text = cs.CardNo;
                string[] Parts = cs.CardExpirationDate.Split('/');
                txtBoxExpMonth.Text = Parts[0];
                txtBoxExpYear.Text = Parts[1];
                txtBoxCardHolderName.Text = cs.CardHolderName;
                txtBoxCCV.Text = cs.CCV;
                txtBoxExpMonth.Foreground = txtBoxExpYear.Foreground = Brushes.Black;
            }
        }


        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxCardNo.Text == "" || txtBoxCCV.Text == "" || txtBoxExpMonth.Text == "mm" || txtBoxExpYear.Text == "yyyy" || txtBoxCardHolderName.Text == "")
            {
                txtBlockGeneralError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockGeneralError.Visibility = Visibility.Hidden;
                cs.CardType = av.validateCardTypeInput(SelectionValueCardType, txtBlockCardTypeError);
                cs.CardNo = av.validateCardNoInput(txtBlockCardNoError1, txtBlockCardNoError2, txtBoxCardNo);
                cs.CardExpirationDate = av.validateExpirationDateInput(txtBlockExpDateError, txtBoxExpMonth, txtBoxExpYear);
                cs.CardHolderName = av.validateCardHolderNameInput(txtBlockCardHolderNameError, txtBoxCardHolderName);
                cs.CCV = av.validateCCVInput(txtBlockCCVError, txtBoxCCV);

                if (
               cs.CardType != null &&
               cs.CardNo != null &&
               cs.CardExpirationDate != null &&
               cs.CardHolderName != null &&
               cs.CCV != null)
                {

                    //navigate to confirmation page
                    this.NavigationService.Navigate(new CreateAccountPage3(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV));
                }
            }
          
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage()); //navigates to welcome page   
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (cs.CardType != null &&
                 cs.CardNo != null &&
                 cs.CardExpirationDate != null &&
                 cs.CardHolderName != null &&
                 cs.CCV != null)
            {
                this.NavigationService.Navigate(new CreateAccountPage1(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV)); //navigate to previous page and pass info for display
            }
            else
            {
                this.NavigationService.Navigate(new CreateAccountPage1(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password));
            }

        }

        //Expiration Month TextBox GotFocus
        //Removes default string from DOB Day textbox when got focus
        private void txtBoxExpMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            if (txtBoxExpMonth.Text == "mm")
            {
                txtBoxExpMonth.Text = string.Empty;
                txtBoxExpMonth.Foreground = Brushes.Black;
            }
            else
                txtBoxExpMonth.Foreground = Brushes.Black;
        }
        //Expiration Month TextBox LostFocus
        //Adds default string to DOB Day textbox if empty when lose focus
        private void txtBoxExpMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxExpMonth.Text))
            {
                txtBoxExpMonth.Text = "mm";
                txtBoxExpMonth.Foreground = Brushes.DarkGray;
            }
        }

        //Expiration Year TextBox GotFocus
        //Removes default string from DOB Day textbox when got focus
        private void txtBoxExpYear_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            if (txtBoxExpYear.Text == "yyyy")
            {
                txtBoxExpYear.Text = string.Empty;
                txtBoxExpYear.Foreground = Brushes.Black;
            }
            else
                txtBoxExpYear.Foreground = Brushes.Black;
        }
        //Expiration Month TextBox LostFocus
        //Adds default string to DOB Day textbox if empty when lose focus
        private void txtBoxExpYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxExpYear.Text))
            {
                txtBoxExpYear.Text = "yyyy";
                txtBoxExpYear.Foreground = Brushes.DarkGray;
            }
        }
        private string SelectionValueCardType { get; set; }

        private void comboBoxCardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            SelectionValueCardType = ((ComboBoxItem)(comboBoxCardType.SelectedItem)).Content.ToString();
            txtBoxCardHolderName.Text = txtBoxCardNo.Text = txtBoxCCV.Text = "";
            txtBoxExpMonth.Text = "mm";
            txtBoxExpYear.Text = "yyyy";
            txtBoxExpYear.Foreground = txtBoxExpMonth.Foreground = Brushes.DarkGray;
        }

        private void txtBoxCardNo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxCardHolderName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxCCV_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }
    }
}

