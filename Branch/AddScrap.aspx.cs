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
    public partial class AddScrap : System.Web.UI.Page
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
                if (Session["ScrapID"] != null)
                {
                    hdnid.Value = Session["ScrapID"].ToString();
                    TblAssestScrap scrap = new TblAssestScrap(hdnid.Value);
                    hdnQuantity.Value = scrap.Quantity.ToString();
                    ddlItems.SelectedValue = scrap.ItemID.ToString();
                    txtQuantity.Text = scrap.Quantity.ToString();
                    txtDescription.Text = scrap.Description.ToString();
                    ddlItems.Enabled = false;
                }
                else
                {
                    hdnid.Value = "";
                    hdnQuantity.Value = "";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblAssestScrap scrap;
            string msg = "Scrap has been added!";
            if (hdnid.Value == "")
            {
                scrap = new TblAssestScrap();
                scrap.IsNew = true;
                scrap.DateX = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            }
            else
            {
                scrap = new TblAssestScrap(hdnid.Value);
                scrap.IsNew = false;
                msg = "Scrap has been updated!";
            }
            scrap.ItemID = Convert.ToInt32(ddlItems.SelectedValue);
            scrap.Quantity = Convert.ToInt32(txtQuantity.Text);
            scrap.Description = txtDescription.Text;
            scrap.BranchID = Convert.ToInt32(Session["BranchID"]);
            scrap.Save();
            UpdateStore();
            Session["ScrapID"] = null;
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(this.Controls);
            ddlItems.Enabled = true;
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        private void LoadItems()
        {
            Query qry = new Query(TblAssestItem.Schema);
            qry.AddWhere(TblAssestItem.Columns.Status, Comparison.Equals, true).AND
                (TblAssestItem.Columns.BranchID,Comparison.Equals,Session["BranchID"]);
            ddlItems.DataSource = qry.ExecuteDataSet().Tables[0];
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataTextField = "Item";
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem("Select Item", "-1"));
        }

        private void UpdateStore()
        {
            TblAssestStore store;
            if (hdnid.Value == "")
            {
                Query qry = new Query(TblAssestStore.Schema);
                qry.AddWhere(TblAssestStore.Columns.ItemID, Comparison.Equals, ddlItems.SelectedValue).AND
                    (TblAssestStore.Columns.BranchID,Comparison.Equals,Session["BranchID"]);
                DataTable dt = qry.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count == 0)
                {

                }
                else
                {
                    store = new SubSonic.Select()
                           .From(TblAssestStore.Schema)
                           .Where(TblAssestStore.Columns.ItemID).IsEqualTo(ddlItems.SelectedValue)
                           .And(TblAssestStore.Columns.BranchID).IsEqualTo(Session["BranchID"])
                           .ExecuteSingle<TblAssestStore>();
                    store.IsNew = false;
                    store.Quantity -= Convert.ToInt32(txtQuantity.Text);
                    store.Save();
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
                    store.Quantity -= Convert.ToInt32(txtQuantity.Text) - Convert.ToInt32(hdnQuantity.Value);
                }
                else
                {
                    store.Quantity += Convert.ToInt32(hdnQuantity.Value) - Convert.ToInt32(txtQuantity.Text);
                }
                store.Save();
            }
        }
    }
}