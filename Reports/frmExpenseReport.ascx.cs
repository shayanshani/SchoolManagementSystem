using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.DL;
using System.Data;
using SchoolManagementSystem.BL;
using System.Text;

namespace SchoolManagementSystem.Reports
{
    public partial class frmExpenseReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchID"] == null & Session["AdminID"] == null)
            {
                Response.Redirect("../administration/LoginPanel.aspx");
            }
            if (!IsPostBack)
            {

                loadBranches();
                if (Session["BranchID"] != null)
                {
                    ddBranches.SelectedValue = Convert.ToString(Session["BranchID"]);
                    loadExpenseHead(ddBranches.SelectedValue);
                    ddBranches.Enabled = false;
                }
                else if (Session["AdminID"] != null)
                {
                    ddBranches.SelectedValue = "-1";
                    ddBranches.Enabled = true;
                }
            }





        }
        public void loadBranches()
        {
            ddBranches.DataSource = helper.ExecutePlainQuery("select * from tbl_Branches where IsActive=1");
            ddBranches.DataTextField = "BranchName";
            ddBranches.DataValueField = "BranchID";

            ddBranches.DataBind();
            ddBranches.Items.Insert(0, new ListItem("Select Branch", "-1"));

        }
        public void loadExpenseHead(string BranchID)
        {

            ddlExpenseHead.DataSource = helper.ExecutePlainQuery("select * from tbl_ExpenseHeads where BranchID=" + BranchID);
            ddlExpenseHead.DataTextField = "Head";
            ddlExpenseHead.DataValueField = "HeadID";
            ddlExpenseHead.DataBind();
            ddlExpenseHead.Items.Insert(0, new ListItem("--Select Expense Head--", "-1"));
            ddlExpenseHead.Items.Insert(1, new ListItem("--All Expense Head--", "-2"));
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBranches.SelectedValue != "-1")
            {
                loadExpenseHead(ddBranches.SelectedValue);
            }
            else
            {
                ddlExpenseHead.DataSource = null;
                ddlExpenseHead.DataBind();
            }
        }


        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedValue == "-1")
            {
                devRptSelectedDate.Visible = false;
                devMonthly.Visible = false;
                devRange.Visible = false;
                DivYearlyReport.Visible = false;
            }
            else if (ddlReportType.SelectedValue == "1")
            {
                devRptSelectedDate.Visible = true;
                devMonthly.Visible = false;
                devRange.Visible = false;
                DivYearlyReport.Visible = false;
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                devRptSelectedDate.Visible = false;
                devMonthly.Visible = true;
                devRange.Visible = false;
                DivYearlyReport.Visible = false;
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                devRptSelectedDate.Visible = false;
                devMonthly.Visible = false;
                devRange.Visible = true;
                DivYearlyReport.Visible = false;
            }
            else if (ddlReportType.SelectedValue == "4")
            {
                devRptSelectedDate.Visible = false;
                devMonthly.Visible = false;
                devRange.Visible = false;
                DivYearlyReport.Visible = true;
            }
        }

        protected void btnShowSelectedReport_Click(object sender, EventArgs e)
        {
            DataTable dt = TblExpense.GetSelectedDateReport(Convert.ToInt32(ddBranches.SelectedValue), Convert.ToInt32(ddlExpenseHead.SelectedValue), Convert.ToDateTime(txtselectDailyDate.SelectedDate));
            if (dt.Rows.Count > 0)
            {

                ExpenseReport.GetExpenseDetails = dt;
                ExpenseReport.BranchName = ddBranches.SelectedItem.Text;
                ExpenseReport.ExpenseHead = ddlExpenseHead.SelectedItem.Text;
                ExpenseReport.rptType = "Expense Date " + Convert.ToDateTime(txtselectDailyDate.SelectedDate).ToString("dd-MM-yyyy");
                string pageurl = "../Reports/ExpenseReport.aspx";
                //Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                ScriptManager.RegisterClientScriptBlock(this.pnl, this.pnl.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
            }
        }

        protected void btnShowMonthlyReport_Click(object sender, EventArgs e)
        {
            DataTable dt = TblExpense.GetSelectedMonthReport(Convert.ToInt32(ddBranches.SelectedValue), Convert.ToInt32(ddlExpenseHead.SelectedValue), ddlFromMonth.SelectedValue, ddlFromYear.SelectedItem.Text);
            if (dt.Rows.Count > 0)
            {

                ExpenseReport.GetExpenseDetails = dt;
                ExpenseReport.BranchName = ddBranches.SelectedItem.Text;
                ExpenseReport.ExpenseHead = ddlExpenseHead.SelectedItem.Text;
                ExpenseReport.rptType = "For Date " + ddlFromMonth.SelectedItem.Text + " , " + ddlFromYear.SelectedItem.Text;
                string pageurl = "../Reports/ExpenseReport.aspx";
              //  Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                ScriptManager.RegisterClientScriptBlock(this.pnl, this.pnl.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
            }
        }

        protected void btnShowRangeReport_Click(object sender, EventArgs e)
        {
            DataTable dt = TblExpense.GetDateRangeReport(Convert.ToInt32(ddBranches.SelectedValue), Convert.ToInt32(ddlExpenseHead.SelectedValue), Convert.ToDateTime(txtRangeFromDate.SelectedDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtToRangeDate.SelectedDate).ToString("yyyy-MM-dd"));
            if (dt.Rows.Count > 0)
            {

                ExpenseReport.GetExpenseDetails = dt;
                ExpenseReport.BranchName = ddBranches.SelectedItem.Text;
                ExpenseReport.ExpenseHead = ddlExpenseHead.SelectedItem.Text;
                ExpenseReport.rptType = "For Date " + Convert.ToDateTime(txtRangeFromDate.SelectedDate).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(txtToRangeDate.SelectedDate).ToString("dd-MM-yyyy");
                string pageurl = "../Reports/ExpenseReport.aspx";
               // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                ScriptManager.RegisterClientScriptBlock(this.pnl, this.pnl.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
            }
        }

        protected void btnShowYearlyReport_Click(object sender, EventArgs e)
        {
            DataTable dt = TblExpense.GetSelectedYearReport(Convert.ToInt32(ddBranches.SelectedValue), Convert.ToInt32(ddlExpenseHead.SelectedValue), ddlYear.SelectedItem.Text);
            if (dt.Rows.Count > 0)
            {

                ExpenseReport.GetExpenseDetails = dt;
                ExpenseReport.BranchName = ddBranches.SelectedItem.Text;
                ExpenseReport.ExpenseHead = ddlExpenseHead.SelectedItem.Text;
                ExpenseReport.rptType = "For Year " + ddlYear.SelectedItem.Text;
                string pageurl = "../Reports/ExpenseReport.aspx";
               // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                 ScriptManager.RegisterClientScriptBlock(this.pnl, this.pnl.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
            }
        }






    }
}