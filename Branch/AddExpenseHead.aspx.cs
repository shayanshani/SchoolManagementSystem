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
    public partial class AddExpenseHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindExpenseHead();
            }
        }

        private void BindExpenseHead()
        {
            rptExpHeads.DataSource = helper.ExecutePlainQuery("select * from tbl_ExpenseHeads where BranchID=" + Session["BranchID"]);
            rptExpHeads.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_ExpenseHeads where Head='" + txtExpenseHead.Text + "' and BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hfHeadID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtExpenseHead.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Expense Head has been added!";
                    TblExpenseHead obj = new TblExpenseHead();
                    obj.IsNew = true;

                    if (!String.IsNullOrEmpty(hfHeadID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblExpenseHead(hfHeadID.Value);
                        msg = "Expense Head has been updated!";
                    }

                    obj.Head = txtExpenseHead.Text;
                    obj.BranchID =Convert.ToInt16(Session["BranchID"]);
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfHeadID.Value = null;
                    BindExpenseHead();
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Internal Server Error!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton ExpenseHeadID = (LinkButton)sender;
            TblExpense obj = new TblExpense(TblExpense.Columns.HeadID, ExpenseHeadID.CommandArgument);
            if (obj.ExpenseID != 0)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Some expenses against " + ExpenseHeadID.CommandName + " are exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
            else
            {
                TblExpenseHead.Delete(ExpenseHeadID.CommandArgument);
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Expense head has been deleted successfully!", "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                BindExpenseHead();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton HeadID = (LinkButton)sender;
            TblExpenseHead obj = new TblExpenseHead(HeadID.CommandArgument);
            txtExpenseHead.Text = obj.Head;
            hfHeadID.Value = HeadID.CommandArgument;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}