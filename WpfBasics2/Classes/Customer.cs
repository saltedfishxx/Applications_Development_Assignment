using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class Customer
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string dob;
        private string country;
        private string townOrCity;
        private string nationality;
        private string address;
        private string postalCd;
        private string username;
        private string password;
        private string cardType;
        private string cardNo;
        private string cardExpirationDate;
        private string cardHolderName;
        private string ccv;
        private string membership;

        public Collection cl = new Collection();

        public Customer() { }
        public Customer(string username) { this.username = username; }
        public Customer(string firstname, string lastname, string email, string phone, string dob, string country, string townorcity, string nationality, string address, string postalcd, string username, string password, string cardtype, string cardno, string expdate, string chname, string ccv, string membership)
        {
            this.firstName = firstname;
            this.lastName = lastname;
            this.email = email;
            this.phone = phone;
            this.dob = dob;
            this.country = country;
            this.townOrCity = townorcity;
            this.nationality = nationality;
            this.address = address;
            this.postalCd = postalcd;
            this.username = username;
            this.password = password;
            this.cardType = cardtype;
            this.cardNo = cardno;
            this.cardExpirationDate = expdate;
            this.cardHolderName = chname;
            this.ccv = ccv;
            this.membership = membership;
        }


        public virtual double calculateFinalPrice(double totalprice) //to be overridden by Premium Customer
        {
            return totalprice;
        }

        public virtual void populateCustomerDetails()
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
        }

        public virtual void addNewCustomer() { }

        public virtual void editCustomer() { }

        
        public string getCustomerInfoLine(string username) 
        {
            string currentUserInfoLine = "";

            List<string> customerLines = cl.getTextFileList("customerInfo");
            foreach (var line in customerLines)
            {
                string[] currentInfo = line.Split('*');
                if (currentInfo[10] == username)
                {
                    currentUserInfoLine = line;
                }
            }
            return currentUserInfoLine;
        }


        public string getCustomerDetail(string username, int zerobasedElementNo)  //to get Membership
        {
            string currentUserInfoLine = getCustomerInfoLine(username);

            string [] elements = currentUserInfoLine.Split('*');

            return elements[zerobasedElementNo];
        }




        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public string DOB
        {
            get { return this.dob; }
            set { this.dob = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public string TownOrCity
        {
            get { return this.townOrCity; }
            set { this.townOrCity = value; }
        }
        public string Nationality
        {
            get { return this.nationality; }
            set { this.nationality = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public string PostalCd
        {
            get { return this.postalCd; }
            set { this.postalCd = value; }
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public string CardType
        {
            get { return this.cardType; }
            set { this.cardType = value; }
        }
        public string CardNo
        {
            get { return this.cardNo; }
            set { this.cardNo = value; }
        }
        public string CardExpirationDate
        {
            get { return this.cardExpirationDate; }
            set { this.cardExpirationDate = value; }
        }
        public string CardHolderName
        {
            get { return this.cardHolderName; }
            set { this.cardHolderName = value; }
        }
        public string CCV
        {
            get { return this.ccv; }
            set { this.ccv = value; }
        }
        public string Membership
        {
            get { return this.membership; }
            set { this.membership = value; }
        }


    }
}

