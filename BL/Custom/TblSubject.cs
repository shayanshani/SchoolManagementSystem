using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblSubject
    {
        public static DataTable Filter(int? isActive, int BranchID)
        {
            if(isActive==-1)
            {
                isActive = null;
            }
            return SPs.SpSubjects(isActive,BranchID).GetDataSet().Tables[0];
        }

        public static DataTable FilterAssignSubjects(int? LevelID,int? ClassID, int BranchID)
        {
            if (LevelID == -1)
            {
                LevelID = null;
            }

            if (ClassID == -1)
            {
                ClassID = null;
            }
            
          
            return SPs.SpAssignSubjects(LevelID,ClassID,BranchID).GetDataSet().Tables[0];
        }
    }
}