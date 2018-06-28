using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;

namespace SchoolManagementSystem.Branch
{
    public partial class ViewStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadStore();
            }
        }

        private void LoadStore()
        {
            rptStore.DataSource = helper.ExecutePlainQuery("select * from vw_Store where BranchID=" + Session["BranchID"]);
            rptStore.DataBind();
        }
    }
}