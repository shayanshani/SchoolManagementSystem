using SchoolManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using System.Globalization;
using System.Web.UI.HtmlControls;
namespace SchoolManagementSystem.Branch
{
    public partial class ClgFeeEnrolement : System.Web.UI.Page
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
            TblStudent objstudent = new TblStudent(TblStudent.Columns.RegistrationNo, txtAdmissionNO.Text);
            TblClgFeeStructure objclgFee = new TblClgFeeStructure();

            string msg = "Fee detail has been submit";

            objclgFee.IsNew = true;

            if (!string.IsNullOrEmpty(hfclgFeeID.Value))
            {
                objclgFee = new TblClgFeeStructure(hfclgFeeID.Value);
                objclgFee.IsNew = false;
                msg = "Fee detail has been updated";
            }

            objclgFee.StudentID = objstudent.StudentID;
            int advance, discount, remaining, totalFee;
            advance = Convert.ToInt32(txtAdvance.Text);
            discount = Convert.ToInt32(txtDiscount.Text);
            totalFee = Convert.ToInt32(txtTotal.Text);
            remaining = totalFee - advance - discount;
            objclgFee.PreviousTotalFee = Convert.ToInt32(lblTotalFee.Text.Replace(",", ""));
            objclgFee.TotalFee = totalFee;
            objclgFee.Advance = advance;
            objclgFee.Discount = discount;
            objclgFee.Remaining = remaining;
            objclgFee.MonthlyFee = remaining / 8;
            objclgFee.Percentage = Convert.ToDouble(Percentage);
            objclgFee.TutionFee = Convert.ToInt32(lblTutionFee.Text.Replace(",", ""));
            objclgFee.Misc = Misc;
            objclgFee.AdmissionFee = AdmissionFee;

            if (rdNone.Checked)
            {
                objclgFee.IsEscholarship = false;
                objclgFee.EScholarship = "None";
            }
            else
            {
                objclgFee.EScholarship = EscholarShip;
                objclgFee.IsEscholarship = true;
            }
            objclgFee.IsActive = 1;
            objclgFee.Save();
            // lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            helper.ClearInputs(Page.Controls);
            btnSave.Text = "Submit";
            BasciInfo.Visible = false;
            SectionScholarShips.Visible = true;
            SectionScholarShipsHeading.Visible = true;
            rdNone.Checked = true;
            hfclgFeeID.Value = string.Empty;

