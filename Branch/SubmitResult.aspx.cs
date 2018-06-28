using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class SubmitResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void BindData(string ClassID)
        {
            rptSubmitResult.DataSource = helper.ExecutePlainQuery(@"select * from TblStudents inner join TblCurrentEnrollment on TblStudents.StudentID=TblCurrentEnrollment.StudentID where TblCurrentEnrollment.ClassNo='" + ClassID + "' and TblStudents.BranchID=" + Convert.ToString(Session["BranchID"]));
            rptSubmitResult.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(ddlClass.SelectedValue);
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClasses(ddlLevel.SelectedValue);
            BindData(ddlClass.SelectedValue);
        }

        private void BindClasses(string LevelID)
        {
            ddlClass.DataSource = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID=" + LevelID + " and BranchID=" + Convert.ToString(Session["BranchID"]));
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassNo";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("Select Class", "-1"));
        }

        // public int getVal()
        // {
        //     return items;
        // }

        //public static int items=0;

        public static DataTable dtHeadings;

        protected void rptSubmitResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlControl thStudentName = e.Item.FindControl("thStudentName") as HtmlControl;
                Repeater rptHeadings = e.Item.FindControl("rptHeadings") as Repeater;
                dtHeadings = helper.ExecutePlainQuery(@"select * from tbl_Subjects inner join tbl_AssignSubject on tbl_Subjects.SubjectID=tbl_AssignSubject.SubjectID where ClassID='" + ddlClass.SelectedValue + "' and BranchID=" + Convert.ToString(Session["BranchID"]));
                rptHeadings.DataSource = dtHeadings;
                rptHeadings.DataBind();
                // items = dtHeadings.Rows.Count;
                thStudentName.Visible = true;
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptMarks = e.Item.FindControl("rptMarks") as Repeater;
                rptMarks.DataSource = dtHeadings;
                rptMarks.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HiddenField hfStudentID = null, hfSubjectID = null;
            Repeater rptMarks = null;
            TextBox txtMarks = null;
            for (int i = 0; i < rptSubmitResult.Items.Count; i++)
            {
                hfStudentID = (HiddenField)rptSubmitResult.Items[i].FindControl("hfStudentID");
                rptMarks = (Repeater)rptSubmitResult.Items[i].FindControl("rptMarks");

                for (int j = 0; j <= rptMarks.Items.Count-1; j++)
                {
                    hfSubjectID = (HiddenField)rptMarks.Items[j].FindControl("hfSubjectID");    
                    txtMarks = (TextBox)rptMarks.Items[j].FindControl("txtMarks");
                    TblStudentResult obj = new TblStudentResult();
                    obj.IsNew = true;
                    obj.StudentID = Convert.ToInt32(hfStudentID.Value);
                    obj.SubjectID = Convert.ToInt32(hfSubjectID.Value);
                    obj.Marks = Convert.ToInt32(txtMarks.Text);
                    obj.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.Save();
                }
            }

            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Result for "+ddlClass.SelectedItem.Text+" has been submited!", "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(Page.Controls);
        }
    }
}