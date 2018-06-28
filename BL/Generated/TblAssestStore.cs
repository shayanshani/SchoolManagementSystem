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
	/// Strongly-typed collection for the TblAssestStore class.
	/// </summary>
    [Serializable]
	public partial class TblAssestStoreCollection : ActiveList<TblAssestStore, TblAssestStoreCollection>
	{	   
		public TblAssestStoreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAssestStoreCollection</returns>
		public TblAssestStoreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAssestStore o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_AssestStore table.
	/// </summary>
	[Serializable]
	public partial class TblAssestStore : ActiveRecord<TblAssestStore>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAssestStore()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAssestStore(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAssestStore(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAssestStore(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_AssestStore", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarStoreID = new TableSchema.TableColumn(schema);
				colvarStoreID.ColumnName = "StoreID";
				colvarStoreID.DataType = DbType.Int32;
				colvarStoreID.MaxLength = 0;
				colvarStoreID.AutoIncrement = true;
				colvarStoreID.IsNullable = false;
				colvarStoreID.IsPrimaryKey = true;
				colvarStoreID.IsForeignKey = false;
				colvarStoreID.IsReadOnly = false;
				colvarStoreID.DefaultSetting = @"";
				colvarStoreID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStoreID);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_AssestStore",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("StoreID")]
		[Bindable(true)]
		public int StoreID 
		{
			get { return GetColumnValue<int>(Columns.StoreID); }
			set { SetColumnValue(Columns.StoreID, value); }
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
		public static void Insert(int? varItemID,int? varQuantity,int? varBranchID)
		{
			TblAssestStore item = new TblAssestStore();
			
			item.ItemID = varItemID;
			
			item.Quantity = varQuantity;
			
			item.BranchID = varBranchID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varStoreID,int? varItemID,int? varQuantity,int? varBranchID)
		{
			TblAssestStore item = new TblAssestStore();
			
				item.StoreID = varStoreID;
			
				item.ItemID = varItemID;
			
				item.Quantity = varQuantity;
			
				item.BranchID = varBranchID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn StoreIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string StoreID = @"StoreID";
			 public static string ItemID = @"ItemID";
			 public static string Quantity = @"Quantity";
			 public static string BranchID = @"BranchID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
