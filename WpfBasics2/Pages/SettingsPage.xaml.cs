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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {

        private string username;
        private Color windowColor;
        private string themeColorText;
        private string email;
        //Properties for storing selected values for comboboxes
        private string selectionValueCountry;
        private string selectionValueNationality;
        private string selectionValueCardType;


        Collection cl = new Collection();
        AccountValidation av = new AccountValidation();

        public SettingsPage(string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            windowColor = color;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Display current user's info in controls for user to edit
            Customer cs = new Customer(username);
            cs.populateCustomerDetails();

            if (cs.Membership == "Premium")
            {
                cbMembership.IsChecked = true;
                PremiumErrorTxtBlock.Visibility = MembershipErrorTxtBlock.Visibility = Visibility.Hidden;
                cbBoxTheme.IsHitTestVisible = true;
            }
            else if (cs.Membership == "Free")
            {
                cbMembership.IsChecked = false;
                PremiumErrorTxtBlock.Visibility = MembershipErrorTxtBlock.Visibility = Visibility.Visible;
                cbBoxTheme.IsHitTestVisible = false;
            }

            txtBoxFName.Text = cs.FirstName;
            txtBoxLName.Text = cs.LastName;
            txtBoxPhone.Text = cs.Phone;
            string[] DOBParts = cs.DOB.Split('/');
            txtBoxDOBDay.Text = DOBParts[0];
            txtBoxDOBMonth.Text = DOBParts[1];
            txtBoxDOBYear.Text = DOBParts[2];
            txtBoxCity.Text = cs.TownOrCity;
            comboBoxCountry.SelectedValue = cs.Country;
            comboBoxNationality.SelectedValue = cs.Nationality;
            txtBoxAddress.Text = cs.Address;
            txtBoxPostalCd.Text = cs.PostalCd;
            txtBoxPW.Password = txtBoxConfirmPW.Password = cs.Password;
            comboBoxCardType.Text = cs.CardType;
            txtBoxCardNo.Text = cs.CardNo;
            string[] Parts = cs.CardExpirationDate.Split('/');
            txtBoxExpMonth.Text = Parts[0];
            txtBoxExpYear.Text = Parts[1];
            txtBoxCardHolderName.Text = cs.CardHolderName;
            txtBoxCCV.Text = cs.CCV;
            txtBoxEmail.Text = cs.Email;
            email = cs.Email;
            txtBoxExpMonth.Foreground = txtBoxExpYear.Foreground = txtBoxPhone.Foreground = txtBoxDOBDay.Foreground = txtBoxDOBMonth.Foreground = txtBoxDOBYear.Foreground = Brushes.Black;
        }



        //Change Themes
        public void changeTheme(Color color, string colorName)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (!window.IsActive)
                {
                    window.Close();
                }
            }
            MainWindow mw = new MainWindow(username, color);
            mw.Top = Window.GetWindow(this).Top;
            mw.Left = Window.GetWindow(this).Left;
            SettingsPage sp = new SettingsPage(username, color);
            sp.cbBoxTheme.Text = colorName;
            mw.Main.Content = sp;
            mw.Show();
            Window.GetWindow(this).Close();
        }


        //gets selection from theme combobox
        private void cbBoxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBoxTheme.SelectedIndex == 0 && cbBoxTheme.Text != "Pure")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FFEBEECE"));
                changeTheme(themeColor, "Pure");

            }
            if (cbBoxTheme.SelectedIndex == 1 && cbBoxTheme.Text != "Light")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FFECEAE2"));
                changeTheme(themeColor, "Light");

            }
            if (cbBoxTheme.SelectedIndex == 2 && cbBoxTheme.Text != "Dark")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FF9E9C87"));
                changeTheme(themeColor, "Dark");
            }
            if (cbBoxTheme.SelectedIndex == 3 && cbBoxTheme.Text != "Even More Green")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FFBEF598"));
                changeTheme(themeColor, "Even More Green");
            }
            if (cbBoxTheme.SelectedIndex == 4 && cbBoxTheme.Text != "Pale Goldenrod")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FFF3E4B0"));
                changeTheme(themeColor, "Pale Goldenrod");
            }
            if (cbBoxTheme.SelectedIndex == 5 && cbBoxTheme.Text != "Light Salmon")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FFF1D6C6"));
                changeTheme(themeColor, "Light Salmon");
            }
            if (cbBoxTheme.SelectedIndex == 6 && cbBoxTheme.Text != "Salty Sea Green")
            {
                Color themeColor = (Color)(ColorConverter.ConvertFromString("#FF94D6A3"));
                changeTheme(themeColor, "Salty Sea Green");
            }
        }



        //Next Button 
        //for Input validation and saving new user info
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            FreeCustomer cs = new FreeCustomer();
            PremiumCustomer pcs = new PremiumCustomer();
            pcs.FirstName = cs.FirstName = av.validateFirstNameInput(txtBlockFNameError, txtBoxFName);
            pcs.LastName = cs.LastName = av.validateLastNameInput(txtBlockLNameError, txtBoxLName);
            pcs.Phone = cs.Phone = av.validatePhoneNoInput(txtBlockPhoneError, txtBoxPhone);
            pcs.DOB = cs.DOB = av.validateDOBInput(txtBlockDOBError, txtBoxDOBDay, txtBoxDOBMonth, txtBoxDOBYear);
            pcs.Country = cs.Country = av.validateCountryInput(selectionValueCountry, txtBlockCountryError);
            pcs.TownOrCity = cs.TownOrCity = av.validateTownOrCityInput(txtBlockCityError, txtBoxCity);
            pcs.Nationality = cs.Nationality = av.validateNationalityInput(selectionValueNationality, txtBlockNationalityError);
            pcs.Address = cs.Address = av.validateAddressInput(txtBlockAddressError, txtBoxAddress);
            pcs.PostalCd = cs.PostalCd = av.validatePostalCdInput(txtBlockPostalCdError1, txtBlockPostalCdError2, txtBoxPostalCd);
            pcs.Password = cs.Password = av.validatePasswordInput(txtBlockPWError1, txtBlockPWError2, txtBlockPWError3, txtBlockConfirmPWError, txtBoxPW, txtBoxConfirmPW);
            pcs.CardType = cs.CardType = av.validateCardTypeInput(selectionValueCardType, txtBlockCardTypeError);
            pcs.CardNo = cs.CardNo = av.validateCardNoInput(txtBlockCardNoError1, txtBlockCardNoError2, txtBoxCardNo);
            pcs.CardExpirationDate = cs.CardExpirationDate = av.validateExpirationDateInput(txtBlockExpDateError, txtBoxExpMonth, txtBoxExpYear);
            pcs.CardHolderName = cs.CardHolderName = av.validateCardHolderNameInput(txtBlockCardHolderNameError, txtBoxCardHolderName);
            pcs.CCV = cs.CCV = av.validateCCVInput(txtBlockCCVError, txtBoxCCV);
            pcs.Email = cs.Email = validateEmailInput();

            if (cbMembership.IsChecked == true)
            {
                pcs.Membership = "Premium";
                cs.Membership = "";
            }
            else
            {
                pcs.Membership = "";
                cs.Membership = "Free";
            }

            if (cs.FirstName != null && cs.LastName != null && cs.Email != "" && cs.Phone != null && cs.DOB != null && cs.Country != null && cs.TownOrCity != null && cs.Nationality != null && cs.Address != null && cs.PostalCd != null && cs.Password != null && cs.CardType != null && cs.CardNo != null && cs.CardExpirationDate != null && cs.CardHolderName != null && cs.CCV != null)
            {
                pcs.Username = cs.Username = username;
                if (pcs.Membership == "Premium")
                {
                    pcs.Subsidy = 0.9;
                    if (cs.getCustomerDetail(username, 17) == "Free")
                    {
                        MessageBox.Show("You have signed up for premium membership! $20 has been charged to your card.");
                    }
                    pcs.editCustomer();
                }
                else if (cs.Membership == "Free")
                {
                    cs.editCustomer();
                }


                this.NavigationService.Navigate(new SettingsPage(username, windowColor));
            }
        }


        //Cancel Button
        private void CancelButton_Click(object sender, RoutedEventArgs e) //Refreshes page
        {
            this.NavigationService.Navigate(new SettingsPage(username, windowColor));
        }


        private void comboBoxCardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionValueCardType = ((ComboBoxItem)(comboBoxCardType.SelectedItem)).Content.ToString();
            txtBoxCardHolderName.Text = txtBoxCardNo.Text = txtBoxCCV.Text = txtBoxExpMonth.Text = txtBoxExpYear.Text = "";
        }
        //Country ComboBox Selection Changed //Sets country combobox selected value to property when selection is changed
        private void comboBoxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionValueCountry = comboBoxCountry.SelectedValue.ToString();
        }



        //Nationality ComboBox Selection Changed //Sets nationality combobox selected value to property when selection is changed
        private void comboBoxNationality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionValueNationality = comboBoxNationality.SelectedValue.ToString();
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



        //DOB Day TextBox GotFocus
        //Removes default string from DOB Day textbox when got focus
        private void txtBoxDOBDay_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxDOBDay.Text == "dd")
            {
                txtBoxDOBDay.Text = string.Empty;
                txtBoxDOBDay.Foreground = Brushes.Black;
            }
            else
                txtBoxDOBDay.Foreground = Brushes.Black;
        }
        //DOB Day TextBox LostFocus
        //Adds default string to DOB Day textbox if empty when lose focus
        private void txtBoxDOBDay_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDOBDay.Text))
            {
                txtBoxDOBDay.Text = "dd";
                txtBoxDOBDay.Foreground = Brushes.DarkGray;
            }
        }



        //DOB Month TextBox GotFocus
        //Removes default string from DOB Month textbox when got focus
        private void txtBoxDOBMonth_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxDOBMonth.Text == "mm")
            {
                txtBoxDOBMonth.Text = string.Empty;
                txtBoxDOBMonth.Foreground = Brushes.Black;

            }
            else
                txtBoxDOBMonth.Foreground = Brushes.Black;
        }
        //DOB Month TextBox LostFocus
        //Adds default string to DOB Month textbox if empty when lose focus
        private void txtBoxDOBMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxDOBMonth.Text))
            {
                txtBoxDOBMonth.Text = "mm";
                txtBoxDOBMonth.Foreground = Brushes.DarkGray;

            }
        }



        //DOB Year TextBox GotFocus
        //Removes default string from DOB year textbox when got focus
        private void txtBoxDOBYear_GotFocus(object sender, RoutedEventArgs e)
        {
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

        //Expiration Month TextBox GotFocus
        //Removes default string from DOB Day textbox when got focus
        private void txtBoxExpMonth_GotFocus(object sender, RoutedEventArgs e)
        {
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
            if (string.IsNullOrWhiteSpace(txtBoxExpMonth.Text))
            {
                txtBoxExpYear.Text = "dd";
                txtBoxExpYear.Foreground = Brushes.DarkGray;
            }
        }
        //Email TextBox GotFocus
        //Removes default string from email textbox when got focus
        private void txtBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
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
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Customer cs = new Customer(username);
            cs.populateCustomerDetails();

            txtBoxFName.Background =
            txtBoxLName.Background =
            txtBoxPhone.Background =
           txtBoxDOBDay.Background =
         txtBoxDOBMonth.Background =
          txtBoxDOBYear.Background =
        comboBoxCountry.Background =
        comboBoxNationality.Background =
        comboBoxCardType.Background =
             txtBoxCity.Background =
          txtBoxAddress.Background =
         txtBoxPostalCd.Background =
               txtBoxPW.Background =
        txtBoxConfirmPW.Background =
           txtBoxCardNo.Background =
         txtBoxExpMonth.Background =
          txtBoxExpYear.Background =
        txtBoxCardHolderName.Background =
        txtBoxEmail.Background =
              txtBoxCCV.Background = new SolidColorBrush(Colors.White);

            if (cs.Membership == "Free")
            {
                cbMembership.IsHitTestVisible = true;
            }

            txtBoxFName.Focusable =
            txtBoxLName.Focusable =
            txtBoxPhone.Focusable =
           txtBoxDOBDay.Focusable =
         txtBoxDOBMonth.Focusable =
          txtBoxDOBYear.Focusable =
        comboBoxCountry.Focusable =
        comboBoxNationality.Focusable =
        comboBoxCardType.Focusable =
             txtBoxCity.Focusable =
          txtBoxAddress.Focusable =
         txtBoxPostalCd.Focusable =
               txtBoxPW.Focusable =
        txtBoxConfirmPW.Focusable =
           txtBoxCardNo.Focusable =
         txtBoxExpMonth.Focusable =
          txtBoxExpYear.Focusable =
        txtBoxCardHolderName.Focusable =
        txtBoxEmail.Focusable =
              txtBoxCCV.Focusable = true;

            txtBoxFName.Cursor =
            txtBoxLName.Cursor =
            txtBoxPhone.Cursor =
           txtBoxDOBDay.Cursor =
         txtBoxDOBMonth.Cursor =
          txtBoxDOBYear.Cursor =
             txtBoxCity.Cursor =
          txtBoxAddress.Cursor =
         txtBoxPostalCd.Cursor =
               txtBoxPW.Cursor =
        txtBoxConfirmPW.Cursor =
           txtBoxCardNo.Cursor =
         txtBoxExpMonth.Cursor =
          txtBoxExpYear.Cursor =
        txtBoxCardHolderName.Cursor =
         txtBoxEmail.Cursor =
              txtBoxCCV.Cursor = Cursors.IBeam;

            comboBoxCountry.Cursor =
        comboBoxNationality.Cursor =
           comboBoxCardType.Cursor = Cursors.Hand;

            comboBoxCountry.IsHitTestVisible =
                    comboBoxNationality.IsHitTestVisible =
                       comboBoxCardType.IsHitTestVisible = true;

            CancelButton.Visibility = ConfirmButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Hidden;
        }

        private string validateEmailInput()
        {
            string Email = "";
            string EmailTxt = txtBoxEmail.Text.Trim().ToLower();
            if (EmailTxt != email)
            {
                if (EmailTxt.Contains("*") || !(EmailTxt.Contains("@")) || !(EmailTxt.Contains(".com")) || EmailTxt.Contains(" ") || string.IsNullOrEmpty(EmailTxt))
                {
                    
                    txtBlockEmailError1.Visibility = Visibility.Visible;
                    txtBlockEmailError2.Visibility = Visibility.Hidden;

                    txtBlockEmailMsg.Visibility = Visibility.Hidden;
                    txtBoxEmail.Text = "e.g. xxxxxx@gmail.com";
                    txtBoxEmail.Foreground = Brushes.DarkGray;
                    Email = "";
                }
                else
                {
                    txtBlockEmailError1.Visibility = Visibility.Hidden;
                    txtBlockEmailError2.Visibility = Visibility.Hidden;
                    txtBlockEmailMsg.Visibility = Visibility.Visible;
                    Email = EmailTxt;
                }

                Collection cl = new Collection();
                List<string> customerlines = cl.getTextFileList("customerInfo");
                foreach (var customerline in customerlines)
                {
                    string[] elements = customerline.Split('*');

                    //Email Validation
                    if (elements[2] == EmailTxt)
                    {
                        txtBlockEmailError1.Visibility = Visibility.Hidden;
                        txtBlockEmailError2.Visibility = Visibility.Visible;
                     
                        txtBlockEmailMsg.Visibility = Visibility.Hidden;
                        txtBoxEmail.Text = "e.g. xxxxxx@gmail.com";
                        txtBoxEmail.Foreground = Brushes.DarkGray;
                        Email = "";
                    }
                    
                }
            }
            else if (EmailTxt == email)
            {
                Email = EmailTxt;
            }

            return Email;
        }
    }



}




