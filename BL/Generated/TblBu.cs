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
	/// Strongly-typed collection for the TblBu class.
	/// </summary>
    [Serializable]
	public partial class TblBuCollection : ActiveList<TblBu, TblBuCollection>
	{	   
		public TblBuCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblBuCollection</returns>
		public TblBuCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblBu o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Bus table.
	/// </summary>
	[Serializable]
	public partial class TblBu : ActiveRecord<TblBu>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblBu()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblBu(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblBu(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblBu(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Bus", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarBusID = new TableSchema.TableColumn(schema);
				colvarBusID.ColumnName = "BusID";
				colvarBusID.DataType = DbType.Int32;
				colvarBusID.MaxLength = 0;
				colvarBusID.AutoIncrement = true;
				colvarBusID.IsNullable = false;
				colvarBusID.IsPrimaryKey = true;
				colvarBusID.IsForeignKey = false;
				colvarBusID.IsReadOnly = false;
				colvarBusID.DefaultSetting = @"";
				colvarBusID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBusID);
				
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
				
				TableSchema.TableColumn colvarBusNo = new TableSchema.TableColumn(schema);
				colvarBusNo.ColumnName = "BusNo";
				colvarBusNo.DataType = DbType.AnsiString;
				colvarBusNo.MaxLength = 50;
				colvarBusNo.AutoIncrement = false;
				colvarBusNo.IsNullable = false;
				colvarBusNo.IsPrimaryKey = false;
				colvarBusNo.IsForeignKey = false;
				colvarBusNo.IsReadOnly = false;
				colvarBusNo.DefaultSetting = @"";
				colvarBusNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBusNo);
				
				TableSchema.TableColumn colvarSeats = new TableSchema.TableColumn(schema);
				colvarSeats.ColumnName = "Seats";
				colvarSeats.DataType = DbType.Int32;
				colvarSeats.MaxLength = 0;
				colvarSeats.AutoIncrement = false;
				colvarSeats.IsNullable = false;
				colvarSeats.IsPrimaryKey = false;
				colvarSeats.IsForeignKey = false;
				colvarSeats.IsReadOnly = false;
				colvarSeats.DefaultSetting = @"";
				colvarSeats.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSeats);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Int32;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = false;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Bus",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("BusID")]
		[Bindable(true)]
		public int BusID 
		{
			get { return GetColumnValue<int>(Columns.BusID); }
			set { SetColumnValue(Columns.BusID, value); }
		}
		  
		[XmlAttribute("RouteID")]
		[Bindable(true)]
		public int RouteID 
		{
			get { return GetColumnValue<int>(Columns.RouteID); }
			set { SetColumnValue(Columns.RouteID, value); }
		}
		  
		[XmlAttribute("BusNo")]
		[Bindable(true)]
		public string BusNo 
		{
			get { return GetColumnValue<string>(Columns.BusNo); }
			set { SetColumnValue(Columns.BusNo, value); }
		}
		  
		[XmlAttribute("Seats")]
		[Bindable(true)]
		public int Seats 
		{
			get { return GetColumnValue<int>(Columns.Seats); }
			set { SetColumnValue(Columns.Seats, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public int IsActive 
		{
			get { return GetColumnValue<int>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varRouteID,string varBusNo,int varSeats,int varIsActive)
		{
			TblBu item = new TblBu();
			
			item.RouteID = varRouteID;
			
			item.BusNo = varBusNo;
			
			item.Seats = varSeats;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varBusID,int varRouteID,string varBusNo,int varSeats,int varIsActive)
		{
			TblBu item = new TblBu();
			
				item.BusID = varBusID;
			
				item.RouteID = varRouteID;
			
				item.BusNo = varBusNo;
			
				item.Seats = varSeats;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn BusIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RouteIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BusNoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SeatsColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string BusID = @"BusID";
			 public static string RouteID = @"RouteID";
			 public static string BusNo = @"BusNo";
			 public static string Seats = @"Seats";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
