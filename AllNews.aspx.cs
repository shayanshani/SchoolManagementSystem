using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem
{
    public partial class AllNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptNews.DataSource = helper.ExecutePlainQuery("Select   * from tbl_News where isActive=1  order by NewsID desc");
                rptEvents.DataSource = helper.ExecutePlainQuery("Select * from tbl_Events where isActive=1");
                rptEvents.DataBind();
                rptNews.DataBind();
            }
        }
    }
}