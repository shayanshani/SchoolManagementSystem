using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SchoolManagementSystem.Branch
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                DashBoardSetting();
                BindNotifications();
            }
        }

        private void DashBoardSetting()
        {
            rptExpenses.DataSource = SPs.SpBranchDashBoard(Convert.ToInt32(Session["BranchID"]), helper.getDateTime()).GetDataSet().Tables[0];
            rptExpenses.DataBind();
            rptAccountDetails.DataSource = SPs.SpBranchDashBoard(Convert.ToInt32(Session["BranchID"]), helper.getDateTime()).GetDataSet().Tables[1];
            rptAccountDetails.DataBind();
            rptStoreDetail.DataSource = SPs.SpBranchDashBoard(Convert.ToInt32(Session["BranchID"]), helper.getDateTime()).GetDataSet().Tables[2];
            rptStoreDetail.DataBind();
            rptBranchInfo.DataSource = SPs.SpBranchDashBoard(Convert.ToInt32(Session["BranchID"]), helper.getDateTime()).GetDataSet().Tables[3];
            rptBranchInfo.DataBind();
        }

        private void BindNotifications()
        {
            try
            {
                DataTable dtNotifications = helper.ExecutePlainQuery("select *,SUBSTRING(NotificationMessage,0,150) as ShortMessage from tbl_NotificationAlert where BranchID=" + Session["BranchID"] + " and isRead=0 order by NotificationID DESC");
                rptNotifications.DataSource = dtNotifications;
                rptNotifications.DataBind();
            }
            catch { }

        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            BindNotifications();
        }




    }
}