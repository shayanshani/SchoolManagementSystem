using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using SubSonic;

namespace SchoolManagementSystem.Branch
{
    public partial class AddEmployee : System.Web.UI.Page
    {

        public static TblEmployee employee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadDesignation();
                LoadRoutes();
                cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();
                txtDOB.FocusedDate = Convert.ToDateTime("1/1/1990");
                //cmpDOJ.ValueToCompare = DateTime.Now.ToShortDateString();
                txtTJoinDate.SelectedDate = DateTime.Now;
                rdoMale.Checked = true;

                if (Session["EmployeeID"] != null)
                {
                    TblEmployee employee = new TblEmployee(Session["EmployeeID"]);
                    txtName.Text = employee.EmployeeName;
                    txtFName.Text = employee.FatherName;

                    txtCNIC.Text = employee.Cnic;
                    txtContact.Text = employee.ContactNo;
                    txtDOB.SelectedDate = Convert.ToDateTime(employee.Dob);
                    txtDOJ.SelectedDate = Convert.ToDateTime(employee.Doj);
                    txtQualification.Text = employee.Qualification;
                    txtAddress.Text = employee.Address;
                    ddlDesignation.SelectedValue = employee.DesignationID.ToString();
                    ddlStatus.SelectedValue = Convert.ToBoolean(employee.IsActive).ToString();
                    hdnpic.Value = employee.Pic;
                    hdnID.Value = employee.EmployeeID.ToString();
                   // reqFpic.Enabled = false;
                    if (employee.Gender == "Male")
                        rdoMale.Checked = true;
                    else
                        rdoFemale.Checked = true;
                    if (employee.IsTransport == true)
                        chkTransport.Checked = true;
                    Session["EmployeeID"] = null;
                }
                else
                    hdnID.Value = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Employee has been added!";
            if (hdnID.Value == "")
            {
                employee = new TblEmployee();
                employee.IsNew = true;
                employee.CreatedBy = Convert.ToString(Session["BranchUserID"]);
            }
            else
            {
                employee = new TblEmployee(hdnID.Value);
                employee.IsNew = false;
                msg = "Employee has been updated!";
                employee.Updated = Convert.ToString(Session["BranchUserID"]);
            }
            employee.BranchID = Convert.ToInt32(Session["BranchID"]);
            employee.DesignationID = Convert.ToInt32(ddlDesignation.SelectedValue);
            employee.EmployeeName = txtName.Text;
            employee.FatherName = txtFName.Text;
            employee.Cnic = txtCNIC.Text;
            employee.ContactNo = txtContact.Text;
            employee.Address = txtAddress.Text;
            employee.Qualification = txtQualification.Text;
            employee.Dob = Convert.ToDateTime(txtDOB.SelectedDate).ToString("yyyy-MM-dd");
            employee.Doj = Convert.ToDateTime(txtDOJ.SelectedDate).ToString("yyyy-MM-dd");
            employee.IsActive = Convert.ToBoolean(ddlStatus.SelectedValue);

            if (rdoMale.Checked)
                employee.Gender = "Male";
            else
                employee.Gender = "Female";
            //if (txtPic.HasFile)
            //{
            //    txtPic.SaveAs(Server.MapPath("~/Admin/assets/CustomImages/" + txtPic.FileName));
            //    employee.Pic = txtPic.FileName;
            //}
            //else
            //    employee.Pic = hdnpic.Value;
            employee.Pic = "N/A";
            if (chkTransport.Checked)
            {
                employee.IsTransport = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else
            {
                employee.IsTransport = false;
                hdnID.Value = "";
            }
            employee.Save();
            lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(this.Controls);
            txtDOB.SelectedDate = null;
            txtDOJ.SelectedDate = null;
            LoadTransportRecord();
            hdnpic.Value = "";
         //   reqFpic.Enabled = true;
        }

        private void LoadTransportRecord()
        {
            TblTransportHolder transport = new SubSonic.Select()
                           .From(TblTransportHolder.Schema)
                           .Where(TblTransportHolder.Columns.MemberID).IsEqualTo(employee.EmployeeID)
                           .And(TblTransportHolder.Columns.MemberType).IsEqualTo(true)
                           .ExecuteSingle<TblTransportHolder>();
            if (transport != null)
            {
                ddlRoute.SelectedValue = transport.RouteID.ToString();
                LoadBuses();
                ddlBus.SelectedValue = transport.BusID.ToString();
                txtDiscount.Text = transport.Discount.ToString();
                txtSeatNo.Text = transport.SeatNo.ToString();
                txtBusStop.Text = transport.Stop.ToString();
                txtTJoinDate.SelectedDate = Convert.ToDateTime(transport.JoiningDate);
            }
        }
        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        private void LoadDesignation()
        {
            Query qry = new Query(TblDesignation.Schema);
            qry.AddWhere(TblDesignation.Columns.Status, Comparison.Equals, true).
                 AND(TblDesignation.Columns.BranchID, Comparison.Equals, Session["BranchID"]);
            ddlDesignation.DataSource = qry.ExecuteDataSet().Tables[0];
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "-1"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TblTransportHolder transport;
            if (hdnID.Value != "")
            {
                transport = new SubSonic.Select()
                            .From(TblTransportHolder.Schema)
                            .Where(TblTransportHolder.Columns.MemberID).IsEqualTo(hdnID.Value)
                            .And(TblTransportHolder.Columns.MemberType).IsEqualTo(true)
                            .ExecuteSingle<TblTransportHolder>();
                if (transport == null)
                {
                    transport = new TblTransportHolder();
                    transport.IsNew = true;
                }
                else
                    transport.IsNew = false;
            }
            else
            {
                transport = new TblTransportHolder();
                transport.IsNew = true;
            }
            transport.RouteID = Convert.ToInt32(ddlRoute.SelectedValue);
            transport.BusID = Convert.ToInt32(ddlBus.SelectedValue);
            transport.MemberID = employee.EmployeeID;
            transport.MemberType = true;
            transport.Discount = Convert.ToInt32(txtDiscount.Text);
            transport.SeatNo = Convert.ToInt32(txtSeatNo.Text);
            transport.Stop = txtBusStop.Text;
            transport.JoiningDate = txtTJoinDate.SelectedDate;
            transport.IsActive = true;
            transport.Save();
            hdnID.Value = "";
        }

        protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBuses();
            }
            catch
            {
            }
        }

        private void LoadRoutes()
        {
            ddlRoute.DataSource = helper.ExecutePlainQuery("select RouteID,rfrom + ' - ' + rto Route from tbl_route where isactive=1 and BranchID=" + Session["BranchID"]);
            ddlRoute.DataValueField = "RouteID";
            ddlRoute.DataTextField = "Route";
            ddlRoute.DataBind();
            ddlRoute.Items.Insert(0, new ListItem("Select Route", "-1"));
        }

        private void LoadBuses()
        {
            try
            {
                Query qry = new Query(TblBu.Schema);
                qry.AddWhere(TblBu.Columns.RouteID, Comparison.Equals, ddlRoute.SelectedValue)
                    .AND(TblBu.Columns.IsActive, Comparison.Equals, true);
                ddlBus.DataSource = qry.ExecuteDataSet().Tables[0];
                ddlBus.DataValueField = "BusID";
                ddlBus.DataTextField = "BusNo";
                ddlBus.DataBind();
                ddlBus.Items.Insert(0, new ListItem("Select Bus", "-1"));
            }
            catch { }
        }
    }
}