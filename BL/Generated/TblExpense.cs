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
	/// Strongly-typed collection for the TblExpense class.
	/// </summary>
    [Serializable]
	public partial class TblExpenseCollection : ActiveList<TblExpense, TblExpenseCollection>
	{	   
		public TblExpenseCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblExpenseCollection</returns>
		public TblExpenseCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblExpense o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Expenses table.
	/// </summary>
	[Serializable]
	public partial class TblExpense : ActiveRecord<TblExpense>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblExpense()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblExpense(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblExpense(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblExpense(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Expenses", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarExpenseID = new TableSchema.TableColumn(schema);
				colvarExpenseID.ColumnName = "ExpenseID";
				colvarExpenseID.DataType = DbType.Int32;
				colvarExpenseID.MaxLength = 0;
				colvarExpenseID.AutoIncrement = true;
				colvarExpenseID.IsNullable = false;
				colvarExpenseID.IsPrimaryKey = true;
				colvarExpenseID.IsForeignKey = false;
				colvarExpenseID.IsReadOnly = false;
				colvarExpenseID.DefaultSetting = @"";
				colvarExpenseID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpenseID);
				
				TableSchema.TableColumn colvarHeadID = new TableSchema.TableColumn(schema);
				colvarHeadID.ColumnName = "HeadID";
				colvarHeadID.DataType = DbType.Int32;
				colvarHeadID.MaxLength = 0;
				colvarHeadID.AutoIncrement = false;
				colvarHeadID.IsNullable = true;
				colvarHeadID.IsPrimaryKey = false;
				colvarHeadID.IsForeignKey = false;
				colvarHeadID.IsReadOnly = false;
				colvarHeadID.DefaultSetting = @"";
				colvarHeadID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHeadID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = true;
				colvarUserID.IsPrimaryKey = false;
				colvarUserID.IsForeignKey = false;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				colvarUserID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserID);
				
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
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.AnsiString;
				colvarTitle.MaxLength = 250;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = true;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "Amount";
				colvarAmount.DataType = DbType.Int32;
				colvarAmount.MaxLength = 0;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = true;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				colvarAmount.DefaultSetting = @"";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = -1;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarExpenseDate = new TableSchema.TableColumn(schema);
				colvarExpenseDate.ColumnName = "ExpenseDate";
				colvarExpenseDate.DataType = DbType.DateTime;
				colvarExpenseDate.MaxLength = 0;
				colvarExpenseDate.AutoIncrement = false;
				colvarExpenseDate.IsNullable = true;
				colvarExpenseDate.IsPrimaryKey = false;
				colvarExpenseDate.IsForeignKey = false;
				colvarExpenseDate.IsReadOnly = false;
				colvarExpenseDate.DefaultSetting = @"";
				colvarExpenseDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpenseDate);
				
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
				
				TableSchema.TableColumn colvarUpdateBy = new TableSchema.TableColumn(schema);
				colvarUpdateBy.ColumnName = "UpdateBy";
				colvarUpdateBy.DataType = DbType.Int32;
				colvarUpdateBy.MaxLength = 0;
				colvarUpdateBy.AutoIncrement = false;
				colvarUpdateBy.IsNullable = true;
				colvarUpdateBy.IsPrimaryKey = false;
				colvarUpdateBy.IsForeignKey = false;
				colvarUpdateBy.IsReadOnly = false;
				colvarUpdateBy.DefaultSetting = @"";
				colvarUpdateBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdateBy);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Expenses",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ExpenseID")]
		[Bindable(true)]
		public int ExpenseID 
		{
			get { return GetColumnValue<int>(Columns.ExpenseID); }
			set { SetColumnValue(Columns.ExpenseID, value); }
		}
		  
		[XmlAttribute("HeadID")]
		[Bindable(true)]
		public int? HeadID 
		{
			get { return GetColumnValue<int?>(Columns.HeadID); }
			set { SetColumnValue(Columns.HeadID, value); }
		}
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public int? UserID 
		{
			get { return GetColumnValue<int?>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("Title")]
		[Bindable(true)]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }
			set { SetColumnValue(Columns.Title, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public int? Amount 
		{
			get { return GetColumnValue<int?>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("ExpenseDate")]
		[Bindable(true)]
		public DateTime? ExpenseDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ExpenseDate); }
			set { SetColumnValue(Columns.ExpenseDate, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime? DateX 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		  
		[XmlAttribute("UpdateBy")]
		[Bindable(true)]
		public int? UpdateBy 
		{
			get { return GetColumnValue<int?>(Columns.UpdateBy); }
			set { SetColumnValue(Columns.UpdateBy, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varHeadID,int? varUserID,int? varBranchID,string varTitle,int? varAmount,string varDescription,DateTime? varExpenseDate,DateTime? varDateX,int? varUpdateBy)
		{
			TblExpense item = new TblExpense();
			
			item.HeadID = varHeadID;
			
			item.UserID = varUserID;
			
			item.BranchID = varBranchID;
			
			item.Title = varTitle;
			
			item.Amount = varAmount;
			
			item.Description = varDescription;
			
			item.ExpenseDate = varExpenseDate;
			
			item.DateX = varDateX;
			
			item.UpdateBy = varUpdateBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varExpenseID,int? varHeadID,int? varUserID,int? varBranchID,string varTitle,int? varAmount,string varDescription,DateTime? varExpenseDate,DateTime? varDateX,int? varUpdateBy)
		{
			TblExpense item = new TblExpense();
			
				item.ExpenseID = varExpenseID;
			
				item.HeadID = varHeadID;
			
				item.UserID = varUserID;
			
				item.BranchID = varBranchID;
			
				item.Title = varTitle;
			
				item.Amount = varAmount;
			
				item.Description = varDescription;
			
				item.ExpenseDate = varExpenseDate;
			
				item.DateX = varDateX;
			
				item.UpdateBy = varUpdateBy;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ExpenseIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HeadIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpenseDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdateByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ExpenseID = @"ExpenseID";
			 public static string HeadID = @"HeadID";
			 public static string UserID = @"UserID";
			 public static string BranchID = @"BranchID";
			 public static string Title = @"Title";
			 public static string Amount = @"Amount";
			 public static string Description = @"Description";
			 public static string ExpenseDate = @"ExpenseDate";
			 public static string DateX = @"Date";
			 public static string UpdateBy = @"UpdateBy";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
