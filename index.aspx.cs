using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.DL;

namespace SchoolManagementSystem
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["css"] = "index.aspx";
            if (!IsPostBack)
            {
                rptNews.DataSource = helper.ExecutePlainQuery("Select top 3 * from tbl_News where isActive=1  order by NewsID desc");
                rptNews.DataBind();
            }
        }
    }
}