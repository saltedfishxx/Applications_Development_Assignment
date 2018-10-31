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
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
  
        private static string username;
        private Color color;
        private int tourIndex = -1;
        private IEnumerable<string> currentUserTourIDs = null;
        Collection cl = new Collection();
        private bool hasPurchasedTour = false;


        public ReviewPage(string username, Color color)
        {
            InitializeComponent();

            ReviewPage.username = username;
            this.color = color;

            Customer cs = new Customer(username);
            cs.populateCustomerDetails();
            txtBoxName.Text = cs.FirstName + " " + cs.LastName;

            ErrorTextBlock1.Visibility = Visibility.Visible;
            comboBoxTourID.IsHitTestVisible = false;
            List<string> bookingUsernames = cl.getTextFileList("bookingInfo");
            foreach (var line in bookingUsernames)
            {
                string [] elements = line.Split('^');
                if(elements[1] == username)
                {
                    ErrorTextBlock1.Visibility = Visibility.Hidden;
                    comboBoxTourID.IsHitTestVisible = true;
                    comboBoxTourID.Cursor = Cursors.Hand;
                    hasPurchasedTour = true;
                }
            }
            currentUserTourIDs = getCurrentUserPurchasedTours(username);

            if (currentUserTourIDs != null)
            {
                foreach (string tourID in currentUserTourIDs)
                {
                    comboBoxTourID.Items.Add(tourID);
                }
            }

            ErrorTextBlock2.Visibility = Visibility.Hidden;
        }



        private IEnumerable<string> getCurrentUserPurchasedTours(string username) //returns a list of current user's previously booked tours
        {
            List<string> bookingLines = cl.getTextFileList("bookingInfo");
            List<string> currentUserTourIDs = new List<string>();
            foreach (var line in bookingLines)
            {
                string[] bookingElements = line.Split('^');
                if (bookingElements[1] == username)
                {
                    for (int i = 5; i < bookingElements.Length; i++)
                    {
                        string[] tourElements = bookingElements[i].Split('*');
                        currentUserTourIDs.Add(tourElements[0]);
                    }
                }
            }
            return currentUserTourIDs.Distinct(); //must be IEnumerable for distinct, (IEnumerable offers most general (least specific) interface that supports the operations that we need)
        }



        private void comboBoxTourID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> tours = cl.getTextFileList("tourInfo");
            string tourID = comboBoxTourID.SelectedValue.ToString();

            int index = 0;
            foreach (var tour in tours)
            {
                string[] tourElements = tour.Split('*');
                if (tourElements[0] == tourID)
                {
                    tourIndex = index;
                }
                index++;
            }
        }



        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            if (hasPurchasedTour)
            {
                if (txtBoxName.Text == "" || txtBoxMessage.Text == "" || txtBoxMessage.Text == "Enter your review of the tour you have purchased and it will be posted in the respective tour details page!" || string.IsNullOrWhiteSpace(txtBoxMessage.Text.Trim()) || string.IsNullOrWhiteSpace(txtBoxName.Text.Trim()))
                {
                    ErrorTextBlock2.Visibility = Visibility.Visible;
                }
                else if (tourIndex == -1)
                {
                    ErrorTextBlock2.Visibility = Visibility.Hidden;
                    ErrorTextBlock1.Visibility = Visibility.Visible;
                    ErrorTextBlock1.Text = "Please select a tour";
                }
                else if (txtBoxName.Text.Length > 50)
                {
                    ErrorTextBlock2.Text = "Please enter a name less than 50 characters";
                }
                else if (txtBoxMessage.Text.Length > 350)
                {
                    ErrorTextBlock2.Text = "Please leave a review less than 350 characters";
                }
                else
                {
                    ErrorTextBlock1.Visibility = Visibility.Hidden;
                    ErrorTextBlock2.Visibility = Visibility.Hidden;
                    Review rv = new Review(tourIndex, txtBoxName.Text.Trim(), txtBoxMessage.Text.Trim(), DateTime.Now);
                    rv.storeReview();

                    this.NavigationService.Navigate(new ReviewSentPage(username, color, tourIndex));
                }
            }
        }


        private void txtBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            Customer cs = new Customer(username);
            if (string.IsNullOrWhiteSpace(txtBoxName.Text))
            {
                txtBoxName.Text = cs.FirstName + " " + cs.LastName;
            }
        }


        //Message TextBox GotFocus   //Removes default string from email textbox when got focus
        private void txtBoxMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxMessage.Foreground = Brushes.Black;
            if (txtBoxMessage.Text == "Enter your review of the tour you have purchased and it will be posted in the respective tour details page!")
            {
                txtBoxMessage.Text = string.Empty;
            }
        }


        //Email TextBox LostFocus    //Adds default string to email textbox if empty when lose focus

        private void txtBoxMessage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxMessage.Text))
            {
                txtBoxMessage.Text = "Enter your review of the tour you have purchased and it will be posted in the respective tour details page!";
                txtBoxMessage.Foreground = Brushes.DarkGray;
            }
        }

    }
}
