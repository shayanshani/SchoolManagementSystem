using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.IO;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class AddEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();

                if (Session["EventID"] != null)
                {
                    TblEvent obj = new TblEvent(Session["EventID"]);
                    txtHeading.Text = obj.EventHeading;
                    txtDetail.Text = obj.EventDetail;
                    txtFromTime.SelectedDate = Convert.ToDateTime(obj.FromTime);
                    txtTimeTo.SelectedDate = Convert.ToDateTime(obj.ToTime);
                    txtVenue.Text = obj.Venue;
                    txtEventDate.SelectedDate = obj.EventDate;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Event detail has been added!";
                TblEvent obj = new TblEvent();
                obj.IsNew = true;

                if (Session["EventID"] != null)
                {
                    obj.IsNew = false;
                    obj = new TblEvent(Session["EventID"]);
                    msg = "Event detail has been updated!";
                }

                obj.EventHeading = txtHeading.Text;
                obj.EventDate = Convert.ToDateTime(String.Format("{0:yyyy/MM/dd}", txtEventDate.SelectedDate));

                TimeZoneInfo timeZoneInfo;
                DateTime dateTime;
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
                dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

                obj.PostedDate = dateTime;
                obj.FromTime = Convert.ToDateTime(txtFromTime.SelectedTime.ToString());
                obj.ToTime = Convert.ToDateTime(txtTimeTo.SelectedTime.ToString());
                obj.Venue = txtVenue.Text;
                obj.EventDetail = txtDetail.Text;
                obj.IsActive = true;
                obj.Save();
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(Page.Controls);
                Session["EventID"] = null;
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerEvent_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}