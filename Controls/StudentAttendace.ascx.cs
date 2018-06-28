using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Controls
{
    public partial class StudentAttendace : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindClass(string LevelID)
        {
            if (!String.IsNullOrEmpty(LevelID))
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
            if (!String.IsNullOrEmpty(ClassID))
            {
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_Groups where ClassID=" + ClassID + " and BranchID=" + Session["BranchID"]);
                ddlGroups.DataSource = dt;
                ddlGroups.DataTextField = "GroupName";
                ddlGroups.DataValueField = "GroupID";
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem("--Select Group--", ""));
            }
        }

        private void LoadAttendance()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptStudentAttendance.DataBind();
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            BindClass(ddlLevel.SelectedValue);
           // LoadAttendance();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGroups.Items.Clear();
            BindGroups(ddlClass.SelectedValue);
            //LoadAttendance();
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadAttendance();
        }

        protected void txtDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            lblAbsenties.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToDateTime(txtDate.SelectedDate).Month); 
            LoadAttendance();
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("StudentProfile.aspx?val=" + btn.CommandArgument);
        }
    }
}