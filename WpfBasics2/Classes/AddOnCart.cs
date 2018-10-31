using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class AddOnCart : Cart
    {
        private double addon = 107;

        public double Addon
        {
            get;
            set;
        }

        public override double calculateSubTotal(double tourPrice, int qty, double totalRmPrice, double totalFlightPrice)
        {
            double subTotal = (tourPrice * qty) + totalFlightPrice + totalRmPrice + addon;

            return subTotal;
        }
    }
}
