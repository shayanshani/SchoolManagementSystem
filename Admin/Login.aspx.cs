using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.Data;
using System.Drawing;
using System.Configuration;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btnSignIN_Click(object sender, EventArgs e)
        {
            DataTable dt = TblAdmin.AdminLogin(txtUserName.Text, txtPassword.Text);

            if (dt.Rows.Count > 0)
            {
                if (chkremember.Checked)
                {
                    Response.Cookies["UserName"].Value = txtUserName.Text;
                    Response.Cookies["Password"].Value = txtPassword.Text;
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                Session.Clear();
                Session["AdminID"] = dt.Rows[0]["AdminID"].ToString();
                Session["Email"] = dt.Rows[0]["AdminEmail"].ToString();
                Session["UserName"] = dt.Rows[0]["AdminName"].ToString();
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid UserName or Password!";
            }
        }

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(TblAdmin.Columns.Contact, txtContact.Text);

            if (ConfigurationManager.AppSettings["PinCode"] == txtPinCode.Text)
            {
                if (!String.IsNullOrEmpty(obj.Contact))
                {
                    obj.IsNew = false;
                    obj.VerificationCode = helper.generateRandomCode(5);
                    SendSms.SendMessage(txtContact.Text, "Your password reset code is " + obj.VerificationCode);
                    obj.Save();
                    divReset.Visible = false;
                    divPasswordUpdate.Visible = true;
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Invalid account contact no!";
                }
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid Pin code!";
            }

        }

        protected void btnFPass_Click(object sender, EventArgs e)
        {
            divLogin.Visible = false;
            divReset.Visible = true;
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(TblAdmin.Columns.Contact, txtContact.Text);
            if (!String.IsNullOrEmpty(obj.Contact))
            {
                if (obj.VerificationCode == txtCode.Text)
                {
                    obj.IsNew = false;
                    obj.Password = txtNewPassword.Text;
                    obj.Save();
                    divReset.Visible = false;
                    divPasswordUpdate.Visible = false;
                    divLogin.Visible = true;
                    lblmsg.ForeColor = Color.Green;
                    lblmsg.Text = "Password has been updated!";
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Invalid Code.!";
                }
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid account contact no.!";
            }
        }
    }
}