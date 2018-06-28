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
	/// Strongly-typed collection for the TblAssignSubject class.
	/// </summary>
    [Serializable]
	public partial class TblAssignSubjectCollection : ActiveList<TblAssignSubject, TblAssignSubjectCollection>
	{	   
		public TblAssignSubjectCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAssignSubjectCollection</returns>
		public TblAssignSubjectCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAssignSubject o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_AssignSubject table.
	/// </summary>
	[Serializable]
	public partial class TblAssignSubject : ActiveRecord<TblAssignSubject>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAssignSubject()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAssignSubject(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAssignSubject(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAssignSubject(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_AssignSubject", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAssignID = new TableSchema.TableColumn(schema);
				colvarAssignID.ColumnName = "AssignID";
				colvarAssignID.DataType = DbType.Int32;
				colvarAssignID.MaxLength = 0;
				colvarAssignID.AutoIncrement = true;
				colvarAssignID.IsNullable = false;
				colvarAssignID.IsPrimaryKey = true;
				colvarAssignID.IsForeignKey = false;
				colvarAssignID.IsReadOnly = false;
				colvarAssignID.DefaultSetting = @"";
				colvarAssignID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAssignID);
				
				TableSchema.TableColumn colvarSubjectID = new TableSchema.TableColumn(schema);
				colvarSubjectID.ColumnName = "SubjectID";
				colvarSubjectID.DataType = DbType.Int32;
				colvarSubjectID.MaxLength = 0;
				colvarSubjectID.AutoIncrement = false;
				colvarSubjectID.IsNullable = true;
				colvarSubjectID.IsPrimaryKey = false;
				colvarSubjectID.IsForeignKey = false;
				colvarSubjectID.IsReadOnly = false;
				colvarSubjectID.DefaultSetting = @"";
				colvarSubjectID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubjectID);
				
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
				
				TableSchema.TableColumn colvarTotalMarks = new TableSchema.TableColumn(schema);
				colvarTotalMarks.ColumnName = "TotalMarks";
				colvarTotalMarks.DataType = DbType.Int32;
				colvarTotalMarks.MaxLength = 0;
				colvarTotalMarks.AutoIncrement = false;
				colvarTotalMarks.IsNullable = true;
				colvarTotalMarks.IsPrimaryKey = false;
				colvarTotalMarks.IsForeignKey = false;
				colvarTotalMarks.IsReadOnly = false;
				colvarTotalMarks.DefaultSetting = @"";
				colvarTotalMarks.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalMarks);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_AssignSubject",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("AssignID")]
		[Bindable(true)]
		public int AssignID 
		{
			get { return GetColumnValue<int>(Columns.AssignID); }
			set { SetColumnValue(Columns.AssignID, value); }
		}
		  
		[XmlAttribute("SubjectID")]
		[Bindable(true)]
		public int? SubjectID 
		{
			get { return GetColumnValue<int?>(Columns.SubjectID); }
			set { SetColumnValue(Columns.SubjectID, value); }
		}
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int? ClassID 
		{
			get { return GetColumnValue<int?>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("TotalMarks")]
		[Bindable(true)]
		public int? TotalMarks 
		{
			get { return GetColumnValue<int?>(Columns.TotalMarks); }
			set { SetColumnValue(Columns.TotalMarks, value); }
		}
		  
		[XmlAttribute("LevelID")]
		[Bindable(true)]
		public int? LevelID 
		{
			get { return GetColumnValue<int?>(Columns.LevelID); }
			set { SetColumnValue(Columns.LevelID, value); }
		}
		  
		[XmlAttribute("AssignTo")]
		[Bindable(true)]
		public int? AssignTo 
		{
			get { return GetColumnValue<int?>(Columns.AssignTo); }
			set { SetColumnValue(Columns.AssignTo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varSubjectID,int? varClassID,int? varTotalMarks,int? varLevelID,int? varAssignTo)
		{
			TblAssignSubject item = new TblAssignSubject();
			
			item.SubjectID = varSubjectID;
			
			item.ClassID = varClassID;
			
			item.TotalMarks = varTotalMarks;
			
			item.LevelID = varLevelID;
			
			item.AssignTo = varAssignTo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAssignID,int? varSubjectID,int? varClassID,int? varTotalMarks,int? varLevelID,int? varAssignTo)
		{
			TblAssignSubject item = new TblAssignSubject();
			
				item.AssignID = varAssignID;
			
				item.SubjectID = varSubjectID;
			
				item.ClassID = varClassID;
			
				item.TotalMarks = varTotalMarks;
			
				item.LevelID = varLevelID;
			
				item.AssignTo = varAssignTo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AssignIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SubjectIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalMarksColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AssignToColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AssignID = @"AssignID";
			 public static string SubjectID = @"SubjectID";
			 public static string ClassID = @"ClassID";
			 public static string TotalMarks = @"TotalMarks";
			 public static string LevelID = @"LevelID";
			 public static string AssignTo = @"AssignTo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
