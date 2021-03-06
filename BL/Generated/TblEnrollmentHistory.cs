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
	/// Strongly-typed collection for the TblEnrollmentHistory class.
	/// </summary>
    [Serializable]
	public partial class TblEnrollmentHistoryCollection : ActiveList<TblEnrollmentHistory, TblEnrollmentHistoryCollection>
	{	   
		public TblEnrollmentHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblEnrollmentHistoryCollection</returns>
		public TblEnrollmentHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblEnrollmentHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the TblEnrollmentHistory table.
	/// </summary>
	[Serializable]
	public partial class TblEnrollmentHistory : ActiveRecord<TblEnrollmentHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblEnrollmentHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblEnrollmentHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblEnrollmentHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblEnrollmentHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TblEnrollmentHistory", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarEhid = new TableSchema.TableColumn(schema);
				colvarEhid.ColumnName = "EHID";
				colvarEhid.DataType = DbType.Int32;
				colvarEhid.MaxLength = 0;
				colvarEhid.AutoIncrement = true;
				colvarEhid.IsNullable = false;
				colvarEhid.IsPrimaryKey = true;
				colvarEhid.IsForeignKey = false;
				colvarEhid.IsReadOnly = false;
				colvarEhid.DefaultSetting = @"";
				colvarEhid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEhid);
				
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
				
				TableSchema.TableColumn colvarCreateBy = new TableSchema.TableColumn(schema);
				colvarCreateBy.ColumnName = "CreateBy";
				colvarCreateBy.DataType = DbType.AnsiString;
				colvarCreateBy.MaxLength = 50;
				colvarCreateBy.AutoIncrement = false;
				colvarCreateBy.IsNullable = true;
				colvarCreateBy.IsPrimaryKey = false;
				colvarCreateBy.IsForeignKey = false;
				colvarCreateBy.IsReadOnly = false;
				colvarCreateBy.DefaultSetting = @"";
				colvarCreateBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateBy);
				
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
				
				TableSchema.TableColumn colvarEnrollmentDate = new TableSchema.TableColumn(schema);
				colvarEnrollmentDate.ColumnName = "EnrollmentDate";
				colvarEnrollmentDate.DataType = DbType.DateTime;
				colvarEnrollmentDate.MaxLength = 0;
				colvarEnrollmentDate.AutoIncrement = false;
				colvarEnrollmentDate.IsNullable = true;
				colvarEnrollmentDate.IsPrimaryKey = false;
				colvarEnrollmentDate.IsForeignKey = false;
				colvarEnrollmentDate.IsReadOnly = false;
				colvarEnrollmentDate.DefaultSetting = @"";
				colvarEnrollmentDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnrollmentDate);
				
				TableSchema.TableColumn colvarGroupID = new TableSchema.TableColumn(schema);
				colvarGroupID.ColumnName = "GroupID";
				colvarGroupID.DataType = DbType.Int32;
				colvarGroupID.MaxLength = 0;
				colvarGroupID.AutoIncrement = false;
				colvarGroupID.IsNullable = true;
				colvarGroupID.IsPrimaryKey = false;
				colvarGroupID.IsForeignKey = false;
				colvarGroupID.IsReadOnly = false;
				colvarGroupID.DefaultSetting = @"";
				colvarGroupID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("TblEnrollmentHistory",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Ehid")]
		[Bindable(true)]
		public int Ehid 
		{
			get { return GetColumnValue<int>(Columns.Ehid); }
			set { SetColumnValue(Columns.Ehid, value); }
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
		  
		[XmlAttribute("CreateBy")]
		[Bindable(true)]
		public string CreateBy 
		{
			get { return GetColumnValue<string>(Columns.CreateBy); }
			set { SetColumnValue(Columns.CreateBy, value); }
		}
		  
		[XmlAttribute("UpdatedBy")]
		[Bindable(true)]
		public string UpdatedBy 
		{
			get { return GetColumnValue<string>(Columns.UpdatedBy); }
			set { SetColumnValue(Columns.UpdatedBy, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("EnrollmentDate")]
		[Bindable(true)]
		public DateTime? EnrollmentDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EnrollmentDate); }
			set { SetColumnValue(Columns.EnrollmentDate, value); }
		}
		  
		[XmlAttribute("GroupID")]
		[Bindable(true)]
		public int? GroupID 
		{
			get { return GetColumnValue<int?>(Columns.GroupID); }
			set { SetColumnValue(Columns.GroupID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varStudentID,int? varClassNo,string varCreateBy,string varUpdatedBy,int? varBranchID,DateTime? varEnrollmentDate,int? varGroupID)
		{
			TblEnrollmentHistory item = new TblEnrollmentHistory();
			
			item.StudentID = varStudentID;
			
			item.ClassNo = varClassNo;
			
			item.CreateBy = varCreateBy;
			
			item.UpdatedBy = varUpdatedBy;
			
			item.BranchID = varBranchID;
			
			item.EnrollmentDate = varEnrollmentDate;
			
			item.GroupID = varGroupID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEhid,int? varStudentID,int? varClassNo,string varCreateBy,string varUpdatedBy,int? varBranchID,DateTime? varEnrollmentDate,int? varGroupID)
		{
			TblEnrollmentHistory item = new TblEnrollmentHistory();
			
				item.Ehid = varEhid;
			
				item.StudentID = varStudentID;
			
				item.ClassNo = varClassNo;
			
				item.CreateBy = varCreateBy;
			
				item.UpdatedBy = varUpdatedBy;
			
				item.BranchID = varBranchID;
			
				item.EnrollmentDate = varEnrollmentDate;
			
				item.GroupID = varGroupID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn EhidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateByColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EnrollmentDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn GroupIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Ehid = @"EHID";
			 public static string StudentID = @"StudentID";
			 public static string ClassNo = @"ClassNo";
			 public static string CreateBy = @"CreateBy";
			 public static string UpdatedBy = @"UpdatedBy";
			 public static string BranchID = @"BranchID";
			 public static string EnrollmentDate = @"EnrollmentDate";
			 public static string GroupID = @"GroupID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
