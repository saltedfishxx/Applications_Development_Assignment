using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    public class Tour
    {
        private string tourID;
        private string tourName;
        private string tourDesc;
        private double tourPrice;
        private string tourStartDate;
        private string tourEndDate;
        private string tourDuration;
        private string tourImageSource;

        public Tour(string tourID, string tourName, string tourDesc, double tourPrice, string tourStartDate, string tourEndDate, string tourDuration, string tourImageSource)
        {
            this.tourID = tourID;
            this.tourName = tourName;
            this.tourDesc = tourDesc;
            this.tourPrice = tourPrice;
            this.tourStartDate = tourStartDate;
            this.tourEndDate = tourEndDate;
            this.tourDuration = tourDuration;
            this.tourImageSource = tourImageSource;
        }
        public Tour() //default constructor
        {

        }
        public string TourID
        {
            get { return tourID; }
            set { this.tourID = value; }
        }
        public string TourName
        {
            get { return tourName; }
            set { this.tourName = value; }
        }
        public string TourDesc
        {
            get { return tourDesc; }
            set { this.tourDesc = value; }
        }
        public double TourPrice
        {
            get { return tourPrice; }
            set { this.tourPrice = value; }
        }
        public string TourStartDate
        {
            get { return tourStartDate; }
            set { this.tourStartDate = value; }
        }
        public string TourEndDate
        {
            get { return tourEndDate; }
            set { this.tourEndDate = value; }
        }
        public string TourDuration
        {
            get { return tourDuration; }
            set { this.tourDuration = value; }
        }
        public string TourImageSource
        {
            get { return tourImageSource; }
            set { this.tourImageSource = value; }
        }
    }
}
