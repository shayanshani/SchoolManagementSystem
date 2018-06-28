using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace SchoolManagementSystem.DL
{
    public class SendSms
    {

        public static string SendMessage(string Number, string Message)
        {
            try
            {
                ThreadStart threadStart = delegate() { send(Number,Message); };
                Thread thread = new Thread(threadStart);
                thread.Start();
                return "Message has been successfuly sent";
            }
            catch
            {
                return "Connection error! Please check the connection and try again";
            }

        }
        public static bool send(string Number,string Message)
        {
                string MyUsername = "ShayanShani"; //Your Username At Lifetimesms.com
                string MyPassword = "42Shani91"; //Your Password At Lifetimesms.com
                string toNumber = Number; //Your cell phone number with country code
                string Masking = "PakPearl"; //Your Company Brand Name
                string MessageText = Message;
                string jsonResponse = SendSMS(Masking, toNumber, MessageText, MyUsername, MyPassword);
                Console.Write(jsonResponse);

                if (jsonResponse == "-3 :Sender ID cant be greater than 11 characters")
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }
        public static string SendSMS(string Masking, string toNumber, string MessageText, string MyUsername, string MyPassword)
        {
            String URI = "http://Lifetimesms.com" +
            "/plain?" +
            "username=" + MyUsername +
            "&password=" + MyPassword +
            "&from=" + Masking +
            "&to=" + toNumber +
            "&message=" + Uri.UnescapeDataString(MessageText); // Visual Studio 10-15
          //  "//&message=" + System.Net.WebUtility.UrlEncode(MessageText);// Visual Studio 12
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                var sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                var httpWebResponse = ex.Response as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return "404:URL not found :" + URI;
                            break;
                        case HttpStatusCode.BadRequest:
                            return "400:Bad Request";
                            break;
                        default:
                            return httpWebResponse.StatusCode.ToString();
                    }
                }
            }
            return null;
        } 
    }
}