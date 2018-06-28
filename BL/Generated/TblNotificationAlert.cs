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
	/// Strongly-typed collection for the TblNotificationAlert class.
	/// </summary>
    [Serializable]
	public partial class TblNotificationAlertCollection : ActiveList<TblNotificationAlert, TblNotificationAlertCollection>
	{	   
		public TblNotificationAlertCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblNotificationAlertCollection</returns>
		public TblNotificationAlertCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblNotificationAlert o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_NotificationAlert table.
	/// </summary>
	[Serializable]
	public partial class TblNotificationAlert : ActiveRecord<TblNotificationAlert>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblNotificationAlert()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblNotificationAlert(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblNotificationAlert(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblNotificationAlert(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_NotificationAlert", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNotificationID = new TableSchema.TableColumn(schema);
				colvarNotificationID.ColumnName = "NotificationID";
				colvarNotificationID.DataType = DbType.Int32;
				colvarNotificationID.MaxLength = 0;
				colvarNotificationID.AutoIncrement = true;
				colvarNotificationID.IsNullable = false;
				colvarNotificationID.IsPrimaryKey = true;
				colvarNotificationID.IsForeignKey = false;
				colvarNotificationID.IsReadOnly = false;
				colvarNotificationID.DefaultSetting = @"";
				colvarNotificationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationID);
				
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
				
				TableSchema.TableColumn colvarNotificationDate = new TableSchema.TableColumn(schema);
				colvarNotificationDate.ColumnName = "NotificationDate";
				colvarNotificationDate.DataType = DbType.DateTime;
				colvarNotificationDate.MaxLength = 0;
				colvarNotificationDate.AutoIncrement = false;
				colvarNotificationDate.IsNullable = true;
				colvarNotificationDate.IsPrimaryKey = false;
				colvarNotificationDate.IsForeignKey = false;
				colvarNotificationDate.IsReadOnly = false;
				colvarNotificationDate.DefaultSetting = @"";
				colvarNotificationDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationDate);
				
				TableSchema.TableColumn colvarNotificationFrom = new TableSchema.TableColumn(schema);
				colvarNotificationFrom.ColumnName = "NotificationFrom";
				colvarNotificationFrom.DataType = DbType.AnsiString;
				colvarNotificationFrom.MaxLength = -1;
				colvarNotificationFrom.AutoIncrement = false;
				colvarNotificationFrom.IsNullable = true;
				colvarNotificationFrom.IsPrimaryKey = false;
				colvarNotificationFrom.IsForeignKey = false;
				colvarNotificationFrom.IsReadOnly = false;
				colvarNotificationFrom.DefaultSetting = @"";
				colvarNotificationFrom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationFrom);
				
				TableSchema.TableColumn colvarNotificationTo = new TableSchema.TableColumn(schema);
				colvarNotificationTo.ColumnName = "NotificationTo";
				colvarNotificationTo.DataType = DbType.AnsiString;
				colvarNotificationTo.MaxLength = -1;
				colvarNotificationTo.AutoIncrement = false;
				colvarNotificationTo.IsNullable = true;
				colvarNotificationTo.IsPrimaryKey = false;
				colvarNotificationTo.IsForeignKey = false;
				colvarNotificationTo.IsReadOnly = false;
				colvarNotificationTo.DefaultSetting = @"";
				colvarNotificationTo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationTo);
				
				TableSchema.TableColumn colvarNotificationSubject = new TableSchema.TableColumn(schema);
				colvarNotificationSubject.ColumnName = "NotificationSubject";
				colvarNotificationSubject.DataType = DbType.AnsiString;
				colvarNotificationSubject.MaxLength = -1;
				colvarNotificationSubject.AutoIncrement = false;
				colvarNotificationSubject.IsNullable = true;
				colvarNotificationSubject.IsPrimaryKey = false;
				colvarNotificationSubject.IsForeignKey = false;
				colvarNotificationSubject.IsReadOnly = false;
				colvarNotificationSubject.DefaultSetting = @"";
				colvarNotificationSubject.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationSubject);
				
				TableSchema.TableColumn colvarNotificationMessage = new TableSchema.TableColumn(schema);
				colvarNotificationMessage.ColumnName = "NotificationMessage";
				colvarNotificationMessage.DataType = DbType.AnsiString;
				colvarNotificationMessage.MaxLength = -1;
				colvarNotificationMessage.AutoIncrement = false;
				colvarNotificationMessage.IsNullable = true;
				colvarNotificationMessage.IsPrimaryKey = false;
				colvarNotificationMessage.IsForeignKey = false;
				colvarNotificationMessage.IsReadOnly = false;
				colvarNotificationMessage.DefaultSetting = @"";
				colvarNotificationMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationMessage);
				
				TableSchema.TableColumn colvarNotificationCode = new TableSchema.TableColumn(schema);
				colvarNotificationCode.ColumnName = "NotificationCode";
				colvarNotificationCode.DataType = DbType.AnsiString;
				colvarNotificationCode.MaxLength = -1;
				colvarNotificationCode.AutoIncrement = false;
				colvarNotificationCode.IsNullable = true;
				colvarNotificationCode.IsPrimaryKey = false;
				colvarNotificationCode.IsForeignKey = false;
				colvarNotificationCode.IsReadOnly = false;
				colvarNotificationCode.DefaultSetting = @"";
				colvarNotificationCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotificationCode);
				
				TableSchema.TableColumn colvarIsRead = new TableSchema.TableColumn(schema);
				colvarIsRead.ColumnName = "isRead";
				colvarIsRead.DataType = DbType.Boolean;
				colvarIsRead.MaxLength = 0;
				colvarIsRead.AutoIncrement = false;
				colvarIsRead.IsNullable = true;
				colvarIsRead.IsPrimaryKey = false;
				colvarIsRead.IsForeignKey = false;
				colvarIsRead.IsReadOnly = false;
				colvarIsRead.DefaultSetting = @"";
				colvarIsRead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsRead);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_NotificationAlert",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("NotificationID")]
		[Bindable(true)]
		public int NotificationID 
		{
			get { return GetColumnValue<int>(Columns.NotificationID); }
			set { SetColumnValue(Columns.NotificationID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("NotificationDate")]
		[Bindable(true)]
		public DateTime? NotificationDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.NotificationDate); }
			set { SetColumnValue(Columns.NotificationDate, value); }
		}
		  
		[XmlAttribute("NotificationFrom")]
		[Bindable(true)]
		public string NotificationFrom 
		{
			get { return GetColumnValue<string>(Columns.NotificationFrom); }
			set { SetColumnValue(Columns.NotificationFrom, value); }
		}
		  
		[XmlAttribute("NotificationTo")]
		[Bindable(true)]
		public string NotificationTo 
		{
			get { return GetColumnValue<string>(Columns.NotificationTo); }
			set { SetColumnValue(Columns.NotificationTo, value); }
		}
		  
		[XmlAttribute("NotificationSubject")]
		[Bindable(true)]
		public string NotificationSubject 
		{
			get { return GetColumnValue<string>(Columns.NotificationSubject); }
			set { SetColumnValue(Columns.NotificationSubject, value); }
		}
		  
		[XmlAttribute("NotificationMessage")]
		[Bindable(true)]
		public string NotificationMessage 
		{
			get { return GetColumnValue<string>(Columns.NotificationMessage); }
			set { SetColumnValue(Columns.NotificationMessage, value); }
		}
		  
		[XmlAttribute("NotificationCode")]
		[Bindable(true)]
		public string NotificationCode 
		{
			get { return GetColumnValue<string>(Columns.NotificationCode); }
			set { SetColumnValue(Columns.NotificationCode, value); }
		}
		  
		[XmlAttribute("IsRead")]
		[Bindable(true)]
		public bool? IsRead 
		{
			get { return GetColumnValue<bool?>(Columns.IsRead); }
			set { SetColumnValue(Columns.IsRead, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,DateTime? varNotificationDate,string varNotificationFrom,string varNotificationTo,string varNotificationSubject,string varNotificationMessage,string varNotificationCode,bool? varIsRead,bool? varIsActive)
		{
			TblNotificationAlert item = new TblNotificationAlert();
			
			item.BranchID = varBranchID;
			
			item.NotificationDate = varNotificationDate;
			
			item.NotificationFrom = varNotificationFrom;
			
			item.NotificationTo = varNotificationTo;
			
			item.NotificationSubject = varNotificationSubject;
			
			item.NotificationMessage = varNotificationMessage;
			
			item.NotificationCode = varNotificationCode;
			
			item.IsRead = varIsRead;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varNotificationID,int? varBranchID,DateTime? varNotificationDate,string varNotificationFrom,string varNotificationTo,string varNotificationSubject,string varNotificationMessage,string varNotificationCode,bool? varIsRead,bool? varIsActive)
		{
			TblNotificationAlert item = new TblNotificationAlert();
			
				item.NotificationID = varNotificationID;
			
				item.BranchID = varBranchID;
			
				item.NotificationDate = varNotificationDate;
			
				item.NotificationFrom = varNotificationFrom;
			
				item.NotificationTo = varNotificationTo;
			
				item.NotificationSubject = varNotificationSubject;
			
				item.NotificationMessage = varNotificationMessage;
			
				item.NotificationCode = varNotificationCode;
			
				item.IsRead = varIsRead;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn NotificationIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationDateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationFromColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationToColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationSubjectColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationMessageColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NotificationCodeColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IsReadColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string NotificationID = @"NotificationID";
			 public static string BranchID = @"BranchID";
			 public static string NotificationDate = @"NotificationDate";
			 public static string NotificationFrom = @"NotificationFrom";
			 public static string NotificationTo = @"NotificationTo";
			 public static string NotificationSubject = @"NotificationSubject";
			 public static string NotificationMessage = @"NotificationMessage";
			 public static string NotificationCode = @"NotificationCode";
			 public static string IsRead = @"isRead";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