            Response.Redirect("ClgFeeEnrolement.aspx?msg=" + helper.Encrypt(msg));
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        static int totalFee, AdmissionFee, Misc, TutionFee, tempTutionFee, CalculateTutionFee, Percentage;
        static double TotalMarks, ObtainedMarks;
        static string EscholarShip = null;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["val"] == null)
                Search(txtAdmissionNO.Text);
        }

        public void Search(string AdmissionNO)
        {
            bool ESchchecked = false;
            string E_scholarShip = null;

            DataTable dt = SPs.SpSearchStudentForclgFeeEnrollment(AdmissionNO, Convert.ToInt32(Session["BranchID"]), 2).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dt.Rows[0]["Enrollement"].ToString()))
                {
                    BasciInfo.Visible = true;

                    lblStudentName.Text = dt.Rows[0]["StudentName"].ToString();
                    lblProgram.Text = dt.Rows[0]["Program"].ToString();

                    DataTable dtClgFee = helper.ExecutePlainQuery("select * from tbl_ClgFeeStructure where StudentID=" + dt.Rows[0]["StudentID"]);

                    if (dtClgFee.Rows.Count > 0)
                    {
                        totalFee = Convert.ToInt32(dtClgFee.Rows[0]["PreviousTotalFee"]);
                        AdmissionFee = Convert.ToInt32(dtClgFee.Rows[0]["AdmissionFee"]);
                        Misc = Convert.ToInt32(dtClgFee.Rows[0]["Misc"]);
                        TutionFee = Convert.ToInt32(dtClgFee.Rows[0]["TutionFee"]);
                        txtAdvance.Text = dtClgFee.Rows[0]["Advance"].ToString();
                        txtDiscount.Text = dtClgFee.Rows[0]["Discount"].ToString();
                        btnSave.Text = "Update";
                        hfclgFeeID.Value = dtClgFee.Rows[0]["FeeID"].ToString();
                        
                        GetScholarShip(ref ESchchecked, ref E_scholarShip, dtClgFee);
                    }
                    else
                    {
                        TblProgramFee obj = new TblProgramFee(TblProgramFee.Columns.Program, lblProgram.Text);
                        if (!String.IsNullOrEmpty(obj.Program))
                        {
                            totalFee = Convert.ToInt32(obj.TotalFee);
                            AdmissionFee = Convert.ToInt32(obj.AdmissionFee);
                            Misc = Convert.ToInt32(obj.Mise);
                            TutionFee = Convert.ToInt32(obj.TuitionFee);
                        }
                    }

                    lblTotalFee.Text = totalFee.ToString("#,##");
                    lblAdmissionFee.Text = AdmissionFee.ToString("#,##");
                    lblMisc.Text = Misc.ToString("#,##");
                    lblTutionFee.Text = TutionFee.ToString("#,##");

                    DataTable dtAc = helper.ExecutePlainQuery("SELECT * from TblStudentAcademicRecord where StudentID='" + dt.Rows[0]["StudentID"].ToString() + "' and ARecordID=(Select MAX(ARecordID) from TblStudentAcademicRecord  where StudentID='" + dt.Rows[0]["StudentID"].ToString() + "')");

                    TotalMarks = Convert.ToInt32(dtAc.Rows[0]["totalmarks"]);
                    ObtainedMarks = Convert.ToInt32(dtAc.Rows[0]["ObtainedMarks"]);

                    lblAdmissionPlusMisc.Text = (AdmissionFee + Misc).ToString("#,##");

                    CalculateFee();

                    Percentage = Convert.ToInt32((ObtainedMarks / TotalMarks) * 100);


                    lblpercentage.Text = Convert.ToString((ObtainedMarks / TotalMarks) * 100);

                    if (lblpercentage.Text.Length > 4)
                    {
                        lblpercentage.Text = lblpercentage.Text.Substring(0, 4);
                    }

                    if (Percentage >= 85)
                    {
                        SectionScholarShips.Visible = false;
                        SectionScholarShipsHeading.Visible = false;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                        txtTotal.Text = "Free";
                      
                        Highlight(trFree);
                    }
                    else if (Percentage >= 80 && Percentage <= 84)
                    {
                        SectionScholarShips.Visible = false;
                        SectionScholarShipsHeading.Visible = false;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = Misc.ToString();
                        
                        Highlight(trMiscOnly);
                    }
                    else if (Percentage >= 75 && Percentage <= 79)
                    {
                        SectionScholarShips.Visible = false;
                        SectionScholarShipsHeading.Visible = false;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = AdmissionFee.ToString();
                        
                        Highlight(trAdmssion);
                    }
                    else if (Percentage >= 70 && Percentage <= 74)
                    {
                        SectionScholarShips.Visible = false;
                        SectionScholarShipsHeading.Visible = false;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = (AdmissionFee + Misc).ToString();
                        
                        Highlight(trAdmissionMisc);
                    }
                    else if (Percentage >= 65 && Percentage <= 69)
                    {
                        SectionScholarShips.Visible = true;
                        SectionScholarShipsHeading.Visible = true;
                        CalculateTutionFee = TutionFee * 80 / 100;
                        TutionFee = TutionFee - CalculateTutionFee;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = (AdmissionFee + Misc + TutionFee).ToString();
                        
                        Highlight(tr80);
                    }
                    else if (Percentage >= 60 && Percentage <= 64)
                    {
                        SectionScholarShips.Visible = true;
                        SectionScholarShipsHeading.Visible = true;
                        CalculateTutionFee = TutionFee * 60 / 100;
                        TutionFee = TutionFee - CalculateTutionFee;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = (AdmissionFee + Misc + TutionFee).ToString();
                        
                        Highlight(tr60);
                    }
                    else if (Percentage >= 55 && Percentage <= 59)
                    {
                        SectionScholarShips.Visible = true;
                        SectionScholarShipsHeading.Visible = true;
                        CalculateTutionFee = TutionFee * 40 / 100;
                        TutionFee = TutionFee - CalculateTutionFee;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = (AdmissionFee + Misc + TutionFee).ToString();
                        
                        Highlight(tr40);
                    }
                    else if (Percentage >= 50 && Percentage <= 54)
                    {
                        SectionScholarShips.Visible = true;
                        SectionScholarShipsHeading.Visible = true;
                        CalculateTutionFee = TutionFee * 20 / 100;
                        TutionFee = TutionFee - CalculateTutionFee;

                        if (String.IsNullOrEmpty(hfclgFeeID.Value))
                            txtTotal.Text = (AdmissionFee + Misc + TutionFee).ToString();
                        
                        Highlight(tr20);
                    }
                    tempTutionFee = TutionFee;
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


        public void Highlight(HtmlControl tr)
        {
            HtmlControl[] trs = { tr20, tr40, tr60, tr80, trAdmissionMisc, trFree, trAdmssion, trMiscOnly };

            for (int i = 0; i <= trs.Length - 1; i++)
            {
                if (trs[i] == tr)
                {
                    trs[i].Attributes["style"] = "background-color: #808080;color: #FFF;";
                }
                else
                {
                    trs[i].Attributes["style"] = "background-color: transparent;color: #404040;";
                }
            }
        }

        private void CalculateFee()
        {
            lbl80TutionFee.Text = GetGridPercentageCal(80, TutionFee);
            lbl80Percent.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl80TutionFee.Text)).ToString("#,##");
            lbl80TutionFeeSch.Text = GetGridPercentageCal(20, Convert.ToInt32(lbl80TutionFee.Text));
            lbl80PercentSch.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl80TutionFeeSch.Text)).ToString("#,##");

            lbl60TutionFee.Text = GetGridPercentageCal(60, TutionFee);
            lbl60Percent.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl60TutionFee.Text)).ToString("#,##");
            lbl60TutionFeeSch.Text = GetGridPercentageCal(20, Convert.ToInt32(lbl60TutionFee.Text));
            lbl60PercentSch.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl60TutionFeeSch.Text)).ToString("#,##");


            lbl40TutionFee.Text = GetGridPercentageCal(40, TutionFee);
            lbl40Percent.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl40TutionFee.Text)).ToString("#,##");
            lbl40TutionFeeSch.Text = GetGridPercentageCal(20, Convert.ToInt32(lbl40TutionFee.Text));
            lbl40PercentSch.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl40TutionFeeSch.Text)).ToString("#,##");


            lbl20TutionFee.Text = GetGridPercentageCal(20, TutionFee);
            lbl20Percent.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl20TutionFee.Text)).ToString("#,##");
            lbl20TutionFeeSch.Text = GetGridPercentageCal(20, Convert.ToInt32(lbl20TutionFee.Text));
            lbl20PercentSch.Text = (AdmissionFee + Misc + Convert.ToInt32(lbl20TutionFeeSch.Text)).ToString("#,##");
        }

        private static string GetGridPercentageCal(int per, int tutionFee)
        {
            return (tutionFee - (tutionFee * per / 100)).ToString();
        }

        private void ScholarShipCalculate(int per)
        {
            CalculateTutionFee = tempTutionFee * per / 100;
            TutionFee = tempTutionFee - CalculateTutionFee;
            txtTotal.Text = (AdmissionFee + Misc + TutionFee).ToString();
        }

        protected void RDHafiz_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Hafiz e Quran";
        }

        protected void rdOldStudent_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Old student";
        }

        protected void RdKinShip_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "KinShip (Brother & sisters)";
        }

        protected void RDSportsMan_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Sportsman";
        }

        protected void rdGemployee_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Government employee";
        }

        protected void RdTeacher_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Teacher's son";
        }

        protected void RdOrphan_CheckedChanged(object sender, EventArgs e)
        {
            ScholarShipCalculate(20);
            EscholarShip = "Orphan";
        }

        protected void rdNone_CheckedChanged(object sender, EventArgs e)
        {
            EscholarShip = "None";
            ScholarShipCalculate(0);
        }

        private void GetScholarShip(ref bool ESchchecked, ref string E_scholarShip, DataTable dtClgFee)
        {
            ESchchecked = Convert.ToBoolean(dtClgFee.Rows[0]["isEscholarship"]);

            if (ESchchecked)
            {
                E_scholarShip = dtClgFee.Rows[0]["EScholarship"].ToString();
                switch (E_scholarShip)
                {
                    case "Hafiz e Quran":
                        rdNone.Checked = false;
                        RDHafiz.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text=dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "Old student":
                        rdNone.Checked = false;
                        rdOldStudent.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "KinShip (Brother & sisters)":
                        rdNone.Checked = false;
                        RdKinShip.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "Sportsman":
                        rdNone.Checked = false;
                        RDSportsMan.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "Government employee":
                        rdNone.Checked = false;
                        rdGemployee.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "Teacher's son":
                        rdNone.Checked = false;
                        RdTeacher.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    case "Orphan":
                        rdNone.Checked = false;
                        RdTeacher.Checked = true;
                        txtTotal.Text = string.Empty;
                        txtTotal.Text = dtClgFee.Rows[0]["TotalFee"].ToString();
                        break;

                    default:
                        rdNone.Checked = true;

                        break;
                }
            }
        }

    }
}