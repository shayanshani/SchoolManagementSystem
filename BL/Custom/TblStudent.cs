using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblStudent
    {
        public static DataTable Filter(int? Session, int BranchID, int? LevelID, int? ClassID, int? GroupID)
        {
            try
            {
                return SPs.SpEnrolledStudents(Session, BranchID, LevelID, ClassID, GroupID).GetDataSet().Tables[0];
            }
            catch {
                return null;
            }
        }
    }
}