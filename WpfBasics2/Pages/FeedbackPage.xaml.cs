using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class FeedbackPage : Page
    {
        public FeedbackPage(string username)
        {
            InitializeComponent();
            Customer cs = new Customer(username);
            cs.populateCustomerDetails();
            txtBlockName.Text = cs.FirstName + " " + cs.LastName;
            txtBlockEmail.Text = cs.Email;
        }



        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxTitle.Text == "Title" || txtBoxMessage.Text == "Enter your query here and we will reply to you via email...")
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
            else if (txtBoxTitle.Text.Length > 150)
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
                ErrorTextBlock.Text = "Ënter a title less that 150 chars";
            }
            else if (txtBoxMessage.Text.Length > 400)
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
                ErrorTextBlock.Text = "Ënter a title less than 400 chars";
            }
            else
            {
                Feedback fb = new Feedback();
                ErrorTextBlock.Visibility = Visibility.Hidden;
                fb.sendEmail(txtBoxTitle.Text.Trim(), txtBlockName.Text, txtBlockEmail.Text, txtBoxMessage.Text.Trim());
                this.NavigationService.Navigate(new FeedbackSentPage());
            }
        }




        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).Close();
        }


        //Message TextBox GotFocus
        //Removes default string from email textbox when got focus
        private void txtBoxMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxMessage.Foreground = Brushes.Black;
            if (txtBoxMessage.Text == "Enter your query here and we will reply to you via email...")
            {
                txtBoxMessage.Text = string.Empty;
            }
        }
        //Email TextBox LostFocus
        //Adds default string to email textbox if empty when lose focus
        private void txtBoxMessage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxMessage.Text))
            {
                txtBoxMessage.Text = "Enter your query here and we will reply to you via email...";
                txtBoxMessage.Foreground = Brushes.DarkGray;
            }
        }

        //Message TextBox GotFocus
        //Removes default string from email textbox when got focus
        private void txtBoxTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxTitle.Foreground = Brushes.Black;
            if (txtBoxTitle.Text == "Title")
            {
                txtBoxTitle.Text = string.Empty;
            }
        }
        //Email TextBox LostFocus
        //Adds default string to email textbox if empty when lose focus
        private void txtBoxTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxTitle.Text))
            {
                txtBoxTitle.Text = "Title";
                txtBoxTitle.Foreground = Brushes.DarkGray;
            }
        }


    }

}
