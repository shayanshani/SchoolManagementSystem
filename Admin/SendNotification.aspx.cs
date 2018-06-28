using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.Data;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class SendNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBranches();
            }
        }

        private void BindBranches()
        {
            DataTable dt=SPs.SpBranches().GetDataSet().Tables[0];
            ddlBranches.DataSource = dt;
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("--Select Branch--", "-1"));
            ddlBranches.Items.Insert(1, new ListItem("--All Branches--", "-2"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblNotificationAlert obj = new TblNotificationAlert();
               
                if (ddlBranches.SelectedValue == "-2")
                {
                    DataTable dt = helper.ExecutePlainQuery("select * from tbl_Branches where isActive=1");

                    foreach(DataRow dr in dt.Rows)
                    {
                        obj.IsNew = true;
                        obj.BranchID = Convert.ToInt32(dr["BranchID"]);
                        obj.NotificationDate = helper.getDateTime();
                        obj.NotificationFrom = Session["Email"].ToString();
                        obj.NotificationMessage = txtMessage.Text;
                        obj.NotificationTo = txtNotificationTo.Text;
                        obj.NotificationSubject = txtSubject.Text;
                        obj.NotificationCode = helper.generateRandomCode(4);
                        obj.IsActive = true;
                        obj.IsRead = false;
                        obj.Save();
                    }
                }
                else
                {
                    obj.IsNew = true;
                    obj.BranchID = Convert.ToInt32(ddlBranches.SelectedValue);
                    obj.NotificationDate = helper.getDateTime();
                    obj.NotificationFrom = Session["Email"].ToString();
                    obj.NotificationMessage = txtMessage.Text;
                    obj.NotificationTo = txtNotificationTo.Text;
                    obj.NotificationSubject = txtSubject.Text;
                    obj.NotificationCode = helper.generateRandomCode(4);
                    obj.IsActive = true;
                    obj.IsRead = false;
                    obj.Save();
                }
               
                
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Notification has been sent!", "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
            }
            catch(Exception ex) {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranches.SelectedValue == "-2")
                txtNotificationTo.Text = "Notification for all branches";
            else if (ddlBranches.SelectedValue == "-1")
                txtNotificationTo.Text = "";
            else
                txtNotificationTo.Text = ddlBranches.SelectedItem.Text;
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}