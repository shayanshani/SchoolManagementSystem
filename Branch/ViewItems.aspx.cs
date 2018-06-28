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
    public partial class ViewItems : System.Web.UI.Page
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
            }
        }

        private void LoadItems()
        {
            Query qry = new Query(TblAssestItem.Schema);
            qry.AddWhere(TblAssestItem.Columns.Status, Comparison.Equals, true)
                .AND(TblAssestItem.Columns.BranchID, Comparison.Equals, Session["BranchID"]);
            rptItems.DataSource = qry.ExecuteDataSet().Tables[0];
            rptItems.DataBind();
            hdnid.Value = "";
            txtItem.Text = "";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblAssestItem asset = new TblAssestItem(btn.CommandArgument);
            txtItem.Text = asset.Item;
            hdnid.Value = asset.ItemID.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblAssestItem item = new TblAssestItem(btn.CommandArgument);
            item.Status = false;
            item.Save();
            LoadItems();
            string msg = "Item has been deleted!";
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Query qry = new Query(TblAssestItem.Schema);
            qry.AddWhere(TblAssestItem.Columns.BranchID, Comparison.Equals, Session["BranchID"])
                .AND(TblAssestItem.Columns.Item, Comparison.Like, txtItem.Text);
            if (qry.ExecuteDataSet().Tables[0].Rows.Count == 0)
            {
                TblAssestItem item;
                string msg = "Item has been added!";
                if (hdnid.Value == null || hdnid.Value == "")
                {
                    item = new BL.TblAssestItem();
                    item.IsNew = true;
                    item.Status = true;
                }
                else
                {
                    item = new BL.TblAssestItem(hdnid.Value);
                    item.IsNew = false;
                    msg = "Item has been updated!";
                }
                item.Item = txtItem.Text;
                item.BranchID = Convert.ToInt32(Session["BranchID"]);
                item.Save();
                LoadItems();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            }
            else
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtItem.Text + " Already Exists", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }
    }
}