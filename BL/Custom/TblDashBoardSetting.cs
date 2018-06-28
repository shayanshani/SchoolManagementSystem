using SchoolManagementSystem.DL;
using System.Data;

namespace SchoolManagementSystem.BL
{
    public class TblDashBoardSetting
    {
        public static DataTable GetDashBoard()
        {
            return helper.Show("sp_AdminDashBoard");

        }
        public static DataTable GetPurchases()
        {
            return helper.ExecutePlainQuery("select * from vw_Stock");

        }
        public static DataTable GetSendNotifications()
        {
            return helper.ExecutePlainQuery("select * from vw_Notification");

        }


    }
}