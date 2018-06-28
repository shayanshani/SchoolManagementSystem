using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Reports
{
    public partial class ExpenseReport : System.Web.UI.Page
    {
        public static DataTable GetExpenseDetails
        {
            get;
            set;
        }
        public static string ExpenseHead
        {
            get;
            set;
        }
        public static string BranchName
        {
            get;
            set;
        }
        public static string rptType
        {
            get;
            set;
        }
        public static string Date
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblHeads.Text = ExpenseHead;
                lblrptType.Text = rptType;
                lblBranchName.Text = BranchName.ToString();
                rptExpenseDetails.DataSource = GetExpenseDetails;
                rptExpenseDetails.DataBind();
            }

        }
        public void LoadReport(int BranchID, int? HeadID, DateTime? CurrentDate, DateTime? FromDate, DateTime ToDate, string ForYear, int ReportType)
        {

        }


    }
}