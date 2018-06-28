using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class ViewEditStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadStock();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["StockID"] = btn.CommandArgument;
            Response.Redirect("AddStock.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblAssestStock stock = new TblAssestStock(btn.CommandArgument);
            TblAssestStore store = new SubSonic.Select()
                           .From(TblAssestStore.Schema)
                           .Where(TblAssestStore.Columns.ItemID).IsEqualTo(stock.ItemID)
                           .And(TblAssestStore.Columns.BranchID).IsEqualTo(Session["BranchID"])
                           .ExecuteSingle<TblAssestStore>();
            store.Quantity -= stock.Quantity;
            store.Save();
            TblAssestStock.Delete(btn.CommandArgument);
            LoadStock();
            string msg = "Item has been deleted!";
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        private void LoadStock()
        {
            rptStock.DataSource = helper.ExecutePlainQuery("select * from vw_Stock where BranchID =" + Session["BranchID"]);
            rptStock.DataBind();
        }
    }
}