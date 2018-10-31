using System;
using System.Collections.Generic;
using System.Globalization;
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
using BookSharp.Classes;

namespace BookSharp.Pages
{
    /// <summary>
    /// Interaction logic for CreateAccountPage1.xaml
    /// </summary>
    public partial class CreateAccountPage1 : Page
    {

        Customer cs = new Customer();
        AccountValidation av = new AccountValidation();

        //Properties for storing selected values for comboboxes
        private string SelectionValueCountry { get; set; }
        private string SelectionValueNationality { get; set; }


        public CreateAccountPage1() 
        {
            InitializeComponent();

        }

        // gets customer info keyed in by customer before in createaccountpage1 when user presses back button in createaccountpage2 
        public CreateAccountPage1(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password)
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

        // gets customer info keyed in by customer before in createaccountpage1 when user presses back button in createaccountpage2 , also info from createaccountpage2 to display in the next page 
        public CreateAccountPage1(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password, string cardtype, string cardno, string expdate, string chname, string ccv)
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
            if (cs.FirstName != null && cs.LastName != null && cs.Email != null && cs.Phone != null && cs.DOB != null && cs.Country != null && cs.TownOrCity != null && cs.Nationality != null && cs.Address != null && cs.PostalCd != null && cs.Username != null && cs.Password != null)
            {
                txtBoxFName.Text = cs.FirstName;
                txtBoxLName.Text = cs.LastName;
                txtBoxEmail.Text = cs.Email;
                txtBoxPhone.Text = cs.Phone;

                string[] DOBParts = cs.DOB.Split('/');
                txtBoxDOBDay.Text = DOBParts[0];
                txtBoxDOBMonth.Text = DOBParts[1];
                txtBoxDOBYear.Text = DOBParts[2];

                comboBoxCountry.SelectedValue = cs.Country;
                txtBoxCity.Text = cs.TownOrCity;
                comboBoxNationality.SelectedValue = cs.Nationality;
                txtBoxAddress.Text = cs.Address;
                txtBoxPostalCd.Text = cs.PostalCd;
                txtBoxUserName.Text = cs.Username;
                txtBoxPW.Password = txtBoxConfirmPW.Password = cs.Password;
                txtBoxEmail.Foreground = txtBoxPhone.Foreground = txtBoxDOBDay.Foreground = txtBoxDOBMonth.Foreground = txtBoxDOBYear.Foreground = Brushes.Black;
            }
        }

