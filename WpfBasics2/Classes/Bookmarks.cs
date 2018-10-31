using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BookSharp.Pages;

namespace BookSharp.Classes
{
    public class Bookmarks
    {
        Collection cl = new Collection();
        
        PremiumCustomer pc = new PremiumCustomer();
        FreeCustomer fc = new FreeCustomer();


        public void populateUserBookmarks(string username) //gets user's booksmarks from previous session customer textfile to store in bookmarks text                                                      file for this session
        {
      
            List<string> bookmarks = new List<string>();
            Customer cs = new Customer();
            string currentUserInfoLine = cs.getCustomerInfoLine(username);
            string [] currentUserInfo = currentUserInfoLine.Split('*');
            string bookmarksLine = currentUserInfo[19];
            if (bookmarksLine!="")
            {
                string[] bookmarksElements = bookmarksLine.Split('^');
                
                for (int i = 0; i < bookmarksElements.Length; i++)
                {
                    bookmarks.Add(bookmarksElements[i]);
                }

                bookmarks.Distinct();
            }
            File.WriteAllLines(cl.getFilePath("bookmarks"), bookmarks);
        }


        public void storeUserBookmarks(string username) //to store customer's bookmarks in textfile for next login //for window_closing for mainwindow
        {
            Customer cs = new Customer();
            List<string> customerLines = cl.getTextFileList("customerInfo");
            List<string> currentBookmarks = cl.getTextFileList("bookmarks");

            string currentUserInfoLine = cs.getCustomerInfoLine(username);
            string[] userInfo = currentUserInfoLine.Split('*');

            List<string> userInfoNoBookmarksList = new List<string>();

            for (int i = 0; i < userInfo.Length - 1; i++)
            {
                userInfoNoBookmarksList.Add(userInfo[i]);
            }
            string userBookmarksLine = "";
            string userInfoNoBookmarksLine = string.Join("*", userInfoNoBookmarksList);
           
            if (currentBookmarks != null)
            {
                userBookmarksLine = string.Join("^", currentBookmarks.Distinct());
            }
            
            string newLine = userInfoNoBookmarksLine + "*" + userBookmarksLine;
            customerLines[customerLines.FindIndex(ind => ind.Equals(currentUserInfoLine))] = newLine;

            File.WriteAllLines(cl.getFilePath("customerInfo"), customerLines);
        }


        public void addBookmark(int ZeroBasedTourLineNo) //for tourdetails pages
        {
            bool isInBookmarks = false;
            
            List<string> lines = cl.getTextFileList("bookmarks");
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if ((cl.getTextFileElement("tourInfo", ZeroBasedTourLineNo, 0).Equals(line)))
                    {
                        MessageBox.Show("You have already added this to your bookmarks!", "Note");
                        isInBookmarks = true;
                    }
                }
            }
            if (!(isInBookmarks))
            {
                lines.Add(cl.getTextFileElement("tourInfo", ZeroBasedTourLineNo, 0));
                File.WriteAllLines(cl.getFilePath("bookmarks"), lines);
                MessageBox.Show("Added to your bookmarks!", "Note");
            }
        }


        public void deleteBookmark(int ZeroBasedTourLineNo) //delete singular bookmark based on the tours line No.
        {
            List<string> lines = cl.getTextFileList("bookmarks");

            foreach (string line in lines.ToList())
            {
               if(line.Equals(cl.getTextFileElement("tourInfo", ZeroBasedTourLineNo, 0)))
                        lines.Remove(line);
                
            }
            File.WriteAllLines(cl.getFilePath("bookmarks"), lines);      
        }


        public void deleteAllBookmarks()  //for event handler for closing app or for logging out of the account
        {
            List<string> lines = cl.getTextFileList("bookmarks");
            foreach (string line in lines.ToList())
            {
                lines.Remove(line);
            }
            lines.RemoveAll(string.IsNullOrWhiteSpace);

            File.WriteAllLines(cl.getFilePath("bookmarks"), lines);
        }



    }
}
