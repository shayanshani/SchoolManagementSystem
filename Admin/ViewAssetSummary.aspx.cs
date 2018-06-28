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
    public partial class ViewAssetSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStoreDetais();
            }
        }
        
        public void BindStoreDetais()
        {
            rptAssetSummary.DataSource = SPs.SpBranchDashBoard(null, helper.getDateTime()).GetDataSet().Tables[2];
            rptAssetSummary.DataBind();
        }
    }
}