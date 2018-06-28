using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.IO;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class ViewBranches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBranches();
            }
        }

        private void BindBranches()
        {
            rptBranches.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton BranchID = (LinkButton)sender;
                Session["BranchEditID"] = BranchID.CommandArgument;
                Response.Redirect("AddBranches.aspx");
            }
            catch { }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LinkButton BranchID = (LinkButton)sender;

            //    TblBranch obj = new TblBranch(BranchID.CommandArgument);
            //    //var filePath = Server.MapPath("~/Admin/assets/CustomImages/" + obj.PrincipleImage);
            //    //if (File.Exists(filePath))
            //    //{
            //    //    File.Delete(filePath);
            //    //}
            //    obj.IsNew = false;
            //    obj.IsActive = false;
            //    obj.Save();

            //    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Branch has been deleted!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            //    BindBranches();
            //}
            //catch(Exception ex) {
            //    lblmsg.Text = ex.ToString();
            //}
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void DDLFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptBranches.DataBind();
        }
    }
}