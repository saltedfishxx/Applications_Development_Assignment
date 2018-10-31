using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BookSharp.Classes;
using BookSharp.Pages;

namespace BookSharp.Classes
{
    public class AccountValidation
    {

       
        Collection cl = new Collection();

        public IEnumerable<string> getCountryNames() //for populating nationality and country comboboxes with countries for users to choose upon account creation and the editing of their account
        {
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            List<string> countryNames = new List<string>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(country.DisplayName.ToString());
            }
            IEnumerable<string> namesAdded = countryNames.OrderBy(names => names).Distinct();
            return namesAdded;
        }

        
       

        
        public string validateFirstNameInput(TextBlock txtBlockFNameError, TextBox txtBoxFName) //First Name Validation Method
        {
            string FNameTxt = txtBoxFName.Text.Trim();
            string FirstName = null;
            if (FNameTxt.Contains("*") || string.IsNullOrWhiteSpace(FNameTxt))
            {
                txtBlockFNameError.Visibility = Visibility.Visible;
            }
            else
            {
                //Changes First Name to have first character capitalised and rest of the characters lowercase
                txtBlockFNameError.Visibility = Visibility.Hidden;
                FirstName = char.ToUpper(FNameTxt[0]) + FNameTxt.Substring(1).ToLower();
            }

            return FirstName;
        }


        
        public string validateLastNameInput(TextBlock txtBlockLNameError, TextBox txtBoxLName) //Last Name Validation Method
        {
            string LNameTxt = txtBoxLName.Text.Trim();
            string LastName = null;
            if (LNameTxt.Contains("*") || string.IsNullOrEmpty(LNameTxt))
            {
                txtBlockLNameError.Visibility = Visibility.Visible;
            }
            else
            {
                //Changes Last Name to have first character capitalised and rest of the characters lowercase
                txtBlockLNameError.Visibility = Visibility.Hidden;
                LastName = char.ToUpper(LNameTxt[0]) + LNameTxt.Substring(1).ToLower();
            }

            return LastName;
        }


