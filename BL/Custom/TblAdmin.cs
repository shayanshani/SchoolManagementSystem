using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace SchoolManagementSystem.BL
{

	public partial class TblAdmin  
	{
        public static DataTable AdminLogin(string UserName,string Password)
        {
            return SPs.SpAdminLogin(UserName, Password).GetDataSet().Tables[0];
        }
	}
}
