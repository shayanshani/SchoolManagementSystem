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
	/// Strongly-typed collection for the TblContactU class.
	/// </summary>
    [Serializable]
	public partial class TblContactUCollection : ActiveList<TblContactU, TblContactUCollection>
	{	   
		public TblContactUCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblContactUCollection</returns>
		public TblContactUCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblContactU o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ContactUs table.
	/// </summary>
	[Serializable]
	public partial class TblContactU : ActiveRecord<TblContactU>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblContactU()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblContactU(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblContactU(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblContactU(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ContactUs", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = true;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = true;
				colvarContactID.IsForeignKey = false;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				colvarContactID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 50;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarContactNo = new TableSchema.TableColumn(schema);
				colvarContactNo.ColumnName = "ContactNo";
				colvarContactNo.DataType = DbType.AnsiString;
				colvarContactNo.MaxLength = 50;
				colvarContactNo.AutoIncrement = false;
				colvarContactNo.IsNullable = true;
				colvarContactNo.IsPrimaryKey = false;
				colvarContactNo.IsForeignKey = false;
				colvarContactNo.IsReadOnly = false;
				colvarContactNo.DefaultSetting = @"";
				colvarContactNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactNo);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.AnsiString;
				colvarMessage.MaxLength = 500;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = true;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarIsReply = new TableSchema.TableColumn(schema);
				colvarIsReply.ColumnName = "IsReply";
				colvarIsReply.DataType = DbType.Boolean;
				colvarIsReply.MaxLength = 0;
				colvarIsReply.AutoIncrement = false;
				colvarIsReply.IsNullable = true;
				colvarIsReply.IsPrimaryKey = false;
				colvarIsReply.IsForeignKey = false;
				colvarIsReply.IsReadOnly = false;
				colvarIsReply.DefaultSetting = @"";
				colvarIsReply.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsReply);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ContactUs",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ContactID")]
		[Bindable(true)]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }
			set { SetColumnValue(Columns.ContactID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("ContactNo")]
		[Bindable(true)]
		public string ContactNo 
		{
			get { return GetColumnValue<string>(Columns.ContactNo); }
			set { SetColumnValue(Columns.ContactNo, value); }
		}
		  
		[XmlAttribute("Message")]
		[Bindable(true)]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }
			set { SetColumnValue(Columns.Message, value); }
		}
		  
		[XmlAttribute("IsReply")]
		[Bindable(true)]
		public bool? IsReply 
		{
			get { return GetColumnValue<bool?>(Columns.IsReply); }
			set { SetColumnValue(Columns.IsReply, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varEmail,string varContactNo,string varMessage,bool? varIsReply)
		{
			TblContactU item = new TblContactU();
			
			item.Name = varName;
			
			item.Email = varEmail;
			
			item.ContactNo = varContactNo;
			
			item.Message = varMessage;
			
			item.IsReply = varIsReply;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varContactID,string varName,string varEmail,string varContactNo,string varMessage,bool? varIsReply)
		{
			TblContactU item = new TblContactU();
			
				item.ContactID = varContactID;
			
				item.Name = varName;
			
				item.Email = varEmail;
			
				item.ContactNo = varContactNo;
			
				item.Message = varMessage;
			
				item.IsReply = varIsReply;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ContactIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactNoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsReplyColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ContactID = @"ContactID";
			 public static string Name = @"Name";
			 public static string Email = @"Email";
			 public static string ContactNo = @"ContactNo";
			 public static string Message = @"Message";
			 public static string IsReply = @"IsReply";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
