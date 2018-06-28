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
	/// Strongly-typed collection for the TblTransportHolder class.
	/// </summary>
    [Serializable]
	public partial class TblTransportHolderCollection : ActiveList<TblTransportHolder, TblTransportHolderCollection>
	{	   
		public TblTransportHolderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblTransportHolderCollection</returns>
		public TblTransportHolderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblTransportHolder o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_TransportHolders table.
	/// </summary>
	[Serializable]
	public partial class TblTransportHolder : ActiveRecord<TblTransportHolder>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblTransportHolder()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblTransportHolder(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblTransportHolder(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblTransportHolder(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_TransportHolders", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTransportID = new TableSchema.TableColumn(schema);
				colvarTransportID.ColumnName = "TransportID";
				colvarTransportID.DataType = DbType.Int32;
				colvarTransportID.MaxLength = 0;
				colvarTransportID.AutoIncrement = true;
				colvarTransportID.IsNullable = false;
				colvarTransportID.IsPrimaryKey = true;
				colvarTransportID.IsForeignKey = false;
				colvarTransportID.IsReadOnly = false;
				colvarTransportID.DefaultSetting = @"";
				colvarTransportID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransportID);
				
				TableSchema.TableColumn colvarRouteID = new TableSchema.TableColumn(schema);
				colvarRouteID.ColumnName = "RouteID";
				colvarRouteID.DataType = DbType.Int32;
				colvarRouteID.MaxLength = 0;
				colvarRouteID.AutoIncrement = false;
				colvarRouteID.IsNullable = false;
				colvarRouteID.IsPrimaryKey = false;
				colvarRouteID.IsForeignKey = false;
				colvarRouteID.IsReadOnly = false;
				colvarRouteID.DefaultSetting = @"";
				colvarRouteID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRouteID);
				
				TableSchema.TableColumn colvarBusID = new TableSchema.TableColumn(schema);
				colvarBusID.ColumnName = "BusID";
				colvarBusID.DataType = DbType.Int32;
				colvarBusID.MaxLength = 0;
				colvarBusID.AutoIncrement = false;
				colvarBusID.IsNullable = true;
				colvarBusID.IsPrimaryKey = false;
				colvarBusID.IsForeignKey = false;
				colvarBusID.IsReadOnly = false;
				colvarBusID.DefaultSetting = @"";
				colvarBusID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBusID);
				
				TableSchema.TableColumn colvarMemberID = new TableSchema.TableColumn(schema);
				colvarMemberID.ColumnName = "MemberID";
				colvarMemberID.DataType = DbType.Int32;
				colvarMemberID.MaxLength = 0;
				colvarMemberID.AutoIncrement = false;
				colvarMemberID.IsNullable = true;
				colvarMemberID.IsPrimaryKey = false;
				colvarMemberID.IsForeignKey = false;
				colvarMemberID.IsReadOnly = false;
				colvarMemberID.DefaultSetting = @"";
				colvarMemberID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMemberID);
				
				TableSchema.TableColumn colvarMemberType = new TableSchema.TableColumn(schema);
				colvarMemberType.ColumnName = "MemberType";
				colvarMemberType.DataType = DbType.Boolean;
				colvarMemberType.MaxLength = 0;
				colvarMemberType.AutoIncrement = false;
				colvarMemberType.IsNullable = true;
				colvarMemberType.IsPrimaryKey = false;
				colvarMemberType.IsForeignKey = false;
				colvarMemberType.IsReadOnly = false;
				colvarMemberType.DefaultSetting = @"";
				colvarMemberType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMemberType);
				
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
				
				TableSchema.TableColumn colvarSeatNo = new TableSchema.TableColumn(schema);
				colvarSeatNo.ColumnName = "SeatNo";
				colvarSeatNo.DataType = DbType.Int32;
				colvarSeatNo.MaxLength = 0;
				colvarSeatNo.AutoIncrement = false;
				colvarSeatNo.IsNullable = true;
				colvarSeatNo.IsPrimaryKey = false;
				colvarSeatNo.IsForeignKey = false;
				colvarSeatNo.IsReadOnly = false;
				colvarSeatNo.DefaultSetting = @"";
				colvarSeatNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeatNo);
				
				TableSchema.TableColumn colvarStop = new TableSchema.TableColumn(schema);
				colvarStop.ColumnName = "Stop";
				colvarStop.DataType = DbType.AnsiString;
				colvarStop.MaxLength = 50;
				colvarStop.AutoIncrement = false;
				colvarStop.IsNullable = true;
				colvarStop.IsPrimaryKey = false;
				colvarStop.IsForeignKey = false;
				colvarStop.IsReadOnly = false;
				colvarStop.DefaultSetting = @"";
				colvarStop.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStop);
				
				TableSchema.TableColumn colvarJoiningDate = new TableSchema.TableColumn(schema);
				colvarJoiningDate.ColumnName = "JoiningDate";
				colvarJoiningDate.DataType = DbType.DateTime;
				colvarJoiningDate.MaxLength = 0;
				colvarJoiningDate.AutoIncrement = false;
				colvarJoiningDate.IsNullable = true;
				colvarJoiningDate.IsPrimaryKey = false;
				colvarJoiningDate.IsForeignKey = false;
				colvarJoiningDate.IsReadOnly = false;
				colvarJoiningDate.DefaultSetting = @"";
				colvarJoiningDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJoiningDate);
				
				TableSchema.TableColumn colvarInActiveDate = new TableSchema.TableColumn(schema);
				colvarInActiveDate.ColumnName = "InActiveDate";
				colvarInActiveDate.DataType = DbType.DateTime;
				colvarInActiveDate.MaxLength = 0;
				colvarInActiveDate.AutoIncrement = false;
				colvarInActiveDate.IsNullable = true;
				colvarInActiveDate.IsPrimaryKey = false;
				colvarInActiveDate.IsForeignKey = false;
				colvarInActiveDate.IsReadOnly = false;
				colvarInActiveDate.DefaultSetting = @"";
				colvarInActiveDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInActiveDate);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Boolean;
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_TransportHolders",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransportID")]
		[Bindable(true)]
		public int TransportID 
		{
			get { return GetColumnValue<int>(Columns.TransportID); }
			set { SetColumnValue(Columns.TransportID, value); }
		}
		  
		[XmlAttribute("RouteID")]
		[Bindable(true)]
		public int RouteID 
		{
			get { return GetColumnValue<int>(Columns.RouteID); }
			set { SetColumnValue(Columns.RouteID, value); }
		}
		  
		[XmlAttribute("BusID")]
		[Bindable(true)]
		public int? BusID 
		{
			get { return GetColumnValue<int?>(Columns.BusID); }
			set { SetColumnValue(Columns.BusID, value); }
		}
		  
		[XmlAttribute("MemberID")]
		[Bindable(true)]
		public int? MemberID 
		{
			get { return GetColumnValue<int?>(Columns.MemberID); }
			set { SetColumnValue(Columns.MemberID, value); }
		}
		  
		[XmlAttribute("MemberType")]
		[Bindable(true)]
		public bool? MemberType 
		{
			get { return GetColumnValue<bool?>(Columns.MemberType); }
			set { SetColumnValue(Columns.MemberType, value); }
		}
		  
		[XmlAttribute("Discount")]
		[Bindable(true)]
		public int? Discount 
		{
			get { return GetColumnValue<int?>(Columns.Discount); }
			set { SetColumnValue(Columns.Discount, value); }
		}
		  
		[XmlAttribute("SeatNo")]
		[Bindable(true)]
		public int? SeatNo 
		{
			get { return GetColumnValue<int?>(Columns.SeatNo); }
			set { SetColumnValue(Columns.SeatNo, value); }
		}
		  
		[XmlAttribute("Stop")]
		[Bindable(true)]
		public string Stop 
		{
			get { return GetColumnValue<string>(Columns.Stop); }
			set { SetColumnValue(Columns.Stop, value); }
		}
		  
		[XmlAttribute("JoiningDate")]
		[Bindable(true)]
		public DateTime? JoiningDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.JoiningDate); }
			set { SetColumnValue(Columns.JoiningDate, value); }
		}
		  
		[XmlAttribute("InActiveDate")]
		[Bindable(true)]
		public DateTime? InActiveDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.InActiveDate); }
			set { SetColumnValue(Columns.InActiveDate, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRouteID,int? varBusID,int? varMemberID,bool? varMemberType,int? varDiscount,int? varSeatNo,string varStop,DateTime? varJoiningDate,DateTime? varInActiveDate,bool? varIsActive)
		{
			TblTransportHolder item = new TblTransportHolder();
			
			item.RouteID = varRouteID;
			
			item.BusID = varBusID;
			
			item.MemberID = varMemberID;
			
			item.MemberType = varMemberType;
			
			item.Discount = varDiscount;
			
			item.SeatNo = varSeatNo;
			
			item.Stop = varStop;
			
			item.JoiningDate = varJoiningDate;
			
			item.InActiveDate = varInActiveDate;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTransportID,int varRouteID,int? varBusID,int? varMemberID,bool? varMemberType,int? varDiscount,int? varSeatNo,string varStop,DateTime? varJoiningDate,DateTime? varInActiveDate,bool? varIsActive)
		{
			TblTransportHolder item = new TblTransportHolder();
			
				item.TransportID = varTransportID;
			
				item.RouteID = varRouteID;
			
				item.BusID = varBusID;
			
				item.MemberID = varMemberID;
			
				item.MemberType = varMemberType;
			
				item.Discount = varDiscount;
			
				item.SeatNo = varSeatNo;
			
				item.Stop = varStop;
			
				item.JoiningDate = varJoiningDate;
			
				item.InActiveDate = varInActiveDate;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TransportIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RouteIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BusIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MemberIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MemberTypeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SeatNoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn StopColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn JoiningDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InActiveDateColumn
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
			 public static string TransportID = @"TransportID";
			 public static string RouteID = @"RouteID";
			 public static string BusID = @"BusID";
			 public static string MemberID = @"MemberID";
			 public static string MemberType = @"MemberType";
			 public static string Discount = @"Discount";
			 public static string SeatNo = @"SeatNo";
			 public static string Stop = @"Stop";
			 public static string JoiningDate = @"JoiningDate";
			 public static string InActiveDate = @"InActiveDate";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