        //Next Button 
        //for Input validation and moving to next page (Payment info page)
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxFName.Text == "" || txtBoxLName.Text == "" || txtBoxEmail.Text == "e.g. xxxxxx@gmail.com" || txtBoxPhone.Text == "e.g. 91234567" || txtBoxDOBDay.Text == "dd" || txtBoxDOBMonth.Text == "mm" || txtBoxDOBYear.Text == "yyyy" || txtBoxCity.Text == "" || txtBoxAddress.Text == "" || txtBoxPostalCd.Text == "" || txtBoxUserName.Text == "" || txtBoxPW.Password == "" || txtBoxConfirmPW.Password == "")
            {
                txtBlockGeneralError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockGeneralError.Visibility = Visibility.Hidden;
                cs.FirstName = av.validateFirstNameInput(txtBlockFNameError, txtBoxFName);
                cs.LastName = av.validateLastNameInput(txtBlockLNameError, txtBoxLName);
                cs.Email = av.validateEmailInput(txtBlockEmailError1, txtBlockEmailError2, txtBlockEmailMsg, txtBoxEmail);
                cs.Phone = av.validatePhoneNoInput(txtBlockPhoneError, txtBoxPhone);
                cs.DOB = av.validateDOBInput(txtBlockDOBError, txtBoxDOBDay, txtBoxDOBMonth, txtBoxDOBYear);
                cs.Country = av.validateCountryInput(SelectionValueCountry, txtBlockCountryError);
                cs.TownOrCity = av.validateTownOrCityInput(txtBlockCityError, txtBoxCity);
                cs.Nationality = av.validateNationalityInput(SelectionValueNationality, txtBlockNationalityError);
                cs.Address = av.validateAddressInput(txtBlockAddressError, txtBoxAddress);
                cs.PostalCd = av.validatePostalCdInput(txtBlockPostalCdError1, txtBlockPostalCdError2, txtBoxPostalCd);
                cs.Username = av.validateUsernameInput(txtBlockUsernameError1, txtBlockUsernameError2, txtBlockUsernameError3, txtBlockUsernameMsg, txtBoxUserName);
                cs.Password = av.validatePasswordInput(txtBlockPWError1, txtBlockPWError2, txtBlockPWError3, txtBlockConfirmPWError, txtBoxPW, txtBoxConfirmPW);



                // Next Page Final Validation   //validation methods will set the properties to not-null values if input is valid
                if (cs.FirstName != null && cs.LastName != null && cs.Email != null && cs.Phone != null && cs.DOB != null && cs.Country != null && cs.TownOrCity != null && cs.Nationality != null && cs.Address != null && cs.PostalCd != null && cs.Username != null && cs.Password != null)
                {
                    if (cs.CardType != null && cs.CardNo != null && cs.CardExpirationDate != null && cs.CardHolderName != null && cs.CCV != null)
                    {
                        //navigate to confirmation page
                        this.NavigationService.Navigate(new CreateAccountPage2(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password, cs.CardType, cs.CardNo, cs.CardExpirationDate, cs.CardHolderName, cs.CCV));
                    }
                    else
                    {
                        //navigate to next page (payment info) and pass linepart string containing customer info from the first account creation page
                        this.NavigationService.Navigate(new CreateAccountPage2(cs.FirstName, cs.LastName, cs.Email, cs.Phone, cs.DOB, cs.Country, cs.TownOrCity, cs.Nationality, cs.Address, cs.PostalCd, cs.Username, cs.Password));
                    }
                }
                else //PW resets everytime
                {
                    txtBoxPW.Password = string.Empty;
                    txtBoxConfirmPW.Password = string.Empty;
                }
            }
         
        }



        //Cancel Button
        //Moves to welcome page and cancels account creation
        private void CancelButton_Click(object sender, RoutedEventArgs e) //navigate to welcome page and set all properties to null
        {
            this.NavigationService.Navigate(new Uri("./Pages/WelcomePage.xaml", UriKind.Relative));
        }



        //Populates Country combobox with countries when combobox loaded
        private void comboBoxCountry_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> countries = av.getCountryNames();
            foreach (string item in countries)
            {
                comboBoxCountry.Items.Add(item);
            }
        }


        //Populates Nationality combobox with countries on load
        private void comboBoxNationality_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> countries = av.getCountryNames();
            foreach (string item in countries)
            {
                comboBoxNationality.Items.Add(item);
            }
        }



        //Country ComboBox Selection Changed //Sets country combobox selected value to property when selection is changed
        private void comboBoxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            SelectionValueCountry = comboBoxCountry.SelectedValue.ToString();
        }



        //Nationality ComboBox Selection Changed //Sets nationality combobox selected value to property when selection is changed
        private void comboBoxNationality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            SelectionValueNationality = comboBoxNationality.SelectedValue.ToString();
        }



        //DOB Day TextBox GotFocus //Removes default string from DOB Day textbox when got focus
        private void txtBoxDOBDay_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            if (txtBoxDOBDay.Text == "dd")
            {
                txtBoxDOBDay.Text = string.Empty;
                txtBoxDOBDay.Foreground = Brushes.Black;
            }
            else
                txtBoxDOBDay.Foreground = Brushes.Black;
        }

        //DOB Day TextBox LostFocus  //Adds default string to DOB Day textbox if empty when lose focus
        private void txtBoxDOBDay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDOBDay.Text))
            {
                txtBoxDOBDay.Text = "dd";
                txtBoxDOBDay.Foreground = Brushes.DarkGray;
            }
        }



        //DOB Month TextBox GotFocus  //Removes default string from DOB Month textbox when got focus
        private void txtBoxDOBMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            if (txtBoxDOBMonth.Text == "mm")
            {
                txtBoxDOBMonth.Text = string.Empty;
                txtBoxDOBMonth.Foreground = Brushes.Black;

            }
            else
                txtBoxDOBMonth.Foreground = Brushes.Black;
        }

        //DOB Month TextBox LostFocus //Adds default string to DOB Month textbox if empty when lose focus
        private void txtBoxDOBMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDOBMonth.Text))
            {
                txtBoxDOBMonth.Text = "mm";
                txtBoxDOBMonth.Foreground = Brushes.DarkGray;
            }
        }


        //DOB Year TextBox GotFocus //Removes default string from DOB year textbox when got focus
        private void txtBoxDOBYear_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            if (txtBoxDOBYear.Text == "yyyy")
            {
                txtBoxDOBYear.Text = string.Empty;
                txtBoxDOBYear.Foreground = Brushes.Black;
            }
            else
                txtBoxDOBYear.Foreground = Brushes.Black;
        }

        //DOB Year TextBox LostFocus
        //Adds default string to DOB year textbox if empty when lose focus
        private void txtBoxDOBYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDOBYear.Text))
            {
                txtBoxDOBYear.Text = "yyyy";
                txtBoxDOBYear.Foreground = Brushes.DarkGray;
            }
        }



        //Phone TextBox GotFocus
        //Removes default string from phone textbox when got focus
        private void txtBoxPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            txtBoxPhone.Foreground = Brushes.Black;
            if (txtBoxPhone.Text == "e.g. 91234567")
            {
                txtBoxPhone.Text = string.Empty;
            }
        }

        //Phone TextBox LostFocus
        //Adds default string to phone textbox if empty when lose focus
        private void txtBoxPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxPhone.Text))
            {
                txtBoxPhone.Text = "e.g. 91234567";
                txtBoxPhone.Foreground = Brushes.DarkGray;
            }
        }



        //Email TextBox GotFocus
        //Removes default string from email textbox when got focus
        private void txtBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
            txtBoxEmail.Foreground = Brushes.Black;
            if (txtBoxEmail.Text == "e.g. xxxxxx@gmail.com")
            {
                txtBoxEmail.Text = string.Empty;
            }
        }

        //Email TextBox LostFocus
        //Adds default string to email textbox if empty when lose focus
        private void txtBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxEmail.Text))
            {
                txtBoxEmail.Text = "e.g. xxxxxx@gmail.com";
                txtBoxEmail.Foreground = Brushes.DarkGray;
            }
        }

        private void txtBoxFName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxLName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxCity_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxPostalCd_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxPW_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }

        private void txtBoxConfirmPW_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBlockGeneralError.Visibility = Visibility.Hidden;
        }
    }
}