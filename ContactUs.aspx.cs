using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.BL;
namespace SchoolManagementSystem
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            TblContactU obj = new TblContactU();
            obj.IsNew = true;
            obj.Name = txtName.Text;
            obj.ContactNo = txtContactNo.Text;
            obj.Email = txtEmail.Text;
            obj.Message = txtmsg.Text;
            obj.Save();
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Your message has been sent. Thanks";
            txtContactNo.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtmsg.Text = "";
        }
    }
}