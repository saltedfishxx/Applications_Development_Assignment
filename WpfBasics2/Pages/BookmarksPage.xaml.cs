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
    /// Interaction logic for BookmarksPage.xaml
    /// </summary>
    public partial class BookmarksPage : Page
    {

        Bookmarks bm = new Bookmarks();
        private string username;
        private Color color;


        public BookmarksPage(string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Collection cl = new Collection();

            buttonsInvisible();

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

            TourPriceTxt1.Text =  "$" + t1.TourPrice.ToString();
            TourPriceTxt2.Text =  "$" + t2.TourPrice.ToString();
            TourPriceTxt3.Text =  "$" + t3.TourPrice.ToString();
            TourPriceTxt4.Text =  "$" + t4.TourPrice.ToString();
            TourPriceTxt5.Text =  "$" + t5.TourPrice.ToString();
            TourPriceTxt6.Text =  "$" + t6.TourPrice.ToString();
            TourPriceTxt7.Text =  "$" + t7.TourPrice.ToString();
            TourPriceTxt8.Text =  "$" + t8.TourPrice.ToString();
            TourPriceTxt9.Text =  "$" + t9.TourPrice.ToString();
            TourPriceTxt10.Text = "$" + t10.TourPrice.ToString();
            TourPriceTxt11.Text = "$" + t11.TourPrice.ToString();
            TourPriceTxt12.Text = "$" + t12.TourPrice.ToString(); 

            TourIDTxt1.Text = t1.TourID;
            TourIDTxt2.Text = t2.TourID;
            TourIDTxt3.Text = t3.TourID;
            TourIDTxt4.Text = t4.TourID;
            TourIDTxt5.Text = t5.TourID;
            TourIDTxt6.Text = t6.TourID;
            TourIDTxt7.Text = t7.TourID;
            TourIDTxt8.Text = t8.TourID;
            TourIDTxt9.Text = t9.TourID;
            TourIDTxt10.Text = t10.TourID;
            TourIDTxt11.Text = t11.TourID;
            TourIDTxt12.Text = t12.TourID;

            TourStartDateTxt1.Text = t1.TourStartDate;
            TourStartDateTxt2.Text = t2.TourStartDate;
            TourStartDateTxt3.Text = t3.TourStartDate;
            TourStartDateTxt4.Text = t4.TourStartDate;
            TourStartDateTxt5.Text = t5.TourStartDate;
            TourStartDateTxt6.Text = t6.TourStartDate;
            TourStartDateTxt7.Text = t7.TourStartDate;
            TourStartDateTxt8.Text = t8.TourStartDate;
            TourStartDateTxt9.Text = t9.TourStartDate;
            TourStartDateTxt10.Text = t10.TourStartDate;
            TourStartDateTxt11.Text = t11.TourStartDate;
            TourStartDateTxt12.Text = t12.TourStartDate;

            TourEndDateTxt1.Text = t1.TourEndDate;
            TourEndDateTxt2.Text = t2.TourEndDate;
            TourEndDateTxt3.Text = t3.TourEndDate;
            TourEndDateTxt4.Text = t4.TourEndDate;
            TourEndDateTxt5.Text = t5.TourEndDate;
            TourEndDateTxt6.Text = t6.TourEndDate;
            TourEndDateTxt7.Text = t7.TourEndDate;
            TourEndDateTxt8.Text = t8.TourEndDate;
            TourEndDateTxt9.Text = t9.TourEndDate;
            TourEndDateTxt10.Text = t10.TourEndDate;
            TourEndDateTxt11.Text = t11.TourEndDate;
            TourEndDateTxt12.Text = t12.TourEndDate;



            List<string> lines = cl.getTextFileList("bookmarks");
            foreach (string line in lines)
            {

                if (line.Equals(cl.getTextFileElement("tourInfo", 0, 0))) //if line == tourid1 //if tourid1 contained in bookmarks(added when click bookmark)
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button1.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 1, 0))) //if line == tourid2
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button2.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 2, 0))) //if line == tourid3
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button3.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 3, 0))) //if line == tourid4
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 4, 0))) //if line == tourid5
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 5, 0))) //if line == tourid6
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button6.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 6, 0))) //if line == tourid7
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button7.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 7, 0))) //if line == tourid8
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button8.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 8, 0))) //if line == tourid9
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button9.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 9, 0))) //if line == tourid10
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button10.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 10, 0))) //if line == tourid11
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button11.Visibility = Visibility.Visible;
                }
                if (line.Equals(cl.getTextFileElement("tourInfo", 11, 0))) //if line == tourid12
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button12.Visibility = Visibility.Visible;
                }
            }
        }


        public void buttonsInvisible()
        {
            txtBlockNone.Visibility = Visibility.Visible;
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
            Button12.Visibility = Visibility.Collapsed;
        }

        //View tour details page Buttons
        private void ViewButton1_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(0, username, color);
        }

        private void ViewButton2_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(1, username, color);
        }

        private void ViewButton3_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(2, username, color);
        }

        private void ViewButton4_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(3, username, color);
        }

        private void ViewButton5_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(4, username, color);
        }

        private void ViewButton6_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(5, username, color);
        }

        private void ViewButton7_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(6, username, color);
        }

        private void ViewButton8_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(7, username, color);
        }

        private void ViewButton9_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(8, username, color);
        }

        private void ViewButton10_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(9, username, color);
        }

        private void ViewButton11_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(10, username, color);
        }

        private void ViewButton12_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new TourDetailsWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            newWindow.Show(); //Show the new window
            newWindow.Main.Content = new Pages.TourDetailsPage(11, username, color);
        }


        //Delete Buttons
        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(0);
            this.NavigationService.Refresh();
        }

        private void DeleteButton2_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(1);
            this.NavigationService.Refresh();
        }

        private void DeleteButton3_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(2);
            this.NavigationService.Refresh();
        }

        private void DeleteButton4_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(3);
            this.NavigationService.Refresh();
        }
        private void DeleteButton5_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(4);
            this.NavigationService.Refresh();
        }
        private void DeleteButton6_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(5);
            this.NavigationService.Refresh();
        }
        private void DeleteButton7_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(6);
            this.NavigationService.Refresh();
        }
        private void DeleteButton8_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(7);
            this.NavigationService.Refresh();
        }
        private void DeleteButton9_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(8);
            this.NavigationService.Refresh();
        }
        private void DeleteButton10_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(9);
            this.NavigationService.Refresh();
        }
        private void DeleteButton11_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(10);
            this.NavigationService.Refresh();
        }
        private void DeleteButton12_Click(object sender, RoutedEventArgs e)
        {
            bm.deleteBookmark(11);
            this.NavigationService.Refresh();
        }

    }
}
