using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookSharp.Classes
{

    class Review
    {
        Collection cl = new Collection();
        private int tourIndex;
        private string reviewName;
        private string reviewMessage;
        private DateTime reviewDateTime;

        public Review() { }
        public Review(int tourIndex) { this.tourIndex = tourIndex; }
        public Review(int tourIndex, string reviewName, string reviewMessage, DateTime reviewDateTime)
        {
            this.tourIndex = tourIndex;
            this.reviewName = reviewName;
            this.reviewMessage = reviewMessage;
            this.reviewDateTime = reviewDateTime;
        }

        public int TourIndex
        {
            get { return this.tourIndex; }
            set { this.tourIndex = value; }
        }
        public string ReviewName
        {
            get { return this.reviewName; }
            set { this.reviewName = value; }
        }
        public string ReviewMessage
        {
            get { return this.reviewMessage; }
            set { this.reviewMessage = value; }
        }
        public DateTime ReviewDateTime
        {
            get { return this.reviewDateTime; }
            set { this.reviewDateTime = value; }
        }


        public void storeReview()
        {
            List<string> reviewParts = new List<string>();
            reviewParts.Add(tourIndex.ToString());
            reviewParts.Add(reviewName);
            reviewParts.Add(reviewMessage);
            reviewParts.Add(Convert.ToString(reviewDateTime));
            string separator = "[(*^s3p4r4t0r^*)]";
            string reviewToStore = string.Join(separator, reviewParts);

            List<string> allReviews = cl.getTextFileList("reviews");
            allReviews.Add(reviewToStore);
          
            File.WriteAllLines(cl.getFilePath("reviews"), allReviews);
        }


        public ArrayList getReviewsList()
        {
            ArrayList tourReviewsList = new ArrayList();
            List<string> allReviewsList = cl.getTextFileList("reviews");
            foreach (var reviewLine in allReviewsList)
            {
                if (reviewLine != null)
                {
                    string[] separator = { "[(*^s3p4r4t0r^*)]" };
                    string[] reviewParts = reviewLine.Split(separator, System.StringSplitOptions.None);
                    if (tourIndex.ToString() == reviewParts[0])
                    {
                        Review review = new Review(int.Parse(reviewParts[0]), reviewParts[1], reviewParts[2], DateTime.Parse(reviewParts[3]));
                        tourReviewsList.Add(review);
                    }
                }
               
            }
            return tourReviewsList;
        }


    }
}
