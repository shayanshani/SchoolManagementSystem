using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Admin
{
    public partial class ViewExpenses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindExpenses();
        }

        public void BindExpenses()
        {
            rptExpenses.DataSource = SPs.SpBranchDashBoard(null, helper.getDateTime()).GetDataSet().Tables[0];
            rptExpenses.DataBind();
        }
    }
}