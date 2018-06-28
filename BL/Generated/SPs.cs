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
namespace SchoolManagementSystem.BL{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the sp_AdminDashBoard Procedure
        /// </summary>
        public static StoredProcedure SpAdminDashBoard()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_AdminDashBoard", DataService.GetInstance("SchoolManagementSystem"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_AdminLogin Procedure
        /// </summary>
        public static StoredProcedure SpAdminLogin(string UserName, string Password)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_AdminLogin", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Password", Password, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_AssignSubjects Procedure
        /// </summary>
        public static StoredProcedure SpAssignSubjects(int? LevelID, int? ClassID, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_AssignSubjects", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ClassID", ClassID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_AttendaceList Procedure
        /// </summary>
        public static StoredProcedure SpAttendaceList(DateTime? DateX, int? BranchID, int? LevelID, int? ClassNo, int? GroupID, int? StudentID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_AttendaceList", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@Date", DateX, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ClassNo", ClassNo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@GroupID", GroupID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@StudentID", StudentID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Attendance Procedure
        /// </summary>
        public static StoredProcedure SpAttendance(int? LevelID, int? ClassNo, int? GroupID, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Attendance", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ClassNo", ClassNo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@GroupID", GroupID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Branch Procedure
        /// </summary>
        public static StoredProcedure SpBranch(int? isActive)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Branch", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@isActive", isActive, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_BranchDashBoard Procedure
        /// </summary>
        public static StoredProcedure SpBranchDashBoard(int? BranchID, DateTime? DateX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_BranchDashBoard", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Date", DateX, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Branches Procedure
        /// </summary>
        public static StoredProcedure SpBranches()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Branches", DataService.GetInstance("SchoolManagementSystem"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_BranchUser Procedure
        /// </summary>
        public static StoredProcedure SpBranchUser(bool? isActive, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_BranchUser", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@isActive", isActive, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_BranchUserLogin Procedure
        /// </summary>
        public static StoredProcedure SpBranchUserLogin(string UserName, string Password)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_BranchUserLogin", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@UserName", UserName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Password", Password, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_EnrolledStudents Procedure
        /// </summary>
        public static StoredProcedure SpEnrolledStudents(int? Session, int? BranchID, int? LevelID, int? ClassNo, int? GroupID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_EnrolledStudents", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@Session", Session, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ClassNo", ClassNo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@GroupID", GroupID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_ExceptionsLog_Insert Procedure
        /// </summary>
        public static StoredProcedure SpExceptionsLogInsert(string Source, DateTime? LogDateTime, string Message, string QueryString, string TargetSite, string StackTrace, string Referer, string Form, string InnerException)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_ExceptionsLog_Insert", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@Source", Source, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@LogDateTime", LogDateTime, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@Message", Message, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@QueryString", QueryString, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@TargetSite", TargetSite, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@StackTrace", StackTrace, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Referer", Referer, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@Form", Form, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@InnerException", InnerException, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_GetClasses Procedure
        /// </summary>
        public static StoredProcedure SpGetClasses(int? LevelID, int? BranchID, int? ClassNo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetClasses", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ClassNo", ClassNo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_GetExpenseReport Procedure
        /// </summary>
        public static StoredProcedure SpGetExpenseReport(int? BranchID, int? HeadID, string CurrentDate, string FromDate, string ToDate, string ForMonth, string ForYear, int? ReportType)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_GetExpenseReport", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@HeadID", HeadID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CurrentDate", CurrentDate, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@FromDate", FromDate, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@ToDate", ToDate, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@ForMonth", ForMonth, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@ForYear", ForYear, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@ReportType", ReportType, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Groups Procedure
        /// </summary>
        public static StoredProcedure SpGroups(int? AssignTo, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Groups", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@AssignTo", AssignTo, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_HostelAssignTO Procedure
        /// </summary>
        public static StoredProcedure SpHostelAssignTO(bool? MemberType, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_HostelAssignTO", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@MemberType", MemberType, DbType.Boolean, null, null);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Hostels Procedure
        /// </summary>
        public static StoredProcedure SpHostels(int? isActive, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Hostels", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@isActive", isActive, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_News Procedure
        /// </summary>
        public static StoredProcedure SpNews()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_News", DataService.GetInstance("SchoolManagementSystem"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_searchStudentForclgFeeEnrollment Procedure
        /// </summary>
        public static StoredProcedure SpSearchStudentForclgFeeEnrollment(string RegID, int? BranchID, int? LevelID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_searchStudentForclgFeeEnrollment", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@RegID", RegID, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LevelID", LevelID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_Subjects Procedure
        /// </summary>
        public static StoredProcedure SpSubjects(int? isActive, int? BranchID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_Subjects", DataService.GetInstance("SchoolManagementSystem"), "dbo");
        	
            sp.Command.AddParameter("@isActive", isActive, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@BranchID", BranchID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
    }
    
}
