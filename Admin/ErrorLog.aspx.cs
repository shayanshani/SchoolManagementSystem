using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Admin
{
    public partial class ErrorLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadErrorLog();
        }

        private void LoadErrorLog()
        {
            rptErrorLog.DataSource = helper.ExecutePlainQuery("select * from tbl_exception");
            rptErrorLog.DataBind();
        }
    }
}