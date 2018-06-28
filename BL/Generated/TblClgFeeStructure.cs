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
	/// Strongly-typed collection for the TblClgFeeStructure class.
	/// </summary>
    [Serializable]
	public partial class TblClgFeeStructureCollection : ActiveList<TblClgFeeStructure, TblClgFeeStructureCollection>
	{	   
		public TblClgFeeStructureCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblClgFeeStructureCollection</returns>
		public TblClgFeeStructureCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblClgFeeStructure o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ClgFeeStructure table.
	/// </summary>
	[Serializable]
	public partial class TblClgFeeStructure : ActiveRecord<TblClgFeeStructure>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblClgFeeStructure()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblClgFeeStructure(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblClgFeeStructure(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblClgFeeStructure(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ClgFeeStructure", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarFeeID = new TableSchema.TableColumn(schema);
				colvarFeeID.ColumnName = "FeeID";
				colvarFeeID.DataType = DbType.Int32;
				colvarFeeID.MaxLength = 0;
				colvarFeeID.AutoIncrement = true;
				colvarFeeID.IsNullable = false;
				colvarFeeID.IsPrimaryKey = true;
				colvarFeeID.IsForeignKey = false;
				colvarFeeID.IsReadOnly = false;
				colvarFeeID.DefaultSetting = @"";
				colvarFeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeID);
				
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
				
				TableSchema.TableColumn colvarPercentage = new TableSchema.TableColumn(schema);
				colvarPercentage.ColumnName = "Percentage";
				colvarPercentage.DataType = DbType.Double;
				colvarPercentage.MaxLength = 0;
				colvarPercentage.AutoIncrement = false;
				colvarPercentage.IsNullable = true;
				colvarPercentage.IsPrimaryKey = false;
				colvarPercentage.IsForeignKey = false;
				colvarPercentage.IsReadOnly = false;
				colvarPercentage.DefaultSetting = @"";
				colvarPercentage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPercentage);
				
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
				
				TableSchema.TableColumn colvarTotalFee = new TableSchema.TableColumn(schema);
				colvarTotalFee.ColumnName = "TotalFee";
				colvarTotalFee.DataType = DbType.Int32;
				colvarTotalFee.MaxLength = 0;
				colvarTotalFee.AutoIncrement = false;
				colvarTotalFee.IsNullable = true;
				colvarTotalFee.IsPrimaryKey = false;
				colvarTotalFee.IsForeignKey = false;
				colvarTotalFee.IsReadOnly = false;
				colvarTotalFee.DefaultSetting = @"";
				colvarTotalFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalFee);
				
				TableSchema.TableColumn colvarAdvance = new TableSchema.TableColumn(schema);
				colvarAdvance.ColumnName = "Advance";
				colvarAdvance.DataType = DbType.Int32;
				colvarAdvance.MaxLength = 0;
				colvarAdvance.AutoIncrement = false;
				colvarAdvance.IsNullable = true;
				colvarAdvance.IsPrimaryKey = false;
				colvarAdvance.IsForeignKey = false;
				colvarAdvance.IsReadOnly = false;
				colvarAdvance.DefaultSetting = @"";
				colvarAdvance.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdvance);
				
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
				
				TableSchema.TableColumn colvarRemaining = new TableSchema.TableColumn(schema);
				colvarRemaining.ColumnName = "Remaining";
				colvarRemaining.DataType = DbType.Int32;
				colvarRemaining.MaxLength = 0;
				colvarRemaining.AutoIncrement = false;
				colvarRemaining.IsNullable = true;
				colvarRemaining.IsPrimaryKey = false;
				colvarRemaining.IsForeignKey = false;
				colvarRemaining.IsReadOnly = false;
				colvarRemaining.DefaultSetting = @"";
				colvarRemaining.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRemaining);
				
				TableSchema.TableColumn colvarPreviousTotalFee = new TableSchema.TableColumn(schema);
				colvarPreviousTotalFee.ColumnName = "PreviousTotalFee";
				colvarPreviousTotalFee.DataType = DbType.Int32;
				colvarPreviousTotalFee.MaxLength = 0;
				colvarPreviousTotalFee.AutoIncrement = false;
				colvarPreviousTotalFee.IsNullable = true;
				colvarPreviousTotalFee.IsPrimaryKey = false;
				colvarPreviousTotalFee.IsForeignKey = false;
				colvarPreviousTotalFee.IsReadOnly = false;
				colvarPreviousTotalFee.DefaultSetting = @"";
				colvarPreviousTotalFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreviousTotalFee);
				
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
				
				TableSchema.TableColumn colvarMisc = new TableSchema.TableColumn(schema);
				colvarMisc.ColumnName = "Misc";
				colvarMisc.DataType = DbType.Int32;
				colvarMisc.MaxLength = 0;
				colvarMisc.AutoIncrement = false;
				colvarMisc.IsNullable = true;
				colvarMisc.IsPrimaryKey = false;
				colvarMisc.IsForeignKey = false;
				colvarMisc.IsReadOnly = false;
				colvarMisc.DefaultSetting = @"";
				colvarMisc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMisc);
				
				TableSchema.TableColumn colvarTutionFee = new TableSchema.TableColumn(schema);
				colvarTutionFee.ColumnName = "TutionFee";
				colvarTutionFee.DataType = DbType.Int32;
				colvarTutionFee.MaxLength = 0;
				colvarTutionFee.AutoIncrement = false;
				colvarTutionFee.IsNullable = true;
				colvarTutionFee.IsPrimaryKey = false;
				colvarTutionFee.IsForeignKey = false;
				colvarTutionFee.IsReadOnly = false;
				colvarTutionFee.DefaultSetting = @"";
				colvarTutionFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTutionFee);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ClgFeeStructure",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("FeeID")]
		[Bindable(true)]
		public int FeeID 
		{
			get { return GetColumnValue<int>(Columns.FeeID); }
			set { SetColumnValue(Columns.FeeID, value); }
		}
		  
		[XmlAttribute("StudentID")]
		[Bindable(true)]
		public int? StudentID 
		{
			get { return GetColumnValue<int?>(Columns.StudentID); }
			set { SetColumnValue(Columns.StudentID, value); }
		}
		  
		[XmlAttribute("Percentage")]
		[Bindable(true)]
		public double? Percentage 
		{
			get { return GetColumnValue<double?>(Columns.Percentage); }
			set { SetColumnValue(Columns.Percentage, value); }
		}
		  
		[XmlAttribute("EScholarship")]
		[Bindable(true)]
		public string EScholarship 
		{
			get { return GetColumnValue<string>(Columns.EScholarship); }
			set { SetColumnValue(Columns.EScholarship, value); }
		}
		  
		[XmlAttribute("TotalFee")]
		[Bindable(true)]
		public int? TotalFee 
		{
			get { return GetColumnValue<int?>(Columns.TotalFee); }
			set { SetColumnValue(Columns.TotalFee, value); }
		}
		  
		[XmlAttribute("Advance")]
		[Bindable(true)]
		public int? Advance 
		{
			get { return GetColumnValue<int?>(Columns.Advance); }
			set { SetColumnValue(Columns.Advance, value); }
		}
		  
		[XmlAttribute("Discount")]
		[Bindable(true)]
		public int? Discount 
		{
			get { return GetColumnValue<int?>(Columns.Discount); }
			set { SetColumnValue(Columns.Discount, value); }
		}
		  
		[XmlAttribute("Remaining")]
		[Bindable(true)]
		public int? Remaining 
		{
			get { return GetColumnValue<int?>(Columns.Remaining); }
			set { SetColumnValue(Columns.Remaining, value); }
		}
		  
		[XmlAttribute("PreviousTotalFee")]
		[Bindable(true)]
		public int? PreviousTotalFee 
		{
			get { return GetColumnValue<int?>(Columns.PreviousTotalFee); }
			set { SetColumnValue(Columns.PreviousTotalFee, value); }
		}
		  
		[XmlAttribute("AdmissionFee")]
		[Bindable(true)]
		public int? AdmissionFee 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionFee); }
			set { SetColumnValue(Columns.AdmissionFee, value); }
		}
		  
		[XmlAttribute("Misc")]
		[Bindable(true)]
		public int? Misc 
		{
			get { return GetColumnValue<int?>(Columns.Misc); }
			set { SetColumnValue(Columns.Misc, value); }
		}
		  
		[XmlAttribute("TutionFee")]
		[Bindable(true)]
		public int? TutionFee 
		{
			get { return GetColumnValue<int?>(Columns.TutionFee); }
			set { SetColumnValue(Columns.TutionFee, value); }
		}
		  
		[XmlAttribute("MonthlyFee")]
		[Bindable(true)]
		public int? MonthlyFee 
		{
			get { return GetColumnValue<int?>(Columns.MonthlyFee); }
			set { SetColumnValue(Columns.MonthlyFee, value); }
		}
		  
		[XmlAttribute("IsEscholarship")]
		[Bindable(true)]
		public bool? IsEscholarship 
		{
			get { return GetColumnValue<bool?>(Columns.IsEscholarship); }
			set { SetColumnValue(Columns.IsEscholarship, value); }
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
		public static void Insert(int? varStudentID,double? varPercentage,string varEScholarship,int? varTotalFee,int? varAdvance,int? varDiscount,int? varRemaining,int? varPreviousTotalFee,int? varAdmissionFee,int? varMisc,int? varTutionFee,int? varMonthlyFee,bool? varIsEscholarship,int? varIsActive)
		{
			TblClgFeeStructure item = new TblClgFeeStructure();
			
			item.StudentID = varStudentID;
			
			item.Percentage = varPercentage;
			
			item.EScholarship = varEScholarship;
			
			item.TotalFee = varTotalFee;
			
			item.Advance = varAdvance;
			
			item.Discount = varDiscount;
			
			item.Remaining = varRemaining;
			
			item.PreviousTotalFee = varPreviousTotalFee;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.Misc = varMisc;
			
			item.TutionFee = varTutionFee;
			
			item.MonthlyFee = varMonthlyFee;
			
			item.IsEscholarship = varIsEscholarship;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varFeeID,int? varStudentID,double? varPercentage,string varEScholarship,int? varTotalFee,int? varAdvance,int? varDiscount,int? varRemaining,int? varPreviousTotalFee,int? varAdmissionFee,int? varMisc,int? varTutionFee,int? varMonthlyFee,bool? varIsEscholarship,int? varIsActive)
		{
			TblClgFeeStructure item = new TblClgFeeStructure();
			
				item.FeeID = varFeeID;
			
				item.StudentID = varStudentID;
			
				item.Percentage = varPercentage;
			
				item.EScholarship = varEScholarship;
			
				item.TotalFee = varTotalFee;
			
				item.Advance = varAdvance;
			
				item.Discount = varDiscount;
			
				item.Remaining = varRemaining;
			
				item.PreviousTotalFee = varPreviousTotalFee;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.Misc = varMisc;
			
				item.TutionFee = varTutionFee;
			
				item.MonthlyFee = varMonthlyFee;
			
				item.IsEscholarship = varIsEscholarship;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn FeeIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PercentageColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EScholarshipColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalFeeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AdvanceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn RemainingColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PreviousTotalFeeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn MiscColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TutionFeeColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn MonthlyFeeColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IsEscholarshipColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string FeeID = @"FeeID";
			 public static string StudentID = @"StudentID";
			 public static string Percentage = @"Percentage";
			 public static string EScholarship = @"EScholarship";
			 public static string TotalFee = @"TotalFee";
			 public static string Advance = @"Advance";
			 public static string Discount = @"Discount";
			 public static string Remaining = @"Remaining";
			 public static string PreviousTotalFee = @"PreviousTotalFee";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string Misc = @"Misc";
			 public static string TutionFee = @"TutionFee";
			 public static string MonthlyFee = @"MonthlyFee";
			 public static string IsEscholarship = @"isEscholarship";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
