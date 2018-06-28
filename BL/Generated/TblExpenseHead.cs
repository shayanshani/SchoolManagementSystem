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
	/// Strongly-typed collection for the TblExpenseHead class.
	/// </summary>
    [Serializable]
	public partial class TblExpenseHeadCollection : ActiveList<TblExpenseHead, TblExpenseHeadCollection>
	{	   
		public TblExpenseHeadCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblExpenseHeadCollection</returns>
		public TblExpenseHeadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblExpenseHead o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ExpenseHeads table.
	/// </summary>
	[Serializable]
	public partial class TblExpenseHead : ActiveRecord<TblExpenseHead>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblExpenseHead()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblExpenseHead(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblExpenseHead(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblExpenseHead(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ExpenseHeads", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarHeadID = new TableSchema.TableColumn(schema);
				colvarHeadID.ColumnName = "HeadID";
				colvarHeadID.DataType = DbType.Int32;
				colvarHeadID.MaxLength = 0;
				colvarHeadID.AutoIncrement = true;
				colvarHeadID.IsNullable = false;
				colvarHeadID.IsPrimaryKey = true;
				colvarHeadID.IsForeignKey = false;
				colvarHeadID.IsReadOnly = false;
				colvarHeadID.DefaultSetting = @"";
				colvarHeadID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHeadID);
				
				TableSchema.TableColumn colvarHead = new TableSchema.TableColumn(schema);
				colvarHead.ColumnName = "Head";
				colvarHead.DataType = DbType.AnsiString;
				colvarHead.MaxLength = 250;
				colvarHead.AutoIncrement = false;
				colvarHead.IsNullable = true;
				colvarHead.IsPrimaryKey = false;
				colvarHead.IsForeignKey = false;
				colvarHead.IsReadOnly = false;
				colvarHead.DefaultSetting = @"";
				colvarHead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHead);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ExpenseHeads",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("HeadID")]
		[Bindable(true)]
		public int HeadID 
		{
			get { return GetColumnValue<int>(Columns.HeadID); }
			set { SetColumnValue(Columns.HeadID, value); }
		}
		  
		[XmlAttribute("Head")]
		[Bindable(true)]
		public string Head 
		{
			get { return GetColumnValue<string>(Columns.Head); }
			set { SetColumnValue(Columns.Head, value); }
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
		public static void Insert(string varHead,int? varBranchID)
		{
			TblExpenseHead item = new TblExpenseHead();
			
			item.Head = varHead;
			
			item.BranchID = varBranchID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHeadID,string varHead,int? varBranchID)
		{
			TblExpenseHead item = new TblExpenseHead();
			
				item.HeadID = varHeadID;
			
				item.Head = varHead;
			
				item.BranchID = varBranchID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HeadIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HeadColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string HeadID = @"HeadID";
			 public static string Head = @"Head";
			 public static string BranchID = @"BranchID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
