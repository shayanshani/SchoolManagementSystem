using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Controls
{
    public partial class ViewSingleNotification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BranchUserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Request.QueryString["val"] != null)
                    BindNotifications();
                else
                    Response.Redirect("ViewAllNorification.aspx");
            }
        }

        private void BindNotifications()
        {
            try
            {
                DataTable dtNotifications = helper.ExecutePlainQuery("select * from tbl_NotificationAlert where BranchID=" + Session["BranchID"] + " and NotificationID="+Request.QueryString["val"]);
                rptNotifications.DataSource = dtNotifications;
                rptNotifications.DataBind();
                lblNotificationHeading.Text = dtNotifications.Rows[0]["NotificationSubject"].ToString();
            }
            catch { }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {

        }
    }
}