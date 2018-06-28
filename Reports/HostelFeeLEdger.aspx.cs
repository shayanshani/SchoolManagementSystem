using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Reports
{
    public partial class HostelFeeLEdger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchID"] == null & Session["AdminID"] == null)
            {
                Response.Redirect("../administration/LoginPanel.aspx");
            }
            if (!IsPostBack)
            {
                BindBranches();
                if (Session["BranchID"] != null)
                {
                    ddlBranch.SelectedValue = Session["BranchID"].ToString();
                    ddlBranch.Enabled = false;
                    BindGrid();
                }
                else if (Session["AdminID"] != null)
                {
                    ddlBranch.SelectedValue = "-1";
                    ddlBranch.Enabled = true;
                    BindGrid();
                }
            }
        }

        private void BindBranches()
        {
            DataTable dt = SPs.SpBranches().GetDataSet().Tables[0];
            ddlBranch.DataSource = dt;
            ddlBranch.DataTextField = "BranchName";
            ddlBranch.DataValueField = "BranchID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("--Select Branch--", ""));
        }

        private void BindGrid()
        {
            rptHostelFeeLedger.DataSource = helper.ExecutePlainQuery("select * from vw_StudentFee where BranchID=" + ddlBranch.SelectedValue + " and IsHostel=1");
            rptHostelFeeLedger.DataBind();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "")
                BindGrid();
        }
    }
}