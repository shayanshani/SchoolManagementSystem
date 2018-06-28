using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblBranchUser
    {
        public static DataTable Filter(bool? isActive, int? branchID)
        {
            return SPs.SpBranchUser(isActive,branchID).GetDataSet().Tables[0];
        }

        public static DataTable BranchUserLogin(string UserName, string Password)
        {
            return SPs.SpBranchUserLogin(UserName, Password).GetDataSet().Tables[0];
        }
    }
}