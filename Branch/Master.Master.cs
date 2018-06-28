using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class Master : System.Web.UI.MasterPage
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
                DataTable dtNotifications = helper.ExecutePlainQuery("select top 3 *,SUBSTRING(NotificationMessage,0,50) as ShortMessage from tbl_NotificationAlert where BranchID=" + Session["BranchID"] + "order by isRead ASC");
                rptNotifications.DataSource = dtNotifications;
                rptNotifications.DataBind();

                DataTable dtIndicator = helper.ExecutePlainQuery("select * from tbl_NotificationAlert where isRead=0 and BranchID=" + Session["BranchID"]);
                if (dtIndicator.Rows.Count > 0)
                {
                    divindicator.Attributes["class"] = "indicator";
                    lblunReadNotification.Text = dtIndicator.Rows.Count.ToString();
                }
                else
                {
                    divindicator.Attributes["class"] = "";
                    lblunReadNotification.Text = dtIndicator.Rows.Count.ToString();
                }
            }
            catch { }

        }

        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["BranchUserID"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            BindNotifications();
        }
    }
}