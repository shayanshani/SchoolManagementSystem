using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["AdminID"]==null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["AdminID"] = null;
            Response.Redirect("Login.aspx");
        }

      
    }
}