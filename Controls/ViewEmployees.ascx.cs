using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Controls
{
    public partial class ViewEmployees : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                loadBranches();
                LoadEmployees();
            }
        }
        public void loadBranches()
        {
            ddlBranches.DataSource = helper.ExecutePlainQuery("select * from tbl_Branches");
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("All Branches", "-1"));
            if (Session["BranchID"] != null)
            {
                ddlBranches.SelectedValue = Convert.ToString(Session["BranchID"]);
                ddlBranches.Enabled = false;

            }
            else if (Session["AdminID"] != null)
            {
                ddlBranches.Enabled = true;
            }
        }
        private void LoadEmployees()
        {
            DataTable dt = null;

            if (ddlBranches.SelectedValue != "-1")
            {
                dt = helper.ExecutePlainQuery("select * from vw_Employee where isActive=1 and BranchID=" + ddlBranches.SelectedValue);

            }
            else
            {
                dt = helper.ExecutePlainQuery("select * from vw_Employee where isActive=1");
            }
            rptEmployee.DataSource = dt;
            rptEmployee.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                LinkButton btn = (LinkButton)sender;
                Session["EmployeeID"] = btn.CommandArgument;
                Response.Redirect("AddEmployee.aspx");
            }
            else
            {
                string msg = "Edit is not allowed in master admin";
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-error alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblEmployee employee = new TblEmployee(btn.CommandArgument);
            employee.IsNew = false;
            employee.IsActive = false;
            employee.Save();
            LoadEmployees();
            string msg = "Employee has been deleted!";
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("EmployeeProfile.aspx?val=" + btn.CommandArgument);
         

        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}