using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.BranchMaster
{
    public partial class AddPrinciples : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBranches();
                if (Request.QueryString["BranchID"]!=null)
                {
                    ddlBranches.SelectedValue = Convert.ToString(Request.QueryString["BranchID"]);
                    loadData(ddlBranches.SelectedValue);
                }
                
            }
        }

        private void loadData(string BranchID)
        {
                TblPrinciple obj = new TblPrinciple(TblPrinciple.Columns.BranchID, BranchID);
                if (obj.PrincipalID!=0)
                {
                    hfPricipalID.Value = obj.PrincipalID.ToString();
                    txtPrincipalName.Text = obj.PrincipalName;
                    txtPrincipalMobile.Text = obj.PrincipalMobile;
                    txtPrincipalEmail.Text = obj.PrincipalEmail;
                    reqFile.Enabled = false;
                }
        }

        private void BindBranches()
        {
            DataTable dt = SPs.SpBranches().GetDataSet().Tables[0];
            ddlBranches.DataSource = dt;
            ddlBranches.DataTextField = "BranchName";
            ddlBranches.DataValueField = "BranchID";
            ddlBranches.DataBind();
            ddlBranches.Items.Insert(0, new ListItem("--Select Branch--", "-1"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (helper.ExecutePlainQuery("select * from tbl_Principles where PrincipalEmail='" + txtPrincipalEmail.Text + "'").Rows.Count > 0 && String.IsNullOrEmpty(hfPricipalID.Value))
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtPrincipalEmail.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
                }
                else
                {
                    string msg = "Principal detail has been added!";
                    TblPrinciple obj = new TblPrinciple();
                    obj.IsNew = true;

                    if (!String.IsNullOrEmpty(Convert.ToString(hfPricipalID.Value)))
                    {
                        obj.IsNew = false;
                        obj = new TblPrinciple(hfPricipalID.Value);
                        msg = "Principal detail has been updated!";
                    }

                    string PostedFile = null;

                    if (FileUpload1.HasFile)
                    {
                        PostedFile = FileUpload1.PostedFile.FileName;

                        if (File.Exists(Server.MapPath("~/Admin/assets/CustomImages/" + PostedFile)))
                        {
                            int c = 1;
                            while (File.Exists(Server.MapPath("~/Admin/assets/CustomImages/" + PostedFile)))
                            {
                                PostedFile = c.ToString() + FileUpload1.PostedFile.FileName;
                                c++;
                            }
                        }

                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Admin/assets/CustomImages/") + PostedFile);
                        obj.PrincipleImage = PostedFile;
                    }

                    obj.BranchID = Convert.ToInt16(ddlBranches.SelectedValue);
                    obj.PrincipalName = txtPrincipalName.Text;
                    obj.PrincipalMobile = txtPrincipalMobile.Text;
                    obj.PrincipalEmail = txtPrincipalEmail.Text;
                    obj.IsActive = true;
                    obj.Save();
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                    helper.ClearInputs(Page.Controls);
                    hfPricipalID.Value = string.Empty;
                    reqFile.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "Internal Server Error!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData(ddlBranches.SelectedValue);
        }
    }
}