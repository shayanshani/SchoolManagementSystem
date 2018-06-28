using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace SchoolManagementSystem.DL
{
    public class SendEmail
    {

        public static string Mail(string ToEmail, string subject, string Body)
        {
            try
            {
                ThreadStart threadStart = delegate() { SendMail(ToEmail, subject, Body); };
                Thread thread = new Thread(threadStart);
                thread.Start();
                return "Email has been successfuly sent";
            }
            catch
            {
                return "Connection error! Please check the connection and try again";
            }

        }

        private static void SendMail(string ToEmail, string subject, string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);
                // mail.To.Add("Another Email ID where you wanna send same email");
                mail.From = new MailAddress("universityportal1@gmail.com");
                mail.Subject = subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new NetworkCredential("universityportal1@gmail.com", "42Shani91");
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.SendAsync(mail, "User");
            }
            catch
            {

            }

        }


        public static bool SendUserMail(string ToEmail, string subject, string Body,string DisplayName)
        {
            try
            {
                ThreadStart threadStart = delegate() { UserMail(ToEmail, subject, Body, DisplayName); };
                Thread thread = new Thread(threadStart);
                thread.Start();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static Boolean UserMail(string ToEmail, string subject, string Body, string displayName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);
                // mail.To.Add("Another Email ID where you wanna send same email");
                mail.From = new MailAddress("universityportaluser@gmail.com", displayName);
                mail.Subject = subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new NetworkCredential("universityportaluser@gmail.com", "42Shani91");
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;

            }

        }
    }
}