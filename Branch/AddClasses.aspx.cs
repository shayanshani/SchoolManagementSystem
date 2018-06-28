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
    public partial class AddClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
                BindClass();
        }
        private void BindClass()
        {
            rptClasses.DataSource = helper.ExecutePlainQuery("select * from Tbl_ClassInformation inner join tbl_Branches on Tbl_ClassInformation.BranchID=tbl_Branches.BranchID where tbl_ClassInformation.BranchID=" + Session["BranchID"]);
            rptClasses.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from Tbl_ClassInformation where ClassName='" + txtClass.Text + "' and  BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hfClassID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtClass.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Class has been added!";
                    TblClassInformation obj = new TblClassInformation();
                    obj.IsNew = true;
                    if (!String.IsNullOrEmpty(hfClassID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblClassInformation(hfClassID.Value);
                        msg = "Class has been updated!";
                    }

                    obj.ClassName = txtClass.Text;
                    obj.LevelID = Convert.ToInt32(ddlLevel.SelectedValue);
                    // obj.IsActive = true;
                    if (obj.IsNew)
                        obj.CreateBy = Session["BranchUserID"].ToString();

                    if (ddlLevel.SelectedValue == "1")
                    {
                        obj.AdmissionFee = Convert.ToInt32(txtAdmissionFee.Text);
                        obj.MothlyFee = Convert.ToInt32(txtMOnthlyFee.Text);
                    }

                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.UpdatedBy = Session["BranchUserID"].ToString();
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfClassID.Value = null;
                    lblPopUpHeading.Text = "Add Class";
                    BindClass();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick1(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton ClassID = (LinkButton)sender;
            TblClassInformation obj = new TblClassInformation(ClassID.CommandArgument);
            ddlLevel.SelectedValue = obj.LevelID.ToString();
            txtClass.Text = obj.ClassName;
            hfClassID.Value = ClassID.CommandArgument;
            lblPopUpHeading.Text = "Update Class";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton ClassID = (LinkButton)sender;
            TblClassInformation.Delete(ClassID.CommandArgument);
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Class has been deleted permanently", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            BindClass();
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLevel.SelectedValue == "2")
            {
                admissionmonth.Visible = false;
            }
            else
            {
                admissionmonth.Visible = true;
            }
        }

    }
}