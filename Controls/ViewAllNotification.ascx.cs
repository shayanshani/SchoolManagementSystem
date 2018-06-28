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
    public partial class ViewAllNotification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BranchUserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                BindNotifications();
            }
        }

        private void BindNotifications()
        {
            try
            {
                DataTable dtNotifications = helper.ExecutePlainQuery("select *,SUBSTRING(NotificationMessage,0,150) as ShortMessage from tbl_NotificationAlert where BranchID=" + Session["BranchID"] + "order by NotificationID DESC");
                rptNotifications.DataSource = dtNotifications;
                rptNotifications.DataBind();
            }
            catch { }
        }

    }
}