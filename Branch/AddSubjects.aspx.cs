using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class AddSubjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                  BindSubject();
            }
        }
        private void BindSubject()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptSubjects.DataBind();
        }
        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_Subjects where SubjectName='" + txtSubject.Text + "'and BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hfSubjectID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtSubject.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Subject has been added!";
                    TblSubject obj = new TblSubject();
                    obj.IsNew = true;

                    if (!String.IsNullOrEmpty(hfSubjectID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblSubject(hfSubjectID.Value);
                        msg = "Subject has been updated!";
                    }

                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.SubjectName = txtSubject.Text;
                    obj.LevelID = Convert.ToInt32(ddlLevel.SelectedValue);
                    obj.IsActive = Convert.ToInt32(ddlStatus.SelectedValue);
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfSubjectID.Value = null;
                    DDLFilter.SelectedIndex = 1;
                }
                BindSubject();
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton SubjectID = (LinkButton)sender;
            TblSubject obj = new TblSubject(SubjectID.CommandArgument);
            ddlLevel.SelectedValue = obj.LevelID.ToString();
            ddlStatus.SelectedValue = obj.IsActive.ToString();
            txtSubject.Text = obj.SubjectName;
            hfSubjectID.Value = SubjectID.CommandArgument;
            BindSubject();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnAssignSubject_Click(object sender, EventArgs e)
        {

        }

        protected void DDLFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
        }
    }
}