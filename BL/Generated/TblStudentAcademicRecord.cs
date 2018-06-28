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
	/// Strongly-typed collection for the TblStudentAcademicRecord class.
	/// </summary>
    [Serializable]
	public partial class TblStudentAcademicRecordCollection : ActiveList<TblStudentAcademicRecord, TblStudentAcademicRecordCollection>
	{	   
		public TblStudentAcademicRecordCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblStudentAcademicRecordCollection</returns>
		public TblStudentAcademicRecordCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblStudentAcademicRecord o = this[i];
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
	/// This is an ActiveRecord class which wraps the TblStudentAcademicRecord table.
	/// </summary>
	[Serializable]
	public partial class TblStudentAcademicRecord : ActiveRecord<TblStudentAcademicRecord>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblStudentAcademicRecord()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblStudentAcademicRecord(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblStudentAcademicRecord(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblStudentAcademicRecord(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TblStudentAcademicRecord", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarARecordID = new TableSchema.TableColumn(schema);
				colvarARecordID.ColumnName = "ARecordID";
				colvarARecordID.DataType = DbType.Int32;
				colvarARecordID.MaxLength = 0;
				colvarARecordID.AutoIncrement = true;
				colvarARecordID.IsNullable = false;
				colvarARecordID.IsPrimaryKey = true;
				colvarARecordID.IsForeignKey = false;
				colvarARecordID.IsReadOnly = false;
				colvarARecordID.DefaultSetting = @"";
				colvarARecordID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarARecordID);
				
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
				
				TableSchema.TableColumn colvarDegree = new TableSchema.TableColumn(schema);
				colvarDegree.ColumnName = "Degree";
				colvarDegree.DataType = DbType.AnsiString;
				colvarDegree.MaxLength = 50;
				colvarDegree.AutoIncrement = false;
				colvarDegree.IsNullable = true;
				colvarDegree.IsPrimaryKey = false;
				colvarDegree.IsForeignKey = false;
				colvarDegree.IsReadOnly = false;
				colvarDegree.DefaultSetting = @"";
				colvarDegree.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDegree);
				
				TableSchema.TableColumn colvarBoard = new TableSchema.TableColumn(schema);
				colvarBoard.ColumnName = "Board";
				colvarBoard.DataType = DbType.AnsiString;
				colvarBoard.MaxLength = 50;
				colvarBoard.AutoIncrement = false;
				colvarBoard.IsNullable = true;
				colvarBoard.IsPrimaryKey = false;
				colvarBoard.IsForeignKey = false;
				colvarBoard.IsReadOnly = false;
				colvarBoard.DefaultSetting = @"";
				colvarBoard.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBoard);
				
				TableSchema.TableColumn colvarYear = new TableSchema.TableColumn(schema);
				colvarYear.ColumnName = "Year";
				colvarYear.DataType = DbType.AnsiString;
				colvarYear.MaxLength = 50;
				colvarYear.AutoIncrement = false;
				colvarYear.IsNullable = true;
				colvarYear.IsPrimaryKey = false;
				colvarYear.IsForeignKey = false;
				colvarYear.IsReadOnly = false;
				colvarYear.DefaultSetting = @"";
				colvarYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarYear);
				
				TableSchema.TableColumn colvarRollNo = new TableSchema.TableColumn(schema);
				colvarRollNo.ColumnName = "RollNo";
				colvarRollNo.DataType = DbType.AnsiString;
				colvarRollNo.MaxLength = 50;
				colvarRollNo.AutoIncrement = false;
				colvarRollNo.IsNullable = true;
				colvarRollNo.IsPrimaryKey = false;
				colvarRollNo.IsForeignKey = false;
				colvarRollNo.IsReadOnly = false;
				colvarRollNo.DefaultSetting = @"";
				colvarRollNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRollNo);
				
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
				
				TableSchema.TableColumn colvarObtainedMarks = new TableSchema.TableColumn(schema);
				colvarObtainedMarks.ColumnName = "ObtainedMarks";
				colvarObtainedMarks.DataType = DbType.Int32;
				colvarObtainedMarks.MaxLength = 0;
				colvarObtainedMarks.AutoIncrement = false;
				colvarObtainedMarks.IsNullable = true;
				colvarObtainedMarks.IsPrimaryKey = false;
				colvarObtainedMarks.IsForeignKey = false;
				colvarObtainedMarks.IsReadOnly = false;
				colvarObtainedMarks.DefaultSetting = @"";
				colvarObtainedMarks.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObtainedMarks);
				
				TableSchema.TableColumn colvarGrade = new TableSchema.TableColumn(schema);
				colvarGrade.ColumnName = "Grade";
				colvarGrade.DataType = DbType.AnsiString;
				colvarGrade.MaxLength = 50;
				colvarGrade.AutoIncrement = false;
				colvarGrade.IsNullable = true;
				colvarGrade.IsPrimaryKey = false;
				colvarGrade.IsForeignKey = false;
				colvarGrade.IsReadOnly = false;
				colvarGrade.DefaultSetting = @"";
				colvarGrade.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGrade);
				
				TableSchema.TableColumn colvarMajorSubject = new TableSchema.TableColumn(schema);
				colvarMajorSubject.ColumnName = "MajorSubject";
				colvarMajorSubject.DataType = DbType.AnsiString;
				colvarMajorSubject.MaxLength = 50;
				colvarMajorSubject.AutoIncrement = false;
				colvarMajorSubject.IsNullable = true;
				colvarMajorSubject.IsPrimaryKey = false;
				colvarMajorSubject.IsForeignKey = false;
				colvarMajorSubject.IsReadOnly = false;
				colvarMajorSubject.DefaultSetting = @"";
				colvarMajorSubject.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMajorSubject);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("TblStudentAcademicRecord",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ARecordID")]
		[Bindable(true)]
		public int ARecordID 
		{
			get { return GetColumnValue<int>(Columns.ARecordID); }
			set { SetColumnValue(Columns.ARecordID, value); }
		}
		  
		[XmlAttribute("StudentID")]
		[Bindable(true)]
		public int? StudentID 
		{
			get { return GetColumnValue<int?>(Columns.StudentID); }
			set { SetColumnValue(Columns.StudentID, value); }
		}
		  
		[XmlAttribute("Degree")]
		[Bindable(true)]
		public string Degree 
		{
			get { return GetColumnValue<string>(Columns.Degree); }
			set { SetColumnValue(Columns.Degree, value); }
		}
		  
		[XmlAttribute("Board")]
		[Bindable(true)]
		public string Board 
		{
			get { return GetColumnValue<string>(Columns.Board); }
			set { SetColumnValue(Columns.Board, value); }
		}
		  
		[XmlAttribute("Year")]
		[Bindable(true)]
		public string Year 
		{
			get { return GetColumnValue<string>(Columns.Year); }
			set { SetColumnValue(Columns.Year, value); }
		}
		  
		[XmlAttribute("RollNo")]
		[Bindable(true)]
		public string RollNo 
		{
			get { return GetColumnValue<string>(Columns.RollNo); }
			set { SetColumnValue(Columns.RollNo, value); }
		}
		  
		[XmlAttribute("TotalMarks")]
		[Bindable(true)]
		public int? TotalMarks 
		{
			get { return GetColumnValue<int?>(Columns.TotalMarks); }
			set { SetColumnValue(Columns.TotalMarks, value); }
		}
		  
		[XmlAttribute("ObtainedMarks")]
		[Bindable(true)]
		public int? ObtainedMarks 
		{
			get { return GetColumnValue<int?>(Columns.ObtainedMarks); }
			set { SetColumnValue(Columns.ObtainedMarks, value); }
		}
		  
		[XmlAttribute("Grade")]
		[Bindable(true)]
		public string Grade 
		{
			get { return GetColumnValue<string>(Columns.Grade); }
			set { SetColumnValue(Columns.Grade, value); }
		}
		  
		[XmlAttribute("MajorSubject")]
		[Bindable(true)]
		public string MajorSubject 
		{
			get { return GetColumnValue<string>(Columns.MajorSubject); }
			set { SetColumnValue(Columns.MajorSubject, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varStudentID,string varDegree,string varBoard,string varYear,string varRollNo,int? varTotalMarks,int? varObtainedMarks,string varGrade,string varMajorSubject)
		{
			TblStudentAcademicRecord item = new TblStudentAcademicRecord();
			
			item.StudentID = varStudentID;
			
			item.Degree = varDegree;
			
			item.Board = varBoard;
			
			item.Year = varYear;
			
			item.RollNo = varRollNo;
			
			item.TotalMarks = varTotalMarks;
			
			item.ObtainedMarks = varObtainedMarks;
			
			item.Grade = varGrade;
			
			item.MajorSubject = varMajorSubject;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varARecordID,int? varStudentID,string varDegree,string varBoard,string varYear,string varRollNo,int? varTotalMarks,int? varObtainedMarks,string varGrade,string varMajorSubject)
		{
			TblStudentAcademicRecord item = new TblStudentAcademicRecord();
			
				item.ARecordID = varARecordID;
			
				item.StudentID = varStudentID;
			
				item.Degree = varDegree;
			
				item.Board = varBoard;
			
				item.Year = varYear;
			
				item.RollNo = varRollNo;
			
				item.TotalMarks = varTotalMarks;
			
				item.ObtainedMarks = varObtainedMarks;
			
				item.Grade = varGrade;
			
				item.MajorSubject = varMajorSubject;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ARecordIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DegreeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BoardColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn YearColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RollNoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalMarksColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ObtainedMarksColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn GradeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn MajorSubjectColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ARecordID = @"ARecordID";
			 public static string StudentID = @"StudentID";
			 public static string Degree = @"Degree";
			 public static string Board = @"Board";
			 public static string Year = @"Year";
			 public static string RollNo = @"RollNo";
			 public static string TotalMarks = @"TotalMarks";
			 public static string ObtainedMarks = @"ObtainedMarks";
			 public static string Grade = @"Grade";
			 public static string MajorSubject = @"MajorSubject";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
