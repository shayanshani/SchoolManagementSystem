using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.DL;
using SchoolManagementSystem.BL;
namespace SchoolManagementSystem.Branch
{
    public partial class AddBuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["BranchID"] != null)
                {
                    loadddlRoute(Convert.ToString(Session["BranchID"]));
                    loadRptBus();
                }

            }
        }
        public void loadRptBus()
        {
            rptBus.DataSource = helper.ExecutePlainQuery("select * from vw_Buses where BranchID=" + Convert.ToString(Session["BranchID"]));
            rptBus.DataBind();
        }
        public void loadddlRoute(string BranchID)
        {
            ddlRoute.DataSource = helper.ExecutePlainQuery("select [RouteID],[RFrom] +' To '+[RTo] as Route from tbl_Route where IsActive=1 and BranchID=" + BranchID);
            ddlRoute.DataTextField = "Route";
            ddlRoute.DataValueField = "RouteID";
            ddlRoute.DataBind();
            ddlRoute.Items.Insert(0, new ListItem("Select Route", "-1"));
        }
        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            hdnBusID.Value = btn.CommandArgument.ToString();
            TblBu obj = new TblBu(hdnBusID.Value);
            txtBusNo.Text = obj.BusNo.ToString();
            txtTotalSeats.Text = obj.Seats.ToString();
            ddlRoute.SelectedValue = obj.RouteID.ToString();
            ddlstatus.SelectedValue = obj.IsActive.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Bus Information has been saved.";

                TblBu obj = new TblBu();
                obj.IsNew = true;
                if (!string.IsNullOrEmpty(hdnBusID.Value))
                {
                    obj = new TblBu(hdnBusID.Value);
                    obj.IsNew = false;
                    msg = "Bus Information has been updated.";
                }
                obj.RouteID = Convert.ToInt32(ddlRoute.SelectedValue);
                obj.BusNo = txtBusNo.Text;
                obj.IsActive = Convert.ToInt32(ddlstatus.SelectedValue);
                obj.Seats = Convert.ToInt32(txtTotalSeats.Text);
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
                hdnBusID.Value = null;

            }
            catch (Exception ex)
            {

                msgDiv.Visible = true;
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");

                lblmsg.Text = ex.ToString();
            }


            loadRptBus();


        }

        protected void btnDriver_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                TblBu bus = new TblBu(btn.CommandName);
                txtBusNo1.Text = bus.BusNo.ToString();
                hdnBusID.Value = bus.BusID.ToString();
                lblDriverPopupHeader.Text = "Add Driver Information";
                if (!string.IsNullOrEmpty(btn.CommandArgument))
                {
                    TblDriver obj = new TblDriver(btn.CommandArgument);
                    txtDName.Text = obj.DName.ToString();
                    txtDMobile.Text = obj.DMobile.ToString();
                    txtDCnic.Text = obj.DCnic.ToString();
                    txtDAddress.Text = obj.DAddress.ToString();
                    hdndriverID.Value = obj.Did.ToString();
                    lblDriverPopupHeader.Text = "Update Driver Information";
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDriver();", true);
            }
            catch (Exception ex)
            {

                msgDiv.Visible = true;
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");

                lblmsg.Text = ex.ToString();
            }

        }

        protected void btnSaveDriver_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Driver information has been saved.";
                TblDriver obj = new TblDriver();
                obj.IsNew = true;
                if (!string.IsNullOrEmpty(hdndriverID.Value))
                {
                    obj = new TblDriver(hdndriverID.Value);
                    obj.IsNew = false;
                    msg = "Driver information has been updated.";
                }
                obj.DName = txtDName.Text;
                obj.DMobile = txtDMobile.Text;
                obj.DCnic = txtDCnic.Text;
                obj.DAddress = txtDAddress.Text;
                obj.BusID = Convert.ToInt32(hdnBusID.Value);
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
                hdnBusID.Value = null;
            }
            catch (Exception ex)
            {

                msgDiv.Visible = true;
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");

                lblmsg.Text = ex.ToString();
            }
            loadRptBus();
        }
    }
}