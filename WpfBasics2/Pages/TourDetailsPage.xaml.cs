using System;
using System.Collections;
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
    /// Interaction logic for TourDetailsPage.xaml
    /// </summary>
    public partial class TourDetailsPage : Page
    {

        private int tourIndex;
        private string username;
        private Color color;

        public TourDetailsPage(int zerobasedTourLineNo, string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            tourIndex = zerobasedTourLineNo;
            this.color = color;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Collection cl = new Collection();
            TourCollection tc = new TourCollection();
            ArrayList allTours = tc.getTours();
            Tour tour = (Tour)allTours[tourIndex];
            ImageTourSource.Source = new BitmapImage(new Uri(tour.TourImageSource));
            TextTourID.Text = tour.TourID;
            TextTourTitle.Text = tour.TourDesc;
            TextTourPrice.Text = "PRICE : $" + tour.TourPrice;
            TextTourDuration.Text = "TOUR AVAILABILITY : " + tour.TourStartDate + " - " + tour.TourEndDate;
            ItineraryDetails.Text = File.ReadAllText(cl.getFilePath("tour" + (tourIndex + 1).ToString()), Encoding.UTF8);
            TextTourSummary.Text = File.ReadAllText(cl.getFilePath("tour" + (tourIndex + 1).ToString() + "Summary"), Encoding.UTF8);

            Review rv = new Review(tourIndex);
            ArrayList reviewsList = rv.getReviewsList();
            reviewsList.Reverse();

            if (reviewsList.Count != 0)
            {
                NoReviewsGrid.Visibility = Visibility.Collapsed;
                foreach (Review review in reviewsList)
                {

                    Image icon = new Image();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Images/greenicon.png", UriKind.Absolute);
                    bitmap.EndInit();
                    icon.Source = bitmap;
                    icon.Height = 26;
                    icon.Width = 26;
                    icon.HorizontalAlignment = HorizontalAlignment.Left;
                    icon.Margin = new Thickness(0, 10, 0, 10);

                    TextBlock customerName = new TextBlock();
                    customerName.Text = ((Review)review).ReviewName;
                    customerName.FontWeight = FontWeights.Bold;
                    customerName.FontSize = 15;
                    customerName.HorizontalAlignment = HorizontalAlignment.Left;

                    customerName.Margin = new Thickness(40, 12, 0, 10);

                    TextBlock date = new TextBlock();
                    date.Text = Convert.ToString(((Review)review).ReviewDateTime.ToShortDateString());
                    date.Margin = new Thickness(0, 10, 100, 10);
                    date.FontSize = 11;
                    date.HorizontalAlignment = HorizontalAlignment.Right;
                    date.Foreground = Brushes.DarkGray;

                    TextBlock time = new TextBlock();
                    time.Text = Convert.ToString(((Review)review).ReviewDateTime.ToShortTimeString());
                    time.Margin = new Thickness(5, 10, 45, 10);
                    time.FontSize = 11;
                    time.HorizontalAlignment = HorizontalAlignment.Right;
                    time.Foreground = Brushes.DarkGray;

                    Grid customerNameContainer = new Grid();
                    customerNameContainer.Margin = new Thickness(0, 15, 0, 10);
                    customerNameContainer.Children.Add(icon);
                    customerNameContainer.Children.Add(customerName);
                    customerNameContainer.Children.Add(date);
                    customerNameContainer.Children.Add(time);

                    TextBlock reviewMessage = new TextBlock();
                    reviewMessage.Margin = new Thickness(40, 10, 20, 20);
                    reviewMessage.TextWrapping = TextWrapping.Wrap;
                    reviewMessage.Text = ((Review)review).ReviewMessage;
                    reviewMessage.FontSize = 11;

                    Line divider = new Line();
                    divider.X1 = 10;
                    divider.X2 = 590;
                    SolidColorBrush Gray = new SolidColorBrush();
                    Gray.Color = Colors.DarkGray;
                    divider.Stroke = Gray;
                    divider.Margin = new Thickness(0, 20, 0, 20);


                    ReviewStackPanel.Children.Add(customerNameContainer);
                    ReviewStackPanel.Children.Add(reviewMessage);
                    ReviewStackPanel.Children.Add(divider);
                }
                NoReviewsGrid.Visibility = Visibility.Collapsed;
            }
        }


        private void BookmarksButton_Click(object sender, RoutedEventArgs e)
        {
            Bookmarks bm = new Bookmarks();
            bm.addBookmark(tourIndex);
        }

        private void AddCartButton_Click(object sender, RoutedEventArgs e)
        {
            Collection cl = new Collection();
            List<string> cartlines = cl.getTextFileList("cartItems");
            bool isInCart = false;
            foreach (var line in cartlines)
            {
                string[] element = line.Split('*');
                if (element[0].Equals(cl.getTextFileElement("tourInfo", tourIndex, 0)))
                {
                    MessageBox.Show("This is already in your cart!", "Note");
                    isInCart = true;
                }
            }
            if (isInCart == false)
            {
                foreach (Window window in App.Current.Windows)
                {
                    if (!window.IsActive)
                    {
                        window.Hide();
                    }
                }
                CartSelectionWindow csw = new CartSelectionWindow(color);
                csw.Top = Window.GetWindow(this).Top;
                csw.Left = Window.GetWindow(this).Left;
                csw.Main.Content = new CartItemSelectionPage(tourIndex, username, color);
                csw.Show();

       

            }

        }
    }
}
