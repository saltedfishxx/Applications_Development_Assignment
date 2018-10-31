using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BookSharp.Classes;
using BookSharp.Pages;

namespace BookSharp
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {

        private string username;
        private Color color;
        public ReceiptWindow(Color color)
        {
            InitializeComponent();
            this.color = color;
            Grid.Background = new SolidColorBrush(color);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Collection cl = new Collection();

            List<string> booking = cl.getTextFileList("bookingInfo");

            string getLine = booking[booking.Count - 1];
            string[] getBookingElement = getLine.Split('^');
            bookingID.Text = getBookingElement[0];
            username = getBookingElement[1];
            bookingDate.Text = getBookingElement[2];
            bookingTime.Text = getBookingElement[3];
            TotalCost.Text = (double.Parse(getBookingElement[4])).ToString("c2");

            Customer cust = new Customer(username);
            cust.populateCustomerDetails();

            custName.Text = cust.FirstName + " " + cust.LastName;
            email.Text = cust.Email;
            contact.Text = cust.Phone;


            for (int i = 5; i < getBookingElement.Length; i++)
            {
                string[] getTourDetails = getBookingElement[i].Split('*');
                TextBlock tourID = new TextBlock();
                tourID.Text = string.Format("({0}) TourID : ", (i - 4));
                tourID.FontWeight = FontWeights.Bold;

                TextBlock tourIDValue = new TextBlock();
                tourIDValue.Text = getTourDetails[0];

                TextBlock tourQty = new TextBlock();
                tourQty.Text = "No. Of People : ";
                tourQty.FontWeight = FontWeights.Bold;

                TextBlock qtyValue = new TextBlock();
                qtyValue.Text = getTourDetails[3];

                TextBlock tourDate = new TextBlock();
                tourDate.Text = "Selected Tour Date : ";
                tourDate.FontWeight = FontWeights.Bold;

                TextBlock dateRange = new TextBlock();
                dateRange.Text = getTourDetails[13] + " - " + getTourDetails[14];

                TextBlock flight = new TextBlock();
                flight.Text = "Flight Choice : ";
                flight.FontWeight = FontWeights.Bold;

                TextBlock flightSelection = new TextBlock();
                flightSelection.Text = getTourDetails[5];

                TextBlock fTicket = new TextBlock();
                fTicket.Text = "No. Of Tickets : ";
                fTicket.FontWeight = FontWeights.Bold;

                TextBlock ticketQty = new TextBlock();
                ticketQty.Text = getTourDetails[4];

                TextBlock room = new TextBlock();
                room.Text = "Room Choice : ";
                room.FontWeight = FontWeights.Bold;

                TextBlock roomSelection = new TextBlock();
                roomSelection.Text = getTourDetails[6];

                TextBlock roomType = new TextBlock();
                roomType.Text = "Room Type : ";
                roomType.FontWeight = FontWeights.Bold;

                TextBlock roomValue = new TextBlock();
                roomValue.Text = string.Format("Single x {0}, Double x {1}", getTourDetails[7], getTourDetails[8]);

                TextBlock tourPrice = new TextBlock();
                tourPrice.Text = "Total Tour Price : ";
                tourPrice.FontWeight = FontWeights.Bold;

                TextBlock tourPriceValue = new TextBlock();
                tourPriceValue.Text = (int.Parse(getTourDetails[2]) * int.Parse(getTourDetails[3])).ToString("c2");

                TextBlock flightPrice = new TextBlock();
                flightPrice.Text = "Flight Price : ";
                flightPrice.FontWeight = FontWeights.Bold;

                TextBlock flightPriceValue = new TextBlock();
                flightPriceValue.Text = "$" + getTourDetails[9];

                TextBlock roomPrice = new TextBlock();
                roomPrice.Text = "Room Price : ";
                roomPrice.FontWeight = FontWeights.Bold;

                TextBlock roomPriceValue = new TextBlock();
                roomPriceValue.Text = "$" + getTourDetails[10];

                TextBlock addon = new TextBlock();
                addon.Text = "Add-on : ";
                addon.FontWeight = FontWeights.Bold;

                TextBlock addonSelection = new TextBlock();
                addonSelection.Text = getTourDetails[11];

                TextBlock subTotal = new TextBlock();
                subTotal.Text = "Subtotal : ";
                subTotal.FontWeight = FontWeights.Bold;

                TextBlock subValue = new TextBlock();
                subValue.Text = "$" + getTourDetails[12];

                StackPanel tour = new StackPanel();
                tour.Margin = new Thickness(10, 10, 0, 0);
                tour.Orientation = Orientation.Horizontal;
                tour.Children.Add(tourID);
                tour.Children.Add(tourIDValue);

                StackPanel qty = new StackPanel();
                qty.Margin = new Thickness(27, 20, 0, 0);
                qty.Orientation = Orientation.Horizontal;
                qty.Children.Add(tourQty);
                qty.Children.Add(qtyValue);

                StackPanel selectedDate = new StackPanel();
                selectedDate.Margin = new Thickness(27, 20, 0, 0);
                selectedDate.Orientation = Orientation.Horizontal;
                selectedDate.Children.Add(tourDate);
                selectedDate.Children.Add(dateRange);

                StackPanel flightChoice = new StackPanel();
                flightChoice.Margin = new Thickness(27, 0, 0, 0);
                flightChoice.Orientation = Orientation.Horizontal;
                flightChoice.Children.Add(flight);
                flightChoice.Children.Add(flightSelection);

                StackPanel flightTicket = new StackPanel();
                flightTicket.Margin = new Thickness(27, 0, 0, 0);
                flightTicket.Orientation = Orientation.Horizontal;
                flightTicket.Children.Add(fTicket);
                flightTicket.Children.Add(ticketQty);

                StackPanel roomChoice = new StackPanel();
                roomChoice.Margin = new Thickness(27, 0, 0, 0);
                roomChoice.Orientation = Orientation.Horizontal;
                roomChoice.Children.Add(room);
                roomChoice.Children.Add(roomSelection);

                StackPanel rmType = new StackPanel();
                rmType.Margin = new Thickness(27, 0, 0, 0);
                rmType.Orientation = Orientation.Horizontal;
                rmType.Children.Add(roomType);
                rmType.Children.Add(roomValue);

                StackPanel totalTour = new StackPanel();
                totalTour.Margin = new Thickness(27, 0, 0, 0);
                totalTour.Orientation = Orientation.Horizontal;
                totalTour.Children.Add(tourPrice);
                totalTour.Children.Add(tourPriceValue);

                StackPanel totalFlight = new StackPanel();
                totalFlight.Margin = new Thickness(27, 0, 0, 0);
                totalFlight.Orientation = Orientation.Horizontal;
                totalFlight.Children.Add(flightPrice);
                totalFlight.Children.Add(flightPriceValue);

                StackPanel totalRoom = new StackPanel();
                totalRoom.Margin = new Thickness(27, 0, 0, 0);
                totalRoom.Orientation = Orientation.Horizontal;
                totalRoom.Children.Add(roomPrice);
                totalRoom.Children.Add(roomPriceValue);

                StackPanel subTotal1 = new StackPanel();
                subTotal1.Margin = new Thickness(27, 0, 0, 0);
                subTotal1.Orientation = Orientation.Horizontal;
                subTotal1.Children.Add(subTotal);
                subTotal1.Children.Add(subValue);

                StackPanel addons = new StackPanel();
                addons.Margin = new Thickness(27, 0, 0, 0);
                addons.Orientation = Orientation.Horizontal;
                addons.Children.Add(addon);
                addons.Children.Add(addonSelection);

                Line divider = new Line();
                divider.X1 = 10;
                divider.X2 = 460;
                SolidColorBrush Gray = new SolidColorBrush();
                Gray.Color = Colors.DarkGray;
                divider.Stroke = Gray;
                divider.Margin = new Thickness(0, 20, 0, 0);

                mainContent.Children.Add(tour);
                mainContent.Children.Add(qty);
                mainContent.Children.Add(selectedDate);
                mainContent.Children.Add(flightChoice);
                mainContent.Children.Add(flightTicket);
                mainContent.Children.Add(roomChoice);
                mainContent.Children.Add(rmType);
                mainContent.Children.Add(addons);
                mainContent.Children.Add(totalTour);
                mainContent.Children.Add(totalFlight);
                mainContent.Children.Add(totalRoom);
                mainContent.Children.Add(subTotal1);
                mainContent.Children.Add(divider);

            }
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Cart ct = new Cart();
            ct.deleteAllCartItems();
            foreach (Window window in App.Current.Windows)
            {
                if (!window.IsActive)
                {
                    window.Close();
                }
                else if (window.IsActive)
                {
                    MainWindow mw = new MainWindow(username, color);
                    mw.Top = Window.GetWindow(this).Top;
                    mw.Main.Content = new CartPage(username, color);
                    mw.Show();
                    window.Close();
                }
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Cart ct = new Cart();
            ct.deleteAllCartItems();
            foreach (Window window in App.Current.Windows)
            {
                if (!window.IsActive)
                {
                    window.Close();
                }
                else if (window.IsActive)
                {
                    MainWindow mw = new MainWindow(username, color);
                    mw.Top = Window.GetWindow(this).Top;
                    mw.Main.Content = new CartPage(username, color);
                    mw.Show();
                    window.Close();
                }
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimiseImage_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MinimiseImage.Opacity = 0.5;
        }

        private void MinimiseImage_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MinimiseImage.Opacity = 0.6;
        }

        private void CloseImage_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseImage.Opacity = 0.9;
        }

        private void CloseImage_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseImage.Opacity = 1;
        }
    }
}