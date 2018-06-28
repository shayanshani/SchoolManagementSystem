using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class HostelAssignTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            if (ddlMemberType.SelectedValue == "0")
                lblEnrolledTo.Text = "Student Name";
            else
                lblEnrolledTo.Text = "Employee Name";

            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptHostelEnrollement.DataBind();
        }
        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddlMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}