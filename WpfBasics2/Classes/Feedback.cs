using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class Feedback
    {
        public void sendEmail(string title, string name, string email, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("victkiwi2@gmail.com"); //To
                mail.From = new MailAddress("victkiwi3@gmail.com"); //From
                mail.Subject = title;
                mail.Body = "Name: " + name + "\r\n Email: " + email + "\r\n Message: " + message;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("victkiwi3@gmail.com", "passwordforappd"); // ***valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail: " + ex.Message);
            }
        }

    }
}
