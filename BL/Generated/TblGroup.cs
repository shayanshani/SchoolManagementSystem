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
	/// Strongly-typed collection for the TblGroup class.
	/// </summary>
    [Serializable]
	public partial class TblGroupCollection : ActiveList<TblGroup, TblGroupCollection>
	{	   
		public TblGroupCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblGroupCollection</returns>
		public TblGroupCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblGroup o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Groups table.
	/// </summary>
	[Serializable]
	public partial class TblGroup : ActiveRecord<TblGroup>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblGroup()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblGroup(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblGroup(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblGroup(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Groups", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarGroupID = new TableSchema.TableColumn(schema);
				colvarGroupID.ColumnName = "GroupID";
				colvarGroupID.DataType = DbType.Int32;
				colvarGroupID.MaxLength = 0;
				colvarGroupID.AutoIncrement = true;
				colvarGroupID.IsNullable = false;
				colvarGroupID.IsPrimaryKey = true;
				colvarGroupID.IsForeignKey = false;
				colvarGroupID.IsReadOnly = false;
				colvarGroupID.DefaultSetting = @"";
				colvarGroupID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupID);
				
				TableSchema.TableColumn colvarGroupName = new TableSchema.TableColumn(schema);
				colvarGroupName.ColumnName = "GroupName";
				colvarGroupName.DataType = DbType.AnsiString;
				colvarGroupName.MaxLength = 250;
				colvarGroupName.AutoIncrement = false;
				colvarGroupName.IsNullable = true;
				colvarGroupName.IsPrimaryKey = false;
				colvarGroupName.IsForeignKey = false;
				colvarGroupName.IsReadOnly = false;
				colvarGroupName.DefaultSetting = @"";
				colvarGroupName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupName);
				
				TableSchema.TableColumn colvarLevelID = new TableSchema.TableColumn(schema);
				colvarLevelID.ColumnName = "LevelID";
				colvarLevelID.DataType = DbType.Int32;
				colvarLevelID.MaxLength = 0;
				colvarLevelID.AutoIncrement = false;
				colvarLevelID.IsNullable = true;
				colvarLevelID.IsPrimaryKey = false;
				colvarLevelID.IsForeignKey = false;
				colvarLevelID.IsReadOnly = false;
				colvarLevelID.DefaultSetting = @"";
				colvarLevelID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLevelID);
				
				TableSchema.TableColumn colvarClassID = new TableSchema.TableColumn(schema);
				colvarClassID.ColumnName = "ClassID";
				colvarClassID.DataType = DbType.Int32;
				colvarClassID.MaxLength = 0;
				colvarClassID.AutoIncrement = false;
				colvarClassID.IsNullable = true;
				colvarClassID.IsPrimaryKey = false;
				colvarClassID.IsForeignKey = false;
				colvarClassID.IsReadOnly = false;
				colvarClassID.DefaultSetting = @"";
				colvarClassID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassID);
				
				TableSchema.TableColumn colvarAssignTo = new TableSchema.TableColumn(schema);
				colvarAssignTo.ColumnName = "AssignTo";
				colvarAssignTo.DataType = DbType.Int32;
				colvarAssignTo.MaxLength = 0;
				colvarAssignTo.AutoIncrement = false;
				colvarAssignTo.IsNullable = true;
				colvarAssignTo.IsPrimaryKey = false;
				colvarAssignTo.IsForeignKey = false;
				colvarAssignTo.IsReadOnly = false;
				colvarAssignTo.DefaultSetting = @"";
				colvarAssignTo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAssignTo);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Groups",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("GroupID")]
		[Bindable(true)]
		public int GroupID 
		{
			get { return GetColumnValue<int>(Columns.GroupID); }
			set { SetColumnValue(Columns.GroupID, value); }
		}
		  
		[XmlAttribute("GroupName")]
		[Bindable(true)]
		public string GroupName 
		{
			get { return GetColumnValue<string>(Columns.GroupName); }
			set { SetColumnValue(Columns.GroupName, value); }
		}
		  
		[XmlAttribute("LevelID")]
		[Bindable(true)]
		public int? LevelID 
		{
			get { return GetColumnValue<int?>(Columns.LevelID); }
			set { SetColumnValue(Columns.LevelID, value); }
		}
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int? ClassID 
		{
			get { return GetColumnValue<int?>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("AssignTo")]
		[Bindable(true)]
		public int? AssignTo 
		{
			get { return GetColumnValue<int?>(Columns.AssignTo); }
			set { SetColumnValue(Columns.AssignTo, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varGroupName,int? varLevelID,int? varClassID,int? varAssignTo,int? varBranchID)
		{
			TblGroup item = new TblGroup();
			
			item.GroupName = varGroupName;
			
			item.LevelID = varLevelID;
			
			item.ClassID = varClassID;
			
			item.AssignTo = varAssignTo;
			
			item.BranchID = varBranchID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varGroupID,string varGroupName,int? varLevelID,int? varClassID,int? varAssignTo,int? varBranchID)
		{
			TblGroup item = new TblGroup();
			
				item.GroupID = varGroupID;
			
				item.GroupName = varGroupName;
			
				item.LevelID = varLevelID;
			
				item.ClassID = varClassID;
			
				item.AssignTo = varAssignTo;
			
				item.BranchID = varBranchID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn GroupIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn GroupNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AssignToColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string GroupID = @"GroupID";
			 public static string GroupName = @"GroupName";
			 public static string LevelID = @"LevelID";
			 public static string ClassID = @"ClassID";
			 public static string AssignTo = @"AssignTo";
			 public static string BranchID = @"BranchID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
