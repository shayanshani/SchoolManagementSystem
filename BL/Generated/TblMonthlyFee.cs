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
	/// Strongly-typed collection for the TblMonthlyFee class.
	/// </summary>
    [Serializable]
	public partial class TblMonthlyFeeCollection : ActiveList<TblMonthlyFee, TblMonthlyFeeCollection>
	{	   
		public TblMonthlyFeeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblMonthlyFeeCollection</returns>
		public TblMonthlyFeeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblMonthlyFee o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_MonthlyFee table.
	/// </summary>
	[Serializable]
	public partial class TblMonthlyFee : ActiveRecord<TblMonthlyFee>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblMonthlyFee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblMonthlyFee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblMonthlyFee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblMonthlyFee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_MonthlyFee", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
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
				
				TableSchema.TableColumn colvarFeeType = new TableSchema.TableColumn(schema);
				colvarFeeType.ColumnName = "FeeType";
				colvarFeeType.DataType = DbType.AnsiString;
				colvarFeeType.MaxLength = 50;
				colvarFeeType.AutoIncrement = false;
				colvarFeeType.IsNullable = true;
				colvarFeeType.IsPrimaryKey = false;
				colvarFeeType.IsForeignKey = false;
				colvarFeeType.IsReadOnly = false;
				colvarFeeType.DefaultSetting = @"";
				colvarFeeType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeType);
				
				TableSchema.TableColumn colvarSchFeeID = new TableSchema.TableColumn(schema);
				colvarSchFeeID.ColumnName = "SchFeeID";
				colvarSchFeeID.DataType = DbType.Int32;
				colvarSchFeeID.MaxLength = 0;
				colvarSchFeeID.AutoIncrement = false;
				colvarSchFeeID.IsNullable = true;
				colvarSchFeeID.IsPrimaryKey = false;
				colvarSchFeeID.IsForeignKey = false;
				colvarSchFeeID.IsReadOnly = false;
				colvarSchFeeID.DefaultSetting = @"";
				colvarSchFeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSchFeeID);
				
				TableSchema.TableColumn colvarClgFeeID = new TableSchema.TableColumn(schema);
				colvarClgFeeID.ColumnName = "ClgFeeID";
				colvarClgFeeID.DataType = DbType.Int32;
				colvarClgFeeID.MaxLength = 0;
				colvarClgFeeID.AutoIncrement = false;
				colvarClgFeeID.IsNullable = true;
				colvarClgFeeID.IsPrimaryKey = false;
				colvarClgFeeID.IsForeignKey = false;
				colvarClgFeeID.IsReadOnly = false;
				colvarClgFeeID.DefaultSetting = @"";
				colvarClgFeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClgFeeID);
				
				TableSchema.TableColumn colvarSno = new TableSchema.TableColumn(schema);
				colvarSno.ColumnName = "Sno";
				colvarSno.DataType = DbType.Int32;
				colvarSno.MaxLength = 0;
				colvarSno.AutoIncrement = false;
				colvarSno.IsNullable = true;
				colvarSno.IsPrimaryKey = false;
				colvarSno.IsForeignKey = false;
				colvarSno.IsReadOnly = false;
				colvarSno.DefaultSetting = @"";
				colvarSno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSno);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "Amount";
				colvarAmount.DataType = DbType.Currency;
				colvarAmount.MaxLength = 0;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = true;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				colvarAmount.DefaultSetting = @"";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
				TableSchema.TableColumn colvarDateX = new TableSchema.TableColumn(schema);
				colvarDateX.ColumnName = "Date";
				colvarDateX.DataType = DbType.DateTime;
				colvarDateX.MaxLength = 0;
				colvarDateX.AutoIncrement = false;
				colvarDateX.IsNullable = true;
				colvarDateX.IsPrimaryKey = false;
				colvarDateX.IsForeignKey = false;
				colvarDateX.IsReadOnly = false;
				colvarDateX.DefaultSetting = @"";
				colvarDateX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateX);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_MonthlyFee",schema);
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
		  
		[XmlAttribute("Ceid")]
		[Bindable(true)]
		public int? Ceid 
		{
			get { return GetColumnValue<int?>(Columns.Ceid); }
			set { SetColumnValue(Columns.Ceid, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("FeeType")]
		[Bindable(true)]
		public string FeeType 
		{
			get { return GetColumnValue<string>(Columns.FeeType); }
			set { SetColumnValue(Columns.FeeType, value); }
		}
		  
		[XmlAttribute("SchFeeID")]
		[Bindable(true)]
		public int? SchFeeID 
		{
			get { return GetColumnValue<int?>(Columns.SchFeeID); }
			set { SetColumnValue(Columns.SchFeeID, value); }
		}
		  
		[XmlAttribute("ClgFeeID")]
		[Bindable(true)]
		public int? ClgFeeID 
		{
			get { return GetColumnValue<int?>(Columns.ClgFeeID); }
			set { SetColumnValue(Columns.ClgFeeID, value); }
		}
		  
		[XmlAttribute("Sno")]
		[Bindable(true)]
		public int? Sno 
		{
			get { return GetColumnValue<int?>(Columns.Sno); }
			set { SetColumnValue(Columns.Sno, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public decimal? Amount 
		{
			get { return GetColumnValue<decimal?>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCeid,int? varBranchID,string varFeeType,int? varSchFeeID,int? varClgFeeID,int? varSno,decimal? varAmount,DateTime? varDateX)
		{
			TblMonthlyFee item = new TblMonthlyFee();
			
			item.Ceid = varCeid;
			
			item.BranchID = varBranchID;
			
			item.FeeType = varFeeType;
			
			item.SchFeeID = varSchFeeID;
			
			item.ClgFeeID = varClgFeeID;
			
			item.Sno = varSno;
			
			item.Amount = varAmount;
			
			item.DateX = varDateX;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varFeeID,int? varCeid,int? varBranchID,string varFeeType,int? varSchFeeID,int? varClgFeeID,int? varSno,decimal? varAmount,DateTime? varDateX)
		{
			TblMonthlyFee item = new TblMonthlyFee();
			
				item.FeeID = varFeeID;
			
				item.Ceid = varCeid;
			
				item.BranchID = varBranchID;
			
				item.FeeType = varFeeType;
			
				item.SchFeeID = varSchFeeID;
			
				item.ClgFeeID = varClgFeeID;
			
				item.Sno = varSno;
			
				item.Amount = varAmount;
			
				item.DateX = varDateX;
			
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
        
        
        
        public static TableSchema.TableColumn CeidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FeeTypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SchFeeIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ClgFeeIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SnoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string FeeID = @"FeeID";
			 public static string Ceid = @"CEID";
			 public static string BranchID = @"BranchID";
			 public static string FeeType = @"FeeType";
			 public static string SchFeeID = @"SchFeeID";
			 public static string ClgFeeID = @"ClgFeeID";
			 public static string Sno = @"Sno";
			 public static string Amount = @"Amount";
			 public static string DateX = @"Date";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
