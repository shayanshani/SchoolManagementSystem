using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblAttendance
    {

        public static DataTable Filter(int? LevelID, int? ClassID, int? GroupID, int BranchID)
        {
            try
            {
                return SPs.SpAttendance(LevelID, ClassID, GroupID, BranchID).GetDataSet().Tables[0];
            }
            catch { return null; }
          
        }

        public static DataTable FilterList(int? LevelID, int? ClassID, int? GroupID,DateTime? Date ,int BranchID)
        {
            try
            {
                return SPs.SpAttendaceList(Date,BranchID,LevelID,ClassID,GroupID,null).GetDataSet().Tables[0];
            }
            catch { return null; }

        }

        public static DataTable FilterProfileList(DateTime? Date,int? LevelID ,int BranchID,int? StudentID)
        {
            try
            {
                //if (String.IsNullOrEmpty(Date.ToString()))
                //    Date = helper.getDateTime();

                return SPs.SpAttendaceList(Date, BranchID, LevelID, null, null, StudentID).GetDataSet().Tables[0];
            }
            catch { return null; }

        }

    }
}