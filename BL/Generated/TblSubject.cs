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
	/// Strongly-typed collection for the TblSubject class.
	/// </summary>
    [Serializable]
	public partial class TblSubjectCollection : ActiveList<TblSubject, TblSubjectCollection>
	{	   
		public TblSubjectCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblSubjectCollection</returns>
		public TblSubjectCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblSubject o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Subjects table.
	/// </summary>
	[Serializable]
	public partial class TblSubject : ActiveRecord<TblSubject>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblSubject()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblSubject(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblSubject(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblSubject(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Subjects", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSubjectID = new TableSchema.TableColumn(schema);
				colvarSubjectID.ColumnName = "SubjectID";
				colvarSubjectID.DataType = DbType.Int32;
				colvarSubjectID.MaxLength = 0;
				colvarSubjectID.AutoIncrement = true;
				colvarSubjectID.IsNullable = false;
				colvarSubjectID.IsPrimaryKey = true;
				colvarSubjectID.IsForeignKey = false;
				colvarSubjectID.IsReadOnly = false;
				colvarSubjectID.DefaultSetting = @"";
				colvarSubjectID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubjectID);
				
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
				
				TableSchema.TableColumn colvarSubjectName = new TableSchema.TableColumn(schema);
				colvarSubjectName.ColumnName = "SubjectName";
				colvarSubjectName.DataType = DbType.AnsiString;
				colvarSubjectName.MaxLength = 50;
				colvarSubjectName.AutoIncrement = false;
				colvarSubjectName.IsNullable = true;
				colvarSubjectName.IsPrimaryKey = false;
				colvarSubjectName.IsForeignKey = false;
				colvarSubjectName.IsReadOnly = false;
				colvarSubjectName.DefaultSetting = @"";
				colvarSubjectName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubjectName);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Subjects",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SubjectID")]
		[Bindable(true)]
		public int SubjectID 
		{
			get { return GetColumnValue<int>(Columns.SubjectID); }
			set { SetColumnValue(Columns.SubjectID, value); }
		}
		  
		[XmlAttribute("LevelID")]
		[Bindable(true)]
		public int? LevelID 
		{
			get { return GetColumnValue<int?>(Columns.LevelID); }
			set { SetColumnValue(Columns.LevelID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("SubjectName")]
		[Bindable(true)]
		public string SubjectName 
		{
			get { return GetColumnValue<string>(Columns.SubjectName); }
			set { SetColumnValue(Columns.SubjectName, value); }
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
		public static void Insert(int? varLevelID,int? varBranchID,string varSubjectName,int? varIsActive)
		{
			TblSubject item = new TblSubject();
			
			item.LevelID = varLevelID;
			
			item.BranchID = varBranchID;
			
			item.SubjectName = varSubjectName;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSubjectID,int? varLevelID,int? varBranchID,string varSubjectName,int? varIsActive)
		{
			TblSubject item = new TblSubject();
			
				item.SubjectID = varSubjectID;
			
				item.LevelID = varLevelID;
			
				item.BranchID = varBranchID;
			
				item.SubjectName = varSubjectName;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SubjectIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SubjectNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SubjectID = @"SubjectID";
			 public static string LevelID = @"LevelID";
			 public static string BranchID = @"BranchID";
			 public static string SubjectName = @"SubjectName";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
