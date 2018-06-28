using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using System.Data;

namespace SchoolManagementSystem.Branch
{
    public partial class ManageAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //BindClass(ddlLevel.SelectedValue);
                //LoadStudents();
                if (Request.QueryString["msg"] != null)
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, helper.Decrypt(Request.QueryString["msg"]), "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
            }
        }


        private void LoadStudents()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptStudents.DataBind();
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Response.Redirect("StudentProfile.aspx?val=" + btn.CommandArgument);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckBox chk = null;
            HiddenField hfStudentID = null, hfClassNo = null;
            bool IsPresent = true;
            for (int i = 0; i < rptStudents.Items.Count; i++)
            {
                chk = (CheckBox)rptStudents.Items[i].FindControl("chkAll");
                hfStudentID = (HiddenField)rptStudents.Items[i].FindControl("hfStudentID");
                //hfClassNo.Value = ;

                if (chk.Checked)
                {
                    IsPresent = true;
                }
                else
                {
                    IsPresent = false;
                }

                TblAttendance obj = new TblAttendance();
                obj.IsNew = true;

                if (AttendaceID.Count != 0)
                {
                    obj = new TblAttendance(AttendaceID[i]);
                    obj.IsNew = false;
                }

                obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                obj.StudentID = Convert.ToInt32(hfStudentID.Value);
                obj.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
                obj.AttendanceDate = helper.getDateTime();
                obj.IsPresent = IsPresent;
                obj.Updateby = Session["BranchUserName"].ToString();
                obj.Save();
            }

            if (ddlClass.Items.Count > 1 && !String.IsNullOrEmpty(ddlClass.SelectedValue))
            {

                DataTable dt = helper.ExecutePlainQuery("select * from TblStudents inner join tbl_Attendance on TblStudents.StudentID=tbl_Attendance.StudentID where CONVERT(date, AttendanceDate)=CONVERT(date,'" + helper.getDateTime() + "') and TblStudents.BranchID=" + Session["BranchID"] + " and tbl_Attendance.ClassNo=" + ddlClass.SelectedValue);
                string Student = null;
                string Description = null;
                string Contact = null;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        IsPresent = Convert.ToBoolean(dt.Rows[i]["IsPresent"]);
                        if (!IsPresent)
                        {
                            if (dt.Rows[i]["Gender"].ToString() == "Male")
                            {
                                Student = "Son";
                            }
                            else
                            {
                                Student = "Daughter";
                            }
                            Description = "Dear " + dt.Rows[i]["GName"] + "sir! your " + Student + " is absent today! Regards: Pak Paerl school & colleges(" + Session["BranchUserName"] + ")";
                            Contact = dt.Rows[i]["GCellNo"].ToString();
                            SendSms.SendMessage(Contact, Description);
                        }
                    }
                }
            }

            AttendaceID.Clear();
            ddlClass.Items.Clear();
            ddlGroups.Items.Clear();
            ddlLevel.SelectedValue = "";
            // lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "", "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            Response.Redirect("ManageAttendance.aspx?msg=" + helper.Encrypt("Attendance has been submited!"));
            LoadStudents();
        }
        static List<string> AttendaceID = new List<string>();
        protected void rptStudents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            AttendaceID.Clear();
            var btn = e.Item.FindControl("btnSubmit") as Button;
            CheckBox chk = null;
            if (ddlClass.Items.Count > 1 && !String.IsNullOrEmpty(ddlClass.SelectedValue))
            {
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_Attendance where CONVERT(date, AttendanceDate)=CONVERT(date,'" + helper.getDateTime() + "') and BranchID=" + Session["BranchID"] + " and ClassNo=" + ddlClass.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    if (btn != null)
                    {
                        btn.Text = "Update";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            chk = (CheckBox)rptStudents.Items[i].FindControl("chkAll");

                            if (Convert.ToBoolean(dt.Rows[i]["isPresent"]) == true)
                            {
                                chk.Checked = true;
                            }
                            else
                            {
                                chk.Checked = false;
                            }

                            AttendaceID.Add(dt.Rows[i]["AttendanceID"].ToString());
                        }
                    }
                }
                else
                {
                    if (btn != null)
                    {
                        btn.Text = "Submit";
                    }
                }
            }
            else
            {
                //  Response.Redirect("index.aspx");
            }

        }

        public string getCheckBoxID()
        {
            return "ContentPlaceHolder1_rptStudents_chkAll_" + rptStudents.Items.Count;
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttendaceID.Clear();
            ddlGroups.Items.Clear();
            BindGroups(ddlClass.SelectedValue);
            LoadStudents();
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

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            BindClass(ddlLevel.SelectedValue);
            // LoadStudents();
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }

    }
}