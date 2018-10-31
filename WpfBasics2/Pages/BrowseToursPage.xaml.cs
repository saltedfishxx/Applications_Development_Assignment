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
    /// Interaction logic for BrowseToursPage.xaml
    /// </summary>
    public partial class BrowseToursPage : Page
    {
        private Color BorderColor;
        private string Username;

        public BrowseToursPage(string username, Color color)
        {
            InitializeComponent();
            Username = username;
            BorderColor = color;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TourCollection tc = new TourCollection();

            Tour t1 = tc.getTour(0);
            Tour t2 = tc.getTour(1);
            Tour t3 = tc.getTour(2);
            Tour t4 = tc.getTour(3);
            Tour t5 = tc.getTour(4);
            Tour t6 = tc.getTour(5);
            Tour t7 = tc.getTour(6);
            Tour t8 = tc.getTour(7);
            Tour t9 = tc.getTour(8);
            Tour t10 = tc.getTour(9);
            Tour t11 = tc.getTour(10);
            Tour t12 = tc.getTour(11);

            TourNameTxt1.Text = t1.TourName;
            TourNameTxt2.Text = t2.TourName;
            TourNameTxt3.Text = t3.TourName;
            TourNameTxt4.Text = t4.TourName;
            TourNameTxt5.Text = t5.TourName;
            TourNameTxt6.Text = t6.TourName;
            TourNameTxt7.Text = t7.TourName;
            TourNameTxt8.Text = t8.TourName;
            TourNameTxt9.Text = t9.TourName;
            TourNameTxt10.Text = t10.TourName;
            TourNameTxt11.Text = t11.TourName;
            TourNameTxt12.Text = t12.TourName;

            TourDescTxt1.Text = t1.TourDesc;
            TourDescTxt2.Text = t2.TourDesc;
            TourDescTxt3.Text = t3.TourDesc;
            TourDescTxt4.Text = t4.TourDesc;
            TourDescTxt5.Text = t5.TourDesc;
            TourDescTxt6.Text = t6.TourDesc;
            TourDescTxt7.Text = t7.TourDesc;
            TourDescTxt8.Text = t8.TourDesc;
            TourDescTxt9.Text = t9.TourDesc;
            TourDescTxt10.Text = t10.TourDesc;
            TourDescTxt11.Text = t11.TourDesc;
            TourDescTxt12.Text = t12.TourDesc;

            TourPriceTxt1.Text = "PRICE: $" + t1.TourPrice.ToString();
            TourPriceTxt2.Text = "PRICE: $" + t2.TourPrice.ToString();
            TourPriceTxt3.Text = "PRICE: $" + t3.TourPrice.ToString();
            TourPriceTxt4.Text = "PRICE: $" + t4.TourPrice.ToString();
            TourPriceTxt5.Text = "PRICE: $" + t5.TourPrice.ToString();
            TourPriceTxt6.Text = "PRICE: $" + t6.TourPrice.ToString();
            TourPriceTxt7.Text = "PRICE: $" + t7.TourPrice.ToString();
            TourPriceTxt8.Text = "PRICE: $" + t8.TourPrice.ToString();
            TourPriceTxt9.Text = "PRICE: $" + t9.TourPrice.ToString();
            TourPriceTxt10.Text = "PRICE: $" + t10.TourPrice.ToString();
            TourPriceTxt11.Text = "PRICE: $" + t11.TourPrice.ToString();
            TourPriceTxt12.Text = "PRICE: $" + t12.TourPrice.ToString();
        }

        private void ViewButton1_Click(object sender, RoutedEventArgs e)
        {
     
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(0, Username, BorderColor);
           
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();



        }

        private void ViewButton2_Click(object sender, RoutedEventArgs e)
        {
  
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(1, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton3_Click(object sender, RoutedEventArgs e)
        {
   
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(2, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton4_Click(object sender, RoutedEventArgs e)
        {
    
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(3, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton5_Click(object sender, RoutedEventArgs e)
        {
    
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(4, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton6_Click(object sender, RoutedEventArgs e)
        {
   
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(5, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton7_Click(object sender, RoutedEventArgs e)
        {
  
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(6, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton8_Click(object sender, RoutedEventArgs e)
        {

            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(7, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton9_Click(object sender, RoutedEventArgs e)
        {
        
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(8, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton10_Click(object sender, RoutedEventArgs e)
        {
          
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(9, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton11_Click(object sender, RoutedEventArgs e)
        {
     
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(10, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }

        private void ViewButton12_Click(object sender, RoutedEventArgs e)
        {
      
            var newWindow = new TourDetailsWindow(BorderColor);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.TourDetailsPage(11, Username, BorderColor);
            newWindow.Show(); //Show the new window
            Application.Current.Windows[0].Hide();
        }
        private void radioD_Checked(object sender, RoutedEventArgs e)
        {

            buttonsVisible();
            SortBudget.SelectedIndex = -1;
            SortBudget.Text = "Budget";
            SortRegion.SelectedIndex = -1;
            SortRegion.Text = "Region";
            SortCountry.SelectedIndex = -1;
            SortCountry.Text = "Country";
        }

        private void SortCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonsVisible();
            sortByCountry();

        }

        private void SortRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonsVisible();
            sortByRegion();
      
        }

        private void SortBudget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonsVisible();
            sortByBudget();
        
        }

        public void buttonsVisible()
        {

            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            Button5.Visibility = Visibility.Visible;
            Button6.Visibility = Visibility.Visible;
            Button7.Visibility = Visibility.Visible;
            Button8.Visibility = Visibility.Visible;
            Button9.Visibility = Visibility.Visible;
            Button10.Visibility = Visibility.Visible;
            Button11.Visibility = Visibility.Visible;
            Button12.Visibility = Visibility.Visible;
        }

        public void sortByCountry()
        {
            if (SortCountry.SelectedIndex == 0)
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;
            }
            if (SortCountry.SelectedIndex == 1)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 2)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 3)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 4)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 5)
            {

                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 6)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            if (SortCountry.SelectedIndex == 7)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;


            }
        }

        public void sortByRegion()
        {
            if (SortRegion.SelectedIndex == 0)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;


            }
            else if (SortRegion.SelectedIndex == 1)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;


            }
            else if (SortRegion.SelectedIndex == 2)
            {
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;


            }
        }

        public void sortByBudget()
        {
            if (SortBudget.SelectedIndex == 0)
            {
                Button1.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            else if (SortBudget.SelectedIndex == 1)
            {
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button7.Visibility = Visibility.Collapsed;
                Button8.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button12.Visibility = Visibility.Collapsed;

            }
            else if (SortBudget.SelectedIndex == 2)
            {

                Button1.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Collapsed;
                Button3.Visibility = Visibility.Collapsed;
                Button4.Visibility = Visibility.Collapsed;
                Button5.Visibility = Visibility.Collapsed;
                Button6.Visibility = Visibility.Collapsed;
                Button9.Visibility = Visibility.Collapsed;
                Button10.Visibility = Visibility.Collapsed;
                Button11.Visibility = Visibility.Collapsed;

            }
        }

    }
}

