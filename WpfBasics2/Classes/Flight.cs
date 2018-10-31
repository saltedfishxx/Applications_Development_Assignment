using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class Flight
    {
        private double flightPrice = 359.70;
        private int numTickets;
        private string flightSelection;

        public Flight(double flightPrice)
        {
            this.flightPrice = flightPrice;
        }

        public Flight(int numTickets, string flightSelection)
        {
            this.numTickets = numTickets;
            this.flightSelection = flightSelection;
        }
        public Flight()
        {

        }
        public double FlightPrice
        {
            get { return flightPrice; }
            set { this.flightPrice = value; }
        }
        public int NumTickets
        {
            get { return numTickets; }
            set { this.numTickets = value; }
        }

        public string FlightSelection
        {
            get { return flightSelection; }
            set { this.flightSelection = value; }
        }

        public double totalFlightPrice(double flightPrice, int flightQty)
        {
            double totalFlightPrice = flightPrice * flightQty;
            return totalFlightPrice;
        }

    }
}
