using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }
    }
}