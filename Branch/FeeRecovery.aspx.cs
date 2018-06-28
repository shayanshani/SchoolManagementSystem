using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SchoolManagementSystem.Branch
{
    public partial class FeeRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //if (!IsPostBack)
            //{
            //    cmptodayDate.ValueToCompare = helper.getDateTime().ToShortDateString();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtAdmissionNO.Text);
        }
        public void loadPrvFees()
        {
            rptFeeRecovery.DataSource = helper.ExecutePlainQuery("select * from tbl_Monthlyfee where CEID=" + hdnCEID.Value + " order by date asc");
            rptFeeRecovery.DataBind();
        }
        public void Search(string AdmissionNO)
        {
            DataTable dt = SPs.SpSearchStudentForclgFeeEnrollment(AdmissionNO, Convert.ToInt32(Session["BranchID"]), 1).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dt.Rows[0]["Enrollement"].ToString()))
                {
                    hdnCEID.Value = Convert.ToString(dt.Rows[0]["CEID"]);

                    lblStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                    lblClass.Text = dt.Rows[0]["ClassName"].ToString();


                    DataTable dtschFee = helper.ExecutePlainQuery("select * from tbl_SchFeeStructure where StudentID=" + dt.Rows[0]["StudentID"]+" and isActive=1");

                    if (dtschFee.Rows.Count > 0)
                    {
                        lblscholarship.Text = Convert.ToString(dtschFee.Rows[0]["EScholarship"]);
                        lblMonthlyFee.Text = dtschFee.Rows[0]["MonthlyPayable"].ToString();
                        lblAdmissionFee.Text = dtschFee.Rows[0]["AdmissionPayable"].ToString();
                        lbldiscount.Text = dtschFee.Rows[0]["Discount"].ToString();

                    }
                }
                loadPrvFees();
            }
            else
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "No record found!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblMonthlyFee obj = new TblMonthlyFee();
            obj.BranchID = Convert.ToInt32(Session["BranchID"]);
            obj.Amount = Convert.ToInt32(txtAmountRecieve.Text);
            obj.Ceid = Convert.ToInt32(hdnCEID.Value);
            obj.DateX = txtDate.SelectedDate;
            obj.FeeType = ddlFeeType.Text;
            obj.SchFeeID = 1;
            obj.ClgFeeID = 0;
            obj.Save();

            TblSchoolHostelLedger t = new TblSchoolHostelLedger();

            if (helper.ExecutePlainQuery("select * from tbl_SchoolHostelLedger where CEID=" + obj.Ceid + " and LedgerType='School'").Rows.Count == 0)
            {
                t.IsNew = true;
                t.Ceid = obj.Ceid;
                t.LedgerType = "School";
                t.Save();
            }

            t = new TblSchoolHostelLedger(TblSchoolHostelLedger.Columns.Ceid, obj.Ceid);
            t.IsNew = false;
            if (ddlFeeType.Text == "Admission Fee")
            {
                t.AdmissionFee = Convert.ToInt32(txtAmountRecieve.Text);
            }
            else if (ddlFeeType.Text == "Re-Admission Fee")
            {
                t.ReAdmissionFee = obj.Amount.ToString();
            }
            else if (ddlFeeType.Text == "Monthly Fee")
            {
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 4)
                {
                    t.Apr = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 5)
                {
                    t.May = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 6)
                {
                    t.June = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 7)
                {
                    t.July = obj.Amount.ToString();

                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 8)
                {
                    t.August = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 9)
                {
                    t.September = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 10)
                {
                    t.October = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 11)
                {
                    t.November = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 12)
                {
                    t.December = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 1)
                {
                    t.January = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 2)
                {
                    t.Fabruary = obj.Amount.ToString();
                }
                if (Convert.ToDateTime(txtDate.SelectedDate).Month == 3)
                {
                    t.March = obj.Amount.ToString();
                }
            }
            t.Save();
            loadPrvFees();
        }

        protected void ddlFeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFeeType.SelectedValue == "Admission Fee")
            {
                txtFeePayable.Text = lblAdmissionFee.Text;

            }
            else if (ddlFeeType.SelectedValue == "Re-Admission Fee")
            {
                txtFeePayable.Text = lblAdmissionFee.Text;
            }
            else if (ddlFeeType.SelectedValue == "Monthly Fee")
            {
                txtFeePayable.Text = lblMonthlyFee.Text;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_Monthlyfee where FeeID=" + btn.CommandArgument);
            TblSchoolHostelLedger t = new TblSchoolHostelLedger(TblSchoolHostelLedger.Columns.Ceid, dt.Rows[0]["CEID"]);
            t.IsNew = false;
            if (Convert.ToString(dt.Rows[0]["FeeType"]) == "Admission Fee")
                t.AdmissionFee = null;
            else if (Convert.ToString(dt.Rows[0]["FeeType"]) == "Re-Admission Fee")
                t.ReAdmissionFee = null;
            else if (Convert.ToString(dt.Rows[0]["FeeType"]) == "Monthly Fee")
            {
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 4)
                {
                    t.Apr = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 5)
                {
                    t.May = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 6)
                {
                    t.June = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 7)
                {
                    t.July = null;

                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 8)
                {
                    t.August = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 9)
                {
                    t.September = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 10)
                {
                    t.October = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 11)
                {
                    t.November = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 12)
                {
                    t.December = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 1)
                {
                    t.January = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 2)
                {
                    t.Fabruary = null;
                }
                if (Convert.ToDateTime(dt.Rows[0]["Date"]).Month == 3)
                {
                    t.March = null;
                }
            }
            t.Save();
            TblMonthlyFee.Delete(btn.CommandArgument);
            loadPrvFees();
        }
    }
}