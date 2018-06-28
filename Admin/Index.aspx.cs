using System;
using SchoolManagementSystem.BL;
using System.Data;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDashBoard();
                LoadStock();
                LoadNotifications();
            }
        }
        public void loadDashBoard()
        {
            DataTable dt = TblDashBoardSetting.GetDashBoard();
            rptDashBoard.DataSource = dt;
            rptDashBoard.DataBind();
        }
        private void LoadStock()
        {
            rptStock.DataSource = TblDashBoardSetting.GetPurchases();
            rptStock.DataBind();
        }
        public void LoadNotifications()
        {
            rptNofications.DataSource = TblDashBoardSetting.GetSendNotifications();
            rptNofications.DataBind();
        }

    }
}