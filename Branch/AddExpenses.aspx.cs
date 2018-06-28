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
    public partial class AddExpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();
                cloneData();
                BindExpenseHead();
            }
        }

        private void cloneData()
        {
            if (Session["ExpenseID"] != null)
            {
                TblExpense obj = new TblExpense(Session["ExpenseID"]);
                txtTitle.Text = obj.Title;
                txtDescription.Text = obj.Description;
                txtAmount.Text = obj.Amount.ToString();
                txtExpenseDate.SelectedDate = obj.ExpenseDate;
                ddlExpenseHead.SelectedValue = obj.HeadID.ToString();
            }
        }

        private void BindExpenseHead()
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ExpenseHeads where BranchID=" + Session["BranchID"]);
            ddlExpenseHead.DataSource = dt;
            ddlExpenseHead.DataTextField = "Head";
            ddlExpenseHead.DataValueField = "HeadID";
            ddlExpenseHead.DataBind();
            ddlExpenseHead.Items.Insert(0, new ListItem("--Select Expense Head--", "-1"));
        }


        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Expenses detail has been added!";
              
                TblExpense obj = new TblExpense();
                obj.IsNew = true;

                if (Session["ExpenseID"] != null)
                {
                    obj.IsNew = false;
                    obj = new TblExpense(Session["ExpenseID"]);
                    msg = "Expenses detail has been updated!";
                }

                obj.HeadID = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                
                if (Session["ExpenseID"] == null)
                {
                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.UserID = Convert.ToInt32(Session["BranchUserID"]);
                }
                obj.UpdateBy = Convert.ToInt32(Session["BranchUserID"]);
                obj.DateX = DateTime.Now;
                obj.ExpenseDate = txtExpenseDate.SelectedDate;
                obj.Title = txtTitle.Text.Trim();
                obj.Description = txtDescription.Text.Trim();
                obj.Amount = Convert.ToInt32(txtAmount.Text);
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
                Session["ExpenseID"] = null;
            }
            catch
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Internal Server Error!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }
    }
}