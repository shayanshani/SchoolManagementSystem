using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.DL;
using SubSonic;
using SchoolManagementSystem.BL;
namespace SchoolManagementSystem.Branch
{
    public partial class AddRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["BranchID"]!=null)
                {
                    loadrptRoute(Convert.ToString(Session["BranchID"]));
                }
               
            }

        }
        public void loadrptRoute(string BranchID)
        {
            rptRoutes.DataSource = helper.ExecutePlainQuery("select * from tbl_Route where BranchID="+BranchID);
            rptRoutes.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblRoute obj =new TblRoute(btn.CommandArgument);
            txtRForm.Text = obj.RFrom.ToString();
            txtRTo.Text = obj.RTo.ToString();
            txtRFee.Text = obj.RFare.ToString();
            ddlstatus.SelectedValue = obj.IsActive.ToString();
            hdnRouteID.Value = obj.RouteID.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Route has been saved.";
            try
            { 

                TblRoute obj = new TblRoute();
                obj.IsNew = true;

                if (!string.IsNullOrEmpty(hdnRouteID.Value))
                {
                    obj = new TblRoute(hdnRouteID.Value);
                    obj.IsNew = false;
                    msg = "Route has been updated.";
                }
                obj.RFrom = txtRForm.Text;
                obj.RTo = txtRTo.Text;
                obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                obj.RFare = Convert.ToInt32(txtRFee.Text);
                obj.IsActive = Convert.ToInt32(ddlstatus.SelectedValue);
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
                loadrptRoute(Convert.ToString(Session["BranchID"]));
            }
            catch (Exception ex)
            {

                msgDiv.Visible = true;
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
        
                lblmsg.Text = ex.ToString();
            }
           

        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}