        //Email Validation Method //Search current customer database for emails taken and shows error for different kinds of non-accepted values
        public string validateEmailInput(TextBlock txtBlockEmailError1, TextBlock txtBlockEmailError2, TextBlock txtBlockEmailMsg, TextBox txtBoxEmail)
        {
            string Email = null;
            Collection cl = new Collection();
            string EmailTxt = txtBoxEmail.Text.Trim().ToLower();
            if (EmailTxt.Contains("*") || !(EmailTxt.Contains("@")) || !(EmailTxt.Contains(".com")) || EmailTxt.Contains(" ") || string.IsNullOrEmpty(EmailTxt))
            {
                txtBlockEmailError1.Visibility = Visibility.Visible;
                txtBlockEmailError2.Visibility = Visibility.Hidden;
                txtBlockEmailMsg.Visibility = Visibility.Hidden;
                txtBoxEmail.Text = "e.g. xxxxxx@gmail.com";
                txtBoxEmail.Foreground = Brushes.DarkGray;
                Email = null;
            }
            else
            {
                txtBlockEmailError1.Visibility = Visibility.Hidden;
                txtBlockEmailError2.Visibility = Visibility.Hidden;
                txtBlockEmailMsg.Visibility = Visibility.Visible;
                Email = EmailTxt;
            }
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
                    Email = null;
                }
           
            }
            return Email;
        }


        
        public string validatePhoneNoInput(TextBlock txtBlockPhoneError, TextBox txtBoxPhone) //Phone Number Validation Method
        {
            int intphone;
            string PhoneNoTxt = txtBoxPhone.Text.Trim();
            PhoneNoTxt = PhoneNoTxt.Replace(" ", string.Empty);
            string Phone = null;
            //Checks for correct length, whether is empty or whitespace, or contains spaces
            if (!(PhoneNoTxt.Length >= 4 && PhoneNoTxt.Length <= 15) || string.IsNullOrEmpty(PhoneNoTxt) || string.IsNullOrWhiteSpace(PhoneNoTxt) || PhoneNoTxt.Contains(" "))
            {
                txtBlockPhoneError.Visibility = Visibility.Visible;
            }
            else if (!int.TryParse(PhoneNoTxt, out intphone))
            {
                txtBlockPhoneError.Visibility = Visibility.Visible;
            }
            else if (int.TryParse(PhoneNoTxt, out intphone))
            {
                txtBlockPhoneError.Visibility = Visibility.Hidden;
                Phone = PhoneNoTxt;
            }
            return Phone;
        }





        //Date Of Birth(DOB) Validation Method 
        public string validateDOBInput(TextBlock txtBlockDOBError, TextBox txtBoxDOBDay, TextBox txtBoxDOBMonth, TextBox txtBoxDOBYear)
        {
            int intday, intmonth, intyear;
            string Day = null, Month = null, Year = null;
            string DOB = null;
            //DOB Day Validation

            if (int.TryParse(txtBoxDOBDay.Text.Trim(), out intday) && !txtBoxDOBDay.Text.Trim().Equals("") && !txtBoxDOBDay.Text.Trim().Equals(" ")) //if is int value
            {
                if (!(intday > 0 && intday < 32))  //if not within days of month
                {
                    txtBlockDOBError.Visibility = Visibility.Visible;
                    txtBoxDOBDay.Foreground = Brushes.DarkGray;
                    txtBoxDOBDay.Text = "dd";
                }
                else //if is a day of a month, set string to variable, hide error
                {
                    txtBlockDOBError.Visibility = Visibility.Hidden;
                    Day = intday.ToString();
                }
            }
            else if (!int.TryParse(txtBoxDOBDay.Text.Trim(), out intday)) //error if not int
            {
                txtBlockDOBError.Visibility = Visibility.Visible;
                txtBoxDOBDay.Foreground = Brushes.DarkGray;
                txtBoxDOBDay.Text = "dd";
            }
            //DOB Month Validation
            if (int.TryParse(txtBoxDOBMonth.Text.Trim(), out intmonth) && !txtBoxDOBDay.Text.Trim().Equals("") && !txtBoxDOBDay.Text.Trim().Equals(" ")) //if int value
            {
                if ((intmonth < 1 || intmonth > 12)) //if not a valid month
                {
                    txtBlockDOBError.Visibility = Visibility.Visible;
                    txtBoxDOBMonth.Foreground = Brushes.DarkGray;
                    txtBoxDOBMonth.Text = "mm";
                }
                else  //else set string to variable, hide error
                {
                    Month = intmonth.ToString();
                    if (Day != null)
                        txtBlockDOBError.Visibility = Visibility.Hidden;
                }
            }
            else if (!int.TryParse(txtBoxDOBMonth.Text.Trim(), out intmonth)) //if not an int value
            {
                txtBlockDOBError.Visibility = Visibility.Visible;
                txtBoxDOBMonth.Foreground = Brushes.DarkGray;
                txtBoxDOBMonth.Text = "mm";
            }
            //DOB Year Validation
            if (int.TryParse(txtBoxDOBYear.Text.Trim(), out intyear) && !txtBoxDOBDay.Text.Trim().Equals("") && !txtBoxDOBDay.Text.Trim().Equals(" ")) //if is an int value
            {
                if (!(intyear >= 1910 && intyear <= DateTime.Now.Year)) //if is not a valid Year of Birth
                {
                    txtBlockDOBError.Visibility = Visibility.Visible;
                    txtBoxDOBYear.Foreground = Brushes.DarkGray;
                    txtBoxDOBYear.Text = "yyyy";
                }
                else //else set string to variable, hide error
                {
                    Year = intyear.ToString();
                    if (Day != null && Month != null)
                        txtBlockDOBError.Visibility = Visibility.Hidden;
                }
            }
            else if (!int.TryParse(txtBoxDOBYear.Text.Trim(), out intyear)) //f not int value
            {
                txtBlockDOBError.Visibility = Visibility.Visible;
                txtBoxDOBYear.Foreground = Brushes.DarkGray;
                txtBoxDOBYear.Text = "yyyy";
            }

            if (Day != null && Month != null && Year != null)
            {
                DOB = Day.PadLeft(2, '0') + "/" + Month.PadLeft(2, '0') + "/" + Year; //concatenate day month and year values into date format
            }

            return DOB;
        }



        //Country Validation Method
        public string validateCountryInput(string SelectedValueCountry, TextBlock txtBlockCountryError)
        {
            string Country = null;
            //Checks if Country combobox has a selected value
            if (SelectedValueCountry == null)
            {
                txtBlockCountryError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockCountryError.Visibility = Visibility.Hidden;
                Country = SelectedValueCountry;
            }
            return Country;
        }


        //Town/City Validation Method
        public string validateTownOrCityInput(TextBlock txtBlockCityError, TextBox txtBoxCity)
        {
            string TownOrCityTxt = txtBoxCity.Text.Trim();
            string TownOrCity = null;
            //Validates so that town/city name must be more than or equal to 2 characters
            if (TownOrCityTxt.Length < 2 || string.IsNullOrWhiteSpace(TownOrCityTxt) || string.IsNullOrEmpty(TownOrCityTxt))
            {
                txtBlockCityError.Visibility = Visibility.Visible;
            }
            else
            {
                Boolean CityHasDigit = false;
                //Makes it compulsory that town/city name does not contain digits
                foreach (char c in TownOrCityTxt)
                {
                    if (Char.IsDigit(c))
                        CityHasDigit = true;
                }
                if (CityHasDigit)
                    txtBlockCityError.Visibility = Visibility.Visible;
                else
                {
                    txtBlockCityError.Visibility = Visibility.Hidden;
                    TownOrCity = char.ToUpper(TownOrCityTxt[0]) + TownOrCityTxt.Substring(1).ToLower();
                }
            }
            return TownOrCity;
        }



        //Nationality Validation Method
        public string validateNationalityInput(string SelectedValueNationality, TextBlock txtBlockNationalityError)
        {

            string Nationality = null;
            //Checks if Nationality combobox has a selected value
            if (SelectedValueNationality == null)
            {
                txtBlockNationalityError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockNationalityError.Visibility = Visibility.Hidden;
                Nationality = SelectedValueNationality;
            }

            return Nationality;
        }



        //Street Address Validation Method
        //Validates address based on whether it contains spaces, digits and letters
        public string validateAddressInput(TextBlock txtBlockAddressError, TextBox txtBoxAddress)
        {
            string Address = null;
            string AddressTxt = txtBoxAddress.Text.Trim();
            Boolean AddressHasDigit = false, AddressHasLetter = false;
            foreach (char c in AddressTxt)
            {
                if (Char.IsDigit(c))
                    AddressHasDigit = true;

                if (Char.IsLetter(c))
                    AddressHasLetter = true;
            }

            if (!AddressTxt.Contains(" ") || !AddressHasDigit || !AddressHasLetter)
            {
                txtBlockAddressError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockAddressError.Visibility = Visibility.Hidden;
                Address = AddressTxt;
            }
            return Address;
        }



        //Postal Code Validation Method
        //Validates postal code must contain at least 4 characters with no spaces or *
        public string validatePostalCdInput(TextBlock txtBlockPostalCdError1, TextBlock txtBlockPostalCdError2, TextBox txtBoxPostalCd)
        {
            string PostalCd = null;
            string PostalCdTxt = txtBoxPostalCd.Text.Trim();
            if (PostalCdTxt.Length < 4)
            {
                txtBlockPostalCdError1.Visibility = Visibility.Visible;
                txtBlockPostalCdError2.Visibility = Visibility.Hidden;
            }
            else if (PostalCdTxt.Contains(" ") || PostalCdTxt.Contains("*"))
            {
                txtBlockPostalCdError2.Visibility = Visibility.Visible;
                txtBlockPostalCdError1.Visibility = Visibility.Hidden;
            }
            else
            {
                txtBlockPostalCdError1.Visibility = Visibility.Hidden;
                txtBlockPostalCdError2.Visibility = Visibility.Hidden;
                PostalCd = PostalCdTxt;
            }
            return PostalCd;

        }




        //Username Validation Method 
        //Search current customer database for usernames taken and shows error for different kinds of non-accepted values
        public string validateUsernameInput(TextBlock txtBlockUsernameError1, TextBlock txtBlockUsernameError2, TextBlock txtBlockUsernameError3, TextBlock txtBlockUsernameMsg, TextBox txtBoxUsername)
        {
            string Username = null;
            Collection cl = new Collection();
            string UserNameText = txtBoxUsername.Text.Trim().ToLower();
            if (UserNameText.Length > 15 || UserNameText.Length < 4)
            {
                txtBlockUsernameError1.Visibility = Visibility.Hidden;
                txtBlockUsernameError3.Visibility = Visibility.Hidden;
                txtBlockUsernameError2.Visibility = Visibility.Visible;
                txtBlockUsernameMsg.Visibility = Visibility.Hidden;
                Username = null;
            }
            else if (UserNameText.Contains("*") || UserNameText.Contains(" ") || string.IsNullOrWhiteSpace(UserNameText))
            {
                txtBlockUsernameError1.Visibility = Visibility.Hidden;
                txtBlockUsernameError2.Visibility = Visibility.Hidden;
                txtBlockUsernameError3.Visibility = Visibility.Visible;
                txtBlockUsernameMsg.Visibility = Visibility.Hidden;
                Username = null;
            }
            else
            {
                Boolean UsernameHasLetters = false;
                foreach (char c in UserNameText)
                {
                    if (char.IsLetter(c))
                    {
                        UsernameHasLetters = true;
                    }
                }
                if (!UsernameHasLetters)
                {
                    txtBlockUsernameError1.Visibility = Visibility.Hidden;
                    txtBlockUsernameError2.Visibility = Visibility.Hidden;
                    txtBlockUsernameError3.Visibility = Visibility.Visible;
                    txtBlockUsernameMsg.Visibility = Visibility.Hidden;
                    Username = null;
                }
                else
                {
                    txtBlockUsernameError1.Visibility = Visibility.Hidden;
                    txtBlockUsernameError2.Visibility = Visibility.Hidden;
                    txtBlockUsernameError3.Visibility = Visibility.Hidden;
                    txtBlockUsernameMsg.Visibility = Visibility.Visible;
                    Username = UserNameText;
                }
            }
            List<string> customerlines = cl.getTextFileList("customerInfo");
            foreach (var customerline in customerlines)
            {
               
                string[] elements = customerline.Split('*');

                //Username Validation
                if (elements[10] == UserNameText)
                {
                    txtBlockUsernameError1.Visibility = Visibility.Visible;
                    txtBlockUsernameError3.Visibility = Visibility.Hidden;
                    txtBlockUsernameError2.Visibility = Visibility.Hidden;
                    txtBlockUsernameMsg.Visibility = Visibility.Hidden;
                    Username = null;
                }
               
            }
            return Username;
        }




        //Password and Confirm Password Input Validation Method
        public string validatePasswordInput(TextBlock txtBlockPWError1, TextBlock txtBlockPWError2, TextBlock txtBlockPWError3, TextBlock txtBlockConfirmPWError, PasswordBox txtBoxPW, PasswordBox txtBoxConfirmPW)
        {
            string Password = null;
            string PWTxt = txtBoxPW.Password.ToString().Trim();
            string confirmPWTxt = txtBoxConfirmPW.Password.ToString().Trim();
            //validates based on length
            if (!(PWTxt.Length >= 8 && PWTxt.Length <= 24))
            {
                txtBlockPWError1.Visibility = Visibility.Visible;
                txtBlockPWError2.Visibility = Visibility.Hidden;
                txtBlockPWError3.Visibility = Visibility.Hidden;
                txtBoxPW.Password = string.Empty;
                txtBoxConfirmPW.Password = string.Empty;

            }
            //validates so it cannot contain space or '*'
            else if (PWTxt.Contains(" ") || PWTxt.Contains("*") || PWTxt.Equals(""))
            {
                txtBlockPWError3.Visibility = Visibility.Visible;
                txtBlockPWError2.Visibility = Visibility.Hidden;
                txtBlockPWError1.Visibility = Visibility.Hidden;
                txtBoxPW.Password = string.Empty;
                txtBoxConfirmPW.Password = string.Empty;
            }
            //validates so it must contain letter and digit
            else
            {
                Boolean PWHasLetter = false;
                Boolean PWHasDigit = false;
                foreach (char c in PWTxt)
                {
                    if (Char.IsLetter(c))
                    {
                        PWHasLetter = true;
                    }
                    if (Char.IsDigit(c))
                    {
                        PWHasDigit = true;
                    }
                }
                if (!(PWHasLetter && PWHasDigit) || string.IsNullOrWhiteSpace(PWTxt))
                {
                    txtBlockPWError1.Visibility = Visibility.Hidden;
                    txtBlockPWError3.Visibility = Visibility.Hidden;
                    txtBlockPWError2.Visibility = Visibility.Visible;
                    txtBoxPW.Password = string.Empty;
                    txtBoxConfirmPW.Password = string.Empty;
                }
                else if (!PWTxt.Equals(confirmPWTxt))
                {
                    txtBlockConfirmPWError.Visibility = Visibility.Visible;
                    txtBlockPWError1.Visibility = Visibility.Hidden;
                    txtBlockPWError3.Visibility = Visibility.Hidden;
                    txtBlockPWError2.Visibility = Visibility.Hidden;
                    txtBoxPW.Password = string.Empty;
                    txtBoxConfirmPW.Password = string.Empty;
                }
                else
                {
                    txtBlockPWError1.Visibility = Visibility.Hidden;
                    txtBlockPWError2.Visibility = Visibility.Hidden;
                    txtBlockPWError3.Visibility = Visibility.Hidden;
                    txtBlockConfirmPWError.Visibility = Visibility.Hidden;
                    Password = PWTxt;
                }
            }
            return Password;
        }





        //Card Type Validation Method
        public string validateCardTypeInput(string SelectionValueCardType, TextBlock txtBlockCardTypeError)
        {
            string CardType = null;
            //Checks if Card type combobox has a selected value
            if (SelectionValueCardType == null)
            {
                txtBlockCardTypeError.Visibility = Visibility.Visible;
            }
            else
            {
                txtBlockCardTypeError.Visibility = Visibility.Hidden;
                CardType = SelectionValueCardType;
            }
            return CardType;
        }



        //Card No Validation
        //Card No must be more than 12 and less than 20 numerical digits
        //Visa -13 or 16, Mastercard -16, AmEx - 15
        public string validateCardNoInput(TextBlock txtBlockCardNoError1, TextBlock txtBlockCardNoError2, TextBox txtBoxCardNo)
        {
            string CardNo = null;
            long intcardNo;
            if (long.TryParse(txtBoxCardNo.Text.Trim(), out intcardNo)) //check if txt is a long int
            {
                if (!(txtBoxCardNo.Text.Trim().Length >= 13 && txtBoxCardNo.Text.Trim().Length <= 19)) //check if txt is more than 12 and less than 20 numerical digits
                {
                    txtBlockCardNoError2.Visibility = Visibility.Visible;
                    txtBlockCardNoError1.Visibility = Visibility.Hidden;
                }
                else //add value to property
                {
                    txtBlockCardNoError1.Visibility = Visibility.Hidden;
                    txtBlockCardNoError2.Visibility = Visibility.Hidden;
                    CardNo = txtBoxCardNo.Text.Trim();
                }
            }
            else //if input != long int value
            {
                txtBlockCardNoError1.Visibility = Visibility.Visible;
                txtBlockCardNoError2.Visibility = Visibility.Hidden;
            }
            return CardNo;
        }




        //Expiration Date Input Validation
        public string validateExpirationDateInput(TextBlock txtBlockExpDateError, TextBox txtBoxExpMonth, TextBox txtBoxExpYear)
        {
            int intmonth, intyear;
            string Month = "", Year = "";
            string CardExpirationDate = null;
            //DOB Month Validation
            if (int.TryParse(txtBoxExpMonth.Text.Trim(), out intmonth)) //check if date input is int
            {
                if ((intmonth < 1 || intmonth > 12)) //check if input is a valid month
                {
                    txtBlockExpDateError.Visibility = Visibility.Visible;
                    txtBoxExpMonth.Foreground = Brushes.DarkGray;
                    txtBoxExpMonth.Text = "mm";
                    Month = null;
                }
                else //add string to month variable
                {
                    Month = intmonth.ToString();
                    txtBlockExpDateError.Visibility = Visibility.Hidden;
                }
            }
            else if (!int.TryParse(txtBoxExpMonth.Text.Trim(), out intmonth))
            {
                txtBlockExpDateError.Visibility = Visibility.Visible;
                txtBoxExpMonth.Foreground = Brushes.DarkGray;
                txtBoxExpMonth.Text = "mm";
                Month = null;
            }
            //DOB Year Validation
            if (int.TryParse(txtBoxExpYear.Text.Trim(), out intyear))
            {
                if (intyear < DateTime.Now.Year || intyear > DateTime.Now.Year + 30)
                {
                    txtBlockExpDateError.Visibility = Visibility.Visible;
                    txtBoxExpYear.Foreground = Brushes.DarkGray;
                    txtBoxExpYear.Text = "yyyy";
                    Year = null;
                }
                else
                {
                    Year = intyear.ToString();
                    if (Month != null)
                    {
                        txtBlockExpDateError.Visibility = Visibility.Hidden;
                    }
                }
            }
            else if (!int.TryParse(txtBoxExpYear.Text.Trim(), out intyear))
            {
                txtBlockExpDateError.Visibility = Visibility.Visible;
                txtBoxExpYear.Foreground = Brushes.DarkGray;
                txtBoxExpYear.Text = "yyyy";
                Year = null;
            }

            if (Month != null && Year != null)
            {
                CardExpirationDate = Month.PadLeft(2, '0') + "/" + Year;
            }

            return CardExpirationDate;
        }


        //Name Validation - Max 26 characters, alphanumerical
        public string validateCardHolderNameInput(TextBlock txtBlockCardHolderNameError, TextBox txtBoxCardHolderName)
        {
            bool isSymbol = false;
            string chName = txtBoxCardHolderName.Text.Trim();
            string CardHolderName = null;
            foreach (char c in chName)
            {
                if (char.IsSymbol(c))
                {
                    isSymbol = true;
                }
            }
            if (string.IsNullOrEmpty(chName) || chName.Contains("*") || isSymbol == true || chName.Length > 26)
            {
                txtBlockCardHolderNameError.Visibility = Visibility.Visible;
                CardHolderName = null;
            }
            else
            {
                txtBlockCardHolderNameError.Visibility = Visibility.Hidden;
                CardHolderName = chName;
            }
            return CardHolderName;
        }



        //CCV2/CVC2 Validation
        //must be 3 - 4 numerical digits
        public string validateCCVInput(TextBlock txtBlockCCVError, TextBox txtBoxCCV)
        {
            int intCCV;
            string CCV = null;
            if (!(int.TryParse(txtBoxCCV.Text.Trim(), out intCCV)))
            {
                txtBlockCCVError.Visibility = Visibility.Visible;
            }
            else
            {
                if (!(txtBoxCCV.Text.Trim().Length == 3 || txtBoxCCV.Text.Trim().Length == 4))
                {
                    txtBlockCCVError.Visibility = Visibility.Visible;
                }
                else
                {
                    txtBlockCCVError.Visibility = Visibility.Hidden;
                    CCV = txtBoxCCV.Text.Trim();
                }
            }
            return CCV;
        }



    }
}
