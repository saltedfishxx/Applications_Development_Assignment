using System;
using System.Collections;
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
    /// Interaction logic for CartItemSelectionPage.xaml
    /// </summary>
    public partial class CartItemSelectionPage : Page
    {
        int selectedCartItem;
        double tourPrice;
        int noOfPeople;
        int noOfTickets;
        int noOfSingleRm;
        int noOfDoubleRm;
        string flightselection = "NIL";
        string roomselection = "NIL";
        double totalFlightPrice;
        double totalRoomPrice;
        string addon = "NIL";
        double subTotal;
        DateTime selectedStartDate;
        DateTime selectedEndDate;
        int tourDuration;
        Cart ct = new Cart();
        AddOnCart aoct = new AddOnCart();
        bool input;
        private string username;
        private Color color;

        public CartItemSelectionPage(int cartitem, string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;
            selectedCartItem = cartitem;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Error.Visibility = Visibility.Hidden;
            ErrorTicket.Visibility = Visibility.Hidden;
            ErrorRoom.Visibility = Visibility.Hidden;
            ErrorDate.Visibility = Visibility.Hidden;


            TourCollection tc = new TourCollection();
            ArrayList allTours = tc.getTours();
            Tour tour = (Tour)allTours[selectedCartItem];
            TourID.Text = tour.TourID;
            TourName.Text = tour.TourName;
            TourDesc.Text = tour.TourDesc;
            tourPrice = tour.TourPrice;
            tourDuration = int.Parse(tour.TourDuration);
            datePicker.DisplayDate = DateTime.Parse(tour.TourStartDate);
            if (DateTime.Compare((DateTime)DateTime.Parse(tour.TourStartDate), DateTime.Now) < 0)
            {
                datePicker.DisplayDateStart = DateTime.Now;
            }
            else
            {
                datePicker.DisplayDateStart = (DateTime)DateTime.Parse(tour.TourStartDate);
            }
            datePicker.DisplayDateEnd = (DateTime)DateTime.Parse(tour.TourEndDate);



        }

        private void NoOfPerson_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NoOfPerson.Text != "" && NoOfPerson.Text != "0")
            {
                if (int.TryParse(NoOfPerson.Text, out noOfPeople))
                {
                    if (noOfPeople > 0)
                    {
                        CBaddFlight.Visibility = CBAddRoom.Visibility = Visibility.Visible;
                        Error.Visibility = Visibility.Hidden;
                        CBaddFlight.IsChecked = CBAddRoom.IsChecked = false;
                        this.NoOfFlightTickets.Items.Clear();

                    }
                    else
                    {
                        Error.Visibility = Visibility.Visible;
                        CBaddFlight.Visibility = CBAddRoom.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    Error.Visibility = Visibility.Visible;
                    CBaddFlight.Visibility = CBAddRoom.Visibility = Visibility.Hidden;
                }
            }
            else if (NoOfPerson.Text == "" || NoOfPerson.Text == "0")
            {
                Error.Visibility = Visibility.Visible;
                CBaddFlight.Visibility = CBAddRoom.Visibility = Visibility.Hidden;
            }

        }

        private void CBaddFlight_Checked(object sender, RoutedEventArgs e)
        {
            NoOfFlightTickets.IsHitTestVisible = true;
            NoOfFlightTickets.Cursor = Cursors.Hand;
            Img1.Opacity = 0.9;
            for (int i = 1; i <= noOfPeople; i++)
            {
                NoOfFlightTickets.Items.Add(i);
            }
        }

        private void CBaddFlight_Unchecked(object sender, RoutedEventArgs e)
        {
            NoOfFlightTickets.IsHitTestVisible = false;
            NoOfFlightTickets.Cursor = Cursors.Arrow;
            Img1.Opacity = 0.5;
            ErrorTicket.Visibility = Visibility.Hidden;
            NoOfFlightTickets.Items.Clear();
        }

        private void CBAddRoom_Unchecked(object sender, RoutedEventArgs e)
        {
            NoOfSingle.Text = "";
            NoOfDouble.Text = "";
            NoOfDouble.Focusable = NoOfSingle.Focusable = false;
            Img2.Opacity = Img3.Opacity = Img4.Opacity = 0.5;
            NoOfDouble.Cursor = NoOfSingle.Cursor = Cursors.Arrow;
            ErrorRoom.Visibility = Visibility.Hidden;
        }

        private void CBAddRoom_Checked(object sender, RoutedEventArgs e)
        {
            NoOfDouble.Focusable = NoOfSingle.Focusable = true;
            NoOfDouble.Cursor = NoOfSingle.Cursor = Cursors.IBeam;
            Img2.Opacity = Img3.Opacity = Img4.Opacity = 0.9;
        }

        private void NoOfFlightTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBaddFlight.IsChecked == true)
            {
                if (NoOfFlightTickets.SelectedIndex < 0)
                {
                    ErrorTicket.Visibility = Visibility.Visible;
                }
                else
                {
                    ErrorTicket.Visibility = Visibility.Hidden;
                    noOfTickets = (int)NoOfFlightTickets.SelectedItem;
                }
            }
            else
            {
                ErrorTicket.Visibility = Visibility.Hidden;
            }

        }

        private void NoOfSingle_TextChanged(object sender, TextChangedEventArgs e)
        {
            input = int.TryParse(NoOfSingle.Text, out noOfSingleRm);

            if (!input || noOfSingleRm <= 0)
            {

                ErrorRoom.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorRoom.Visibility = Visibility.Hidden;
                noOfSingleRm = int.Parse(NoOfSingle.Text);
            }
        }


        private void NoOfDouble_TextChanged(object sender, TextChangedEventArgs e)
        {
            input = int.TryParse(NoOfDouble.Text, out noOfDoubleRm);

            if (!input || noOfDoubleRm <= 0)
            {
                ErrorRoom.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorRoom.Visibility = Visibility.Hidden;
                noOfDoubleRm = int.Parse(NoOfDouble.Text);
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            if (NoOfPerson.Text.Equals("") || int.Parse(NoOfPerson.Text) == 0)
            {
                Error.Visibility = Visibility.Visible;
            }
            else if (NoOfPerson.Text != null)
            {
                if ((CBAddRoom.IsChecked == true && NoOfDouble.Text == "" && NoOfSingle.Text == ""))
                {
                    ErrorRoom.Visibility = Visibility.Visible;
                    ErrorRoom.Text = "Please enter number of rooms or uncheck the box";
                }
                else if (rbYes.IsChecked == true)
                {
                    addon = "Yes";
                    checkFlight();
                    checkRoom();
                    checkDate();
                }
                else if (rbNo.IsChecked == true)
                {
                    addon = "No";
                    checkFlight();
                    checkRoom();
                    checkDate();
                }


                if (Error.Visibility != Visibility.Visible && ErrorDate.Visibility != Visibility.Visible && ErrorRoom.Visibility != Visibility.Visible && ErrorTicket.Visibility != Visibility.Visible && ErrorDate.Visibility != Visibility.Visible && NoOfPerson.Text != "")
                {
                    aoct.updateCartItem(selectedCartItem, noOfPeople, noOfTickets, flightselection, roomselection, noOfSingleRm, noOfDoubleRm, totalFlightPrice, totalRoomPrice, addon, subTotal, selectedStartDate, selectedEndDate);
                    aoct.addCartItem(selectedCartItem, noOfPeople, noOfTickets, flightselection, roomselection, noOfSingleRm, noOfDoubleRm, totalFlightPrice, totalRoomPrice, addon, subTotal, selectedStartDate, selectedEndDate);

                    MessageBox.Show("Cart item has been updated!", "Note");
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



                    Window.GetWindow(this).Close();
                    CartPage cp1 = new CartPage(username, color);
                    mw.Main.Content = cp1;
                    mw.Show();

                }

            }
        }


        private void checkDate()
        {
            if (datePicker.SelectedDate == null)
            {
                ErrorDate.Text = "Please select a date";
                ErrorDate.Visibility = Visibility.Visible;
            }
            else
            {
                selectedEndDate = selectedStartDate.AddDays(tourDuration-1);

                Collection cl = new Collection();
                List<string> cartItems = cl.getTextFileList("cartItems");
                bool isClashing = false;
                if (cartItems.Count != 0)
                {
                    foreach (var line in cartItems)
                    {
                        string[] elements = line.Split('*');
                        DateTime startDate = Convert.ToDateTime(elements[13]); //start date of other cart items
                        DateTime endDate = Convert.ToDateTime(elements[14]); //end date of other cart items

                        if (elements[0] != cl.getTextFileElement("tourInfo", selectedCartItem, 0)) //if cart item is not the selected cart item
                        {
                            for (int i = 0; i < tourDuration; i++) //for each day of the tour
                            {
                                if (selectedStartDate.AddDays(i) >= startDate && selectedStartDate.AddDays(i) <= endDate) //if the dates of selected tour falls within the startdate and enddate of other tours
                                {
                                    ErrorDate.Text = "Date clashes with tour dates in cart";
                                    ErrorDate.Visibility = Visibility.Visible;
                                    isClashing = true;
                                }
                            }

                            if (!isClashing)
                            {
                                ErrorDate.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
                else //if no other cart items
                {
                    ErrorDate.Visibility = Visibility.Hidden;
                }

            }
        }


        private void checkFlight()
        {
            if (CBaddFlight.IsChecked == true)
            {
                flightselection = "Yes";
                if (NoOfFlightTickets.SelectedIndex < 0)
                {
                    ErrorTicket.Visibility = Visibility.Visible;
                }
                else
                {

                    ErrorTicket.Visibility = Visibility.Hidden;
                    Flight f = new Flight(noOfTickets, flightselection);
                    totalFlightPrice = f.totalFlightPrice(f.FlightPrice, noOfTickets);
                    subTotal = ct.calculateSubTotal(tourPrice, noOfPeople, totalRoomPrice, totalFlightPrice);
                }

            }
            else
            {
                flightselection = "No";
                noOfTickets = 0;
                Flight f = new Flight(noOfTickets, flightselection);
                totalFlightPrice = f.totalFlightPrice(f.FlightPrice, noOfTickets);
                subTotal = ct.calculateSubTotal(tourPrice, noOfPeople, totalRoomPrice, totalFlightPrice);
            }
        }

        private void checkRoom()
        {
            if (CBAddRoom.IsChecked == true)
            {
                roomselection = "Yes";
                if (NoOfDouble.Text == null || NoOfSingle.Text == null)
                {
                    ErrorRoom.Text = "Error: Please enter value!";
                    ErrorRoom.Visibility = Visibility.Visible;
                }
                else if ((noOfDoubleRm * 2) + noOfSingleRm > noOfPeople)
                {
                    ErrorRoom.Text = "Error: Rooms selected are more than no. of people";
                    ErrorRoom.Visibility = Visibility.Visible;
                }
                else
                {

                    Room r = new Room(noOfSingleRm, noOfDoubleRm, roomselection);
                    totalRoomPrice = r.calculateTotalRmPrice(r.SingleRmPrice, noOfSingleRm, r.DoubleRmPrice, noOfDoubleRm);
                    subTotal = ct.calculateSubTotal(tourPrice, noOfPeople, totalRoomPrice, totalFlightPrice);
                }
            }
            else
            {
                roomselection = "No";
                noOfSingleRm = 0;
                noOfDoubleRm = 0;
                Room r = new Room(noOfSingleRm, noOfDoubleRm, roomselection);
                totalRoomPrice = r.calculateTotalRmPrice(r.SingleRmPrice, noOfSingleRm, r.DoubleRmPrice, noOfDoubleRm);
                subTotal = ct.calculateSubTotal(tourPrice, noOfPeople, totalRoomPrice, totalFlightPrice);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStartDate = (DateTime)Convert.ToDateTime(Convert.ToDateTime(datePicker.SelectedDate).ToShortDateString());
            ErrorDate.Visibility = Visibility.Hidden;


        }

    }
}
