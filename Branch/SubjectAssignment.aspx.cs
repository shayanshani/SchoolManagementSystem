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
    public partial class SubjectAssignment : System.Web.UI.Page
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
                LoadDesignation();
            }
        }

        private void LoadDesignation()
        {
            Query qry = new Query(TblDesignation.Schema);
            qry.AddWhere(TblDesignation.Columns.Status, Comparison.Equals, true).
                 AND(TblDesignation.Columns.BranchID, Comparison.Equals, Session["BranchID"]);
            ddlDesignation.DataSource = qry.ExecuteDataSet().Tables[0];
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "-1"));
        }

        private void BindGrid()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptAssignSubjects.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_AssignSubject where ClassID=" + ddlAsClass.SelectedValue + " and SubjectID=" + ddlSubjects.SelectedValue).Rows.Count > 0 && String.IsNullOrEmpty(hfAssignID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ddlSubjects.SelectedItem.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Subject has been assigned!";
                    TblAssignSubject obj = new TblAssignSubject();
                    obj.IsNew = true;
                    if (!String.IsNullOrEmpty(hfAssignID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblAssignSubject(hfAssignID.Value);
                        msg = "Subject assignment has been updated!";
                    }
                    if (obj.IsNew)
                        obj.AssignTo = -1;

                    obj.ClassID = Convert.ToInt32(ddlAsClass.SelectedValue);
                    obj.SubjectID = Convert.ToInt32(ddlSubjects.SelectedValue);
                    obj.LevelID = Convert.ToInt16(ddlAcLevel.SelectedValue);
                    obj.TotalMarks = Convert.ToInt32(txtMarks.Text);
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    hfAssignID.Value = null;
                }
                helper.ClearInputs(Page.Controls);
                BindGrid();
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }
        private void BindClasses(string LevelID)
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where  LevelID=" + LevelID + "and BranchID=" + Session["BranchID"]);
            DDLClass.DataSource = dt;
            DDLClass.DataTextField = "ClassName";
            DDLClass.DataValueField = "ClassNo";
            DDLClass.DataBind();
            DDLClass.Items.Insert(0, new ListItem("--Select class--", "-1"));
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClasses(ddlLevel.SelectedValue);
            BindGrid();
        }

        protected void ddlAcLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAssignemtClass(ddlAcLevel.SelectedValue);
        }

        private void BindAssignemtClass(string LevelID)
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID=" + LevelID + " and BranchID=" + Session["BranchID"]);
            ddlAsClass.DataSource = dt;
            ddlAsClass.DataTextField = "ClassName";
            ddlAsClass.DataValueField = "ClassNo";
            ddlAsClass.DataBind();
            ddlAsClass.Items.Insert(0, new ListItem("--Select class--", "-1"));

            DataTable dtSubjects = helper.ExecutePlainQuery("select * from tbl_Subjects where isActive=1 and BranchID=" + Session["BranchID"]);
            ddlSubjects.DataSource = dtSubjects;
            ddlSubjects.DataTextField = "SubjectName";
            ddlSubjects.DataValueField = "SubjectID";
            ddlSubjects.DataBind();
            ddlSubjects.Items.Insert(0, new ListItem("--Select Subject--", "-1"));
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton AssignID = (LinkButton)sender;
                TblAssignSubject obj = new TblAssignSubject(AssignID.CommandArgument);
                TblSubject objsub = new TblSubject(obj.AssignID);
                ddlAcLevel.SelectedValue = obj.LevelID.ToString();
                BindAssignemtClass(obj.LevelID.ToString());
                ddlAsClass.SelectedValue = obj.ClassID.ToString();
                ddlSubjects.SelectedValue = obj.SubjectID.ToString();
                txtMarks.Text = obj.TotalMarks.ToString();
                hfAssignID.Value = AssignID.CommandArgument;
                BindGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            catch
            {

            }
        }

        private void BindEmployees(string DesignationID)
        {
            DataTable dt = helper.ExecutePlainQuery("select *,tbl_Employees.EmployeeName+' '+tbl_Employees.FatherName as FullName from tbl_Employees where DesignationID=" + DesignationID);
            ddlEmployees.DataSource = dt;
            ddlEmployees.DataTextField = "EmployeeName";
            ddlEmployees.DataValueField = "EmployeeID";
            ddlEmployees.DataBind();
            ddlEmployees.Items.Insert(0, new ListItem("--Select Employee--", "-1"));
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmployees(ddlDesignation.SelectedValue);
        }

        protected void btnAssignTO_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton AssignID = (LinkButton)sender;
                hfAssignID.Value = AssignID.CommandArgument;
                DataTable dt = helper.ExecutePlainQuery("select * from tbl_AssignSubject where AssignID=" + AssignID.CommandArgument);
                if (dt.Rows.Count > 0)
                {
                    if(!String.IsNullOrEmpty(AssignID.CommandName))
                    {
                        LoadDesignation();
                        ddlDesignation.SelectedValue = AssignID.CommandName;
                        BindEmployees(ddlDesignation.SelectedValue);
                        ddlEmployees.SelectedValue = dt.Rows[0]["AssignTo"].ToString();
                    }
                }
                BindGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEmployeeModal();", true);
            }
            catch
            {

            }
        }

        protected void btnAssigntoEmployee_Click(object sender, EventArgs e)
        {
            string msg = "Subject has been assigned!";
            TblAssignSubject obj = new TblAssignSubject();
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfAssignID.Value))
            {
                obj.IsNew = false;
                obj = new TblAssignSubject(hfAssignID.Value);
                msg = "Subject assignment has been updated!";
            }
            obj.AssignTo = Convert.ToInt32(ddlEmployees.SelectedValue);
            obj.Save();
            BindGrid();
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            hfAssignID.Value = null;
        }
    }
}