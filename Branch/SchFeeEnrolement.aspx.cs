using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class SchFeeEnrolement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["val"] != null)
                {
                    Search(Request.QueryString["val"]);
                    txtAdmissionNO.Text = Convert.ToString(Request.QueryString["val"]);
                    txtAdmissionNO.Enabled = false;
                }
                if (Request.QueryString["msg"] != null)
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, helper.Decrypt(Request.QueryString["msg"]), "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //TblStudent objstudent = new TblStudent(TblStudent.Columns.RegistrationNo, txtAdmissionNO.Text);

            DataTable dt = helper.ExecutePlainQuery("select * from TblStudents where RegistrationNo='" + txtAdmissionNO.Text + "' and BranchID=" + Session["BranchID"]);

            if (dt.Rows.Count > 0)
            {
                TblSchFeeStructure objschFee = new TblSchFeeStructure();
                string msg = "Fee detail has been submit";

                objschFee.IsNew = true;

                if (!string.IsNullOrEmpty(hfSchFeeID.Value))
                {
                    objschFee = new TblSchFeeStructure(hfSchFeeID.Value);
                    objschFee.IsNew = false;
                    msg = "Fee detail has been updated";
                }

                int discount, remainingMonthlyFee, Monthlyfee;


                discount = Convert.ToInt32(txtDiscount.Text);
                Monthlyfee = Convert.ToInt32(txtMonthlyFee.Text);
                remainingMonthlyFee = Monthlyfee - discount;

                objschFee.StudentID = Convert.ToInt32(dt.Rows[0]["StudentID"]);
                objschFee.AdmissionFee = Convert.ToInt32(lblAdmissionFee.Text);

                objschFee.Discount = discount;
                objschFee.AdmissionPayable = Convert.ToInt32(txtAdmisionFee.Text);
                objschFee.MonthlyFee = Convert.ToInt32(lblMonthlyFee.Text);
                objschFee.MonthlyPayable = remainingMonthlyFee;

                if (OtherDescDiv.Visible)
                    objschFee.DescriptionforOthers = txtOtherDescr.Text;
                else
                    objschFee.DescriptionforOthers = "N/A";

                if (rdNone.Checked)
                {
                    objschFee.IsEscholarship = false;
                    objschFee.EScholarship = "None";
                }
                else
                {
                    objschFee.EScholarship = EscholarShip;
                    objschFee.IsEscholarship = true;
                }
                objschFee.IsActive = 1;
                objschFee.Save();
                helper.ClearInputs(Page.Controls);
                btnSave.Text = "Submit";
                BasciInfo.Visible = false;
                SectionScholarShips.Visible = true;
                SectionScholarShipsHeading.Visible = true;
                rdNone.Checked = true;
                hfSchFeeID.Value = string.Empty;

                Response.Redirect("SchFeeEnrolement.aspx?msg=" + helper.Encrypt(msg));
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["val"] == null)
                Search(txtAdmissionNO.Text);
        }
        static string EscholarShip = null;
        public void Search(string AdmissionNO)
        {
            bool ESchchecked = false;
            string E_scholarShip = null;

            DataTable dt = SPs.SpSearchStudentForclgFeeEnrollment(AdmissionNO, Convert.ToInt32(Session["BranchID"]), 1).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dt.Rows[0]["Enrollement"].ToString()))
                {
                    BasciInfo.Visible = true;
                    lblStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                    lblClass.Text = dt.Rows[0]["ClassName"].ToString();

                    DataTable dtschFee = helper.ExecutePlainQuery("select * from tbl_SchFeeStructure where StudentID=" + dt.Rows[0]["StudentID"]+" and isActive=1");

                    if (dtschFee.Rows.Count > 0)
                    {
                        lblGrClass.Text = lblClass.Text;
                        lblMonthlyFee.Text = dtschFee.Rows[0]["MonthlyFee"].ToString();
                        txtMonthlyFee.Text = lblMonthlyFee.Text;//dtschFee.Rows[0]["RemainingMonthlyFee"].ToString();
                        lblAdmissionFee.Text = dtschFee.Rows[0]["AdmissionFee"].ToString();
                        txtAdmisionFee.Text = lblAdmissionFee.Text; //dtschFee.Rows[0]["Remaining"].ToString();
                        // txtAdvance.Text = dtschFee.Rows[0]["Advance"].ToString();
                        txtDiscount.Text = dtschFee.Rows[0]["Discount"].ToString();
                        btnSave.Text = "Update";
                        hfSchFeeID.Value = dtschFee.Rows[0]["SchFeeID"].ToString();
                        ESchchecked = Convert.ToBoolean(dtschFee.Rows[0]["isEscholarship"]);

                        if (ESchchecked)
                        {
                            E_scholarShip = dtschFee.Rows[0]["EScholarship"].ToString();
                            switch (E_scholarShip)
                            {
                                case "Hafiz e Quran":
                                    CalAdmision();
                                    rdNone.Checked = false;
                                    RDHafiz.Checked = true;
                                    break;

                                case "KinShip (Brother & sisters)":
                                    txtMonthlyFee.Text = (Convert.ToInt32(lblMonthlyFee.Text) / 2).ToString();
                                    txtAdmisionFee.Text = lblAdmissionFee.Text;

                                    rdNone.Checked = false;
                                    RdKinShip.Checked = true;
                                    break;

                                case "Fata Student":
                                    CalAdmision();
                                    rdNone.Checked = false;
                                    RDFata.Checked = true;
                                    break;

                                case "Teacher's son":
                                    CalAdmision();
                                    rdNone.Checked = false;
                                    RdTeacher.Checked = true;
                                    break;

                                case "Orphan":
                                    CalAdmision();
                                    rdNone.Checked = false;
                                    RdOrphan.Checked = true;
                                    break;

                                case "Other":
                                    txtAdmisionFee.Enabled = true;
                                    txtMonthlyFee.Enabled = true;
                                    txtAdmisionFee.Text = dtschFee.Rows[0]["AdmissionPayable"].ToString();
                                    txtMonthlyFee.Text = dtschFee.Rows[0]["MonthlyPayable"].ToString();
                                    txtOtherDescr.Text = dtschFee.Rows[0]["DescriptionforOthers"].ToString();
                                    DiscountDiv.Visible = false;
                                    OtherDescDiv.Visible = true;
                                    rdNone.Checked = false;
                                    rdOther.Checked = true;
                                    break;

                                default:
                                    txtAdmisionFee.Text = lblAdmissionFee.Text;
                                    txtMonthlyFee.Text = lblMonthlyFee.Text;
                                    rdNone.Checked = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        DataTable dtclass = helper.ExecutePlainQuery(@"select * from tbl_ClassInformation where ClassNo='" + dt.Rows[0]["ClassID"] + "' and BranchID=" + Session["BranchID"]);
                        if (dtclass.Rows.Count > 0)
                        {
                            lblGrClass.Text = dtclass.Rows[0]["ClassName"].ToString();
                            lblAdmissionFee.Text = dtclass.Rows[0]["AdmissionFee"].ToString();
                            lblMonthlyFee.Text = dtclass.Rows[0]["MothlyFee"].ToString();
                            txtAdmisionFee.Text = lblAdmissionFee.Text;
                            txtMonthlyFee.Text = lblMonthlyFee.Text;
                        }
                    }
                }
                else
                {
                    lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, dt.Rows[0]["StudentName"] + " is not enrolled yet!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
                }
            }
            else
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, "No record found!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-close-circle-o");
            }
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void RDHafiz_CheckedChanged(object sender, EventArgs e)
        {
            CalAdmision();
            EscholarShip = "Hafiz e Quran";

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        private void CalAdmision()
        {
            txtAdmisionFee.Text = (Convert.ToInt32(lblAdmissionFee.Text) / 2).ToString();
            txtMonthlyFee.Text = lblMonthlyFee.Text;
        }

        protected void RdKinShip_CheckedChanged(object sender, EventArgs e)
        {
            txtMonthlyFee.Text = (Convert.ToInt32(lblMonthlyFee.Text) / 2).ToString();
            txtAdmisionFee.Text = lblAdmissionFee.Text;
            EscholarShip = "KinShip (Brother & sisters)";

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        protected void RDFata_CheckedChanged(object sender, EventArgs e)
        {
            CalAdmision();
            EscholarShip = "Fata Student";

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        protected void RdTeacher_CheckedChanged(object sender, EventArgs e)
        {
            CalAdmision();
            EscholarShip = "Teacher's son";

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        protected void RdOrphan_CheckedChanged(object sender, EventArgs e)
        {
            CalAdmision();
            EscholarShip = "Orphan";

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        protected void rdNone_CheckedChanged(object sender, EventArgs e)
        {
            EscholarShip = "None";
            txtAdmisionFee.Text = lblAdmissionFee.Text;
            txtMonthlyFee.Text = lblMonthlyFee.Text;

            txtAdmisionFee.Enabled = false;
            txtMonthlyFee.Enabled = false;
            DiscountDiv.Visible = true;
            OtherDescDiv.Visible = false;
        }

        protected void rdOther_CheckedChanged(object sender, EventArgs e)
        {
            EscholarShip = "Other";
            txtAdmisionFee.Text = lblAdmissionFee.Text;
            txtMonthlyFee.Text = lblMonthlyFee.Text;
            txtAdmisionFee.Enabled = true;
            txtMonthlyFee.Enabled = true;
            DiscountDiv.Visible = false;
            OtherDescDiv.Visible = true;
        }
    }
}