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
    public partial class StudentPromotion : System.Web.UI.Page
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

        private void BindClass(string LevelID, DropDownList ddlclass)
        {
            if (!String.IsNullOrEmpty(LevelID))
            {
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID=" + LevelID + " and BranchID=" + Session["BranchID"]);
                ddlclass.DataSource = dt;
                ddlclass.DataTextField = "ClassName";
                ddlclass.DataValueField = "ClassNo";
                ddlclass.DataBind();
                ddlclass.Items.Insert(0, new ListItem("--Select Class--", ""));
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

        private void LoadEnrolledStudents()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptEnrolledStudents.DataBind();
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("StudentProfile.aspx?val=" + btn.CommandArgument);
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            BindClass(ddlLevel.SelectedValue, ddlClass);
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

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEnrolledStudents();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
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

        protected void btnSchPromotion_Click(object sender, EventArgs e)
        {
            LinkButton btnSchPromotion = (LinkButton)sender;
            hfstudentID.Value = btnSchPromotion.CommandArgument;
            hfLevel.Value = "1";
            divGroup.Visible = false;
            DataTable dt = null, dtFee = null;
            //DataTable dt = helper.ExecutePlainQuery("select * from TblCurrentEnrollment where TblCurrentEnrollment.StudentID=" + btnSchPromotion.CommandArgument + " and isActive=1 and BranchID=" + Session["BranchID"]);
            //if (dt.Rows.Count > 0)
            //{
            //    BindClass("1", ddlClassP);
            //    ddlLevelP.SelectedValue = "1";
            //    ddlClassP.SelectedValue = dt.Rows[0]["ClassNo"].ToString();
            //    LoadGroup(ddlClassP.SelectedValue);
            //    txtEnrollmentDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["EnrollmentDate"]);
            //    //hfEnrollementID.Value = dt.Rows[0]["CEID"].ToString();
            //}
            //else
            //{

            //}

            dt = helper.ExecutePlainQuery(string.Format(@"select
(select max(CEID) from TblCurrentEnrollment where StudentID={0} and isActive=1 and BranchID={1} and CEID={2}) as CEID", hfstudentID.Value, Session["BranchID"], btnSchPromotion.CommandName));
            dtFee = helper.ExecutePlainQuery(string.Format(@"select max(SchFeeID) as SchFeeID from tbl_SchFeeStructure where StudentID={0} and isActive=1", hfstudentID.Value));
            if (dt.Rows.Count > 0 && dtFee.Rows.Count > 0)
            {
                hfschFeeID.Value = dtFee.Rows[0]["SchFeeID"].ToString();
                hfEnrollementIDToUpdate.Value = dt.Rows[0]["CEID"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnClgPromotion_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Student promotion has been submitted!";

            TblCurrentEnrollment objpromotion = new TblCurrentEnrollment();
            objpromotion.IsNew = true;

            if (!string.IsNullOrEmpty(hfEnrollementID.Value))
            {
                objpromotion = new TblCurrentEnrollment(hfEnrollementID.Value);
                objpromotion.IsNew = false;
                msg = "Student promotion has been updated!";
            }

            if (objpromotion.IsNew)
            {
                TblCurrentEnrollment objprev = new TblCurrentEnrollment(hfEnrollementIDToUpdate.Value);
                objprev.IsNew = false;
                objprev.IsActive = 0;
                objprev.Save();

                TblSchFeeStructure objSch = new TblSchFeeStructure(hfschFeeID.Value);
                objSch.IsNew = false;
                objSch.IsActive = 0;
                objSch.Save();
            }

            objpromotion.StudentID = Convert.ToInt32(hfstudentID.Value);
            objpromotion.ClassNo = Convert.ToInt32(ddlClassP.SelectedValue);
            objpromotion.BranchID = Convert.ToInt32(Session["BranchID"]);
            objpromotion.EnrollmentDate = txtEnrollmentDate.SelectedDate;
            objpromotion.IsActive = 1;
            if (objpromotion.IsNew)
                objpromotion.CreateBy = Convert.ToString(Session["BranchUserID"]);
            else
                objpromotion.UpdatedBy = Convert.ToString(Session["BranchUserID"]);

            if (ddlLevelP.SelectedValue == "2")
            {
                objpromotion.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
            }
            else
            {
                objpromotion.GroupID = null;
            }
            objpromotion.Save();

           // lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            //helper.ClearInputs(this.pnlDrop.Controls);
            hfstudentID.Value = "";
            txtEnrollmentDate.SelectedDate = null;
            ddlLevelP.SelectedValue = "-1";
            ddlClassP.SelectedIndex = 0;
            hfEnrollementID.Value = "";
            hfEnrollementIDToUpdate.Value = "";
            //LoadEnrolledStudents();
            DataTable dt = helper.ExecutePlainQuery("select StudentID,RegistrationNo from TblStudents where StudentID=" + objpromotion.StudentID);
            Response.Redirect("SchFeeEnrolement.aspx?val=" + dt.Rows[0]["RegistrationNo"]);
        }

        protected void ddlClassP_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroup(ddlClass.SelectedValue);
        }

        protected void ddlLevelP_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass(ddlLevelP.SelectedValue, ddlClassP);
        }
    }
}