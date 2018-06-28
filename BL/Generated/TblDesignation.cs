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
	/// Strongly-typed collection for the TblDesignation class.
	/// </summary>
    [Serializable]
	public partial class TblDesignationCollection : ActiveList<TblDesignation, TblDesignationCollection>
	{	   
		public TblDesignationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblDesignationCollection</returns>
		public TblDesignationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblDesignation o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Designation table.
	/// </summary>
	[Serializable]
	public partial class TblDesignation : ActiveRecord<TblDesignation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblDesignation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblDesignation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblDesignation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblDesignation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Designation", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarDesignationID = new TableSchema.TableColumn(schema);
				colvarDesignationID.ColumnName = "DesignationID";
				colvarDesignationID.DataType = DbType.Int32;
				colvarDesignationID.MaxLength = 0;
				colvarDesignationID.AutoIncrement = true;
				colvarDesignationID.IsNullable = false;
				colvarDesignationID.IsPrimaryKey = true;
				colvarDesignationID.IsForeignKey = false;
				colvarDesignationID.IsReadOnly = false;
				colvarDesignationID.DefaultSetting = @"";
				colvarDesignationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDesignationID);
				
				TableSchema.TableColumn colvarDesignation = new TableSchema.TableColumn(schema);
				colvarDesignation.ColumnName = "Designation";
				colvarDesignation.DataType = DbType.AnsiString;
				colvarDesignation.MaxLength = 50;
				colvarDesignation.AutoIncrement = false;
				colvarDesignation.IsNullable = true;
				colvarDesignation.IsPrimaryKey = false;
				colvarDesignation.IsForeignKey = false;
				colvarDesignation.IsReadOnly = false;
				colvarDesignation.DefaultSetting = @"";
				colvarDesignation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDesignation);
				
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
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Boolean;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = true;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				colvarStatus.DefaultSetting = @"";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Designation",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("DesignationID")]
		[Bindable(true)]
		public int DesignationID 
		{
			get { return GetColumnValue<int>(Columns.DesignationID); }
			set { SetColumnValue(Columns.DesignationID, value); }
		}
		  
		[XmlAttribute("Designation")]
		[Bindable(true)]
		public string Designation 
		{
			get { return GetColumnValue<string>(Columns.Designation); }
			set { SetColumnValue(Columns.Designation, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public bool? Status 
		{
			get { return GetColumnValue<bool?>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
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
		public static void Insert(string varDesignation,int? varBranchID,bool? varStatus,string varCreatedBy,string varUpdatedBy)
		{
			TblDesignation item = new TblDesignation();
			
			item.Designation = varDesignation;
			
			item.BranchID = varBranchID;
			
			item.Status = varStatus;
			
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
		public static void Update(int varDesignationID,string varDesignation,int? varBranchID,bool? varStatus,string varCreatedBy,string varUpdatedBy)
		{
			TblDesignation item = new TblDesignation();
			
				item.DesignationID = varDesignationID;
			
				item.Designation = varDesignation;
			
				item.BranchID = varBranchID;
			
				item.Status = varStatus;
			
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
        
        
        public static TableSchema.TableColumn DesignationIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DesignationColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string DesignationID = @"DesignationID";
			 public static string Designation = @"Designation";
			 public static string BranchID = @"BranchID";
			 public static string Status = @"Status";
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
