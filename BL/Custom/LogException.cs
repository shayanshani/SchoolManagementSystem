using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL.Custom
{
    public class LogException
    {
        public LogException() //ctor
        {
        }
        public void HandleException(Exception ex)
        {
            HttpContext ctx = HttpContext.Current;
            string strData = String.Empty;
            int evtId = 0;
            bool logIt = true;
            // Convert.ToBoolean(ConfigurationManager.AppSettings["logErrors"]);
            if (logIt)
            {
                string dbConnString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

                string referer = String.Empty;
                if (ctx.Request.ServerVariables["HTTP_REFERER"] != null)
                {
                    referer = ctx.Request.ServerVariables["HTTP_REFERER"].ToString();
                }
                string sForm = (ctx.Request.Form != null) ? ctx.Request.Form.ToString() : String.Empty;

                string logDateTime = DateTime.Now.ToString();
                string sQuery = (ctx.Request.QueryString != null) ? ctx.Request.QueryString.ToString() : String.Empty;
                strData = "\nSOURCE: " + ex.Source +
                "\nLogDateTime: " + logDateTime +
                "\nMESSAGE: " + ex.Message +
               "\nFORM: " + sForm +
               "\nQUERYSTRING: " + sQuery +
               "\nTARGETSITE: " + ex.TargetSite +
               "\nSTACKTRACE: " + ex.StackTrace +
               "\nREFERER: " + referer +
                "\nInnerException: " + ex.InnerException;



                if (dbConnString.Length > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ExceptionsLog_Insert";
                    SqlConnection cn = new SqlConnection(dbConnString);
                    cmd.Connection = cn;
                    cn.Open();
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@Source", ex.Source));
                        cmd.Parameters.Add(new SqlParameter("@LogDateTime", logDateTime));
                        cmd.Parameters.Add(new SqlParameter("@Message", ex.Message)); cmd.Parameters.Add(new SqlParameter("@Form", sForm));
                        cmd.Parameters.Add(new SqlParameter("@QueryString", sQuery));
                        cmd.Parameters.Add(new SqlParameter("@TargetSite", ex.TargetSite.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@StackTrace", ex.StackTrace.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Referer", referer));
                        cmd.Parameters.Add(new SqlParameter("@InnerException", ex.InnerException.ToString()));
                        //SqlParameter outParm = new SqlParameter("@EventId", SqlDbType.Int);
                        //outParm.Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(outParm);
                        cmd.ExecuteNonQuery();
                        // evtId = Convert.ToInt32(cmd.Parameters[8].Value);
                        cmd.Dispose();
                        cn.Close();
                    }
                    catch (Exception exc)
                    {

                        //EventLog.WriteEntry(ex.Source, "Database Error From Exception Log!", EventLogEntryType.Error, 65535);
                    }
                    finally
                    {
                        cmd.Dispose();
                        cn.Close();
                    }
                    try
                    {
                        EventLog.WriteEntry(ex.Source, strData, EventLogEntryType.Error, evtId);
                    }
                    catch (Exception exl)
                    {
                        Debug.WriteLine("EventLog Write Error: " + exl.Message);
                    }
                }
            }

            //string strEmails = System.Configuration.ConfigurationSettings.AppSettings["emailAddresses"].ToString();
            //if (strEmails.Length > 0)
            //{
            //    string[] emails = strEmails.Split(Convert.ToChar("|"));
            //    MailMessage msg = new MailMessage();
            //    msg.BodyFormat = MailFormat.Text;
            //    msg.To = emails[0];

            //    for (int i = 1; i < emails.Length; i++)
            //        msg.Cc = emails[i];

            //    string fromEmail = System.Configuration.ConfigurationSettings.AppSettings["fromEmail"].ToString();
            //    msg.From = fromEmail;
            //    msg.Subject = "Web application error!";
            //    string detailURL =
            //        System.Configuration.ConfigurationSettings.AppSettings["detailURL"].ToString();
            //    msg.Body = strData + detailURL + "?EvtId=" + evtId.ToString();
            //    SmtpMail.SmtpServer =
            //        System.Configuration.ConfigurationSettings.AppSettings["smtpServer"].ToString();
            //    try
            //    {

            //        SmtpMail.Send(msg);
            //    }
            //    catch (Exception excm)
            //    {
            //        Debug.WriteLine(excm.Message);

            //    }
            //}
            //else
            //{
            //    return;
            //}
        }
    }
}