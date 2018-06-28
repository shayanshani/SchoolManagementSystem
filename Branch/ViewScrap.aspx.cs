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
    public partial class ViewScrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadScrap();
            }
        }

        private void LoadScrap()
        {
            rptScrap.DataSource = helper.ExecutePlainQuery("select * from vw_Scrap where BranchID=" + Session["BranchID"]);
            rptScrap.DataBind();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["ScrapID"] = btn.CommandArgument;
            Response.Redirect("AddScrap.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblAssestScrap scrap = new TblAssestScrap(btn.CommandArgument);
            TblAssestStore store = new SubSonic.Select()
                           .From(TblAssestStore.Schema)
                           .Where(TblAssestStore.Columns.ItemID).IsEqualTo(scrap.ItemID)
                           .And(TblAssestStore.Columns.BranchID).IsEqualTo(Session["BranchID"])
                           .ExecuteSingle<TblAssestStore>(); 
            store.Quantity += scrap.Quantity;
            store.Save();
            TblAssestScrap.Delete(btn.CommandArgument);
            LoadScrap();
            string msg = "Scrap has been deleted!";
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}