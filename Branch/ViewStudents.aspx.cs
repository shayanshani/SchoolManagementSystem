using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class ViewStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                // cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();

                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            rptStudents.DataSource = helper.ExecutePlainQuery("select *,(select count(*) from tbl_ClgFeeStructure where tbl_ClgFeeStructure.StudentID=TblStudents.StudentID and tbl_ClgFeeStructure.isActive=1) as CFeeStatus,(select count(*) from tbl_SchFeeStructure where tbl_SchFeeStructure.StudentID=TblStudents.StudentID and tbl_SchFeeStructure.isActive=1) as SFeeStatus,(select count(*) from TblCurrentEnrollment where TblCurrentEnrollment.StudentID=TblStudents.StudentID) as EnrollemntStatus from TblStudents where isActive=1 and BranchID=" + Session["BranchID"]);
            rptStudents.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["StudentID"] = btn.CommandArgument;
            Response.Redirect("StudentAdmission.aspx");
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("StudentProfile.aspx?val=" + btn.CommandArgument);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblCurrentEnrollment obj = new TblCurrentEnrollment();
            obj.IsNew = true;
            string msg = "Student has been enrolled!";

            if (hfEnrollementID.Value != "")
            {
                obj = new TblCurrentEnrollment(hfEnrollementID.Value);
                obj.IsNew = false;
                msg = "Student Enrollment has been updated!";
            }

            obj.StudentID = Convert.ToInt32(hfstudentID.Value);
            obj.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
            obj.BranchID = Convert.ToInt32(Session["BranchID"]);
            obj.EnrollmentDate = txtEnrollmentDate.SelectedDate;
            obj.IsActive = Convert.ToInt32(ddlStatus.SelectedValue);

            if (obj.IsNew)
            {
                obj.CreateBy = Convert.ToString(Session["BranchUserID"]);
            }
            else
            {
                obj.UpdatedBy = Convert.ToString(Session["BranchUserID"]);
            }

            if (hfLevel.Value == "2")
            {
                obj.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
            }
            else
            {
                obj.GroupID = null;
            }

            obj.Save();

            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(this.Controls);
            hfstudentID.Value = "";
            hfLevel.Value = "";
            txtEnrollmentDate.SelectedDate = null;
            hfEnrollementID.Value = "";
            LoadStudents();
        }

        protected void btnSchoolEnroll_Click(object sender, EventArgs e)
        {
            LinkButton btnSchEnro = (LinkButton)sender;
            hfstudentID.Value = btnSchEnro.CommandArgument;
            BindClasses(btnSchEnro.CommandName);
            hfLevel.Value = btnSchEnro.CommandName;
            divGroup.Visible = false;
            DataTable dt = helper.ExecutePlainQuery("select * from TblCurrentEnrollment where TblCurrentEnrollment.StudentID=" + btnSchEnro.CommandArgument);
            if (dt.Rows.Count > 0)
            {
                BindClasses(btnSchEnro.CommandName);
                ddlClass.SelectedValue = dt.Rows[0]["ClassNo"].ToString();
                LoadGroup(ddlClass.SelectedValue);
                //  ddlGroup.SelectedValue = dt.Rows[0]["GroupID"].ToString();
                txtEnrollmentDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EnrollmentDate"]);
                ddlStatus.SelectedValue = dt.Rows[0]["isActive"].ToString();
                hfEnrollementID.Value = dt.Rows[0]["CEID"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnClgEnroll_Click(object sender, EventArgs e)
        {
            LinkButton btnClgEnro = (LinkButton)sender;
            hfstudentID.Value = btnClgEnro.CommandArgument;
            BindClasses(btnClgEnro.CommandName);
            hfLevel.Value = btnClgEnro.CommandName;
            divGroup.Visible = true;
            DataTable dt = helper.ExecutePlainQuery("select * from TblCurrentEnrollment where TblCurrentEnrollment.StudentID=" + btnClgEnro.CommandArgument);
            if (dt.Rows.Count > 0)
            {
                BindClasses(btnClgEnro.CommandName);
                ddlClass.SelectedValue = dt.Rows[0]["ClassNo"].ToString();
                LoadGroup(ddlClass.SelectedValue);
                ddlGroup.SelectedValue = dt.Rows[0]["GroupID"].ToString();
                txtEnrollmentDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EnrollmentDate"]);
                ddlStatus.SelectedValue = dt.Rows[0]["isActive"].ToString();
                hfEnrollementID.Value = dt.Rows[0]["CEID"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        private void BindClasses(string LevelID)
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where  LevelID=" + LevelID + " and BranchID=" + Session["BranchID"]);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassNo";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--Select class--", "-1"));
        }

        private void LoadGroup(string ClassID)
        {
            try
            {
                Query qry = new Query(TblGroup.Schema);
                qry.AddWhere(TblGroup.Columns.BranchID, Comparison.Equals, Session["BranchID"]).
                    AND(TblGroup.Columns.ClassID, Comparison.Equals, ClassID);
                ddlGroup.DataSource = qry.ExecuteDataSet().Tables[0];
                ddlGroup.DataValueField = "GroupID";
                ddlGroup.DataTextField = "GroupName";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("--Select Group--", "-1"));
            }
            catch
            { }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroup(ddlClass.SelectedValue);
        }
    }
}