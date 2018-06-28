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
	/// Strongly-typed collection for the TblAssestStockHistory class.
	/// </summary>
    [Serializable]
	public partial class TblAssestStockHistoryCollection : ActiveList<TblAssestStockHistory, TblAssestStockHistoryCollection>
	{	   
		public TblAssestStockHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAssestStockHistoryCollection</returns>
		public TblAssestStockHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAssestStockHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_AssestStockHistory table.
	/// </summary>
	[Serializable]
	public partial class TblAssestStockHistory : ActiveRecord<TblAssestStockHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAssestStockHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAssestStockHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAssestStockHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAssestStockHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_AssestStockHistory", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarHistoryID = new TableSchema.TableColumn(schema);
				colvarHistoryID.ColumnName = "HistoryID";
				colvarHistoryID.DataType = DbType.Int32;
				colvarHistoryID.MaxLength = 0;
				colvarHistoryID.AutoIncrement = true;
				colvarHistoryID.IsNullable = false;
				colvarHistoryID.IsPrimaryKey = true;
				colvarHistoryID.IsForeignKey = false;
				colvarHistoryID.IsReadOnly = false;
				colvarHistoryID.DefaultSetting = @"";
				colvarHistoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHistoryID);
				
				TableSchema.TableColumn colvarStockID = new TableSchema.TableColumn(schema);
				colvarStockID.ColumnName = "StockID";
				colvarStockID.DataType = DbType.Int32;
				colvarStockID.MaxLength = 0;
				colvarStockID.AutoIncrement = false;
				colvarStockID.IsNullable = true;
				colvarStockID.IsPrimaryKey = false;
				colvarStockID.IsForeignKey = false;
				colvarStockID.IsReadOnly = false;
				colvarStockID.DefaultSetting = @"";
				colvarStockID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStockID);
				
				TableSchema.TableColumn colvarItemID = new TableSchema.TableColumn(schema);
				colvarItemID.ColumnName = "ItemID";
				colvarItemID.DataType = DbType.Int32;
				colvarItemID.MaxLength = 0;
				colvarItemID.AutoIncrement = false;
				colvarItemID.IsNullable = true;
				colvarItemID.IsPrimaryKey = false;
				colvarItemID.IsForeignKey = false;
				colvarItemID.IsReadOnly = false;
				colvarItemID.DefaultSetting = @"";
				colvarItemID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemID);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = true;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarPerPrice = new TableSchema.TableColumn(schema);
				colvarPerPrice.ColumnName = "PerPrice";
				colvarPerPrice.DataType = DbType.Currency;
				colvarPerPrice.MaxLength = 0;
				colvarPerPrice.AutoIncrement = false;
				colvarPerPrice.IsNullable = true;
				colvarPerPrice.IsPrimaryKey = false;
				colvarPerPrice.IsForeignKey = false;
				colvarPerPrice.IsReadOnly = false;
				colvarPerPrice.DefaultSetting = @"";
				colvarPerPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerPrice);
				
				TableSchema.TableColumn colvarTotalPrice = new TableSchema.TableColumn(schema);
				colvarTotalPrice.ColumnName = "TotalPrice";
				colvarTotalPrice.DataType = DbType.Currency;
				colvarTotalPrice.MaxLength = 0;
				colvarTotalPrice.AutoIncrement = false;
				colvarTotalPrice.IsNullable = true;
				colvarTotalPrice.IsPrimaryKey = false;
				colvarTotalPrice.IsForeignKey = false;
				colvarTotalPrice.IsReadOnly = false;
				colvarTotalPrice.DefaultSetting = @"";
				colvarTotalPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalPrice);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_AssestStockHistory",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("HistoryID")]
		[Bindable(true)]
		public int HistoryID 
		{
			get { return GetColumnValue<int>(Columns.HistoryID); }
			set { SetColumnValue(Columns.HistoryID, value); }
		}
		  
		[XmlAttribute("StockID")]
		[Bindable(true)]
		public int? StockID 
		{
			get { return GetColumnValue<int?>(Columns.StockID); }
			set { SetColumnValue(Columns.StockID, value); }
		}
		  
		[XmlAttribute("ItemID")]
		[Bindable(true)]
		public int? ItemID 
		{
			get { return GetColumnValue<int?>(Columns.ItemID); }
			set { SetColumnValue(Columns.ItemID, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public int? Quantity 
		{
			get { return GetColumnValue<int?>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("PerPrice")]
		[Bindable(true)]
		public decimal? PerPrice 
		{
			get { return GetColumnValue<decimal?>(Columns.PerPrice); }
			set { SetColumnValue(Columns.PerPrice, value); }
		}
		  
		[XmlAttribute("TotalPrice")]
		[Bindable(true)]
		public decimal? TotalPrice 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalPrice); }
			set { SetColumnValue(Columns.TotalPrice, value); }
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
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varStockID,int? varItemID,int? varQuantity,decimal? varPerPrice,decimal? varTotalPrice,int? varUserID,int? varBranchID)
		{
			TblAssestStockHistory item = new TblAssestStockHistory();
			
			item.StockID = varStockID;
			
			item.ItemID = varItemID;
			
			item.Quantity = varQuantity;
			
			item.PerPrice = varPerPrice;
			
			item.TotalPrice = varTotalPrice;
			
			item.UserID = varUserID;
			
			item.BranchID = varBranchID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHistoryID,int? varStockID,int? varItemID,int? varQuantity,decimal? varPerPrice,decimal? varTotalPrice,int? varUserID,int? varBranchID)
		{
			TblAssestStockHistory item = new TblAssestStockHistory();
			
				item.HistoryID = varHistoryID;
			
				item.StockID = varStockID;
			
				item.ItemID = varItemID;
			
				item.Quantity = varQuantity;
			
				item.PerPrice = varPerPrice;
			
				item.TotalPrice = varTotalPrice;
			
				item.UserID = varUserID;
			
				item.BranchID = varBranchID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HistoryIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StockIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PerPriceColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalPriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string HistoryID = @"HistoryID";
			 public static string StockID = @"StockID";
			 public static string ItemID = @"ItemID";
			 public static string Quantity = @"Quantity";
			 public static string PerPrice = @"PerPrice";
			 public static string TotalPrice = @"TotalPrice";
			 public static string UserID = @"UserID";
			 public static string BranchID = @"BranchID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
