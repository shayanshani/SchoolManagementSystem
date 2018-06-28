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
	/// Strongly-typed collection for the TblAmountTransfer class.
	/// </summary>
    [Serializable]
	public partial class TblAmountTransferCollection : ActiveList<TblAmountTransfer, TblAmountTransferCollection>
	{	   
		public TblAmountTransferCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAmountTransferCollection</returns>
		public TblAmountTransferCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAmountTransfer o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_AmountTransfers table.
	/// </summary>
	[Serializable]
	public partial class TblAmountTransfer : ActiveRecord<TblAmountTransfer>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAmountTransfer()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAmountTransfer(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAmountTransfer(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAmountTransfer(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_AmountTransfers", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTransferID = new TableSchema.TableColumn(schema);
				colvarTransferID.ColumnName = "TransferID";
				colvarTransferID.DataType = DbType.Int32;
				colvarTransferID.MaxLength = 0;
				colvarTransferID.AutoIncrement = true;
				colvarTransferID.IsNullable = false;
				colvarTransferID.IsPrimaryKey = true;
				colvarTransferID.IsForeignKey = false;
				colvarTransferID.IsReadOnly = false;
				colvarTransferID.DefaultSetting = @"";
				colvarTransferID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransferID);
				
				TableSchema.TableColumn colvarSenderID = new TableSchema.TableColumn(schema);
				colvarSenderID.ColumnName = "SenderID";
				colvarSenderID.DataType = DbType.Int32;
				colvarSenderID.MaxLength = 0;
				colvarSenderID.AutoIncrement = false;
				colvarSenderID.IsNullable = true;
				colvarSenderID.IsPrimaryKey = false;
				colvarSenderID.IsForeignKey = false;
				colvarSenderID.IsReadOnly = false;
				colvarSenderID.DefaultSetting = @"";
				colvarSenderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSenderID);
				
				TableSchema.TableColumn colvarRecieverID = new TableSchema.TableColumn(schema);
				colvarRecieverID.ColumnName = "RecieverID";
				colvarRecieverID.DataType = DbType.Int32;
				colvarRecieverID.MaxLength = 0;
				colvarRecieverID.AutoIncrement = false;
				colvarRecieverID.IsNullable = true;
				colvarRecieverID.IsPrimaryKey = false;
				colvarRecieverID.IsForeignKey = false;
				colvarRecieverID.IsReadOnly = false;
				colvarRecieverID.DefaultSetting = @"";
				colvarRecieverID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecieverID);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_AmountTransfers",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransferID")]
		[Bindable(true)]
		public int TransferID 
		{
			get { return GetColumnValue<int>(Columns.TransferID); }
			set { SetColumnValue(Columns.TransferID, value); }
		}
		  
		[XmlAttribute("SenderID")]
		[Bindable(true)]
		public int? SenderID 
		{
			get { return GetColumnValue<int?>(Columns.SenderID); }
			set { SetColumnValue(Columns.SenderID, value); }
		}
		  
		[XmlAttribute("RecieverID")]
		[Bindable(true)]
		public int? RecieverID 
		{
			get { return GetColumnValue<int?>(Columns.RecieverID); }
			set { SetColumnValue(Columns.RecieverID, value); }
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
		public static void Insert(int? varSenderID,int? varRecieverID,int? varAmount,string varDescription,DateTime? varDateX)
		{
			TblAmountTransfer item = new TblAmountTransfer();
			
			item.SenderID = varSenderID;
			
			item.RecieverID = varRecieverID;
			
			item.Amount = varAmount;
			
			item.Description = varDescription;
			
			item.DateX = varDateX;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTransferID,int? varSenderID,int? varRecieverID,int? varAmount,string varDescription,DateTime? varDateX)
		{
			TblAmountTransfer item = new TblAmountTransfer();
			
				item.TransferID = varTransferID;
			
				item.SenderID = varSenderID;
			
				item.RecieverID = varRecieverID;
			
				item.Amount = varAmount;
			
				item.Description = varDescription;
			
				item.DateX = varDateX;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TransferIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SenderIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RecieverIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TransferID = @"TransferID";
			 public static string SenderID = @"SenderID";
			 public static string RecieverID = @"RecieverID";
			 public static string Amount = @"Amount";
			 public static string Description = @"Description";
			 public static string DateX = @"Date";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
