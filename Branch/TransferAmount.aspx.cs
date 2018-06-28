using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class TransferAmount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBranches();
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
            string msg = "Amount has been transfered!";
            TblAmountTransfer obj = new TblAmountTransfer();
            obj.IsNew = true;

            if (!String.IsNullOrEmpty(Convert.ToString(hfAmountID.Value)))
            {
                obj.IsNew = false;
                obj = new TblAmountTransfer(hfAmountID.Value);
                msg = "Transfer detail has been updated!";
            }
            obj.SenderID = Convert.ToInt32(Session["BranchID"]);
            obj.RecieverID = Convert.ToInt32(ddlBranches.SelectedValue);
            obj.Amount = Convert.ToInt32(txtAmount.Text);
            obj.Description = txtDesciption.Text;
            obj.DateX = helper.getDateTime();
            obj.Save();
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(Page.Controls);
            hfAmountID.Value = string.Empty;
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}