using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{

        public class Room
        {
            private double singleRmPrice = 90.50;
            private double doubleRmPrice = 125.50;
            private int noOfSingles;
            private int noOfDoubles;
            private string roomSelection;

            public Room(double singleRmPrice, double doubleRmPrice)
            {
                this.singleRmPrice = singleRmPrice;
                this.doubleRmPrice = doubleRmPrice;
            }

            public Room(int noOfSingles, int noOfDoubles, string roomSelection)
            {
                this.noOfSingles = noOfSingles;
                this.noOfDoubles = noOfDoubles;
                this.roomSelection = roomSelection;
            }
            public Room()
            {

            }
            public double SingleRmPrice
            {
                get { return singleRmPrice; }
                set { this.singleRmPrice = value; }
            }

            public double DoubleRmPrice
            {
                get { return doubleRmPrice; }
                set { this.doubleRmPrice = value; }
            }

            public int NoOfSingles
            {
                get { return noOfSingles; }
                set { this.noOfSingles = value; }
            }

            public int NoOfDoubles
            {
                get { return noOfDoubles; }
                set { this.noOfDoubles = value; }
            }

            public string RoomSelection
            {
                get { return roomSelection; }
                set { this.roomSelection = value; }
            }

            public double calculateTotalRmPrice(double singleRmPrice, int singleRmQty, double doubleRmPrice, int doubleRmQty)
            {
                double totalRmPrice = (singleRmPrice * singleRmQty) + (doubleRmPrice * doubleRmQty);
                return totalRmPrice;
            }
        }
    }
