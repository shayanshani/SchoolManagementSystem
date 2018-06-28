using SchoolManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using SchoolManagementSystem.BL.Custom;

namespace SchoolManagementSystem
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //UserEnd Pages
            Routing(RouteTable.Routes, "HomePage", "Home", "~/index.aspx");
            Routing(RouteTable.Routes, "LoginPanel", "Login", "~/Administration/LoginPanel.aspx");
            Routing(RouteTable.Routes, "AllNews", "News", "~/AllNews.aspx");
            Routing(RouteTable.Routes, "SingleNews", "News/{val}", "~/News.aspx");
            Routing(RouteTable.Routes, "Events", "Events", "~/Events.aspx");
            Routing(RouteTable.Routes, "ContactUs", "Contact", "~/ContactUs.aspx");


        }

        public static void Routing(RouteCollection RC, string RoutName, string routeUrl, string Page)
        {
            RC.MapPageRoute(RoutName, routeUrl, Page);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            
            LogException exc = new LogException();
            exc.HandleException(Server.GetLastError());
            string servername;
            string HostName = "";
            if (HttpContext.Current.Request.IsSecureConnection)
            {
                servername = HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["SERVER_NAME"]);
                HostName = "https://" + servername + "/";
            }
            else
            {
                servername = HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["SERVER_NAME"]);
                HostName = "http://" + servername + "/";
            }
            string ErrorPage = HostName + "pages-404.html";
            if (servername.ToLower() != "localhost")
                Response.Redirect(ErrorPage);

        }
 

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}