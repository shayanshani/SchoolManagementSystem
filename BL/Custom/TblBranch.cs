using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.BL
{
    public partial class TblBranch
    {
        public static DataTable Filter(int? isActive)
        {
            return SPs.SpBranch(isActive).GetDataSet().Tables[0];
        }
    }
}