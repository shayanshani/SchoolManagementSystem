using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.IO;
using System.Data;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class AddBranches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BranchEditID"] != null)
                {
                    TblBranch obj = new TblBranch(Session["BranchEditID"]);
                    txtBranchName.Text = obj.BranchName;
                    txtPhoneNo.Text = obj.BPhoneNo;
                    txtAddress.Text = obj.BAddress;
                    ddlStatus.SelectedValue = obj.IsActive.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_Branches where BranchName='" + txtBranchName.Text + "'").Rows.Count > 0 && String.IsNullOrEmpty(Convert.ToString(Session["BranchEditID"])))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtBranchName.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Branch has been added!";
                    TblBranch obj = new TblBranch();
                    obj.IsNew = true;

                    if (Session["BranchEditID"] != null)
                    {
                        obj.IsNew = false;
                        obj = new TblBranch(Session["BranchEditID"]);
                        msg = "Branch has been updated!";
                    }

                    obj.BranchName = txtBranchName.Text;
                    obj.BPhoneNo = txtPhoneNo.Text;
                    obj.BAddress = txtAddress.Text;
                    obj.IsActive = Convert.ToInt32(ddlStatus.SelectedValue);
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    Session["BranchEditID"] = null;
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
    }
}