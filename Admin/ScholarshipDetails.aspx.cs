using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
using SchoolManagementSystem.DL;
namespace SchoolManagementSystem.Admin
{
    public partial class ScholarshipDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadScholarship();
            }

        }
        public void loadScholarship()
        {
            rptScholarship.DataSource = helper.ExecutePlainQuery("select * from tbl_ProgramFee");
            rptScholarship.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblProgramFee obj = new TblProgramFee();
            obj.IsNew = true;
            if (!string.IsNullOrEmpty(hdnScholarshipID.Value))
            {
                obj = new TblProgramFee(hdnScholarshipID.Value);
                obj.IsNew = false;
            }
            obj.Program = DDProgName.SelectedValue;
            obj.TotalFee = Convert.ToInt32(txtTotalFee.Text);
            obj.TuitionFee = Convert.ToInt32(txtTuitionFee.Text);
            obj.Mise = Convert.ToInt32(txtMisc.Text);
            obj.AdmissionFee = Convert.ToInt32(txtAdmissionFee.Text);
            obj.Save();
            hdnScholarshipID.Value = null;
            helper.ClearInputs(this.Page.Controls);


        }

        protected void timerNews_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}