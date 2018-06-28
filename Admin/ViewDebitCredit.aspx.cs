using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;

namespace SchoolManagementSystem.Admin
{
    public partial class ViewDebitCredit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDebits();
            }
        }

        public void BindDebits()
        {
            rptDebitCredit.DataSource = SPs.SpBranchDashBoard(null,helper.getDateTime()).GetDataSet().Tables[1];
            rptDebitCredit.DataBind();
        }
    }
}