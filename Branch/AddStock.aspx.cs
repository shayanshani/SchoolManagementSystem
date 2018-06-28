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
    public partial class AddStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadItems();
                cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();
                if (Session["StockID"] != null)
                {
                    hdnID.Value = Session["StockID"].ToString();
                    TblAssestStock stock = new TblAssestStock(hdnID.Value);
                    stock.IsNew = false;
                    hdnQuantity.Value = stock.Quantity.ToString();
                    ddlItems.SelectedValue = stock.ItemID.ToString();
                    ddlItems.Enabled = false;
                    txtQuantity.Text = stock.Quantity.ToString();
                    txtPP.Text = stock.PerPrice.ToString();
                    txtTotalPrice.Text = stock.TotalPrice.ToString();
                    txtDescription.Text = stock.Description.ToString();
                    txtPurchaseDate.SelectedDate = Convert.ToDateTime(stock.PurchaseDate);
                }
                else
                {
                    hdnID.Value = "";
                }
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblAssestStock stock;
            string msg = "Stock has been added!";
            if (hdnID.Value == "")
            {
                stock = new TblAssestStock();
                stock.IsNew = true;
            }
            else
            {
                stock = new TblAssestStock(hdnID.Value);
                stock.IsNew = false;
                msg = "Stock has been updated!";
            }
            stock.ItemID = Convert.ToInt32(ddlItems.SelectedValue);
            stock.Quantity = Convert.ToInt32(txtQuantity.Text);
            stock.PerPrice = Convert.ToDecimal(txtPP.Text);
            stock.TotalPrice = Convert.ToDecimal(Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtPP.Text));
            stock.PurchaseDate = (Convert.ToDateTime(txtPurchaseDate.SelectedDate)).ToString("yyyy-MM-dd");
            stock.EntryDate = DateTime.Now.ToString("yyyy-MM-dd");
            stock.Description = txtDescription.Text;
            stock.UserID = Convert.ToInt32(Session["BranchUserID"]);
            stock.BranchID = Convert.ToInt32(Session["BranchID"]);
            stock.Save();
            UpdateStore();
            Session["StockID"] = null;
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(this.Controls);
            ddlItems.Enabled = true;
            txtPurchaseDate.SelectedDate = null;
        }

        private void LoadItems()
        {
            Query qry = new Query(TblAssestItem.Schema);
            qry.AddWhere(TblAssestItem.Columns.Status, Comparison.Equals, true).AND
                (TblAssestItem.Columns.BranchID, Comparison.Equals, Session["BranchID"]);
            ddlItems.DataSource = qry.ExecuteDataSet().Tables[0];
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataTextField = "Item";
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem("Select Item", "-1"));
        }

        private void UpdateStore()
        {
            TblAssestStore store;
            if (hdnID.Value == "")
            {
                Query qry = new Query(TblAssestStore.Schema);
                qry.AddWhere(TblAssestStore.Columns.ItemID, Comparison.Equals, ddlItems.SelectedValue).AND
                    (TblAssestStore.Columns.BranchID, Comparison.Equals, Session["BranchID"]);
                DataTable dt = qry.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count == 0)
                {
                    store = new TblAssestStore();
                    store.IsNew = true;
                    store.ItemID = Convert.ToInt32(ddlItems.SelectedValue);
                    store.Quantity = Convert.ToInt32(txtQuantity.Text);
                    store.BranchID = Convert.ToInt32(Session["BranchID"]);
                }
                else
                {
                    store = new SubSonic.Select()
                           .From(TblAssestStore.Schema)
                           .Where(TblAssestStore.Columns.ItemID).IsEqualTo(ddlItems.SelectedValue)
                           .And(TblAssestStore.Columns.BranchID).IsEqualTo(Session["BranchID"])
                           .ExecuteSingle<TblAssestStore>();
                    store.IsNew = false;
                    store.Quantity += Convert.ToInt32(txtQuantity.Text);
                }
            }
            else
            {
                store = new SubSonic.Select()
                          .From(TblAssestStore.Schema)
                          .Where(TblAssestStore.Columns.ItemID).IsEqualTo(ddlItems.SelectedValue)
                          .And(TblAssestStore.Columns.BranchID).IsEqualTo(Session["BranchID"])
                          .ExecuteSingle<TblAssestStore>();
                store.IsNew = false;
                if (Convert.ToInt32(txtQuantity.Text) > Convert.ToInt32(hdnQuantity.Value))
                {
                    store.Quantity += Convert.ToInt32(txtQuantity.Text) - Convert.ToInt32(hdnQuantity.Value);
                }
                else
                {
                    store.Quantity -= Convert.ToInt32(hdnQuantity.Value) - Convert.ToInt32(txtQuantity.Text);
                }
            }
            store.Save();
        }
    }
}