using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class AddBranchUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBranches();
                if (Request.QueryString["BranchID"] != null)
                {
                    ddlBranches.SelectedValue = Request.QueryString["BranchID"];
                    loadData(ddlBranches.SelectedValue);
                }

            }
        }

        private void loadData(string BranchID)
        {
            hfUserID.Value = string.Empty;
            TblBranchUser obj = new TblBranchUser(TblBranchUser.Columns.BranchID, BranchID);

            if (obj.UserID != 0)
            {
                hfUserID.Value = obj.UserID.ToString();
                txtUserName.Text = obj.UserName;
                txtContact.Text = obj.Contact;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                //   reqFile.Enabled = false;
            }
            else
            {
                //foreach (Control ctrl in this.Controls)
                //{
                //    if (ctrl is TextBox)
                //        ((TextBox)ctrl).Text = string.Empty;
                //}
                txtUserName.Text = string.Empty;
                txtContact.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtAddress.Text = string.Empty;
            }
        }

        private void BindBranches()
        {
            DataTable dt = SPs.SpBranches().GetDataSet().Tables[0];
            ddlBranches.DataSource = dt;
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("--Select Branch--", "-1"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_BranchUser where Email='" + txtEmail.Text + "'").Rows.Count > 0 && String.IsNullOrEmpty(Convert.ToString(hfUserID.Value)))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtEmail.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
                }
                else
                {
                    string msg = "User detail has been added!";
                    TblBranchUser obj = new TblBranchUser();
                    obj.IsNew = true;

                    if (!String.IsNullOrEmpty(Convert.ToString(hfUserID.Value)))
                    {
                        obj.IsNew = false;
                        obj = new TblBranchUser(hfUserID.Value);
                        msg = "User detail has been updated!";
                    }

                    obj.BranchID = Convert.ToInt16(ddlBranches.SelectedValue);
                    obj.UserName = txtUserName.Text;
                    obj.Contact = txtContact.Text;
                    obj.Email = txtEmail.Text;
                    obj.Image = "N/A";
                    obj.Address = txtAddress.Text;
                    obj.IsActive = true;

                    if (obj.IsNew == true)
                    {
                        obj.IsFirst = true;
                        obj.Password = helper.generateRandomCode(5);
                        SendSms.SendMessage(txtContact.Text, "Your account has been registered! Your password is " + obj.Password);
                        SendEmail.Mail(txtEmail.Text, "Password", "Your account has been registered! Your password is " + obj.Password);
                    }

                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfUserID.Value = string.Empty;
                    //   reqFile.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData(ddlBranches.SelectedValue);
        }
    }
}