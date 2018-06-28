using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Controls
{
    public partial class EmployeeProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.QueryString["val"] != null)
            {
                loadEmployeeInfo(Convert.ToString(Request.QueryString["val"]));
            }
            else
            {
                Response.Redirect("ViewEmployee.aspx");
            }
             

        }

        public void loadEmployeeInfo(string EmployeeID)
        {
            rptEmployeeProfile.DataSource = helper.ExecutePlainQuery("Select * from vw_Employee where EmployeeID=" + EmployeeID);
            rptEmployeeProfile.DataBind();
            rptAssignSubjects.DataSource = helper.ExecutePlainQuery("select * from vw_EmployeeAssignSubjects where EmployeeID=" + EmployeeID);
            rptAssignSubjects.DataBind();
        }
    }
}