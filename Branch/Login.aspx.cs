using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["BranchUserName"] != null && Request.Cookies["BracnhUserPassword"] != null)
                {
                    txtBranchName.Text = Request.Cookies["BranchUserName"].Value;
                    txtBranchPassword.Attributes["value"] = Request.Cookies["BracnhUserPassword"].Value;
                }
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            TblBranchUser obj = new TblBranchUser(TblBranchUser.Columns.Contact, txtContact.Text);
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

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            TblBranchUser obj = new TblBranchUser(TblBranchUser.Columns.Contact, txtContact.Text);
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
                lblmsg.Text = "Invalid account contact no.!";
            }
        }

        protected void btnSignIN_Click(object sender, EventArgs e)
        {
            DataTable dt = TblBranchUser.BranchUserLogin(txtBranchName.Text, txtBranchPassword.Text);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["ActiveUser"]) == false)
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Account is deactivated! <br> Please contact with administration";
                }
                else
                {
                    Session.Clear();
                    Session["BranchUserID"] = dt.Rows[0]["UserID"].ToString();
                    if (Convert.ToBoolean(dt.Rows[0]["isFirst"]) == true)
                    {
                        divLogin.Visible = false;
                        divFirstLogin.Visible = true;
                    }
                    else
                    {
                        if (chkremember.Checked)
                        {
                            Response.Cookies["BranchUserName"].Value = txtBranchName.Text;
                            Response.Cookies["BracnhUserPassword"].Value = txtBranchPassword.Text;
                            Response.Cookies["BranchUserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["BracnhUserPassword"].Expires = DateTime.Now.AddDays(30);
                        }
                        Session["BranchID"] = dt.Rows[0]["BranchID"].ToString();
                        Session["BranchUserEmail"] = dt.Rows[0]["Email"].ToString();
                        Session["BranchUserName"] = dt.Rows[0]["UserName"].ToString();
                        Session["BranchName"] = dt.Rows[0]["BranchName"].ToString();
                        Response.Redirect("Index.aspx");
                    }
                }

            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid UserName or Password!";
            }
        }

        protected void btnFPass_Click(object sender, EventArgs e)
        {
            divLogin.Visible = false;
            divReset.Visible = true;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            TblBranchUser obj = new TblBranchUser(Session["BranchUserID"]);
            obj.IsNew = false;
            obj.IsFirst = false;
            obj.Password = txtfNewPassword.Text;
            obj.Save();
            divLogin.Visible = true;
            divFirstLogin.Visible = false;
        }
    }
}