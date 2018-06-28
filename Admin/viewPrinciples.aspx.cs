using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Admin
{
    public partial class viewPrinciples : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranches();
                LoadPrinciples();
            }
        }
        public void loadBranches()
        {
            ddlBranches.DataSource = helper.ExecutePlainQuery("select * from tbl_Branches");
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("All Branches", "-1"));

        }
        private void LoadPrinciples()
        {
            if (ddlBranches.SelectedValue!="-1")
            {
                 rptEmployee.DataSource = helper.ExecutePlainQuery("select * from vw_Principles where BranchID="+ddlBranches.SelectedValue);

            }
            else
            {
                rptEmployee.DataSource = helper.ExecutePlainQuery("select * from vw_Principles");

            }
           
            rptEmployee.DataBind();
        }


        
        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrinciples();
        }
    }

}