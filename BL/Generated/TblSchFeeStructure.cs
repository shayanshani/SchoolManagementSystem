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
	/// Strongly-typed collection for the TblSchFeeStructure class.
	/// </summary>
    [Serializable]
	public partial class TblSchFeeStructureCollection : ActiveList<TblSchFeeStructure, TblSchFeeStructureCollection>
	{	   
		public TblSchFeeStructureCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblSchFeeStructureCollection</returns>
		public TblSchFeeStructureCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblSchFeeStructure o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_SchFeeStructure table.
	/// </summary>
	[Serializable]
	public partial class TblSchFeeStructure : ActiveRecord<TblSchFeeStructure>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblSchFeeStructure()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblSchFeeStructure(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblSchFeeStructure(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblSchFeeStructure(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_SchFeeStructure", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSchFeeID = new TableSchema.TableColumn(schema);
				colvarSchFeeID.ColumnName = "SchFeeID";
				colvarSchFeeID.DataType = DbType.Int32;
				colvarSchFeeID.MaxLength = 0;
				colvarSchFeeID.AutoIncrement = true;
				colvarSchFeeID.IsNullable = false;
				colvarSchFeeID.IsPrimaryKey = true;
				colvarSchFeeID.IsForeignKey = false;
				colvarSchFeeID.IsReadOnly = false;
				colvarSchFeeID.DefaultSetting = @"";
				colvarSchFeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSchFeeID);
				
				TableSchema.TableColumn colvarEScholarship = new TableSchema.TableColumn(schema);
				colvarEScholarship.ColumnName = "EScholarship";
				colvarEScholarship.DataType = DbType.AnsiString;
				colvarEScholarship.MaxLength = -1;
				colvarEScholarship.AutoIncrement = false;
				colvarEScholarship.IsNullable = true;
				colvarEScholarship.IsPrimaryKey = false;
				colvarEScholarship.IsForeignKey = false;
				colvarEScholarship.IsReadOnly = false;
				colvarEScholarship.DefaultSetting = @"";
				colvarEScholarship.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEScholarship);
				
				TableSchema.TableColumn colvarAdmissionFee = new TableSchema.TableColumn(schema);
				colvarAdmissionFee.ColumnName = "AdmissionFee";
				colvarAdmissionFee.DataType = DbType.Int32;
				colvarAdmissionFee.MaxLength = 0;
				colvarAdmissionFee.AutoIncrement = false;
				colvarAdmissionFee.IsNullable = true;
				colvarAdmissionFee.IsPrimaryKey = false;
				colvarAdmissionFee.IsForeignKey = false;
				colvarAdmissionFee.IsReadOnly = false;
				colvarAdmissionFee.DefaultSetting = @"";
				colvarAdmissionFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdmissionFee);
				
				TableSchema.TableColumn colvarMonthlyFee = new TableSchema.TableColumn(schema);
				colvarMonthlyFee.ColumnName = "MonthlyFee";
				colvarMonthlyFee.DataType = DbType.Int32;
				colvarMonthlyFee.MaxLength = 0;
				colvarMonthlyFee.AutoIncrement = false;
				colvarMonthlyFee.IsNullable = true;
				colvarMonthlyFee.IsPrimaryKey = false;
				colvarMonthlyFee.IsForeignKey = false;
				colvarMonthlyFee.IsReadOnly = false;
				colvarMonthlyFee.DefaultSetting = @"";
				colvarMonthlyFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMonthlyFee);
				
				TableSchema.TableColumn colvarMonthlyPayable = new TableSchema.TableColumn(schema);
				colvarMonthlyPayable.ColumnName = "MonthlyPayable";
				colvarMonthlyPayable.DataType = DbType.Int32;
				colvarMonthlyPayable.MaxLength = 0;
				colvarMonthlyPayable.AutoIncrement = false;
				colvarMonthlyPayable.IsNullable = true;
				colvarMonthlyPayable.IsPrimaryKey = false;
				colvarMonthlyPayable.IsForeignKey = false;
				colvarMonthlyPayable.IsReadOnly = false;
				colvarMonthlyPayable.DefaultSetting = @"";
				colvarMonthlyPayable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMonthlyPayable);
				
				TableSchema.TableColumn colvarAdmissionPayable = new TableSchema.TableColumn(schema);
				colvarAdmissionPayable.ColumnName = "AdmissionPayable";
				colvarAdmissionPayable.DataType = DbType.Int32;
				colvarAdmissionPayable.MaxLength = 0;
				colvarAdmissionPayable.AutoIncrement = false;
				colvarAdmissionPayable.IsNullable = true;
				colvarAdmissionPayable.IsPrimaryKey = false;
				colvarAdmissionPayable.IsForeignKey = false;
				colvarAdmissionPayable.IsReadOnly = false;
				colvarAdmissionPayable.DefaultSetting = @"";
				colvarAdmissionPayable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdmissionPayable);
				
				TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
				colvarDiscount.ColumnName = "Discount";
				colvarDiscount.DataType = DbType.Int32;
				colvarDiscount.MaxLength = 0;
				colvarDiscount.AutoIncrement = false;
				colvarDiscount.IsNullable = true;
				colvarDiscount.IsPrimaryKey = false;
				colvarDiscount.IsForeignKey = false;
				colvarDiscount.IsReadOnly = false;
				colvarDiscount.DefaultSetting = @"";
				colvarDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscount);
				
				TableSchema.TableColumn colvarIsEscholarship = new TableSchema.TableColumn(schema);
				colvarIsEscholarship.ColumnName = "isEscholarship";
				colvarIsEscholarship.DataType = DbType.Boolean;
				colvarIsEscholarship.MaxLength = 0;
				colvarIsEscholarship.AutoIncrement = false;
				colvarIsEscholarship.IsNullable = true;
				colvarIsEscholarship.IsPrimaryKey = false;
				colvarIsEscholarship.IsForeignKey = false;
				colvarIsEscholarship.IsReadOnly = false;
				colvarIsEscholarship.DefaultSetting = @"";
				colvarIsEscholarship.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsEscholarship);
				
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
				
				TableSchema.TableColumn colvarDescriptionforOthers = new TableSchema.TableColumn(schema);
				colvarDescriptionforOthers.ColumnName = "DescriptionforOthers";
				colvarDescriptionforOthers.DataType = DbType.AnsiString;
				colvarDescriptionforOthers.MaxLength = -1;
				colvarDescriptionforOthers.AutoIncrement = false;
				colvarDescriptionforOthers.IsNullable = true;
				colvarDescriptionforOthers.IsPrimaryKey = false;
				colvarDescriptionforOthers.IsForeignKey = false;
				colvarDescriptionforOthers.IsReadOnly = false;
				colvarDescriptionforOthers.DefaultSetting = @"";
				colvarDescriptionforOthers.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescriptionforOthers);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_SchFeeStructure",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SchFeeID")]
		[Bindable(true)]
		public int SchFeeID 
		{
			get { return GetColumnValue<int>(Columns.SchFeeID); }
			set { SetColumnValue(Columns.SchFeeID, value); }
		}
		  
		[XmlAttribute("EScholarship")]
		[Bindable(true)]
		public string EScholarship 
		{
			get { return GetColumnValue<string>(Columns.EScholarship); }
			set { SetColumnValue(Columns.EScholarship, value); }
		}
		  
		[XmlAttribute("AdmissionFee")]
		[Bindable(true)]
		public int? AdmissionFee 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionFee); }
			set { SetColumnValue(Columns.AdmissionFee, value); }
		}
		  
		[XmlAttribute("MonthlyFee")]
		[Bindable(true)]
		public int? MonthlyFee 
		{
			get { return GetColumnValue<int?>(Columns.MonthlyFee); }
			set { SetColumnValue(Columns.MonthlyFee, value); }
		}
		  
		[XmlAttribute("MonthlyPayable")]
		[Bindable(true)]
		public int? MonthlyPayable 
		{
			get { return GetColumnValue<int?>(Columns.MonthlyPayable); }
			set { SetColumnValue(Columns.MonthlyPayable, value); }
		}
		  
		[XmlAttribute("AdmissionPayable")]
		[Bindable(true)]
		public int? AdmissionPayable 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionPayable); }
			set { SetColumnValue(Columns.AdmissionPayable, value); }
		}
		  
		[XmlAttribute("Discount")]
		[Bindable(true)]
		public int? Discount 
		{
			get { return GetColumnValue<int?>(Columns.Discount); }
			set { SetColumnValue(Columns.Discount, value); }
		}
		  
		[XmlAttribute("IsEscholarship")]
		[Bindable(true)]
		public bool? IsEscholarship 
		{
			get { return GetColumnValue<bool?>(Columns.IsEscholarship); }
			set { SetColumnValue(Columns.IsEscholarship, value); }
		}
		  
		[XmlAttribute("StudentID")]
		[Bindable(true)]
		public int? StudentID 
		{
			get { return GetColumnValue<int?>(Columns.StudentID); }
			set { SetColumnValue(Columns.StudentID, value); }
		}
		  
		[XmlAttribute("DescriptionforOthers")]
		[Bindable(true)]
		public string DescriptionforOthers 
		{
			get { return GetColumnValue<string>(Columns.DescriptionforOthers); }
			set { SetColumnValue(Columns.DescriptionforOthers, value); }
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
		public static void Insert(string varEScholarship,int? varAdmissionFee,int? varMonthlyFee,int? varMonthlyPayable,int? varAdmissionPayable,int? varDiscount,bool? varIsEscholarship,int? varStudentID,string varDescriptionforOthers,int? varIsActive)
		{
			TblSchFeeStructure item = new TblSchFeeStructure();
			
			item.EScholarship = varEScholarship;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.MonthlyFee = varMonthlyFee;
			
			item.MonthlyPayable = varMonthlyPayable;
			
			item.AdmissionPayable = varAdmissionPayable;
			
			item.Discount = varDiscount;
			
			item.IsEscholarship = varIsEscholarship;
			
			item.StudentID = varStudentID;
			
			item.DescriptionforOthers = varDescriptionforOthers;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSchFeeID,string varEScholarship,int? varAdmissionFee,int? varMonthlyFee,int? varMonthlyPayable,int? varAdmissionPayable,int? varDiscount,bool? varIsEscholarship,int? varStudentID,string varDescriptionforOthers,int? varIsActive)
		{
			TblSchFeeStructure item = new TblSchFeeStructure();
			
				item.SchFeeID = varSchFeeID;
			
				item.EScholarship = varEScholarship;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.MonthlyFee = varMonthlyFee;
			
				item.MonthlyPayable = varMonthlyPayable;
			
				item.AdmissionPayable = varAdmissionPayable;
			
				item.Discount = varDiscount;
			
				item.IsEscholarship = varIsEscholarship;
			
				item.StudentID = varStudentID;
			
				item.DescriptionforOthers = varDescriptionforOthers;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SchFeeIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EScholarshipColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MonthlyFeeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MonthlyPayableColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionPayableColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IsEscholarshipColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionforOthersColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SchFeeID = @"SchFeeID";
			 public static string EScholarship = @"EScholarship";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string MonthlyFee = @"MonthlyFee";
			 public static string MonthlyPayable = @"MonthlyPayable";
			 public static string AdmissionPayable = @"AdmissionPayable";
			 public static string Discount = @"Discount";
			 public static string IsEscholarship = @"isEscholarship";
			 public static string StudentID = @"StudentID";
			 public static string DescriptionforOthers = @"DescriptionforOthers";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
