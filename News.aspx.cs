using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["val"].ToString() == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    rptSideNews.DataSource = helper.ExecutePlainQuery("Select top 5  * from tbl_News where isActive=1  order by NewsID desc");

                    rptSideNews.DataBind();
                    rptNews.DataSource = helper.ExecutePlainQuery("Select * from tbl_News where NewsID="+Page.RouteData.Values["val"]);
                    rptNews.DataBind();
                    rptEvents.DataSource = helper.ExecutePlainQuery("Select * from tbl_Events where isActive=1");
                    rptEvents.DataBind();
                }
                
            }

        }
    }
}