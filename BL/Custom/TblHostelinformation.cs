using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblHostelinformation
    {
        public static DataTable Filter(int? isActive, int BranchID)
        {
            if (isActive == -1)
            {
                isActive = null;
            }
            return SPs.SpHostels(isActive, BranchID).GetDataSet().Tables[0];
        }

        public static DataTable FilterMember(int MemberTypePrm, int BranchID)
        {
            bool MemberType=true;

            if(MemberTypePrm==1)
            {
                MemberType = true;
            }
            if(MemberTypePrm==0)
            {
                MemberType = false;
            }

            return SPs.SpHostelAssignTO(MemberType,BranchID).GetDataSet().Tables[0];
        }
    }
}