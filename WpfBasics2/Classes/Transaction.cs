using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class Transaction
    {
        private string bookingID = "B00000001";
        private DateTime bookingDateTime = DateTime.Now;
        private double totalCost;
        public Transaction()
        {

        }

        public string BookingID
        {
            get { return bookingID; }
            set { this.bookingID = value; }
        }
        public DateTime BookingDateTime
        {
            get { return bookingDateTime; }
            set { this.bookingDateTime = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }
            set { this.totalCost = value; }
        }

        public void generateReceipt(string username)
        {
            Customer cust = new Customer();
            FreeCustomer fcust = new FreeCustomer();
            PremiumCustomer pcust = new PremiumCustomer();
            Collection cl = new Collection();
            List<string> cartItems = File.ReadAllLines(cl.getFilePath("cartItems")).ToList();
            List<string> bookingLines = File.ReadAllLines(cl.getFilePath("bookingInfo")).ToList();
            List<string> cartDetails = new List<string>();

            if (cl.getTextFileList("bookingInfo") == null)
            {
                cartDetails.Add(bookingID.ToString());
                cartDetails.Add(username);
                cartDetails.Add(bookingDateTime.ToShortDateString());
                cartDetails.Add(bookingDateTime.ToShortTimeString());
                cartDetails.Add(TotalCost.ToString());
                foreach (var line in cartItems.ToList())
                {
                    cartDetails.Add(line);
                } 
                string checkoutline = string.Join("^", cartDetails);
                bookingLines.Add(checkoutline);
                File.WriteAllLines(cl.getFilePath("bookingInfo"), bookingLines);
            }
            else
            {
                bookingID = string.Format("B" + "{0:D8}", (bookingLines.Count() + 1));
                cartDetails.Add(bookingID);
                cartDetails.Add(username);
                cartDetails.Add(bookingDateTime.ToShortDateString());
                cartDetails.Add(bookingDateTime.ToShortTimeString());
                cartDetails.Add(TotalCost.ToString());
                foreach (var line in cartItems.ToList())
                {
                    cartDetails.Add(line);
                }    
                string checkoutline = string.Join("^", cartDetails);
                bookingLines.Add(checkoutline);
                File.WriteAllLines(cl.getFilePath("bookingInfo"), bookingLines);
            }
        }
    }

}
