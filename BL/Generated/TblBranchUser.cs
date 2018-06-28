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
	/// Strongly-typed collection for the TblBranchUser class.
	/// </summary>
    [Serializable]
	public partial class TblBranchUserCollection : ActiveList<TblBranchUser, TblBranchUserCollection>
	{	   
		public TblBranchUserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblBranchUserCollection</returns>
		public TblBranchUserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblBranchUser o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_BranchUser table.
	/// </summary>
	[Serializable]
	public partial class TblBranchUser : ActiveRecord<TblBranchUser>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblBranchUser()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblBranchUser(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblBranchUser(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblBranchUser(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_BranchUser", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = true;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = true;
				colvarUserID.IsForeignKey = false;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				colvarUserID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarBranchID = new TableSchema.TableColumn(schema);
				colvarBranchID.ColumnName = "BranchID";
				colvarBranchID.DataType = DbType.Int32;
				colvarBranchID.MaxLength = 0;
				colvarBranchID.AutoIncrement = false;
				colvarBranchID.IsNullable = true;
				colvarBranchID.IsPrimaryKey = false;
				colvarBranchID.IsForeignKey = false;
				colvarBranchID.IsReadOnly = false;
				colvarBranchID.DefaultSetting = @"";
				colvarBranchID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBranchID);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.AnsiString;
				colvarUserName.MaxLength = 50;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = true;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarContact = new TableSchema.TableColumn(schema);
				colvarContact.ColumnName = "Contact";
				colvarContact.DataType = DbType.AnsiString;
				colvarContact.MaxLength = 50;
				colvarContact.AutoIncrement = false;
				colvarContact.IsNullable = true;
				colvarContact.IsPrimaryKey = false;
				colvarContact.IsForeignKey = false;
				colvarContact.IsReadOnly = false;
				colvarContact.DefaultSetting = @"";
				colvarContact.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContact);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = -1;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
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
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.AnsiString;
				colvarAddress.MaxLength = -1;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarImage = new TableSchema.TableColumn(schema);
				colvarImage.ColumnName = "Image";
				colvarImage.DataType = DbType.AnsiString;
				colvarImage.MaxLength = -1;
				colvarImage.AutoIncrement = false;
				colvarImage.IsNullable = true;
				colvarImage.IsPrimaryKey = false;
				colvarImage.IsForeignKey = false;
				colvarImage.IsReadOnly = false;
				colvarImage.DefaultSetting = @"";
				colvarImage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImage);
				
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
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "isActive";
				colvarIsActive.DataType = DbType.Boolean;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = true;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				TableSchema.TableColumn colvarIsFirst = new TableSchema.TableColumn(schema);
				colvarIsFirst.ColumnName = "isFirst";
				colvarIsFirst.DataType = DbType.Boolean;
				colvarIsFirst.MaxLength = 0;
				colvarIsFirst.AutoIncrement = false;
				colvarIsFirst.IsNullable = true;
				colvarIsFirst.IsPrimaryKey = false;
				colvarIsFirst.IsForeignKey = false;
				colvarIsFirst.IsReadOnly = false;
				colvarIsFirst.DefaultSetting = @"";
				colvarIsFirst.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsFirst);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_BranchUser",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("UserName")]
		[Bindable(true)]
		public string UserName 
		{
			get { return GetColumnValue<string>(Columns.UserName); }
			set { SetColumnValue(Columns.UserName, value); }
		}
		  
		[XmlAttribute("Contact")]
		[Bindable(true)]
		public string Contact 
		{
			get { return GetColumnValue<string>(Columns.Contact); }
			set { SetColumnValue(Columns.Contact, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("Image")]
		[Bindable(true)]
		public string Image 
		{
			get { return GetColumnValue<string>(Columns.Image); }
			set { SetColumnValue(Columns.Image, value); }
		}
		  
		[XmlAttribute("VerificationCode")]
		[Bindable(true)]
		public string VerificationCode 
		{
			get { return GetColumnValue<string>(Columns.VerificationCode); }
			set { SetColumnValue(Columns.VerificationCode, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		  
		[XmlAttribute("IsFirst")]
		[Bindable(true)]
		public bool? IsFirst 
		{
			get { return GetColumnValue<bool?>(Columns.IsFirst); }
			set { SetColumnValue(Columns.IsFirst, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,string varUserName,string varContact,string varEmail,string varPassword,string varAddress,string varImage,string varVerificationCode,bool? varIsActive,bool? varIsFirst)
		{
			TblBranchUser item = new TblBranchUser();
			
			item.BranchID = varBranchID;
			
			item.UserName = varUserName;
			
			item.Contact = varContact;
			
			item.Email = varEmail;
			
			item.Password = varPassword;
			
			item.Address = varAddress;
			
			item.Image = varImage;
			
			item.VerificationCode = varVerificationCode;
			
			item.IsActive = varIsActive;
			
			item.IsFirst = varIsFirst;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserID,int? varBranchID,string varUserName,string varContact,string varEmail,string varPassword,string varAddress,string varImage,string varVerificationCode,bool? varIsActive,bool? varIsFirst)
		{
			TblBranchUser item = new TblBranchUser();
			
				item.UserID = varUserID;
			
				item.BranchID = varBranchID;
			
				item.UserName = varUserName;
			
				item.Contact = varContact;
			
				item.Email = varEmail;
			
				item.Password = varPassword;
			
				item.Address = varAddress;
			
				item.Image = varImage;
			
				item.VerificationCode = varVerificationCode;
			
				item.IsActive = varIsActive;
			
				item.IsFirst = varIsFirst;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn VerificationCodeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IsFirstColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserID = @"UserID";
			 public static string BranchID = @"BranchID";
			 public static string UserName = @"UserName";
			 public static string Contact = @"Contact";
			 public static string Email = @"Email";
			 public static string Password = @"Password";
			 public static string Address = @"Address";
			 public static string Image = @"Image";
			 public static string VerificationCode = @"VerificationCode";
			 public static string IsActive = @"isActive";
			 public static string IsFirst = @"isFirst";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
