using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookSharp.Classes
{
    class Cart
    {
        private double subTotal;
        private double totalCost;
        private int peopleQty;
        Flight f = new Flight();
        public Cart()
        {

        }
        public double SubTotal
        {
            get { return subTotal; }
            set { this.subTotal = value; }
        }

        public int PeopleQty
        {
            get { return peopleQty; }
            set { this.peopleQty = value; }
        }
        public double TotalCost
        {
            get { return totalCost; }
            set { this.totalCost = value; }
        }

        public virtual double calculateSubTotal(double tourPrice, int qty, double totalRmPrice, double totalFlightPrice)
        {
            double subTotal = (tourPrice * qty) + totalFlightPrice + totalRmPrice;
            return subTotal;
        }

        public double calculateTotal()
        {
            Collection cl = new Collection();
            List<string> lines = cl.getTextFileList("cartItems");
            List<string> lineElements = new List<string>();
            foreach (string line in lines)
            {
                if (line != null)
                {
                    string[] getElement = line.Split('*'); //get element stores each element in one line
                    double subTotal = double.Parse(getElement[12]);
                    totalCost += subTotal;
                }
            }
            return totalCost;
        }

        public void addCartItem(int TourLineNo, int noOfPeople, int noOfTickets, string flightSelection, string roomSelection, int noOfSingle, int noOfDouble, double flightPrice, double roomPrice, string addon, double subTotal, DateTime selectedStartDate, DateTime selectedEndDate) //for cartselection pages
        {

            bool isInCart = false;
            Collection cl = new Collection();
            List<string> lines = cl.getTextFileList("cartItems");
            List<string> lineElements = new List<string>();
            foreach (string line in lines)
            {
                string[] getElement = line.Split('*'); //get element stores each element in one line
                string element = getElement[0];
                if (!string.IsNullOrEmpty(line))
                {
                    if ((cl.getTextFileElement("tourInfo", TourLineNo, 0).Equals(element)))
                    {

                        isInCart = true;
                    }
                }
            }
            if (!(isInCart))
            {
                lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 0));
                lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 2));
                lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 3));
                lineElements.Add(noOfPeople.ToString());
                lineElements.Add(noOfTickets.ToString());
                lineElements.Add(flightSelection);
                lineElements.Add(roomSelection);
                lineElements.Add(noOfSingle.ToString());
                lineElements.Add(noOfDouble.ToString());
                lineElements.Add(string.Format("{0:f2}", flightPrice));
                lineElements.Add(string.Format("{0:f2}", roomPrice));
                lineElements.Add(addon);
                lineElements.Add(string.Format("{0:f2}", subTotal));
                lineElements.Add(selectedStartDate.ToShortDateString());
                lineElements.Add(selectedEndDate.ToShortDateString());
                //join all into a single line
                string addElements = string.Join("*", lineElements);
                lines.Add(addElements);
                //write line
                File.WriteAllLines(cl.getFilePath("cartItems"), lines);
            }


        }

        public void updateCartItem(int TourLineNo, int noOfPeople, int noOfTickets, string flightSelection, string roomSelection, int noOfSingle, int noOfDouble, double flightPrice, double roomPrice, string addon, double subTotal, DateTime selectedStartDate, DateTime selectedEndDate) //for cartselection pages)
        {
            Collection cl = new Collection();
            List<string> lines = cl.getTextFileList("cartItems");
            List<string> lineElements = new List<string>();
            lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 0));
            lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 2));
            lineElements.Add(cl.getTextFileElement("tourInfo", TourLineNo, 3));
            lineElements.Add(noOfPeople.ToString());
            lineElements.Add(noOfTickets.ToString());
            lineElements.Add(flightSelection);
            lineElements.Add(roomSelection);
            lineElements.Add(string.Format("{0}", noOfSingle));
            lineElements.Add(string.Format("{0}", noOfDouble));
            lineElements.Add(string.Format("{0:f2}", flightPrice));
            lineElements.Add(string.Format("{0:f2}", roomPrice));
            lineElements.Add(addon);
            lineElements.Add(string.Format("{0:f2}", subTotal));
            lineElements.Add(selectedStartDate.ToShortDateString());
            lineElements.Add(selectedEndDate.ToShortDateString());
            //join all into a single line
            string addElements = string.Join("*", lineElements);
            foreach (string line in lines)
            {
                string[] getElement = line.Split('*'); //get element stores each element in one line
                string element = getElement[0];

                if ((cl.getTextFileElement("tourInfo", TourLineNo, 0).Equals(element)))
                {
                    if (!addElements.Equals(line))
                    {
                        string text = File.ReadAllText(cl.getFilePath("cartItems"));
                        text = text.Replace(line, addElements);
                        File.WriteAllText(cl.getFilePath("cartItems"), text);
                   
                    }
                }
            }
        }



        public void deleteCartItem(int TourLineNo) //delete singular cart item based on the tours line No.
        {

            Collection cl = new Collection();
            List<string> lines = cl.getTextFileList("cartItems");

            foreach (string line in lines.ToList())
            {
                string[] getElement = line.Split('*'); //get element stores each element in one line
                string element = getElement[0];
                if (element.Equals(cl.getTextFileElement("tourInfo", TourLineNo, 0)))
                {
                    lines.Remove(line);
                }
                    

            }
            File.WriteAllLines(cl.getFilePath("cartItems"), lines);


        }


        public void deleteAllCartItems()  //for event handler for closing app or for logging out of the account
        {
            Collection cl = new Collection();
            List<string> lines = cl.getTextFileList("cartItems");
            foreach (string line in lines.ToList())
            {
                lines.Remove(line);
            }
            lines.RemoveAll(string.IsNullOrWhiteSpace);

            File.WriteAllLines(cl.getFilePath("cartItems"), lines);
        }


    }
}
