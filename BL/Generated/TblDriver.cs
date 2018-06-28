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
	/// Strongly-typed collection for the TblDriver class.
	/// </summary>
    [Serializable]
	public partial class TblDriverCollection : ActiveList<TblDriver, TblDriverCollection>
	{	   
		public TblDriverCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblDriverCollection</returns>
		public TblDriverCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblDriver o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Driver table.
	/// </summary>
	[Serializable]
	public partial class TblDriver : ActiveRecord<TblDriver>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblDriver()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblDriver(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblDriver(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblDriver(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Driver", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarDid = new TableSchema.TableColumn(schema);
				colvarDid.ColumnName = "DID";
				colvarDid.DataType = DbType.Int32;
				colvarDid.MaxLength = 0;
				colvarDid.AutoIncrement = true;
				colvarDid.IsNullable = false;
				colvarDid.IsPrimaryKey = true;
				colvarDid.IsForeignKey = false;
				colvarDid.IsReadOnly = false;
				colvarDid.DefaultSetting = @"";
				colvarDid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDid);
				
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
				colvarBusID.IsNullable = false;
				colvarBusID.IsPrimaryKey = false;
				colvarBusID.IsForeignKey = false;
				colvarBusID.IsReadOnly = false;
				colvarBusID.DefaultSetting = @"";
				colvarBusID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBusID);
				
				TableSchema.TableColumn colvarDName = new TableSchema.TableColumn(schema);
				colvarDName.ColumnName = "DName";
				colvarDName.DataType = DbType.AnsiString;
				colvarDName.MaxLength = 50;
				colvarDName.AutoIncrement = false;
				colvarDName.IsNullable = false;
				colvarDName.IsPrimaryKey = false;
				colvarDName.IsForeignKey = false;
				colvarDName.IsReadOnly = false;
				colvarDName.DefaultSetting = @"";
				colvarDName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDName);
				
				TableSchema.TableColumn colvarDCnic = new TableSchema.TableColumn(schema);
				colvarDCnic.ColumnName = "DCnic";
				colvarDCnic.DataType = DbType.AnsiString;
				colvarDCnic.MaxLength = 50;
				colvarDCnic.AutoIncrement = false;
				colvarDCnic.IsNullable = false;
				colvarDCnic.IsPrimaryKey = false;
				colvarDCnic.IsForeignKey = false;
				colvarDCnic.IsReadOnly = false;
				colvarDCnic.DefaultSetting = @"";
				colvarDCnic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDCnic);
				
				TableSchema.TableColumn colvarDAddress = new TableSchema.TableColumn(schema);
				colvarDAddress.ColumnName = "DAddress";
				colvarDAddress.DataType = DbType.AnsiString;
				colvarDAddress.MaxLength = -1;
				colvarDAddress.AutoIncrement = false;
				colvarDAddress.IsNullable = false;
				colvarDAddress.IsPrimaryKey = false;
				colvarDAddress.IsForeignKey = false;
				colvarDAddress.IsReadOnly = false;
				colvarDAddress.DefaultSetting = @"";
				colvarDAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDAddress);
				
				TableSchema.TableColumn colvarDMobile = new TableSchema.TableColumn(schema);
				colvarDMobile.ColumnName = "DMobile";
				colvarDMobile.DataType = DbType.AnsiString;
				colvarDMobile.MaxLength = 50;
				colvarDMobile.AutoIncrement = false;
				colvarDMobile.IsNullable = false;
				colvarDMobile.IsPrimaryKey = false;
				colvarDMobile.IsForeignKey = false;
				colvarDMobile.IsReadOnly = false;
				colvarDMobile.DefaultSetting = @"";
				colvarDMobile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDMobile);
				
				TableSchema.TableColumn colvarDPic = new TableSchema.TableColumn(schema);
				colvarDPic.ColumnName = "DPic";
				colvarDPic.DataType = DbType.AnsiString;
				colvarDPic.MaxLength = -1;
				colvarDPic.AutoIncrement = false;
				colvarDPic.IsNullable = false;
				colvarDPic.IsPrimaryKey = false;
				colvarDPic.IsForeignKey = false;
				colvarDPic.IsReadOnly = false;
				colvarDPic.DefaultSetting = @"";
				colvarDPic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDPic);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Driver",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Did")]
		[Bindable(true)]
		public int Did 
		{
			get { return GetColumnValue<int>(Columns.Did); }
			set { SetColumnValue(Columns.Did, value); }
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
		public int BusID 
		{
			get { return GetColumnValue<int>(Columns.BusID); }
			set { SetColumnValue(Columns.BusID, value); }
		}
		  
		[XmlAttribute("DName")]
		[Bindable(true)]
		public string DName 
		{
			get { return GetColumnValue<string>(Columns.DName); }
			set { SetColumnValue(Columns.DName, value); }
		}
		  
		[XmlAttribute("DCnic")]
		[Bindable(true)]
		public string DCnic 
		{
			get { return GetColumnValue<string>(Columns.DCnic); }
			set { SetColumnValue(Columns.DCnic, value); }
		}
		  
		[XmlAttribute("DAddress")]
		[Bindable(true)]
		public string DAddress 
		{
			get { return GetColumnValue<string>(Columns.DAddress); }
			set { SetColumnValue(Columns.DAddress, value); }
		}
		  
		[XmlAttribute("DMobile")]
		[Bindable(true)]
		public string DMobile 
		{
			get { return GetColumnValue<string>(Columns.DMobile); }
			set { SetColumnValue(Columns.DMobile, value); }
		}
		  
		[XmlAttribute("DPic")]
		[Bindable(true)]
		public string DPic 
		{
			get { return GetColumnValue<string>(Columns.DPic); }
			set { SetColumnValue(Columns.DPic, value); }
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
		public static void Insert(int varRouteID,int varBusID,string varDName,string varDCnic,string varDAddress,string varDMobile,string varDPic,int varIsActive)
		{
			TblDriver item = new TblDriver();
			
			item.RouteID = varRouteID;
			
			item.BusID = varBusID;
			
			item.DName = varDName;
			
			item.DCnic = varDCnic;
			
			item.DAddress = varDAddress;
			
			item.DMobile = varDMobile;
			
			item.DPic = varDPic;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varDid,int varRouteID,int varBusID,string varDName,string varDCnic,string varDAddress,string varDMobile,string varDPic,int varIsActive)
		{
			TblDriver item = new TblDriver();
			
				item.Did = varDid;
			
				item.RouteID = varRouteID;
			
				item.BusID = varBusID;
			
				item.DName = varDName;
			
				item.DCnic = varDCnic;
			
				item.DAddress = varDAddress;
			
				item.DMobile = varDMobile;
			
				item.DPic = varDPic;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn DidColumn
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
        
        
        
        public static TableSchema.TableColumn DNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DCnicColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DAddressColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DMobileColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DPicColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Did = @"DID";
			 public static string RouteID = @"RouteID";
			 public static string BusID = @"BusID";
			 public static string DName = @"DName";
			 public static string DCnic = @"DCnic";
			 public static string DAddress = @"DAddress";
			 public static string DMobile = @"DMobile";
			 public static string DPic = @"DPic";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
