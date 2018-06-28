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
	/// Strongly-typed collection for the TblHostelinformation class.
	/// </summary>
    [Serializable]
	public partial class TblHostelinformationCollection : ActiveList<TblHostelinformation, TblHostelinformationCollection>
	{	   
		public TblHostelinformationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblHostelinformationCollection</returns>
		public TblHostelinformationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblHostelinformation o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Hostelinformation table.
	/// </summary>
	[Serializable]
	public partial class TblHostelinformation : ActiveRecord<TblHostelinformation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblHostelinformation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblHostelinformation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblHostelinformation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblHostelinformation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Hostelinformation", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarHostelID = new TableSchema.TableColumn(schema);
				colvarHostelID.ColumnName = "HostelID";
				colvarHostelID.DataType = DbType.Int32;
				colvarHostelID.MaxLength = 0;
				colvarHostelID.AutoIncrement = true;
				colvarHostelID.IsNullable = false;
				colvarHostelID.IsPrimaryKey = true;
				colvarHostelID.IsForeignKey = false;
				colvarHostelID.IsReadOnly = false;
				colvarHostelID.DefaultSetting = @"";
				colvarHostelID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelID);
				
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
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = false;
				colvarEmployeeID.IsNullable = true;
				colvarEmployeeID.IsPrimaryKey = false;
				colvarEmployeeID.IsForeignKey = false;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				colvarEmployeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarHostelName = new TableSchema.TableColumn(schema);
				colvarHostelName.ColumnName = "HostelName";
				colvarHostelName.DataType = DbType.AnsiString;
				colvarHostelName.MaxLength = -1;
				colvarHostelName.AutoIncrement = false;
				colvarHostelName.IsNullable = true;
				colvarHostelName.IsPrimaryKey = false;
				colvarHostelName.IsForeignKey = false;
				colvarHostelName.IsReadOnly = false;
				colvarHostelName.DefaultSetting = @"";
				colvarHostelName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelName);
				
				TableSchema.TableColumn colvarHostelContact = new TableSchema.TableColumn(schema);
				colvarHostelContact.ColumnName = "HostelContact";
				colvarHostelContact.DataType = DbType.AnsiString;
				colvarHostelContact.MaxLength = 50;
				colvarHostelContact.AutoIncrement = false;
				colvarHostelContact.IsNullable = true;
				colvarHostelContact.IsPrimaryKey = false;
				colvarHostelContact.IsForeignKey = false;
				colvarHostelContact.IsReadOnly = false;
				colvarHostelContact.DefaultSetting = @"";
				colvarHostelContact.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelContact);
				
				TableSchema.TableColumn colvarHostelLocation = new TableSchema.TableColumn(schema);
				colvarHostelLocation.ColumnName = "HostelLocation";
				colvarHostelLocation.DataType = DbType.AnsiString;
				colvarHostelLocation.MaxLength = -1;
				colvarHostelLocation.AutoIncrement = false;
				colvarHostelLocation.IsNullable = true;
				colvarHostelLocation.IsPrimaryKey = false;
				colvarHostelLocation.IsForeignKey = false;
				colvarHostelLocation.IsReadOnly = false;
				colvarHostelLocation.DefaultSetting = @"";
				colvarHostelLocation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelLocation);
				
				TableSchema.TableColumn colvarHostelFee = new TableSchema.TableColumn(schema);
				colvarHostelFee.ColumnName = "HostelFee";
				colvarHostelFee.DataType = DbType.Int32;
				colvarHostelFee.MaxLength = 0;
				colvarHostelFee.AutoIncrement = false;
				colvarHostelFee.IsNullable = true;
				colvarHostelFee.IsPrimaryKey = false;
				colvarHostelFee.IsForeignKey = false;
				colvarHostelFee.IsReadOnly = false;
				colvarHostelFee.DefaultSetting = @"";
				colvarHostelFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelFee);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "isActive";
				colvarIsActive.DataType = DbType.Int32;
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Hostelinformation",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("HostelID")]
		[Bindable(true)]
		public int HostelID 
		{
			get { return GetColumnValue<int>(Columns.HostelID); }
			set { SetColumnValue(Columns.HostelID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("EmployeeID")]
		[Bindable(true)]
		public int? EmployeeID 
		{
			get { return GetColumnValue<int?>(Columns.EmployeeID); }
			set { SetColumnValue(Columns.EmployeeID, value); }
		}
		  
		[XmlAttribute("HostelName")]
		[Bindable(true)]
		public string HostelName 
		{
			get { return GetColumnValue<string>(Columns.HostelName); }
			set { SetColumnValue(Columns.HostelName, value); }
		}
		  
		[XmlAttribute("HostelContact")]
		[Bindable(true)]
		public string HostelContact 
		{
			get { return GetColumnValue<string>(Columns.HostelContact); }
			set { SetColumnValue(Columns.HostelContact, value); }
		}
		  
		[XmlAttribute("HostelLocation")]
		[Bindable(true)]
		public string HostelLocation 
		{
			get { return GetColumnValue<string>(Columns.HostelLocation); }
			set { SetColumnValue(Columns.HostelLocation, value); }
		}
		  
		[XmlAttribute("HostelFee")]
		[Bindable(true)]
		public int? HostelFee 
		{
			get { return GetColumnValue<int?>(Columns.HostelFee); }
			set { SetColumnValue(Columns.HostelFee, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public int? IsActive 
		{
			get { return GetColumnValue<int?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,int? varEmployeeID,string varHostelName,string varHostelContact,string varHostelLocation,int? varHostelFee,int? varIsActive)
		{
			TblHostelinformation item = new TblHostelinformation();
			
			item.BranchID = varBranchID;
			
			item.EmployeeID = varEmployeeID;
			
			item.HostelName = varHostelName;
			
			item.HostelContact = varHostelContact;
			
			item.HostelLocation = varHostelLocation;
			
			item.HostelFee = varHostelFee;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHostelID,int? varBranchID,int? varEmployeeID,string varHostelName,string varHostelContact,string varHostelLocation,int? varHostelFee,int? varIsActive)
		{
			TblHostelinformation item = new TblHostelinformation();
			
				item.HostelID = varHostelID;
			
				item.BranchID = varBranchID;
			
				item.EmployeeID = varEmployeeID;
			
				item.HostelName = varHostelName;
			
				item.HostelContact = varHostelContact;
			
				item.HostelLocation = varHostelLocation;
			
				item.HostelFee = varHostelFee;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HostelIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EmployeeIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelContactColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelLocationColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelFeeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string HostelID = @"HostelID";
			 public static string BranchID = @"BranchID";
			 public static string EmployeeID = @"EmployeeID";
			 public static string HostelName = @"HostelName";
			 public static string HostelContact = @"HostelContact";
			 public static string HostelLocation = @"HostelLocation";
			 public static string HostelFee = @"HostelFee";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
