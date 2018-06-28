using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace SchoolManagementSystem.BL
{
	 
	public partial class TblExpense  
	{
         
        public static DataTable GetSelectedDateReport(int BranchID,int? HeadID,DateTime CurrentDate)
        {
            if (HeadID==-2)
            {
                HeadID = null; 
            }
            return SPs.SpGetExpenseReport(BranchID, HeadID, CurrentDate.ToString("yyyy-MM-dd"), null, null, null, null, 1).GetDataSet().Tables[0];
        }
        public static DataTable GetSelectedMonthReport(int BranchID, int? HeadID, string ForMonth, string ForYear)
        {
            if (HeadID == -2)
            {
                HeadID = null;
            }
            return SPs.SpGetExpenseReport(BranchID, HeadID,null,null,null,ForMonth,ForYear,2).GetDataSet().Tables[0];
        }
        public static DataTable GetDateRangeReport(int BranchID, int? HeadID, string FromDate, string ToDate)
        {
            if (HeadID == -2)
            {
                HeadID = null;
            }
            return SPs.SpGetExpenseReport(BranchID, HeadID, null, FromDate, ToDate, null, null, 3).GetDataSet().Tables[0];
        }
        public static DataTable GetSelectedYearReport(int BranchID, int? HeadID, string ForYear)
        {
            if (HeadID == -2)
            {
                HeadID = null;
            }
            return SPs.SpGetExpenseReport(BranchID, HeadID, null, null, null, null, ForYear, 4).GetDataSet().Tables[0];
        }

	}
}
