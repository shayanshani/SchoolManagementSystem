using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace SchoolManagementSystem.DL
{
    public class helper
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        public static void ExecuteQuery(string query, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(prm);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable ExecutePlainQuery(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable Show(string query, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable Show(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void query(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            //cmd.Parameters.AddRange(prm);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string DisplayNotificationMessage(HtmlGenericControl DivID, string msg, string msgClass, HtmlGenericControl IconID, string IconClass)
        {
            DivID.Visible = true;
            DivID.Attributes["class"] = msgClass;
            IconID.Attributes["class"] = IconClass;
            return msg;
        }

        public static void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);

                if (ctrl is DropDownList)
                    ((DropDownList)ctrl).SelectedValue = Convert.ToString(-1);
                ClearInputs(ctrl.Controls);

            }
        }

        public static string Encrypt(string clearText)
      {
          string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
          byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
          using (Aes encryptor = Aes.Create())
          {
              Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
              encryptor.Key = pdb.GetBytes(32);
              encryptor.IV = pdb.GetBytes(16);
              using (MemoryStream ms = new MemoryStream())
              {
                  using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                  {
                      cs.Write(clearBytes, 0, clearBytes.Length);
                      cs.Close();
                  }
                  clearText = Convert.ToBase64String(ms.ToArray());
              }
          }
          return clearText;
      }

        public static string Decrypt(string cipherText)
      {
          string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
          byte[] cipherBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));
          
          using (Aes encryptor = Aes.Create())
          {
              Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
              encryptor.Key = pdb.GetBytes(32);
              encryptor.IV = pdb.GetBytes(16);
              using (MemoryStream ms = new MemoryStream())
              {
                  using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                  {
                      cs.Write(cipherBytes, 0, cipherBytes.Length);
                      cs.Close();
                  }
                  cipherText = Encoding.Unicode.GetString(ms.ToArray());
              }
          }
          return cipherText;
      }

        public static string generateRandomCode(int length)
        {
            Random ran = new Random();
            var arr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            char[] genstring = new char[length];

            for (int a = 0; a < genstring.Length; a++)
            {
                genstring[a] = arr[ran.Next(arr.Length - 1)]; // obj.Next(10)
            }

            string genratedcode = new String(genstring);
            return genratedcode;
        }

        public static DateTime getDateTime()
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            return dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }
        
    }
}