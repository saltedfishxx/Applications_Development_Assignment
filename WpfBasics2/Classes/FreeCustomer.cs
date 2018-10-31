using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookSharp.Classes
{
    class FreeCustomer : Customer
    {
        private DateTime expirydate;

        public FreeCustomer() { }
        public FreeCustomer(string username) : base (username) { }

        public FreeCustomer(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password, string cardtype, string cardno, string expdate, string chname, string ccv, string membership, DateTime expirydate) : base(firstname, lastname, email, phone, dob, country, townorcity, nationality, address, postalcd, username, password, cardtype, cardno, expdate, chname, ccv, membership)
        {
            this.expirydate = expirydate;
        }


        public DateTime ExpiryDate
        {
            get { return this.expirydate; }
            set { this.expirydate = value; }
        }

        public override void populateCustomerDetails()
        {
            string currentUserInfoLine = getCustomerInfoLine(Username);
            string[] elements = currentUserInfoLine.Split('*');
            FirstName = elements[0];
            LastName = elements[1];
            Email = elements[2];
            Phone = elements[3];
            DOB = elements[4];
            Country = elements[5];
            TownOrCity = elements[6];
            Nationality = elements[7];
            Address = elements[8];
            PostalCd = elements[9];      
            Password = elements[11];
            CardType = elements[12];
            CardNo = elements[13];
            CardExpirationDate = elements[14];
            CardHolderName = elements[15];
            CCV = elements[16];
            Membership = elements[17];
            ExpiryDate = DateTime.Parse(elements[18]);
        }

        public override void addNewCustomer()
        {
            List<string> lines = cl.getTextFileList("customerInfo");

            string customerToAdd = FirstName + "*" + LastName + "*" + Email + "*" + Phone + "*" + DOB + "*" + Country + "*" + TownOrCity + "*" + Nationality + "*" + Address + "*" + PostalCd + "*" + Username + "*" + Password + "*" + CardType + "*" + CardNo + "*" + CardExpirationDate + "*" + CardHolderName + "*" + CCV + "*" + Membership + "*" + Convert.ToString(ExpiryDate) + "*";

            lines.Add(customerToAdd);

            File.WriteAllLines(cl.getFilePath("customerInfo"), lines);
        }


        public override void editCustomer()
        {
            List<string> customerLines = cl.getTextFileList("customerInfo");
            Customer cs = new Customer(Username);
            cs.populateCustomerDetails();
            string currentUserInfoLine = cs.getCustomerInfoLine(Username);


            string newLine = FirstName + '*' + LastName + '*' + Email + '*' + Phone + '*' + DOB + '*' + Country + '*' + TownOrCity + '*' + Nationality + '*' + Address + '*' + PostalCd + '*' + Username + '*' + Password + '*' + CardType + '*' + CardNo + '*' + CardExpirationDate + '*' + CardHolderName + '*' + CCV + '*' + Membership + '*' + cs.getCustomerDetail(Username ,18) + "*" ;

            customerLines[customerLines.FindIndex(ind => ind.Equals(currentUserInfoLine))] = newLine;

            File.WriteAllLines(cl.getFilePath("customerInfo"), customerLines);
        }


        public void deleteExpiredCustomers()
        {
            List<string> customerLines = cl.getTextFileList("customerInfo");
            List<string> newlines = new List<string>();
            foreach (var line in customerLines)
            {
                string[] elements = line.Split('*');
                if (elements[17] == "Free")
                {
                    DateTime expirydate = DateTime.Parse(elements[18]);

                    if (DateTime.Compare(expirydate, DateTime.Now) >= 0)
                    {
                        newlines.Add(line);
                    }                   
                }
                else
                {
                    newlines.Add(line);
                }
            }

            File.WriteAllLines(cl.getFilePath("customerInfo"), newlines);

        }

    }
}
