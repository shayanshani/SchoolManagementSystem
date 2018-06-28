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
	/// Strongly-typed collection for the TblAttendance class.
	/// </summary>
    [Serializable]
	public partial class TblAttendanceCollection : ActiveList<TblAttendance, TblAttendanceCollection>
	{	   
		public TblAttendanceCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAttendanceCollection</returns>
		public TblAttendanceCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAttendance o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Attendance table.
	/// </summary>
	[Serializable]
	public partial class TblAttendance : ActiveRecord<TblAttendance>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAttendance()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAttendance(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAttendance(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAttendance(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Attendance", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAttendanceID = new TableSchema.TableColumn(schema);
				colvarAttendanceID.ColumnName = "AttendanceID";
				colvarAttendanceID.DataType = DbType.Int32;
				colvarAttendanceID.MaxLength = 0;
				colvarAttendanceID.AutoIncrement = true;
				colvarAttendanceID.IsNullable = false;
				colvarAttendanceID.IsPrimaryKey = true;
				colvarAttendanceID.IsForeignKey = false;
				colvarAttendanceID.IsReadOnly = false;
				colvarAttendanceID.DefaultSetting = @"";
				colvarAttendanceID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAttendanceID);
				
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
				
				TableSchema.TableColumn colvarAttendanceDate = new TableSchema.TableColumn(schema);
				colvarAttendanceDate.ColumnName = "AttendanceDate";
				colvarAttendanceDate.DataType = DbType.DateTime;
				colvarAttendanceDate.MaxLength = 0;
				colvarAttendanceDate.AutoIncrement = false;
				colvarAttendanceDate.IsNullable = true;
				colvarAttendanceDate.IsPrimaryKey = false;
				colvarAttendanceDate.IsForeignKey = false;
				colvarAttendanceDate.IsReadOnly = false;
				colvarAttendanceDate.DefaultSetting = @"";
				colvarAttendanceDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAttendanceDate);
				
				TableSchema.TableColumn colvarIsPresent = new TableSchema.TableColumn(schema);
				colvarIsPresent.ColumnName = "isPresent";
				colvarIsPresent.DataType = DbType.Boolean;
				colvarIsPresent.MaxLength = 0;
				colvarIsPresent.AutoIncrement = false;
				colvarIsPresent.IsNullable = true;
				colvarIsPresent.IsPrimaryKey = false;
				colvarIsPresent.IsForeignKey = false;
				colvarIsPresent.IsReadOnly = false;
				colvarIsPresent.DefaultSetting = @"";
				colvarIsPresent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsPresent);
				
				TableSchema.TableColumn colvarUpdateby = new TableSchema.TableColumn(schema);
				colvarUpdateby.ColumnName = "Updateby";
				colvarUpdateby.DataType = DbType.AnsiString;
				colvarUpdateby.MaxLength = 250;
				colvarUpdateby.AutoIncrement = false;
				colvarUpdateby.IsNullable = true;
				colvarUpdateby.IsPrimaryKey = false;
				colvarUpdateby.IsForeignKey = false;
				colvarUpdateby.IsReadOnly = false;
				colvarUpdateby.DefaultSetting = @"";
				colvarUpdateby.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdateby);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Attendance",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("AttendanceID")]
		[Bindable(true)]
		public int AttendanceID 
		{
			get { return GetColumnValue<int>(Columns.AttendanceID); }
			set { SetColumnValue(Columns.AttendanceID, value); }
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
		  
		[XmlAttribute("AttendanceDate")]
		[Bindable(true)]
		public DateTime? AttendanceDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.AttendanceDate); }
			set { SetColumnValue(Columns.AttendanceDate, value); }
		}
		  
		[XmlAttribute("IsPresent")]
		[Bindable(true)]
		public bool? IsPresent 
		{
			get { return GetColumnValue<bool?>(Columns.IsPresent); }
			set { SetColumnValue(Columns.IsPresent, value); }
		}
		  
		[XmlAttribute("Updateby")]
		[Bindable(true)]
		public string Updateby 
		{
			get { return GetColumnValue<string>(Columns.Updateby); }
			set { SetColumnValue(Columns.Updateby, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,int? varStudentID,int? varClassNo,DateTime? varAttendanceDate,bool? varIsPresent,string varUpdateby)
		{
			TblAttendance item = new TblAttendance();
			
			item.BranchID = varBranchID;
			
			item.StudentID = varStudentID;
			
			item.ClassNo = varClassNo;
			
			item.AttendanceDate = varAttendanceDate;
			
			item.IsPresent = varIsPresent;
			
			item.Updateby = varUpdateby;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAttendanceID,int? varBranchID,int? varStudentID,int? varClassNo,DateTime? varAttendanceDate,bool? varIsPresent,string varUpdateby)
		{
			TblAttendance item = new TblAttendance();
			
				item.AttendanceID = varAttendanceID;
			
				item.BranchID = varBranchID;
			
				item.StudentID = varStudentID;
			
				item.ClassNo = varClassNo;
			
				item.AttendanceDate = varAttendanceDate;
			
				item.IsPresent = varIsPresent;
			
				item.Updateby = varUpdateby;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AttendanceIDColumn
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
        
        
        
        public static TableSchema.TableColumn AttendanceDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsPresentColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatebyColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AttendanceID = @"AttendanceID";
			 public static string BranchID = @"BranchID";
			 public static string StudentID = @"StudentID";
			 public static string ClassNo = @"ClassNo";
			 public static string AttendanceDate = @"AttendanceDate";
			 public static string IsPresent = @"isPresent";
			 public static string Updateby = @"Updateby";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
