using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;

namespace SchoolManagementSystem.Branch
{
    public partial class AddClassGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
              //  BindClasses();
                BindGroups();
                //BindGroupDropDown();
                BindDesignation();
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

        private void BindDesignation()
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_Designation where BranchID=" + Session["BranchID"]);
            ddlDesignation.DataSource = dt;
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "-1"));
        }

        //private void BindGroupDropDown()
        //{
        //    DataTable dt = helper.ExecutePlainQuery("select * from tbl_Groups where BranchID=" + Session["BranchID"]);
        //    ddlGroups.DataSource = dt;
        //    ddlGroups.DataTextField = "GroupName";
        //    ddlGroups.DataValueField = "GroupID";
        //    ddlGroups.DataBind();
        //    ddlGroups.Items.Insert(0, new ListItem("--Select Group--", "-1"));
        //}
        private void BindGroups()
        {
            rptGroups.DataSource = SPs.SpGroups(null, Convert.ToInt32(Session["BranchID"])).GetDataSet().Tables[0]; ;
            rptGroups.DataBind();
        }
        private void BindClasses()
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where LevelID="+ddlLevel.SelectedValue+" and BranchID=" + Session["BranchID"]);
            ddlclass.DataSource = dt;
            ddlclass.DataTextField = "ClassName";
            ddlclass.DataValueField = "ClassNo";
            ddlclass.DataBind();
            ddlclass.Items.Insert(0, new ListItem("--Select class--", "-1"));
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton GroupID = (LinkButton)sender;
            TblGroup obj = new TblGroup(GroupID.CommandArgument);
            ddlLevel.SelectedValue = obj.LevelID.ToString();
            BindClasses();
            ddlclass.SelectedValue = obj.ClassID.ToString();
            txtGroup.Text = obj.GroupName;
            hfGroupID.Value = GroupID.CommandArgument;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton GroupID = (LinkButton)sender;
            TblGroup.Delete(GroupID.CommandArgument);
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Group has been deleted permanently", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            BindGroups();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_Groups where GroupName='" + txtGroup.Text + "' and ClassID="+ddlclass.SelectedValue+" and BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hfGroupID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtGroup.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Group has been added!";
                    TblGroup obj = new TblGroup();
                    obj.IsNew = true;
                    if (!String.IsNullOrEmpty(hfGroupID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblGroup(hfGroupID.Value);
                        msg = "Group has been updated!";
                    }

                    obj.GroupName = txtGroup.Text;
                    obj.ClassID = Convert.ToInt32(ddlclass.SelectedValue);
                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.LevelID =Convert.ToInt32(ddlLevel.SelectedValue);
                    if (obj.IsNew)
                    {
                        obj.AssignTo = -1;
                    }

                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    hfGroupID.Value = null;
                    BindGroups();
                }
                helper.ClearInputs(Page.Controls);
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void btnAssignTo_Click(object sender, EventArgs e)
        {
            LinkButton GroupID = (LinkButton)sender;
            TblGroup obj = new TblGroup(GroupID.CommandArgument);
            if (obj.AssignTo != -1)
            {
                DataTable dt = SPs.SpGroups(obj.AssignTo, Convert.ToInt32(Session["BranchID"])).GetDataSet().Tables[0];
                string DesignationID = dt.Rows[0]["DesignationID"].ToString();
                ddlDesignation.SelectedValue = DesignationID;
                BindEmployees(DesignationID);
                ddlEmployees.SelectedValue = dt.Rows[0]["EmployeeID"].ToString();
            }
            hfGroupID.Value = GroupID.CommandArgument;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAssignTo();", true);
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from Tbl_Groups where GroupID='" + hfGroupID.Value + "' and AssignTo='" + ddlEmployees.SelectedValue + "' and BranchID=" + Session["BranchID"]).Rows.Count > 0)
                {
                    lblmsg.Text = lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "This group already assigned to " + ddlEmployees.SelectedItem.Text + "!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
                }
                else
                {
                    TblGroup obj = new TblGroup(hfGroupID.Value);
                    obj.AssignTo = Convert.ToInt16(ddlEmployees.SelectedValue);
                    obj.IsNew = false;
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Group " + obj.GroupName + " has been assigned to " + ddlEmployees.SelectedItem.Text, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    BindGroups();
                }
            }
            catch
            {

            }
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmployees(ddlDesignation.SelectedValue);
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClasses();
        }
    }
}