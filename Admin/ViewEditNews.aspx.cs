using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class ViewEditNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNews();
            }
        }

        private void BindNews()
        {
            rptNews.DataSource = SPs.SpNews().GetDataSet().Tables[0];
            rptNews.DataBind();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton NewsID = (LinkButton)sender;
                Session["NewsID"] = NewsID.CommandArgument;
                Response.Redirect("AddNews.aspx");
            }
            catch { }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton NewsID = (LinkButton)sender;

                TblNews obj = new TblNews(NewsID.CommandArgument);
                var filePath = Server.MapPath("~/Admin/assets/CustomImages/NewsImages/" + obj.Image);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                TblNews.Delete(NewsID.CommandArgument);
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "News detail has been deleted!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                BindNews();
            }
            catch { }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}