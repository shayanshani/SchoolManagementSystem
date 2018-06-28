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
    public partial class AddHostel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    cloneData();
                    LoadDesignation();
                }
            }
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
            ddlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "-1"));
        }

        private void BindEmployees(string DesignationID)
        {
            DataTable dt = helper.ExecutePlainQuery("select *,tbl_Employees.EmployeeName+' '+tbl_Employees.FatherName as FullName from tbl_Employees where DesignationID=" + DesignationID);
            ddlEmployees.DataSource = dt;
            ddlEmployees.DataTextField = "EmployeeName";
            ddlEmployees.DataValueField = "EmployeeID";
            ddlEmployees.DataBind();
            ddlEmployees.Items.Insert(0, new ListItem("--Select Employee--", "-1"));
        }

        private void cloneData()
        {
            if (Session["HostelID"] != null)
            {
                TblHostelinformation obj = new TblHostelinformation(Session["HostelID"]);
                txtHostelName.Text = obj.HostelName;
                txtHostelContact.Text = obj.HostelContact;
                txtHostelFee.Text = obj.HostelFee.ToString();
                txtHostelLocation.Text = obj.HostelLocation;
                ddlStatus.SelectedValue = obj.IsActive.ToString();
                LoadDesignation();
                TblEmployee objemp = new TblEmployee(obj.EmployeeID);
                ddlDesignation.SelectedValue = objemp.DesignationID.ToString();
                BindEmployees(ddlDesignation.SelectedValue);
                ddlEmployees.SelectedValue = obj.EmployeeID.ToString();
              
                hfHostelID.Value = obj.HostelID.ToString();
                Session["HostelID"] = null;
            }
            else
                hfHostelID.Value = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_Hostelinformation where [HostelName]='" + txtHostelName.Text + "' and BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hfHostelID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtHostelName.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
                else
                {
                    string msg = "Hostel detail has been added!";

                    TblHostelinformation obj = new TblHostelinformation();
                    obj.IsNew = true;

                    if (hfHostelID.Value != "")
                    {
                        obj.IsNew = false;
                        obj = new TblHostelinformation(hfHostelID.Value);
                        msg = "Hostel detail has been updated!";
                    }

                    obj.HostelName = txtHostelName.Text;
                    obj.HostelContact = txtHostelContact.Text;
                    obj.HostelFee = Convert.ToInt32(txtHostelFee.Text);
                    obj.HostelLocation = txtHostelLocation.Text;
                    obj.BranchID = Convert.ToInt32(Session["BranchID"]);
                    obj.EmployeeID = Convert.ToInt32(ddlEmployees.SelectedValue);
                    obj.IsActive =Convert.ToInt32(ddlStatus.SelectedValue);

                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfHostelID.Value = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.InnerException.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmployees(ddlDesignation.SelectedValue);
        }
    }
}