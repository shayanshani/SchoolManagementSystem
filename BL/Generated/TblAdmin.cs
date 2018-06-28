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
	/// <summary>
	/// Strongly-typed collection for the TblAdmin class.
	/// </summary>
    [Serializable]
	public partial class TblAdminCollection : ActiveList<TblAdmin, TblAdminCollection>
	{	   
		public TblAdminCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAdminCollection</returns>
		public TblAdminCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAdmin o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the tbl_Admins table.
	/// </summary>
	[Serializable]
	public partial class TblAdmin : ActiveRecord<TblAdmin>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAdmin()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAdmin(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAdmin(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAdmin(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("tbl_Admins", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAdminID = new TableSchema.TableColumn(schema);
				colvarAdminID.ColumnName = "AdminID";
				colvarAdminID.DataType = DbType.Int32;
				colvarAdminID.MaxLength = 0;
				colvarAdminID.AutoIncrement = true;
				colvarAdminID.IsNullable = false;
				colvarAdminID.IsPrimaryKey = true;
				colvarAdminID.IsForeignKey = false;
				colvarAdminID.IsReadOnly = false;
				colvarAdminID.DefaultSetting = @"";
				colvarAdminID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdminID);
				
				TableSchema.TableColumn colvarAdminName = new TableSchema.TableColumn(schema);
				colvarAdminName.ColumnName = "AdminName";
				colvarAdminName.DataType = DbType.AnsiString;
				colvarAdminName.MaxLength = 250;
				colvarAdminName.AutoIncrement = false;
				colvarAdminName.IsNullable = true;
				colvarAdminName.IsPrimaryKey = false;
				colvarAdminName.IsForeignKey = false;
				colvarAdminName.IsReadOnly = false;
				colvarAdminName.DefaultSetting = @"";
				colvarAdminName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdminName);
				
				TableSchema.TableColumn colvarAdminEmail = new TableSchema.TableColumn(schema);
				colvarAdminEmail.ColumnName = "AdminEmail";
				colvarAdminEmail.DataType = DbType.AnsiString;
				colvarAdminEmail.MaxLength = 250;
				colvarAdminEmail.AutoIncrement = false;
				colvarAdminEmail.IsNullable = true;
				colvarAdminEmail.IsPrimaryKey = false;
				colvarAdminEmail.IsForeignKey = false;
				colvarAdminEmail.IsReadOnly = false;
				colvarAdminEmail.DefaultSetting = @"";
				colvarAdminEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdminEmail);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "Password";
				colvarPassword.DataType = DbType.AnsiString;
				colvarPassword.MaxLength = 250;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = true;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarContact = new TableSchema.TableColumn(schema);
				colvarContact.ColumnName = "Contact";
				colvarContact.DataType = DbType.AnsiString;
				colvarContact.MaxLength = 250;
				colvarContact.AutoIncrement = false;
				colvarContact.IsNullable = true;
				colvarContact.IsPrimaryKey = false;
				colvarContact.IsForeignKey = false;
				colvarContact.IsReadOnly = false;
				colvarContact.DefaultSetting = @"";
				colvarContact.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContact);
				
				TableSchema.TableColumn colvarVerificationCode = new TableSchema.TableColumn(schema);
				colvarVerificationCode.ColumnName = "VerificationCode";
				colvarVerificationCode.DataType = DbType.AnsiString;
				colvarVerificationCode.MaxLength = -1;
				colvarVerificationCode.AutoIncrement = false;
				colvarVerificationCode.IsNullable = true;
				colvarVerificationCode.IsPrimaryKey = false;
				colvarVerificationCode.IsForeignKey = false;
				colvarVerificationCode.IsReadOnly = false;
				colvarVerificationCode.DefaultSetting = @"";
				colvarVerificationCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVerificationCode);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Admins",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("AdminID")]
		[Bindable(true)]
		public int AdminID 
		{
			get { return GetColumnValue<int>(Columns.AdminID); }
			set { SetColumnValue(Columns.AdminID, value); }
		}
		  
		[XmlAttribute("AdminName")]
		[Bindable(true)]
		public string AdminName 
		{
			get { return GetColumnValue<string>(Columns.AdminName); }
			set { SetColumnValue(Columns.AdminName, value); }
		}
		  
		[XmlAttribute("AdminEmail")]
		[Bindable(true)]
		public string AdminEmail 
		{
			get { return GetColumnValue<string>(Columns.AdminEmail); }
			set { SetColumnValue(Columns.AdminEmail, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		  
		[XmlAttribute("Contact")]
		[Bindable(true)]
		public string Contact 
		{
			get { return GetColumnValue<string>(Columns.Contact); }
			set { SetColumnValue(Columns.Contact, value); }
		}
		  
		[XmlAttribute("VerificationCode")]
		[Bindable(true)]
		public string VerificationCode 
		{
			get { return GetColumnValue<string>(Columns.VerificationCode); }
			set { SetColumnValue(Columns.VerificationCode, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varAdminName,string varAdminEmail,string varPassword,string varContact,string varVerificationCode)
		{
			TblAdmin item = new TblAdmin();
			
			item.AdminName = varAdminName;
			
			item.AdminEmail = varAdminEmail;
			
			item.Password = varPassword;
			
			item.Contact = varContact;
			
			item.VerificationCode = varVerificationCode;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAdminID,string varAdminName,string varAdminEmail,string varPassword,string varContact,string varVerificationCode)
		{
			TblAdmin item = new TblAdmin();
			
				item.AdminID = varAdminID;
			
				item.AdminName = varAdminName;
			
				item.AdminEmail = varAdminEmail;
			
				item.Password = varPassword;
			
				item.Contact = varContact;
			
				item.VerificationCode = varVerificationCode;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AdminIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AdminNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AdminEmailColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn VerificationCodeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AdminID = @"AdminID";
			 public static string AdminName = @"AdminName";
			 public static string AdminEmail = @"AdminEmail";
			 public static string Password = @"Password";
			 public static string Contact = @"Contact";
			 public static string VerificationCode = @"VerificationCode";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
