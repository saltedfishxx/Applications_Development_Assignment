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

namespace BookSharp.Pages
{
    /// <summary>
    /// Interaction logic for ReviewSent.xaml
    /// </summary>
    public partial class ReviewSentPage : Page
    {
        private string username;
        private Color color;
        private int tourIndex;

        public ReviewSentPage(string username, Color color, int tourindex)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;
            this.tourIndex = tourindex;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReviewPage(username, color));
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            TourDetailsWindow td = new TourDetailsWindow(color);
            td.Top = Window.GetWindow(this).Top;
            td.Left = Window.GetWindow(this).Left;
            Window.GetWindow(this).Hide();
            td.Main.Content = new TourDetailsPage(tourIndex, username, color);
            td.Show();
        }
    }
}
