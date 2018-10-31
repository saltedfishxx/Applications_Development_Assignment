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
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        Flight f = new Flight();
        Room r = new Room();
        Cart ct = new Cart();

        Transaction ts = new Transaction();
        double finalprice;
        double totalcost;
        private string username;
        private Color color;

        public CartPage(string username, Color color)
        {
            InitializeComponent();
            this.username = username;
            this.color = color;

            TourCollection tc = new TourCollection();

            ArrayList allTours = tc.getTours();
            Tour t1 = (Tour)allTours[0];
            Tour t2 = (Tour)allTours[1];
            Tour t3 = (Tour)allTours[2];
            Tour t4 = (Tour)allTours[3];
            Tour t5 = (Tour)allTours[4];
            Tour t6 = (Tour)allTours[5];
            Tour t7 = (Tour)allTours[6];
            Tour t8 = (Tour)allTours[7];
            Tour t9 = (Tour)allTours[8];
            Tour t10 = (Tour)allTours[9];
            Tour t11 = (Tour)allTours[10];
            Tour t12 = (Tour)allTours[11];


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

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer(username);
            FreeCustomer fcust = new FreeCustomer(username);
            PremiumCustomer pcust = new PremiumCustomer(username);
            Collection cl = new Collection();
            buttonsInvisible();
            string[] getElement;
            string element;
            List<string> cartList = cl.getTextFileList("cartItems");
            foreach (var singleline in cartList)
            {
                getElement = singleline.Split('*'); //get element stores each element in one line

                element = getElement[0];

                if (element.Equals(cl.getTextFileElement("tourInfo", 0, 0))) //if line == tourid1 
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button1.Visibility = Visibility.Visible;
                    Flight1.Text = getElement[5];
                    Rooms1.Text = getElement[6];
                    Qty1.Text = getElement[3];
                    FlightPrice1.Text = "$" + getElement[9];
                    RoomPrice1.Text = "$" + getElement[10];
                    Addons1.Text = getElement[11];
                    Subtotal1.Text = "$" + getElement[12];
                    TourDate1.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 1, 0))) //if line == tourid2
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button2.Visibility = Visibility.Visible;
                    Flight2.Text = getElement[5];
                    Rooms2.Text = getElement[6];
                    Qty2.Text = getElement[3];
                    FlightPrice2.Text = "$" + getElement[9];
                    RoomPrice2.Text = "$" + getElement[10];
                    Addons2.Text = getElement[11];
                    Subtotal2.Text = "$" + getElement[12];
                    TourDate2.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 2, 0))) //if line == tourid3
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button3.Visibility = Visibility.Visible;
                    Flight3.Text = getElement[5];
                    Rooms3.Text = getElement[6];
                    Qty3.Text = getElement[3];
                    FlightPrice3.Text = "$" + getElement[9];
                    RoomPrice3.Text = "$" + getElement[10];
                    Addons3.Text = getElement[11];
                    Subtotal3.Text = "$" + getElement[12];
                    TourDate3.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 3, 0))) //if line == tourid4
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button4.Visibility = Visibility.Visible;
                    Flight4.Text = getElement[5];
                    Rooms4.Text = getElement[6];
                    Qty4.Text = getElement[3];
                    FlightPrice4.Text = "$" + getElement[9];
                    RoomPrice4.Text = "$" + getElement[10];
                    Addons4.Text = getElement[11];
                    Subtotal4.Text = "$" + getElement[12];
                    TourDate4.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 4, 0))) //if line == tourid5
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button5.Visibility = Visibility.Visible;
                    Flight5.Text = getElement[5];
                    Rooms5.Text = getElement[6];
                    Qty5.Text = getElement[3];
                    FlightPrice5.Text = "$" + getElement[9];
                    RoomPrice5.Text = "$" + getElement[10];
                    Addons5.Text = getElement[11];
                    Subtotal5.Text = "$" + getElement[12];
                    TourDate5.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 5, 0))) //if line == tourid6
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button6.Visibility = Visibility.Visible;
                    Flight6.Text = getElement[5];
                    Rooms6.Text = getElement[6];
                    Qty6.Text = getElement[3];
                    FlightPrice6.Text = "$" + getElement[9];
                    RoomPrice6.Text = "$" + getElement[10];
                    Addons6.Text = getElement[11];
                    Subtotal6.Text = "$" + getElement[12];
                    TourDate6.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 6, 0))) //if line == tourid7
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button7.Visibility = Visibility.Visible;
                    Flight7.Text = getElement[5];
                    Rooms7.Text = getElement[6];
                    Qty7.Text = getElement[3];
                    FlightPrice7.Text = "$" + getElement[9];
                    RoomPrice7.Text = "$" + getElement[10];
                    Addons7.Text = getElement[11];
                    Subtotal7.Text = "$" + getElement[12];
                    TourDate7.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 7, 0))) //if line == tourid8
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button8.Visibility = Visibility.Visible;
                    Flight8.Text = getElement[5];
                    Rooms8.Text = getElement[6];
                    Qty8.Text = getElement[3];
                    FlightPrice8.Text = "$" + getElement[9];
                    RoomPrice8.Text = "$" + getElement[10];
                    Addons8.Text = getElement[11];
                    Subtotal8.Text = "$" + getElement[12];
                    TourDate8.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 8, 0))) //if line == tourid9
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button9.Visibility = Visibility.Visible;
                    Flight9.Text = getElement[5];
                    Rooms9.Text = getElement[6];
                    Qty9.Text = getElement[3];
                    FlightPrice9.Text = "$" + getElement[9];
                    RoomPrice9.Text = "$" + getElement[10];
                    Addons9.Text = getElement[11];
                    Subtotal9.Text = "$" + getElement[12];
                    TourDate9.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 9, 0))) //if line == tourid10
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button10.Visibility = Visibility.Visible;
                    Flight10.Text = getElement[5];
                    Rooms10.Text = getElement[6];
                    Qty10.Text = getElement[3];
                    FlightPrice10.Text = "$" + getElement[9];
                    RoomPrice10.Text = "$" + getElement[10];
                    Addons10.Text = getElement[11];
                    Subtotal10.Text = "$" + getElement[12];
                    TourDate10.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 10, 0))) //if line == tourid11
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button11.Visibility = Visibility.Visible;
                    Flight11.Text = getElement[5];
                    Rooms11.Text = getElement[6];
                    Qty11.Text = getElement[3];
                    FlightPrice11.Text = "$" + getElement[9];
                    RoomPrice11.Text = "$" + getElement[10];
                    Addons11.Text = getElement[11];
                    Subtotal11.Text = "$" + getElement[12];
                    TourDate11.Text = getElement[13];
                }
                if (element.Equals(cl.getTextFileElement("tourInfo", 11, 0))) //if line == tourid12
                {
                    txtBlockNone.Visibility = Visibility.Collapsed;
                    Button12.Visibility = Visibility.Visible;
                    Flight12.Text = getElement[5];
                    Rooms12.Text = getElement[6];
                    Qty12.Text = getElement[3];
                    FlightPrice12.Text = "$" + getElement[9];
                    RoomPrice12.Text = "$" + getElement[10];
                    Addons12.Text = getElement[11];
                    Subtotal12.Text = "$" + getElement[12];
                    TourDate12.Text = getElement[13];
                }

            }
            cust.populateCustomerDetails();
            totalcost = ct.calculateTotal();
            if (cust.Membership == "Free")
            {
                fcust.populateCustomerDetails();
                subsidy.Text = "None";
                finalprice = fcust.calculateFinalPrice(totalcost);
                TotalCost.Text = string.Format("{0:c2}", finalprice);
            }
            else if (cust.Membership == "Premium")
            {
                pcust.populateCustomerDetails();
                subsidy.Text = "10%";
                finalprice = pcust.calculateFinalPrice(totalcost);
                TotalCost.Text = string.Format("{0:c2}", finalprice);
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

        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(0);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton2_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(1);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton3_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(2);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton4_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(3);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton5_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(4);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton6_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(5);
            this.NavigationService.Navigate(new CartPage(username, color));

        }

        private void DeleteButton7_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(6);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton8_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(7);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton9_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(8);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton10_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(9);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void DeleteButton11_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(10);
            this.NavigationService.Navigate(new CartPage(username, color));

        }

        private void DeleteButton12_Click(object sender, RoutedEventArgs e)
        {
            ct.deleteCartItem(11);
            this.NavigationService.Navigate(new CartPage(username, color));
        }

        private void EditButton1_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(0, username, color);
            newWindow.Show();
            
        }

        private void EditButton2_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(1, username, color);
            newWindow.Show();
     
        }

        private void EditButton3_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(2, username, color);
            newWindow.Show();
          
        }

        private void EditButton4_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(3, username, color);
            newWindow.Show();
       
        }

        private void EditButton5_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(4, username, color);
            newWindow.Show();
        
        }

        private void EditButton6_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(5, username, color);
            newWindow.Show();
           
        }

        private void EditButton7_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(6, username, color);
            newWindow.Show();
            
        }

        private void EditButton8_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(7, username, color);
            newWindow.Show();
            
        }

        private void EditButton9_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(8, username, color);
            newWindow.Show();
       
        }

        private void EditButton10_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color); 
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(9, username, color);
            newWindow.Show();
     
        }

        private void EditButton11_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color);
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left;
            newWindow.Main.Content = new Pages.CartItemSelectionPage(10, username, color);
            newWindow.Show();
          
        }

        private void EditButton12_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CartSelectionWindow(color); 
            newWindow.Top = Window.GetWindow(this).Top;
            newWindow.Left = Window.GetWindow(this).Left + (Window.GetWindow(this).ActualWidth*3);
            newWindow.Main.Content = new Pages.CartItemSelectionPage(11, username, color);
            newWindow.Show();
  
            
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlockNone.Visibility != Visibility.Visible)
            {
                MessageBoxResult mb = MessageBox.Show("Do you wish to checkout?", "Checkout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (mb == MessageBoxResult.Yes)
                {
                    ts.TotalCost = finalprice;
                    ts.generateReceipt(username);
                    var newWindow = new ReceiptWindow(color);
                    newWindow.Top = Window.GetWindow(this).Top;
                    newWindow.Show();
                }
            } else
            {
                MessageBox.Show("You have not selected any cart items", "Note");
            }
            
        }
    }
}

