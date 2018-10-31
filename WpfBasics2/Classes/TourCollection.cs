using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections;

namespace BookSharp.Classes
{
    public class TourCollection
    {
        ArrayList Alltours = new ArrayList();
        Collection cl = new Collection();
        public ArrayList getTours() //stores tour details from txt file to array list
        {
            List<string> txtFileTours = cl.getTextFileList("tourInfo");
            for(int i = 0; i < txtFileTours.Count; i++)
            {
                Tour tour = new Tour(cl.getTextFileElement("tourInfo", i, 0), cl.getTextFileElement("tourInfo", i, 1), cl.getTextFileElement("tourInfo", i, 2), Double.Parse(cl.getTextFileElement("tourInfo", i, 3)),
                    cl.getTextFileElement("tourInfo", i, 4), cl.getTextFileElement("tourInfo", i, 5), cl.getTextFileElement("tourInfo", i, 6), cl.getTextFileElement("tourInfo", i, 7));

                Alltours.Add(tour);
            }

            return Alltours;
        }

        public Tour getTour(int zeroBasedLineNo)
        {
            ArrayList tours = getTours();
            int count = 0;
            Tour tourToReturn = null;
            foreach (Tour tour in tours)
            {
                if (count == zeroBasedLineNo)
                {
                    tourToReturn = tour;
                }
                count++;
            }
            return tourToReturn;
        }

    }
}

