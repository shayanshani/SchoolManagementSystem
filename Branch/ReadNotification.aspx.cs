using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using System.Data;
using SchoolManagementSystem.DL;
using SchoolManagementSystem.BL;

namespace SchoolManagementSystem.Branch
{
    public partial class ReadNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MessageRead();
            }
        }

        private void MessageRead()
        {
            TblNotificationAlert objAlert = new TblNotificationAlert(Request.QueryString["val"]);
            objAlert.IsNew = false;
            objAlert.IsRead = true;
            objAlert.Save();
        }
    }
}