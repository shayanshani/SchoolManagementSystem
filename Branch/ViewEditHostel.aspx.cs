using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class ViewEditHostel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindHostels();
            }
        }

        private void BindHostels()
        {
            hfGetBranchID.Value = Convert.ToString(Session["BranchID"]);
            rptHostels.DataBind();
        }


        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton HostelID = (LinkButton)sender;
                Session["HostelID"] = HostelID.CommandArgument;
                Response.Redirect("AddHostel.aspx");
            }
            catch { }
        }

        protected void DDLFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindHostels();
        }
    }
}