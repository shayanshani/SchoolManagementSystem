using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System.IO;
using System.Globalization;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NewsID"] != null)
                {
                    TblNews obj = new TblNews(Session["NewsID"]);
                    txtHeading.Text = obj.Heading;
                    txtDescription.Text = obj.Description;
                    reqFile.Enabled = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    string msg = "News detail has been added!";
                    TblNews obj = new TblNews();
                    obj.IsNew = true;

                    if (Session["NewsID"] != null)
                    {
                        obj.IsNew = false;
                        obj = new TblNews(Session["NewsID"]);
                        msg = "News detail has been updated!";
                    }

                    string PostedFile = null;

                    if (FileUpload1.HasFile)
                    {
                        PostedFile = FileUpload1.PostedFile.FileName;

                        if (File.Exists(Server.MapPath("~/Admin/assets/CustomImages/NewsImages/" + PostedFile)))
                        {
                            int c = 1;
                            while (File.Exists(Server.MapPath("~/Admin/assets/CustomImages/NewsImages/" + PostedFile)))
                            {
                                PostedFile = c.ToString() + FileUpload1.PostedFile.FileName;
                                c++;
                            }
                        }

                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Admin/assets/CustomImages/NewsImages/"+ PostedFile) );
                        obj.Image = PostedFile;
                    }

                   

                    obj.Heading = txtHeading.Text;
                    obj.Description = txtDescription.Text;
                    obj.PostedDate = helper.getDateTime();
                    obj.ExpiryDate = DateTime.Now.AddDays(30);
                    obj.IsActive = true;
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    Session["NewsID"] = null;
                    reqFile.Enabled = true;
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, ex.ToString(), "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
    }
}