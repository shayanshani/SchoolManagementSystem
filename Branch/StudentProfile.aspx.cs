using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SchoolManagementSystem.Branch
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["val"] != null)
                {
                    loadStudentInfo(Convert.ToString(Request.QueryString["val"]));
                }
                else
                {
                    Response.Redirect("ViewStudents.aspx");
                }
            }

        }

        private void LoadAttendance(Repeater rptStudentAttendance, HiddenField hfGetBranchID)
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptStudentAttendance.DataBind();
        }

        public void loadStudentInfo(string StudentID)
        {
            rptStudentProfile.DataSource = helper.ExecutePlainQuery(@"select top 1 s.* , cl.ClassName ,cl.ClassName+' '+gr.GroupName as Class 
            from  TblStudents s 
left join 
TblCurrentEnrollment ce on s.StudentID=ce.StudentID
left join tbl_ClassInformation cl on cl.ClassNo=ce.ClassNo
left join tbl_Groups gr on gr.ClassID=cl.ClassNo where s.StudentID=" + StudentID + " order by ce.CEID desc");
            rptStudentProfile.DataBind();
        }

        protected void rptStudentProfile_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hfGetBranchID = (HiddenField)e.Item.FindControl("hfGetBranchID");
            Repeater rptStudentAttendance = (Repeater)e.Item.FindControl("rptStudentAttendance");
            Label lblStudentName = (Label)e.Item.FindControl("lblStudentName");
            Label lblAbsenties = (Label)e.Item.FindControl("lblAbsenties");
            HiddenField hfStudentName = (HiddenField)e.Item.FindControl("hfStudentName");
            var txtDate = (RadDatePicker)e.Item.FindControl("txtDate");
            Label lblTotalAbsenties = (Label)e.Item.FindControl("lblTotalAbsenties");
         

            lblStudentName.Text = hfStudentName.Value;
            if (!String.IsNullOrEmpty(txtDate.SelectedDate.ToString()))
                lblAbsenties.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToDateTime(txtDate.SelectedDate).Month);
            else
                lblAbsenties.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(helper.getDateTime().Month);

            LoadAttendance(rptStudentAttendance, hfGetBranchID);
            GetAbsenties(helper.getDateTime(), lblTotalAbsenties);
        }

        protected void txtDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            for (int i = 0; i < rptStudentProfile.Items.Count; i++)
            {
                HiddenField hfGetBranchID = (HiddenField)rptStudentProfile.Items[i].FindControl("hfGetBranchID");
                Repeater rptStudentAttendance = (Repeater)rptStudentProfile.Items[i].FindControl("rptStudentAttendance");
                Label lblAbsenties = (Label)rptStudentProfile.Items[i].FindControl("lblAbsenties");
                RadDatePicker txtDate = (RadDatePicker)rptStudentProfile.Items[i].FindControl("txtDate");
                Label lblTotalAbsenties = (Label)rptStudentProfile.Items[i].FindControl("lblTotalAbsenties");
              
                if (!String.IsNullOrEmpty(txtDate.SelectedDate.ToString()))
                    lblAbsenties.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(txtDate.SelectedDate).Month);

                LoadAttendance(rptStudentAttendance, hfGetBranchID);
                GetAbsenties(txtDate.SelectedDate, lblTotalAbsenties);
            }
        }

        private void GetAbsenties(DateTime? Date, Label lblTotalAbsenties)
        {
            string qry = String.Format(@"Select
(select count(*) from tbl_Attendance where isPresent=0 
and StudentID={0}
and MONTH(CAST(AttendanceDate as date))=MONTH(Cast('{1}' as date))
and YEAR(CAST(AttendanceDate as date))=YEAR(Cast('{1}' as date))) as Absenties", Convert.ToString(Request.QueryString["val"]),Date);
            DataTable dt = helper.ExecutePlainQuery(qry);
            lblTotalAbsenties.Text = dt.Rows[0]["Absenties"].ToString();
        }
    }
}