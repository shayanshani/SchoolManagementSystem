using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class ManageUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBranches();
                rptUsers.DataBind();
            }
        }

        private void BindBranches()
        {
            DataTable dt = SPs.SpBranches().GetDataSet().Tables[0];
            ddlBranches.DataSource = dt;
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("--Select Branch--", ""));
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton userID = (LinkButton)sender;
                TblBranchUser obj = new TblBranchUser(userID.CommandArgument);
                obj.IsActive = false;
                obj.IsNew = false;
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "User detail has been deleted!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                rptUsers.DataBind();
            }
            catch(Exception ex) {
            
            }
          
        }

        protected void DDLFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptUsers.DataBind();
        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptUsers.DataBind();
        }
    }
}