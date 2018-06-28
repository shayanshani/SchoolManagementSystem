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
    public partial class CollegeFeeLedger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchID"] == null & Session["AdminID"] == null)
            {
                Response.Redirect("../administration/LoginPanel.aspx");
            }
            if (!IsPostBack)
            {
                FillYearDropDown();
                BindBranches();
                if (Session["BranchID"] != null)
                {
                    ddlBranch.SelectedValue = Session["BranchID"].ToString();
                    ddlBranch.Enabled = false;
                    BindClass();
                }
                else if (Session["AdminID"] != null)
                {
                    ddlBranch.SelectedValue = "-1";
                    ddlBranch.Enabled = true;
                    BindClass();
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
        private void FillYearDropDown()
        {
            for (int i = 2010; i <= helper.getDateTime().Year; i++)
            {
                ddlSession.Items.Add(i.ToString());
            }
            ddlSession.Items.Insert(0, new ListItem("--Select Year--", ""));
        }
        private void BindClass()
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID=1 and BranchID=" + ddlBranch.SelectedValue);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassNo";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--Select Class--", ""));

        }

        private void BindGrid()
        {
            rptCollegeFeeLedger.DataSource = helper.ExecutePlainQuery("select * from vw_StudentFee where ClassNo=" + ddlClass.SelectedValue + " and BranchID=" + ddlBranch.SelectedValue + " and year(enrollmentdate)=" + ddlSession.Text + " and LedgerType='College'");
            rptCollegeFeeLedger.DataBind();
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "" && ddlSession.SelectedValue != "" && ddlClass.SelectedValue != "")
                BindGrid();
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "")
                BindClass();
            if (ddlBranch.SelectedValue != "" && ddlSession.SelectedValue != "" && ddlClass.SelectedValue != "")
                BindGrid();
        }

        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "" && ddlSession.SelectedValue != "" && ddlClass.SelectedValue != "")
                BindGrid();
        }

    }
}