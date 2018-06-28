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
	/// Strongly-typed collection for the TblRoute class.
	/// </summary>
    [Serializable]
	public partial class TblRouteCollection : ActiveList<TblRoute, TblRouteCollection>
	{	   
		public TblRouteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblRouteCollection</returns>
		public TblRouteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblRoute o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Route table.
	/// </summary>
	[Serializable]
	public partial class TblRoute : ActiveRecord<TblRoute>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblRoute()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblRoute(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblRoute(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblRoute(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Route", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRouteID = new TableSchema.TableColumn(schema);
				colvarRouteID.ColumnName = "RouteID";
				colvarRouteID.DataType = DbType.Int32;
				colvarRouteID.MaxLength = 0;
				colvarRouteID.AutoIncrement = true;
				colvarRouteID.IsNullable = false;
				colvarRouteID.IsPrimaryKey = true;
				colvarRouteID.IsForeignKey = false;
				colvarRouteID.IsReadOnly = false;
				colvarRouteID.DefaultSetting = @"";
				colvarRouteID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRouteID);
				
				TableSchema.TableColumn colvarBranchID = new TableSchema.TableColumn(schema);
				colvarBranchID.ColumnName = "BranchID";
				colvarBranchID.DataType = DbType.Int32;
				colvarBranchID.MaxLength = 0;
				colvarBranchID.AutoIncrement = false;
				colvarBranchID.IsNullable = false;
				colvarBranchID.IsPrimaryKey = false;
				colvarBranchID.IsForeignKey = false;
				colvarBranchID.IsReadOnly = false;
				colvarBranchID.DefaultSetting = @"";
				colvarBranchID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBranchID);
				
				TableSchema.TableColumn colvarRFrom = new TableSchema.TableColumn(schema);
				colvarRFrom.ColumnName = "RFrom";
				colvarRFrom.DataType = DbType.AnsiString;
				colvarRFrom.MaxLength = -1;
				colvarRFrom.AutoIncrement = false;
				colvarRFrom.IsNullable = false;
				colvarRFrom.IsPrimaryKey = false;
				colvarRFrom.IsForeignKey = false;
				colvarRFrom.IsReadOnly = false;
				colvarRFrom.DefaultSetting = @"";
				colvarRFrom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRFrom);
				
				TableSchema.TableColumn colvarRTo = new TableSchema.TableColumn(schema);
				colvarRTo.ColumnName = "RTo";
				colvarRTo.DataType = DbType.AnsiString;
				colvarRTo.MaxLength = -1;
				colvarRTo.AutoIncrement = false;
				colvarRTo.IsNullable = false;
				colvarRTo.IsPrimaryKey = false;
				colvarRTo.IsForeignKey = false;
				colvarRTo.IsReadOnly = false;
				colvarRTo.DefaultSetting = @"";
				colvarRTo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRTo);
				
				TableSchema.TableColumn colvarRFare = new TableSchema.TableColumn(schema);
				colvarRFare.ColumnName = "RFare";
				colvarRFare.DataType = DbType.Int32;
				colvarRFare.MaxLength = 0;
				colvarRFare.AutoIncrement = false;
				colvarRFare.IsNullable = false;
				colvarRFare.IsPrimaryKey = false;
				colvarRFare.IsForeignKey = false;
				colvarRFare.IsReadOnly = false;
				colvarRFare.DefaultSetting = @"";
				colvarRFare.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRFare);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Int32;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = false;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarUpdatedBy = new TableSchema.TableColumn(schema);
				colvarUpdatedBy.ColumnName = "UpdatedBy";
				colvarUpdatedBy.DataType = DbType.AnsiString;
				colvarUpdatedBy.MaxLength = 50;
				colvarUpdatedBy.AutoIncrement = false;
				colvarUpdatedBy.IsNullable = true;
				colvarUpdatedBy.IsPrimaryKey = false;
				colvarUpdatedBy.IsForeignKey = false;
				colvarUpdatedBy.IsReadOnly = false;
				colvarUpdatedBy.DefaultSetting = @"";
				colvarUpdatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedBy);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Route",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RouteID")]
		[Bindable(true)]
		public int RouteID 
		{
			get { return GetColumnValue<int>(Columns.RouteID); }
			set { SetColumnValue(Columns.RouteID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int BranchID 
		{
			get { return GetColumnValue<int>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("RFrom")]
		[Bindable(true)]
		public string RFrom 
		{
			get { return GetColumnValue<string>(Columns.RFrom); }
			set { SetColumnValue(Columns.RFrom, value); }
		}
		  
		[XmlAttribute("RTo")]
		[Bindable(true)]
		public string RTo 
		{
			get { return GetColumnValue<string>(Columns.RTo); }
			set { SetColumnValue(Columns.RTo, value); }
		}
		  
		[XmlAttribute("RFare")]
		[Bindable(true)]
		public int RFare 
		{
			get { return GetColumnValue<int>(Columns.RFare); }
			set { SetColumnValue(Columns.RFare, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public int IsActive 
		{
			get { return GetColumnValue<int>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("UpdatedBy")]
		[Bindable(true)]
		public string UpdatedBy 
		{
			get { return GetColumnValue<string>(Columns.UpdatedBy); }
			set { SetColumnValue(Columns.UpdatedBy, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varBranchID,string varRFrom,string varRTo,int varRFare,int varIsActive,string varCreatedBy,string varUpdatedBy)
		{
			TblRoute item = new TblRoute();
			
			item.BranchID = varBranchID;
			
			item.RFrom = varRFrom;
			
			item.RTo = varRTo;
			
			item.RFare = varRFare;
			
			item.IsActive = varIsActive;
			
			item.CreatedBy = varCreatedBy;
			
			item.UpdatedBy = varUpdatedBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRouteID,int varBranchID,string varRFrom,string varRTo,int varRFare,int varIsActive,string varCreatedBy,string varUpdatedBy)
		{
			TblRoute item = new TblRoute();
			
				item.RouteID = varRouteID;
			
				item.BranchID = varBranchID;
			
				item.RFrom = varRFrom;
			
				item.RTo = varRTo;
			
				item.RFare = varRFare;
			
				item.IsActive = varIsActive;
			
				item.CreatedBy = varCreatedBy;
			
				item.UpdatedBy = varUpdatedBy;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RouteIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RFromColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RToColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn RFareColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RouteID = @"RouteID";
			 public static string BranchID = @"BranchID";
			 public static string RFrom = @"RFrom";
			 public static string RTo = @"RTo";
			 public static string RFare = @"RFare";
			 public static string IsActive = @"IsActive";
			 public static string CreatedBy = @"CreatedBy";
			 public static string UpdatedBy = @"UpdatedBy";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
