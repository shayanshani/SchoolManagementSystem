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
	/// Strongly-typed collection for the TblSchoolHostelLedger class.
	/// </summary>
    [Serializable]
	public partial class TblSchoolHostelLedgerCollection : ActiveList<TblSchoolHostelLedger, TblSchoolHostelLedgerCollection>
	{	   
		public TblSchoolHostelLedgerCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblSchoolHostelLedgerCollection</returns>
		public TblSchoolHostelLedgerCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblSchoolHostelLedger o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_SchoolHostelLedger table.
	/// </summary>
	[Serializable]
	public partial class TblSchoolHostelLedger : ActiveRecord<TblSchoolHostelLedger>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblSchoolHostelLedger()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblSchoolHostelLedger(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblSchoolHostelLedger(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblSchoolHostelLedger(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_SchoolHostelLedger", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSno = new TableSchema.TableColumn(schema);
				colvarSno.ColumnName = "Sno";
				colvarSno.DataType = DbType.Int32;
				colvarSno.MaxLength = 0;
				colvarSno.AutoIncrement = true;
				colvarSno.IsNullable = false;
				colvarSno.IsPrimaryKey = true;
				colvarSno.IsForeignKey = false;
				colvarSno.IsReadOnly = false;
				colvarSno.DefaultSetting = @"";
				colvarSno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSno);
				
				TableSchema.TableColumn colvarCeid = new TableSchema.TableColumn(schema);
				colvarCeid.ColumnName = "CEID";
				colvarCeid.DataType = DbType.Int32;
				colvarCeid.MaxLength = 0;
				colvarCeid.AutoIncrement = false;
				colvarCeid.IsNullable = true;
				colvarCeid.IsPrimaryKey = false;
				colvarCeid.IsForeignKey = false;
				colvarCeid.IsReadOnly = false;
				colvarCeid.DefaultSetting = @"";
				colvarCeid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCeid);
				
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
				
				TableSchema.TableColumn colvarHostelSecurity = new TableSchema.TableColumn(schema);
				colvarHostelSecurity.ColumnName = "HostelSecurity";
				colvarHostelSecurity.DataType = DbType.Int32;
				colvarHostelSecurity.MaxLength = 0;
				colvarHostelSecurity.AutoIncrement = false;
				colvarHostelSecurity.IsNullable = true;
				colvarHostelSecurity.IsPrimaryKey = false;
				colvarHostelSecurity.IsForeignKey = false;
				colvarHostelSecurity.IsReadOnly = false;
				colvarHostelSecurity.DefaultSetting = @"";
				colvarHostelSecurity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelSecurity);
				
				TableSchema.TableColumn colvarApr = new TableSchema.TableColumn(schema);
				colvarApr.ColumnName = "Apr";
				colvarApr.DataType = DbType.AnsiString;
				colvarApr.MaxLength = 500;
				colvarApr.AutoIncrement = false;
				colvarApr.IsNullable = true;
				colvarApr.IsPrimaryKey = false;
				colvarApr.IsForeignKey = false;
				colvarApr.IsReadOnly = false;
				colvarApr.DefaultSetting = @"";
				colvarApr.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApr);
				
				TableSchema.TableColumn colvarMay = new TableSchema.TableColumn(schema);
				colvarMay.ColumnName = "May";
				colvarMay.DataType = DbType.AnsiString;
				colvarMay.MaxLength = 500;
				colvarMay.AutoIncrement = false;
				colvarMay.IsNullable = true;
				colvarMay.IsPrimaryKey = false;
				colvarMay.IsForeignKey = false;
				colvarMay.IsReadOnly = false;
				colvarMay.DefaultSetting = @"";
				colvarMay.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMay);
				
				TableSchema.TableColumn colvarJune = new TableSchema.TableColumn(schema);
				colvarJune.ColumnName = "June";
				colvarJune.DataType = DbType.AnsiString;
				colvarJune.MaxLength = 500;
				colvarJune.AutoIncrement = false;
				colvarJune.IsNullable = true;
				colvarJune.IsPrimaryKey = false;
				colvarJune.IsForeignKey = false;
				colvarJune.IsReadOnly = false;
				colvarJune.DefaultSetting = @"";
				colvarJune.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJune);
				
				TableSchema.TableColumn colvarJuly = new TableSchema.TableColumn(schema);
				colvarJuly.ColumnName = "July";
				colvarJuly.DataType = DbType.AnsiString;
				colvarJuly.MaxLength = 500;
				colvarJuly.AutoIncrement = false;
				colvarJuly.IsNullable = true;
				colvarJuly.IsPrimaryKey = false;
				colvarJuly.IsForeignKey = false;
				colvarJuly.IsReadOnly = false;
				colvarJuly.DefaultSetting = @"";
				colvarJuly.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJuly);
				
				TableSchema.TableColumn colvarAugust = new TableSchema.TableColumn(schema);
				colvarAugust.ColumnName = "August";
				colvarAugust.DataType = DbType.AnsiString;
				colvarAugust.MaxLength = 500;
				colvarAugust.AutoIncrement = false;
				colvarAugust.IsNullable = true;
				colvarAugust.IsPrimaryKey = false;
				colvarAugust.IsForeignKey = false;
				colvarAugust.IsReadOnly = false;
				colvarAugust.DefaultSetting = @"";
				colvarAugust.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAugust);
				
				TableSchema.TableColumn colvarSeptember = new TableSchema.TableColumn(schema);
				colvarSeptember.ColumnName = "September";
				colvarSeptember.DataType = DbType.AnsiString;
				colvarSeptember.MaxLength = 500;
				colvarSeptember.AutoIncrement = false;
				colvarSeptember.IsNullable = true;
				colvarSeptember.IsPrimaryKey = false;
				colvarSeptember.IsForeignKey = false;
				colvarSeptember.IsReadOnly = false;
				colvarSeptember.DefaultSetting = @"";
				colvarSeptember.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeptember);
				
				TableSchema.TableColumn colvarOctober = new TableSchema.TableColumn(schema);
				colvarOctober.ColumnName = "October";
				colvarOctober.DataType = DbType.AnsiString;
				colvarOctober.MaxLength = 500;
				colvarOctober.AutoIncrement = false;
				colvarOctober.IsNullable = true;
				colvarOctober.IsPrimaryKey = false;
				colvarOctober.IsForeignKey = false;
				colvarOctober.IsReadOnly = false;
				colvarOctober.DefaultSetting = @"";
				colvarOctober.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOctober);
				
				TableSchema.TableColumn colvarNovember = new TableSchema.TableColumn(schema);
				colvarNovember.ColumnName = "November";
				colvarNovember.DataType = DbType.AnsiString;
				colvarNovember.MaxLength = 500;
				colvarNovember.AutoIncrement = false;
				colvarNovember.IsNullable = true;
				colvarNovember.IsPrimaryKey = false;
				colvarNovember.IsForeignKey = false;
				colvarNovember.IsReadOnly = false;
				colvarNovember.DefaultSetting = @"";
				colvarNovember.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNovember);
				
				TableSchema.TableColumn colvarDecember = new TableSchema.TableColumn(schema);
				colvarDecember.ColumnName = "December";
				colvarDecember.DataType = DbType.AnsiString;
				colvarDecember.MaxLength = 500;
				colvarDecember.AutoIncrement = false;
				colvarDecember.IsNullable = true;
				colvarDecember.IsPrimaryKey = false;
				colvarDecember.IsForeignKey = false;
				colvarDecember.IsReadOnly = false;
				colvarDecember.DefaultSetting = @"";
				colvarDecember.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDecember);
				
				TableSchema.TableColumn colvarJanuary = new TableSchema.TableColumn(schema);
				colvarJanuary.ColumnName = "january";
				colvarJanuary.DataType = DbType.AnsiString;
				colvarJanuary.MaxLength = 500;
				colvarJanuary.AutoIncrement = false;
				colvarJanuary.IsNullable = true;
				colvarJanuary.IsPrimaryKey = false;
				colvarJanuary.IsForeignKey = false;
				colvarJanuary.IsReadOnly = false;
				colvarJanuary.DefaultSetting = @"";
				colvarJanuary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJanuary);
				
				TableSchema.TableColumn colvarFabruary = new TableSchema.TableColumn(schema);
				colvarFabruary.ColumnName = "Fabruary";
				colvarFabruary.DataType = DbType.AnsiString;
				colvarFabruary.MaxLength = 500;
				colvarFabruary.AutoIncrement = false;
				colvarFabruary.IsNullable = true;
				colvarFabruary.IsPrimaryKey = false;
				colvarFabruary.IsForeignKey = false;
				colvarFabruary.IsReadOnly = false;
				colvarFabruary.DefaultSetting = @"";
				colvarFabruary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFabruary);
				
				TableSchema.TableColumn colvarMarch = new TableSchema.TableColumn(schema);
				colvarMarch.ColumnName = "March";
				colvarMarch.DataType = DbType.AnsiString;
				colvarMarch.MaxLength = 500;
				colvarMarch.AutoIncrement = false;
				colvarMarch.IsNullable = true;
				colvarMarch.IsPrimaryKey = false;
				colvarMarch.IsForeignKey = false;
				colvarMarch.IsReadOnly = false;
				colvarMarch.DefaultSetting = @"";
				colvarMarch.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMarch);
				
				TableSchema.TableColumn colvarRemarks = new TableSchema.TableColumn(schema);
				colvarRemarks.ColumnName = "Remarks";
				colvarRemarks.DataType = DbType.AnsiString;
				colvarRemarks.MaxLength = 500;
				colvarRemarks.AutoIncrement = false;
				colvarRemarks.IsNullable = true;
				colvarRemarks.IsPrimaryKey = false;
				colvarRemarks.IsForeignKey = false;
				colvarRemarks.IsReadOnly = false;
				colvarRemarks.DefaultSetting = @"";
				colvarRemarks.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRemarks);
				
				TableSchema.TableColumn colvarLedgerType = new TableSchema.TableColumn(schema);
				colvarLedgerType.ColumnName = "LedgerType";
				colvarLedgerType.DataType = DbType.AnsiString;
				colvarLedgerType.MaxLength = 500;
				colvarLedgerType.AutoIncrement = false;
				colvarLedgerType.IsNullable = true;
				colvarLedgerType.IsPrimaryKey = false;
				colvarLedgerType.IsForeignKey = false;
				colvarLedgerType.IsReadOnly = false;
				colvarLedgerType.DefaultSetting = @"";
				colvarLedgerType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLedgerType);
				
				TableSchema.TableColumn colvarReAdmissionFee = new TableSchema.TableColumn(schema);
				colvarReAdmissionFee.ColumnName = "ReAdmissionFee";
				colvarReAdmissionFee.DataType = DbType.AnsiString;
				colvarReAdmissionFee.MaxLength = 50;
				colvarReAdmissionFee.AutoIncrement = false;
				colvarReAdmissionFee.IsNullable = true;
				colvarReAdmissionFee.IsPrimaryKey = false;
				colvarReAdmissionFee.IsForeignKey = false;
				colvarReAdmissionFee.IsReadOnly = false;
				colvarReAdmissionFee.DefaultSetting = @"";
				colvarReAdmissionFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReAdmissionFee);
				
				TableSchema.TableColumn colvarArrears = new TableSchema.TableColumn(schema);
				colvarArrears.ColumnName = "Arrears";
				colvarArrears.DataType = DbType.Int32;
				colvarArrears.MaxLength = 0;
				colvarArrears.AutoIncrement = false;
				colvarArrears.IsNullable = true;
				colvarArrears.IsPrimaryKey = false;
				colvarArrears.IsForeignKey = false;
				colvarArrears.IsReadOnly = false;
				colvarArrears.DefaultSetting = @"";
				colvarArrears.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArrears);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_SchoolHostelLedger",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Sno")]
		[Bindable(true)]
		public int Sno 
		{
			get { return GetColumnValue<int>(Columns.Sno); }
			set { SetColumnValue(Columns.Sno, value); }
		}
		  
		[XmlAttribute("Ceid")]
		[Bindable(true)]
		public int? Ceid 
		{
			get { return GetColumnValue<int?>(Columns.Ceid); }
			set { SetColumnValue(Columns.Ceid, value); }
		}
		  
		[XmlAttribute("AdmissionFee")]
		[Bindable(true)]
		public int? AdmissionFee 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionFee); }
			set { SetColumnValue(Columns.AdmissionFee, value); }
		}
		  
		[XmlAttribute("HostelSecurity")]
		[Bindable(true)]
		public int? HostelSecurity 
		{
			get { return GetColumnValue<int?>(Columns.HostelSecurity); }
			set { SetColumnValue(Columns.HostelSecurity, value); }
		}
		  
		[XmlAttribute("Apr")]
		[Bindable(true)]
		public string Apr 
		{
			get { return GetColumnValue<string>(Columns.Apr); }
			set { SetColumnValue(Columns.Apr, value); }
		}
		  
		[XmlAttribute("May")]
		[Bindable(true)]
		public string May 
		{
			get { return GetColumnValue<string>(Columns.May); }
			set { SetColumnValue(Columns.May, value); }
		}
		  
		[XmlAttribute("June")]
		[Bindable(true)]
		public string June 
		{
			get { return GetColumnValue<string>(Columns.June); }
			set { SetColumnValue(Columns.June, value); }
		}
		  
		[XmlAttribute("July")]
		[Bindable(true)]
		public string July 
		{
			get { return GetColumnValue<string>(Columns.July); }
			set { SetColumnValue(Columns.July, value); }
		}
		  
		[XmlAttribute("August")]
		[Bindable(true)]
		public string August 
		{
			get { return GetColumnValue<string>(Columns.August); }
			set { SetColumnValue(Columns.August, value); }
		}
		  
		[XmlAttribute("September")]
		[Bindable(true)]
		public string September 
		{
			get { return GetColumnValue<string>(Columns.September); }
			set { SetColumnValue(Columns.September, value); }
		}
		  
		[XmlAttribute("October")]
		[Bindable(true)]
		public string October 
		{
			get { return GetColumnValue<string>(Columns.October); }
			set { SetColumnValue(Columns.October, value); }
		}
		  
		[XmlAttribute("November")]
		[Bindable(true)]
		public string November 
		{
			get { return GetColumnValue<string>(Columns.November); }
			set { SetColumnValue(Columns.November, value); }
		}
		  
		[XmlAttribute("December")]
		[Bindable(true)]
		public string December 
		{
			get { return GetColumnValue<string>(Columns.December); }
			set { SetColumnValue(Columns.December, value); }
		}
		  
		[XmlAttribute("January")]
		[Bindable(true)]
		public string January 
		{
			get { return GetColumnValue<string>(Columns.January); }
			set { SetColumnValue(Columns.January, value); }
		}
		  
		[XmlAttribute("Fabruary")]
		[Bindable(true)]
		public string Fabruary 
		{
			get { return GetColumnValue<string>(Columns.Fabruary); }
			set { SetColumnValue(Columns.Fabruary, value); }
		}
		  
		[XmlAttribute("March")]
		[Bindable(true)]
		public string March 
		{
			get { return GetColumnValue<string>(Columns.March); }
			set { SetColumnValue(Columns.March, value); }
		}
		  
		[XmlAttribute("Remarks")]
		[Bindable(true)]
		public string Remarks 
		{
			get { return GetColumnValue<string>(Columns.Remarks); }
			set { SetColumnValue(Columns.Remarks, value); }
		}
		  
		[XmlAttribute("LedgerType")]
		[Bindable(true)]
		public string LedgerType 
		{
			get { return GetColumnValue<string>(Columns.LedgerType); }
			set { SetColumnValue(Columns.LedgerType, value); }
		}
		  
		[XmlAttribute("ReAdmissionFee")]
		[Bindable(true)]
		public string ReAdmissionFee 
		{
			get { return GetColumnValue<string>(Columns.ReAdmissionFee); }
			set { SetColumnValue(Columns.ReAdmissionFee, value); }
		}
		  
		[XmlAttribute("Arrears")]
		[Bindable(true)]
		public int? Arrears 
		{
			get { return GetColumnValue<int?>(Columns.Arrears); }
			set { SetColumnValue(Columns.Arrears, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCeid,int? varAdmissionFee,int? varHostelSecurity,string varApr,string varMay,string varJune,string varJuly,string varAugust,string varSeptember,string varOctober,string varNovember,string varDecember,string varJanuary,string varFabruary,string varMarch,string varRemarks,string varLedgerType,string varReAdmissionFee,int? varArrears)
		{
			TblSchoolHostelLedger item = new TblSchoolHostelLedger();
			
			item.Ceid = varCeid;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.HostelSecurity = varHostelSecurity;
			
			item.Apr = varApr;
			
			item.May = varMay;
			
			item.June = varJune;
			
			item.July = varJuly;
			
			item.August = varAugust;
			
			item.September = varSeptember;
			
			item.October = varOctober;
			
			item.November = varNovember;
			
			item.December = varDecember;
			
			item.January = varJanuary;
			
			item.Fabruary = varFabruary;
			
			item.March = varMarch;
			
			item.Remarks = varRemarks;
			
			item.LedgerType = varLedgerType;
			
			item.ReAdmissionFee = varReAdmissionFee;
			
			item.Arrears = varArrears;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSno,int? varCeid,int? varAdmissionFee,int? varHostelSecurity,string varApr,string varMay,string varJune,string varJuly,string varAugust,string varSeptember,string varOctober,string varNovember,string varDecember,string varJanuary,string varFabruary,string varMarch,string varRemarks,string varLedgerType,string varReAdmissionFee,int? varArrears)
		{
			TblSchoolHostelLedger item = new TblSchoolHostelLedger();
			
				item.Sno = varSno;
			
				item.Ceid = varCeid;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.HostelSecurity = varHostelSecurity;
			
				item.Apr = varApr;
			
				item.May = varMay;
			
				item.June = varJune;
			
				item.July = varJuly;
			
				item.August = varAugust;
			
				item.September = varSeptember;
			
				item.October = varOctober;
			
				item.November = varNovember;
			
				item.December = varDecember;
			
				item.January = varJanuary;
			
				item.Fabruary = varFabruary;
			
				item.March = varMarch;
			
				item.Remarks = varRemarks;
			
				item.LedgerType = varLedgerType;
			
				item.ReAdmissionFee = varReAdmissionFee;
			
				item.Arrears = varArrears;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SnoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CeidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelSecurityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AprColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MayColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn JuneColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn JulyColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AugustColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn SeptemberColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn OctoberColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NovemberColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DecemberColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn JanuaryColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FabruaryColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn MarchColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn RemarksColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn LedgerTypeColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ReAdmissionFeeColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ArrearsColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Sno = @"Sno";
			 public static string Ceid = @"CEID";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string HostelSecurity = @"HostelSecurity";
			 public static string Apr = @"Apr";
			 public static string May = @"May";
			 public static string June = @"June";
			 public static string July = @"July";
			 public static string August = @"August";
			 public static string September = @"September";
			 public static string October = @"October";
			 public static string November = @"November";
			 public static string December = @"December";
			 public static string January = @"january";
			 public static string Fabruary = @"Fabruary";
			 public static string March = @"March";
			 public static string Remarks = @"Remarks";
			 public static string LedgerType = @"LedgerType";
			 public static string ReAdmissionFee = @"ReAdmissionFee";
			 public static string Arrears = @"Arrears";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
