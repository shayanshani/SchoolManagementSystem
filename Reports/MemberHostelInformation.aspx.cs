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
    public partial class MemberHostelInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("~/Branch/Login.aspx");
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
            if (ddlType.SelectedValue == "0")
            {
                rptStudent.DataSource = helper.ExecutePlainQuery("select * from vw_StudentHostelInformation where BranchID=" + ddlBranch.SelectedValue + " and IsActive=1");
                rptStudent.DataBind();
                divEmployee.Visible = false;
                divStudent.Visible = true;
            }
            else
            {
                rptEmployee.DataSource = helper.ExecutePlainQuery("select * from vw_EmployeeHostelInformation where BranchID=" + ddlBranch.SelectedValue + " and IsActive=1");
                rptEmployee.DataBind();
                divStudent.Visible = false;
                divEmployee.Visible = true;
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "")
                BindGrid();
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}