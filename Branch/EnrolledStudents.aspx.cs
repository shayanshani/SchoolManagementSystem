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
    public partial class EnrolledStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                FillYearDropDown();
                LoadEnrolledStudents();
            }
        }

        private void FillYearDropDown()
        {
            for (int i = 2010; i <= helper.getDateTime().Year; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            ddlYear.Items.Insert(0, new ListItem("--Select Year--", ""));
        }

        private void BindClass(string LevelID)
        {
            if(!String.IsNullOrEmpty(LevelID))
            {
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID=" + LevelID + " and BranchID=" + Session["BranchID"]);
                ddlClass.DataSource = dt;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassNo";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, new ListItem("--Select Class--", ""));
            }
        }

        private void BindGroups(string ClassID)
        {
            if(!String.IsNullOrEmpty(ClassID))
            {
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_Groups where ClassID=" + ClassID + " and BranchID=" + Session["BranchID"]);
                ddlGroups.DataSource = dt;
                ddlGroups.DataTextField = "GroupName";
                ddlGroups.DataValueField = "GroupID";
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem("--Select Group--", ""));
            }
        }

        private void LoadEnrolledStudents()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptEnrolledStudents.DataBind();
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            BindClass(ddlLevel.SelectedValue);
            LoadEnrolledStudents();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGroups.Items.Clear();
            BindGroups(ddlClass.SelectedValue);
            LoadEnrolledStudents();
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEnrolledStudents();
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("StudentProfile.aspx?val=" + btn.CommandArgument);
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {

        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEnrolledStudents();
        }
    }
}