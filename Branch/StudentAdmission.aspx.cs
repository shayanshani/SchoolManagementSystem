using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Branch
{
    public partial class StudentAdmission : System.Web.UI.Page
    {

        public static TblStudent student;
        string postedFile = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["BranchUserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                cmptodayDate.ValueToCompare = DateTime.Now.ToShortDateString();
                cmpDOA.ValueToCompare = DateTime.Now.ToShortDateString();
                cmpDOB.ValueToCompare = DateTime.Now.ToShortDateString();
                LoadRoutes();
                LoadHostels();
                radioMale.Checked = true;
                radioSpring.Checked = true;
                //divHostel.Visible = false;
                //divTransport.Visible = false;
                if (Session["StudentID"] != null)
                {
                    TblStudent student = new TblStudent(Session["StudentID"]);
                    txtStudentName.Text = student.StudentName;
                    txtFatherName.Text = student.FatherName;
                    txtRegNo.Text = student.RegistrationNo;
                    ddlLevel.SelectedValue = student.LevelID.ToString();
                    BindClasses(ddlLevel.SelectedValue);
                    ddlClass.SelectedValue = student.ClassNo.ToString();
                    if (student.GroupID != -1)
                    {
                        LoadGroup(ddlClass.SelectedValue);
                        ddlGroup.SelectedValue = student.GroupID.ToString();
                    }

                    if (student.LevelID.ToString() == "2")
                    {

                        DDProgName.SelectedValue = student.Program;
                        Query qry = new Query(TblStudentAcademicRecord.Schema);
                        qry.AddWhere(TblStudentAcademicRecord.Columns.StudentID, Comparison.Equals, student.StudentID);
                        DataTable dt = qry.ExecuteDataSet().Tables[0];
                        DropDownMatric.SelectedValue = dt.Rows[0]["Degree"].ToString();
                        txtSCCInstitue.Text = dt.Rows[0]["Board"].ToString();
                        txtSSCYear.Text = dt.Rows[0]["Year"].ToString();
                        txtSSCRNo.Text = dt.Rows[0]["RollNo"].ToString();
                        txtSSCTMarks.Text = dt.Rows[0]["TotalMarks"].ToString();
                        txtSSCOMarks.Text = dt.Rows[0]["ObtainedMarks"].ToString();
                        txtSSCGrade.Text = dt.Rows[0]["Grade"].ToString();
                        txtSSCDestinction.Text = dt.Rows[0]["MajorSubject"].ToString();

                        if (dt.Rows.Count == 2)
                        {
                            DropDownInter.SelectedValue = dt.Rows[1]["Degree"].ToString();
                            txtInterInstitue.Text = dt.Rows[1]["Board"].ToString();
                            txtInterYear.Text = dt.Rows[1]["Year"].ToString();
                            txtInterRNo.Text = dt.Rows[1]["RollNo"].ToString();
                            txtInterTMarks.Text = dt.Rows[1]["TotalMarks"].ToString();
                            txtInterOMarks.Text = dt.Rows[1]["ObtainedMarks"].ToString();
                            txtInterGrade.Text = dt.Rows[1]["Grade"].ToString();
                            txtInterDestinction.Text = dt.Rows[1]["MajorSubject"].ToString();
                        }
                        devAcademic.Visible = true;
                    }
                    if (student.Session == "Spring")
                        radioSpring.Checked = true;
                    else
                        radioFall.Checked = true;
                   
                    txtDOB.SelectedDate = Convert.ToDateTime(student.Dob);
                    txtDOA.SelectedDate = Convert.ToDateTime(student.DateofAdmission);
                    hdnID.Value = student.StudentID.ToString();
                    reqFpic.Enabled = false;
                    lblimgName.Text = student.Pic;
                    lblimgName.Visible = true;

                    if (student.Gender == "Male")
                        radioMale.Checked = true;
                    else
                        radioFemale.Checked = true;
                    if (student.IsTrannsport == true)
                    {
                        chkTransport.Checked = true;
                        divTransport.Visible = true;
                    }
                    if (student.IsHostel == true)
                    {
                        chkHostel.Checked = true;
                        divHostel.Visible = true;
                    }
                    txtNationality.Text = student.Nationality;
                    txtDomicile.Text = student.Domicile;
                    ddlReligion.SelectedValue = student.Religion;
                    txtCNIC.Text = student.Cnic;
                    txtPlaceOfBirth.Text = student.PlaceofBirth;
                    txtStdEmail.Text = student.SEmail;
                    txtStdCell.Text = student.SCellNo;
                    txtHomeAddress.Text = student.SAddress;
                    txtPhoneNo.Text = student.SHomePhone;
                    txtGardianName.Text = student.GName;
                    txtRelationship.Text = student.GRelationship;
                    txtOfficeAddress.Text = student.GAddress;
                    txtGEmail.Text = student.GEmail;
                    txtGOccupation.Text = student.GOccupation;
                    txtMonthlyIncome.Text = student.GMonthlyIncome.ToString();
                    txtGCell.Text = student.GCellNo;

                    LoadHostelRecord();
                    LoadTransportRecord();
                    //LoadEnrollment();
                    Session["StudentID"] = null;
                }
                else
                    hdnID.Value = "";
            }

            if (txtPic.HasFile)
            {
                lblimgName.Text = txtPic.FileName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (helper.ExecutePlainQuery("select * from TblStudents where RegistrationNo='" + txtRegNo.Text + "' and BranchID=" + Session["BranchID"]).Rows.Count > 0 && String.IsNullOrEmpty(hdnID.Value))
            {
                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, txtRegNo.Text + " already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "icon mdi mdi-check");
            }
            else
            {
                string msg = "student has been added!";
                if (hdnID.Value == "")
                {
                    student = new TblStudent();
                    student.IsNew = true;
                    student.CreateBy = Convert.ToString(Session["BranchUserID"]);
                }
                else
                {
                    student = new TblStudent(hdnID.Value);
                    student.IsNew = false;
                    msg = "student has been updated!";
                    student.UpdatedBy = Convert.ToString(Session["BranchUserID"]);
                }
                student.BranchID = Convert.ToInt32(Session["BranchID"]);
                student.StudentName = txtStudentName.Text;
                student.FatherName = txtFatherName.Text;
                student.IsActive = true;
                student.RegistrationNo = txtRegNo.Text;
                student.LevelID = Convert.ToInt32(ddlLevel.SelectedValue);

                if (DDProgName.SelectedValue != "-1")
                    if (DDProgName.SelectedValue == "PreEng")
                        student.Program = "FSC";
                    else if (DDProgName.SelectedValue == "PreMed")
                        student.Program = "FSC";
                    else
                        student.Program = DDProgName.SelectedValue;

                if (radioSpring.Checked)
                    student.Session = "Spring";
                else
                    student.Session = "Autumn";
                student.DateofAdmission = txtDOA.SelectedDate;
                if (radioMale.Checked)
                    student.Gender = "Male";
                else
                    student.Gender = "Female";


                if (txtPic.HasFile)
                {
                    if (String.IsNullOrEmpty(lblimgName.Text))
                        postedFile = txtPic.FileName;
                    else
                        postedFile = lblimgName.Text;

                    txtPic.SaveAs(Server.MapPath("~/Admin/assets/CustomImages/" + txtPic.FileName));
                    student.Pic = postedFile;
                }

                student.Nationality = txtNationality.Text;
                student.Domicile = txtDomicile.Text;
                student.Religion = ddlReligion.SelectedValue;
                student.Cnic = txtCNIC.Text;
                student.Dob = txtDOB.SelectedDate;
                student.PlaceofBirth = txtPlaceOfBirth.Text;
                student.SEmail = txtStdEmail.Text;
                student.SCellNo = txtStdCell.Text;
                student.SHomePhone = txtPhoneNo.Text;
                student.SAddress = txtHomeAddress.Text;
                if (chkTransport.Checked)
                {
                    student.IsTrannsport = true;
                }
                else
                {
                    student.IsTrannsport = false;
                }
                if (chkHostel.Checked)
                {
                    student.IsHostel = true;
                }
                else
                {
                    student.IsHostel = false;
                }
                student.GName = txtGardianName.Text;
                student.GRelationship = txtRelationship.Text;
                student.GAddress = txtOfficeAddress.Text;
                student.GEmail = txtGEmail.Text;
                student.GOccupation = txtGOccupation.Text;
                student.GMonthlyIncome = Convert.ToDecimal(txtMonthlyIncome.Text);
                student.GCellNo = txtGCell.Text;
                student.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
                
                if (!String.IsNullOrEmpty(ddlGroup.SelectedValue))
                    student.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                
                student.Save();

                if (ddlLevel.SelectedValue == "2")
                {
                    student.Program = DDProgName.SelectedValue;
                    Query qry = new Query(TblStudentAcademicRecord.Schema);
                    qry.AddWhere(TblStudentAcademicRecord.Columns.StudentID, Comparison.Equals, student.StudentID);
                    DataTable dt = qry.ExecuteDataSet().Tables[0];
                    TblStudentAcademicRecord academic;
                    if (dt.Rows.Count == 0)
                    {
                        academic = new TblStudentAcademicRecord();
                        academic.IsNew = true;
                    }
                    else
                    {
                        academic = new TblStudentAcademicRecord(dt.Rows[0]["ARecordID"]);
                        academic.IsNew = false;
                    }
                    academic.StudentID = student.StudentID;
                    academic.Degree = DropDownMatric.SelectedValue;
                    academic.Board = txtSCCInstitue.Text;
                    academic.Year = txtSSCYear.Text;
                    academic.RollNo = txtSSCRNo.Text;
                    academic.TotalMarks = Convert.ToInt32(txtSSCTMarks.Text);
                    academic.ObtainedMarks = Convert.ToInt32(txtSSCOMarks.Text);
                    academic.Grade = txtSSCGrade.Text;
                    academic.MajorSubject = txtSSCDestinction.Text;
                    academic.Save();

                    if (DropDownInter.SelectedValue != "-1")
                    {
                        TblStudentAcademicRecord interacademic;
                        if (dt.Rows.Count == 0)
                        {
                            interacademic = new TblStudentAcademicRecord();
                            interacademic.IsNew = true;
                        }
                        else
                        {
                            interacademic = new TblStudentAcademicRecord(dt.Rows[1]["ARecordID"]);
                            interacademic.IsNew = false;
                        }
                        interacademic.StudentID = student.StudentID;
                        interacademic.Degree = DropDownInter.SelectedValue;
                        interacademic.Board = txtInterInstitue.Text;
                        interacademic.Year = txtInterYear.Text;
                        interacademic.RollNo = txtInterRNo.Text;
                        interacademic.TotalMarks = Convert.ToInt32(txtInterTMarks.Text);
                        interacademic.ObtainedMarks = Convert.ToInt32(txtInterOMarks.Text);
                        interacademic.Grade = txtInterGrade.Text;
                        interacademic.MajorSubject = txtInterDestinction.Text;
                        interacademic.Save();
                    }
                }

                if (chkTransport.Checked)
                {
                    TblTransportHolder transport;
                    if (hdnID.Value != "")
                    {
                        transport = new SubSonic.Select()
                                    .From(TblTransportHolder.Schema)
                                    .Where(TblTransportHolder.Columns.MemberID).IsEqualTo(hdnID.Value)
                                    .And(TblTransportHolder.Columns.MemberType).IsEqualTo(false)
                                    .ExecuteSingle<TblTransportHolder>();
                        if (transport == null)
                        {
                            transport = new TblTransportHolder();
                            transport.IsNew = true;
                        }
                        else
                            transport.IsNew = false;
                    }
                    else
                    {
                        transport = new TblTransportHolder();
                        transport.IsNew = true;
                    }
                    transport.RouteID = Convert.ToInt32(ddlRoute.SelectedValue);
                    transport.BusID = Convert.ToInt32(ddlBus.SelectedValue);
                    transport.MemberID = student.StudentID;
                    transport.MemberType = false;
                    transport.Discount = Convert.ToInt32(txtDiscount.Text);
                    transport.SeatNo = Convert.ToInt32(txtSeatNo.Text);
                    transport.Stop = txtBusStop.Text;
                    transport.JoiningDate = txtTJoinDate.SelectedDate;
                    transport.IsActive = true;
                    transport.Save();
                }

                if (chkHostel.Checked)
                {
                    TblHostelEnrollment hostel;
                    if (hdnID.Value != "")
                    {
                        hostel = new SubSonic.Select()
                                    .From(TblHostelEnrollment.Schema)
                                    .Where(TblHostelEnrollment.Columns.MemberID).IsEqualTo(hdnID.Value)
                                    .And(TblHostelEnrollment.Columns.MemberType).IsEqualTo(false)
                                    .ExecuteSingle<TblHostelEnrollment>();
                        if (hostel == null)
                        {
                            hostel = new TblHostelEnrollment();
                            hostel.IsNew = true;
                        }
                        else
                            hostel.IsNew = false;
                    }
                    else
                    {
                        hostel = new TblHostelEnrollment();
                        hostel.IsNew = true;
                    }
                    hostel.MemberID = student.StudentID;
                    hostel.MemberType = false;
                    hostel.HostelID = Convert.ToInt32(ddlHostel.SelectedValue);
                    hostel.HAdmissionDate = txtEnrollDate.SelectedDate;
                    hostel.Save();
                }

                //TblCurrentEnrollment Currenroll;
                //if (hdnID.Value != "")
                //{
                //    Currenroll = new SubSonic.Select()
                //                .From(TblCurrentEnrollment.Schema)
                //                .Where(TblCurrentEnrollment.Columns.StudentID).IsEqualTo(hdnID.Value)
                //                .ExecuteSingle<TblCurrentEnrollment>();
                //    if (Currenroll == null)
                //    {
                //        Currenroll = new TblCurrentEnrollment();
                //        Currenroll.IsNew = true;
                //        Currenroll.CreateBy = Convert.ToString(Session["BranchUserID"]);
                //    }
                //    else
                //    {
                //        Currenroll.IsNew = false;
                //        Currenroll.UpdatedBy = Convert.ToString(Session["BranchUserID"]);
                //    }
                //}
                //else
                //{
                //    Currenroll = new TblCurrentEnrollment();
                //    Currenroll.IsNew = true;
                //    Currenroll.CreateBy = Convert.ToString(Session["BranchUserID"]);
                //}
                //Currenroll.StudentID = student.StudentID;
                //Currenroll.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
                //Currenroll.BranchID = Convert.ToInt32(Session["BranchID"]);
                //Currenroll.EnrollmentDate = DateTime.Now;
                //Currenroll.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                //Currenroll.Save();

                //TblEnrollmentHistory EnrollHistory;
                //if (hdnID.Value != "")
                //{
                //    EnrollHistory = new SubSonic.Select()
                //                .From(TblEnrollmentHistory.Schema)
                //                .Where(TblEnrollmentHistory.Columns.StudentID).IsEqualTo(hdnID.Value)
                //                .And(TblEnrollmentHistory.Columns.ClassNo).IsEqualTo(ddlClass.SelectedValue)
                //                .ExecuteSingle<TblEnrollmentHistory>();
                //    if (EnrollHistory == null)
                //    {
                //        EnrollHistory = new TblEnrollmentHistory();
                //        EnrollHistory.IsNew = true;
                //        EnrollHistory.CreateBy = Convert.ToString(Session["BranchUserID"]);
                //    }
                //    else
                //    {
                //        EnrollHistory.IsNew = false;
                //        EnrollHistory.UpdatedBy = Convert.ToString(Session["BranchUserID"]);
                //    }
                //}
                //else
                //{
                //    EnrollHistory = new TblEnrollmentHistory();
                //    EnrollHistory.IsNew = true;
                //    EnrollHistory.CreateBy = Convert.ToString(Session["BranchUserID"]);
                //}
                //EnrollHistory.StudentID = student.StudentID;
                //EnrollHistory.ClassNo = Convert.ToInt32(ddlClass.SelectedValue);
                //EnrollHistory.BranchID = Convert.ToInt32(Session["BranchID"]);
                //EnrollHistory.EnrollmentDate = DateTime.Now;
                //EnrollHistory.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                //EnrollHistory.Save();

                lblmsg.Text = helper.DisplayNotificationMessage(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "icon mdi mdi-check");
                helper.ClearInputs(this.Controls);
                txtDOB.SelectedDate = null;
                txtDOA.SelectedDate = null;
                //  LoadTransportRecord();
                // LoadHostelRecord();
                lblimgName.Text = string.Empty;
                hdnID.Value = "";
                reqFpic.Enabled = true;
                chkHostel.Checked = false;
                chkTransport.Checked = false;
                lblimgName.Visible = false;
            }


        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLevel.SelectedValue == "2")
            {
                divProgram.Visible = true;
                devAcademic.Visible = true;
            }
            else
            {
                divProgram.Visible = false;
                devAcademic.Visible = false;
            }
            BindClasses(ddlLevel.SelectedValue);
        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        private void LoadTransportRecord()
        {
            TblTransportHolder transport = new SubSonic.Select()
                           .From(TblTransportHolder.Schema)
                           .Where(TblTransportHolder.Columns.MemberID).IsEqualTo(hdnID.Value)
                           .And(TblTransportHolder.Columns.MemberType).IsEqualTo(false)
                           .ExecuteSingle<TblTransportHolder>();
            if (transport != null)
            {
                ddlRoute.SelectedValue = transport.RouteID.ToString();
                LoadBuses();
                ddlBus.SelectedValue = transport.BusID.ToString();
                txtDiscount.Text = transport.Discount.ToString();
                txtSeatNo.Text = transport.SeatNo.ToString();
                txtBusStop.Text = transport.Stop.ToString();
                txtTJoinDate.SelectedDate = Convert.ToDateTime(transport.JoiningDate);
            }
        }

        private void LoadHostelRecord()
        {
            TblHostelEnrollment hostel = new SubSonic.Select()
                           .From(TblHostelEnrollment.Schema)
                           .Where(TblHostelEnrollment.Columns.MemberID).IsEqualTo(hdnID.Value)
                           .And(TblHostelEnrollment.Columns.MemberType).IsEqualTo(false)
                           .ExecuteSingle<TblHostelEnrollment>();
            if (hostel != null)
            {
                ddlHostel.SelectedValue = hostel.HostelID.ToString();
                txtEnrollDate.SelectedDate = Convert.ToDateTime(hostel.HAdmissionDate);
            }
        }

        private void LoadEnrollment()
        {
            TblCurrentEnrollment currenroll = new SubSonic.Select()
                           .From(TblCurrentEnrollment.Schema)
                           .Where(TblCurrentEnrollment.Columns.StudentID).IsEqualTo(hdnID.Value)
                           .ExecuteSingle<TblCurrentEnrollment>();
            if (currenroll != null)
            {
                ddlClass.SelectedValue = currenroll.ClassNo.ToString();
                LoadGroup(ddlClass.SelectedValue);
                ddlGroup.SelectedValue = currenroll.GroupID.ToString();
            }
        }

        protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBuses();
            }
            catch
            {
            }
        }

        private void LoadRoutes()
        {
            ddlRoute.DataSource = helper.ExecutePlainQuery("select RouteID,rfrom + ' - ' + rto Route from tbl_route where isactive=1 and BranchID=" + Session["BranchID"]);
            ddlRoute.DataValueField = "RouteID";
            ddlRoute.DataTextField = "Route";
            ddlRoute.DataBind();
            ddlRoute.Items.Insert(0, new ListItem("Select Route", "-1"));
        }

        private void LoadBuses()
        {
            try
            {
                Query qry = new Query(TblBu.Schema);
                qry.AddWhere(TblBu.Columns.RouteID, Comparison.Equals, ddlRoute.SelectedValue)
                    .AND(TblBu.Columns.IsActive, Comparison.Equals, true);
                ddlBus.DataSource = qry.ExecuteDataSet().Tables[0];
                ddlBus.DataValueField = "BusID";
                ddlBus.DataTextField = "BusNo";
                ddlBus.DataBind();
                ddlBus.Items.Insert(0, new ListItem("Select Bus", "-1"));
            }
            catch { }
        }

        private void LoadHostels()
        {
            Query qry = new Query(TblHostelinformation.Schema);
            qry.AddWhere(TblHostelinformation.Columns.BranchID, Comparison.Equals, Session["BranchID"]).
                AND(TblHostelinformation.Columns.IsActive, Comparison.Equals, true);
            ddlHostel.DataSource = qry.ExecuteDataSet().Tables[0];
            ddlHostel.DataValueField = "HostelID";
            ddlHostel.DataTextField = "HostelName";
            ddlHostel.DataBind();
            ddlHostel.Items.Insert(0, new ListItem("Select Hostel", "-1"));
        }

        private void BindClasses(string LevelID)
        {
            DataTable dt = helper.ExecutePlainQuery("select * from tbl_ClassInformation where  LevelID=" + LevelID + "and BranchID=" + Session["BranchID"]);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassNo";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("--Select class--", "-1"));
        }

        private void LoadGroup(string ClassID)
        {
            try
            {
                Query qry = new Query(TblGroup.Schema);
                qry.AddWhere(TblGroup.Columns.BranchID, Comparison.Equals, Session["BranchID"]).
                    AND(TblGroup.Columns.ClassID, Comparison.Equals, ClassID);
                ddlGroup.DataSource = qry.ExecuteDataSet().Tables[0];
                ddlGroup.DataValueField = "GroupID";
                ddlGroup.DataTextField = "GroupName";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("--Select Group--", "-1"));
            }
            catch
            { }
        }

        protected void chkTransport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransport.Checked)
                divTransport.Visible = true;
            else
                divTransport.Visible = false;
        }

        protected void chkHostel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHostel.Checked)
                divHostel.Visible = true;
            else
                divHostel.Visible = false;
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroup(ddlClass.SelectedValue);
        }
    }
}