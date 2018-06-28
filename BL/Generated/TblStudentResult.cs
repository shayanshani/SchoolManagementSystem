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
	/// Strongly-typed collection for the TblStudentResult class.
	/// </summary>
    [Serializable]
	public partial class TblStudentResultCollection : ActiveList<TblStudentResult, TblStudentResultCollection>
	{	   
		public TblStudentResultCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblStudentResultCollection</returns>
		public TblStudentResultCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblStudentResult o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_StudentResult table.
	/// </summary>
	[Serializable]
	public partial class TblStudentResult : ActiveRecord<TblStudentResult>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblStudentResult()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblStudentResult(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblStudentResult(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblStudentResult(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_StudentResult", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarResultID = new TableSchema.TableColumn(schema);
				colvarResultID.ColumnName = "ResultID";
				colvarResultID.DataType = DbType.Int32;
				colvarResultID.MaxLength = 0;
				colvarResultID.AutoIncrement = true;
				colvarResultID.IsNullable = false;
				colvarResultID.IsPrimaryKey = true;
				colvarResultID.IsForeignKey = false;
				colvarResultID.IsReadOnly = false;
				colvarResultID.DefaultSetting = @"";
				colvarResultID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResultID);
				
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
				
				TableSchema.TableColumn colvarStudentID = new TableSchema.TableColumn(schema);
				colvarStudentID.ColumnName = "StudentID";
				colvarStudentID.DataType = DbType.Int32;
				colvarStudentID.MaxLength = 0;
				colvarStudentID.AutoIncrement = false;
				colvarStudentID.IsNullable = true;
				colvarStudentID.IsPrimaryKey = false;
				colvarStudentID.IsForeignKey = false;
				colvarStudentID.IsReadOnly = false;
				colvarStudentID.DefaultSetting = @"";
				colvarStudentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStudentID);
				
				TableSchema.TableColumn colvarClassNo = new TableSchema.TableColumn(schema);
				colvarClassNo.ColumnName = "ClassNo";
				colvarClassNo.DataType = DbType.Int32;
				colvarClassNo.MaxLength = 0;
				colvarClassNo.AutoIncrement = false;
				colvarClassNo.IsNullable = true;
				colvarClassNo.IsPrimaryKey = false;
				colvarClassNo.IsForeignKey = false;
				colvarClassNo.IsReadOnly = false;
				colvarClassNo.DefaultSetting = @"";
				colvarClassNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassNo);
				
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
				
				TableSchema.TableColumn colvarMarks = new TableSchema.TableColumn(schema);
				colvarMarks.ColumnName = "Marks";
				colvarMarks.DataType = DbType.Int32;
				colvarMarks.MaxLength = 0;
				colvarMarks.AutoIncrement = false;
				colvarMarks.IsNullable = true;
				colvarMarks.IsPrimaryKey = false;
				colvarMarks.IsForeignKey = false;
				colvarMarks.IsReadOnly = false;
				colvarMarks.DefaultSetting = @"";
				colvarMarks.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMarks);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_StudentResult",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ResultID")]
		[Bindable(true)]
		public int ResultID 
		{
			get { return GetColumnValue<int>(Columns.ResultID); }
			set { SetColumnValue(Columns.ResultID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("StudentID")]
		[Bindable(true)]
		public int? StudentID 
		{
			get { return GetColumnValue<int?>(Columns.StudentID); }
			set { SetColumnValue(Columns.StudentID, value); }
		}
		  
		[XmlAttribute("ClassNo")]
		[Bindable(true)]
		public int? ClassNo 
		{
			get { return GetColumnValue<int?>(Columns.ClassNo); }
			set { SetColumnValue(Columns.ClassNo, value); }
		}
		  
		[XmlAttribute("SubjectID")]
		[Bindable(true)]
		public int? SubjectID 
		{
			get { return GetColumnValue<int?>(Columns.SubjectID); }
			set { SetColumnValue(Columns.SubjectID, value); }
		}
		  
		[XmlAttribute("Marks")]
		[Bindable(true)]
		public int? Marks 
		{
			get { return GetColumnValue<int?>(Columns.Marks); }
			set { SetColumnValue(Columns.Marks, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,int? varStudentID,int? varClassNo,int? varSubjectID,int? varMarks)
		{
			TblStudentResult item = new TblStudentResult();
			
			item.BranchID = varBranchID;
			
			item.StudentID = varStudentID;
			
			item.ClassNo = varClassNo;
			
			item.SubjectID = varSubjectID;
			
			item.Marks = varMarks;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varResultID,int? varBranchID,int? varStudentID,int? varClassNo,int? varSubjectID,int? varMarks)
		{
			TblStudentResult item = new TblStudentResult();
			
				item.ResultID = varResultID;
			
				item.BranchID = varBranchID;
			
				item.StudentID = varStudentID;
			
				item.ClassNo = varClassNo;
			
				item.SubjectID = varSubjectID;
			
				item.Marks = varMarks;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ResultIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SubjectIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MarksColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ResultID = @"ResultID";
			 public static string BranchID = @"BranchID";
			 public static string StudentID = @"StudentID";
			 public static string ClassNo = @"ClassNo";
			 public static string SubjectID = @"SubjectID";
			 public static string Marks = @"Marks";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
