using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class ViewEditEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEvents();
            }
        }

        private void BindEvents()
        {
            rptEvents.DataSource = helper.ExecutePlainQuery("select * from tbl_Events where isActive=1");
            rptEvents.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton NewsID = (LinkButton)sender;
                Session["EventID"] = NewsID.CommandArgument;
                Response.Redirect("AddEvents.aspx");
            }
            catch { }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton EventID = (LinkButton)sender;
                TblEvent.Delete(EventID.CommandArgument);
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Event detail has been deleted!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                BindEvents();
            }
            catch { }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}