using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.DL;
using SchoolManagementSystem.BL;
namespace SchoolManagementSystem.Branch
{
    public partial class ViewEditExpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if(!IsPostBack)
            {
                BindExpenses();
            }
        }

        private void BindExpenses()
        {
            rptExpenses.DataSource = helper.ExecutePlainQuery("select * from vw_Expenses  where BranchID=" + Session["BranchID"]);
            rptExpenses.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton ExpenseID = (LinkButton)sender;
                Session["ExpenseID"] = ExpenseID.CommandArgument;
                Response.Redirect("AddExpenses.aspx");
            }
            catch { }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton ExpenseID = (LinkButton)sender;
                TblExpense.Delete(ExpenseID.CommandArgument);
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Expenses detail has been deleted!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                BindExpenses();
            }
            catch { }
        }
    }
}