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
	/// Strongly-typed collection for the TblAssestItem class.
	/// </summary>
    [Serializable]
	public partial class TblAssestItemCollection : ActiveList<TblAssestItem, TblAssestItemCollection>
	{	   
		public TblAssestItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAssestItemCollection</returns>
		public TblAssestItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAssestItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_AssestItems table.
	/// </summary>
	[Serializable]
	public partial class TblAssestItem : ActiveRecord<TblAssestItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAssestItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAssestItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAssestItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAssestItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_AssestItems", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarItemID = new TableSchema.TableColumn(schema);
				colvarItemID.ColumnName = "ItemID";
				colvarItemID.DataType = DbType.Int32;
				colvarItemID.MaxLength = 0;
				colvarItemID.AutoIncrement = true;
				colvarItemID.IsNullable = false;
				colvarItemID.IsPrimaryKey = true;
				colvarItemID.IsForeignKey = false;
				colvarItemID.IsReadOnly = false;
				colvarItemID.DefaultSetting = @"";
				colvarItemID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemID);
				
				TableSchema.TableColumn colvarItem = new TableSchema.TableColumn(schema);
				colvarItem.ColumnName = "Item";
				colvarItem.DataType = DbType.AnsiString;
				colvarItem.MaxLength = 50;
				colvarItem.AutoIncrement = false;
				colvarItem.IsNullable = true;
				colvarItem.IsPrimaryKey = false;
				colvarItem.IsForeignKey = false;
				colvarItem.IsReadOnly = false;
				colvarItem.DefaultSetting = @"";
				colvarItem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItem);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Boolean;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = true;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				colvarStatus.DefaultSetting = @"";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_AssestItems",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ItemID")]
		[Bindable(true)]
		public int ItemID 
		{
			get { return GetColumnValue<int>(Columns.ItemID); }
			set { SetColumnValue(Columns.ItemID, value); }
		}
		  
		[XmlAttribute("Item")]
		[Bindable(true)]
		public string Item 
		{
			get { return GetColumnValue<string>(Columns.Item); }
			set { SetColumnValue(Columns.Item, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public bool? Status 
		{
			get { return GetColumnValue<bool?>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
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
		public static void Insert(string varItem,bool? varStatus,int? varBranchID)
		{
			TblAssestItem item = new TblAssestItem();
			
			item.Item = varItem;
			
			item.Status = varStatus;
			
			item.BranchID = varBranchID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varItemID,string varItem,bool? varStatus,int? varBranchID)
		{
			TblAssestItem item = new TblAssestItem();
			
				item.ItemID = varItemID;
			
				item.Item = varItem;
			
				item.Status = varStatus;
			
				item.BranchID = varBranchID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ItemIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
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
			 public static string ItemID = @"ItemID";
			 public static string Item = @"Item";
			 public static string Status = @"Status";
			 public static string BranchID = @"BranchID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
