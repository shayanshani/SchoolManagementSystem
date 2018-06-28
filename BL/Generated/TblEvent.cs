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
	/// Strongly-typed collection for the TblEvent class.
	/// </summary>
    [Serializable]
	public partial class TblEventCollection : ActiveList<TblEvent, TblEventCollection>
	{	   
		public TblEventCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblEventCollection</returns>
		public TblEventCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblEvent o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Events table.
	/// </summary>
	[Serializable]
	public partial class TblEvent : ActiveRecord<TblEvent>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblEvent()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblEvent(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblEvent(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblEvent(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Events", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarEventID = new TableSchema.TableColumn(schema);
				colvarEventID.ColumnName = "EventID";
				colvarEventID.DataType = DbType.Int32;
				colvarEventID.MaxLength = 0;
				colvarEventID.AutoIncrement = true;
				colvarEventID.IsNullable = false;
				colvarEventID.IsPrimaryKey = true;
				colvarEventID.IsForeignKey = false;
				colvarEventID.IsReadOnly = false;
				colvarEventID.DefaultSetting = @"";
				colvarEventID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventID);
				
				TableSchema.TableColumn colvarEventHeading = new TableSchema.TableColumn(schema);
				colvarEventHeading.ColumnName = "EventHeading";
				colvarEventHeading.DataType = DbType.AnsiString;
				colvarEventHeading.MaxLength = -1;
				colvarEventHeading.AutoIncrement = false;
				colvarEventHeading.IsNullable = true;
				colvarEventHeading.IsPrimaryKey = false;
				colvarEventHeading.IsForeignKey = false;
				colvarEventHeading.IsReadOnly = false;
				colvarEventHeading.DefaultSetting = @"";
				colvarEventHeading.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventHeading);
				
				TableSchema.TableColumn colvarEventDetail = new TableSchema.TableColumn(schema);
				colvarEventDetail.ColumnName = "EventDetail";
				colvarEventDetail.DataType = DbType.AnsiString;
				colvarEventDetail.MaxLength = -1;
				colvarEventDetail.AutoIncrement = false;
				colvarEventDetail.IsNullable = true;
				colvarEventDetail.IsPrimaryKey = false;
				colvarEventDetail.IsForeignKey = false;
				colvarEventDetail.IsReadOnly = false;
				colvarEventDetail.DefaultSetting = @"";
				colvarEventDetail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventDetail);
				
				TableSchema.TableColumn colvarEventDate = new TableSchema.TableColumn(schema);
				colvarEventDate.ColumnName = "EventDate";
				colvarEventDate.DataType = DbType.DateTime;
				colvarEventDate.MaxLength = 0;
				colvarEventDate.AutoIncrement = false;
				colvarEventDate.IsNullable = true;
				colvarEventDate.IsPrimaryKey = false;
				colvarEventDate.IsForeignKey = false;
				colvarEventDate.IsReadOnly = false;
				colvarEventDate.DefaultSetting = @"";
				colvarEventDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventDate);
				
				TableSchema.TableColumn colvarFromTime = new TableSchema.TableColumn(schema);
				colvarFromTime.ColumnName = "FromTime";
				colvarFromTime.DataType = DbType.DateTime;
				colvarFromTime.MaxLength = 0;
				colvarFromTime.AutoIncrement = false;
				colvarFromTime.IsNullable = true;
				colvarFromTime.IsPrimaryKey = false;
				colvarFromTime.IsForeignKey = false;
				colvarFromTime.IsReadOnly = false;
				colvarFromTime.DefaultSetting = @"";
				colvarFromTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFromTime);
				
				TableSchema.TableColumn colvarToTime = new TableSchema.TableColumn(schema);
				colvarToTime.ColumnName = "ToTime";
				colvarToTime.DataType = DbType.DateTime;
				colvarToTime.MaxLength = 0;
				colvarToTime.AutoIncrement = false;
				colvarToTime.IsNullable = true;
				colvarToTime.IsPrimaryKey = false;
				colvarToTime.IsForeignKey = false;
				colvarToTime.IsReadOnly = false;
				colvarToTime.DefaultSetting = @"";
				colvarToTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarToTime);
				
				TableSchema.TableColumn colvarVenue = new TableSchema.TableColumn(schema);
				colvarVenue.ColumnName = "Venue";
				colvarVenue.DataType = DbType.AnsiString;
				colvarVenue.MaxLength = -1;
				colvarVenue.AutoIncrement = false;
				colvarVenue.IsNullable = true;
				colvarVenue.IsPrimaryKey = false;
				colvarVenue.IsForeignKey = false;
				colvarVenue.IsReadOnly = false;
				colvarVenue.DefaultSetting = @"";
				colvarVenue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVenue);
				
				TableSchema.TableColumn colvarPostedDate = new TableSchema.TableColumn(schema);
				colvarPostedDate.ColumnName = "PostedDate";
				colvarPostedDate.DataType = DbType.DateTime;
				colvarPostedDate.MaxLength = 0;
				colvarPostedDate.AutoIncrement = false;
				colvarPostedDate.IsNullable = true;
				colvarPostedDate.IsPrimaryKey = false;
				colvarPostedDate.IsForeignKey = false;
				colvarPostedDate.IsReadOnly = false;
				colvarPostedDate.DefaultSetting = @"";
				colvarPostedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPostedDate);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "isActive";
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Events",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("EventID")]
		[Bindable(true)]
		public int EventID 
		{
			get { return GetColumnValue<int>(Columns.EventID); }
			set { SetColumnValue(Columns.EventID, value); }
		}
		  
		[XmlAttribute("EventHeading")]
		[Bindable(true)]
		public string EventHeading 
		{
			get { return GetColumnValue<string>(Columns.EventHeading); }
			set { SetColumnValue(Columns.EventHeading, value); }
		}
		  
		[XmlAttribute("EventDetail")]
		[Bindable(true)]
		public string EventDetail 
		{
			get { return GetColumnValue<string>(Columns.EventDetail); }
			set { SetColumnValue(Columns.EventDetail, value); }
		}
		  
		[XmlAttribute("EventDate")]
		[Bindable(true)]
		public DateTime? EventDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EventDate); }
			set { SetColumnValue(Columns.EventDate, value); }
		}
		  
		[XmlAttribute("FromTime")]
		[Bindable(true)]
		public DateTime? FromTime 
		{
			get { return GetColumnValue<DateTime?>(Columns.FromTime); }
			set { SetColumnValue(Columns.FromTime, value); }
		}
		  
		[XmlAttribute("ToTime")]
		[Bindable(true)]
		public DateTime? ToTime 
		{
			get { return GetColumnValue<DateTime?>(Columns.ToTime); }
			set { SetColumnValue(Columns.ToTime, value); }
		}
		  
		[XmlAttribute("Venue")]
		[Bindable(true)]
		public string Venue 
		{
			get { return GetColumnValue<string>(Columns.Venue); }
			set { SetColumnValue(Columns.Venue, value); }
		}
		  
		[XmlAttribute("PostedDate")]
		[Bindable(true)]
		public DateTime? PostedDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.PostedDate); }
			set { SetColumnValue(Columns.PostedDate, value); }
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
		public static void Insert(string varEventHeading,string varEventDetail,DateTime? varEventDate,DateTime? varFromTime,DateTime? varToTime,string varVenue,DateTime? varPostedDate,bool? varIsActive)
		{
			TblEvent item = new TblEvent();
			
			item.EventHeading = varEventHeading;
			
			item.EventDetail = varEventDetail;
			
			item.EventDate = varEventDate;
			
			item.FromTime = varFromTime;
			
			item.ToTime = varToTime;
			
			item.Venue = varVenue;
			
			item.PostedDate = varPostedDate;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEventID,string varEventHeading,string varEventDetail,DateTime? varEventDate,DateTime? varFromTime,DateTime? varToTime,string varVenue,DateTime? varPostedDate,bool? varIsActive)
		{
			TblEvent item = new TblEvent();
			
				item.EventID = varEventID;
			
				item.EventHeading = varEventHeading;
			
				item.EventDetail = varEventDetail;
			
				item.EventDate = varEventDate;
			
				item.FromTime = varFromTime;
			
				item.ToTime = varToTime;
			
				item.Venue = varVenue;
			
				item.PostedDate = varPostedDate;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn EventIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EventHeadingColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EventDetailColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EventDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FromTimeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ToTimeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn VenueColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PostedDateColumn
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
			 public static string EventID = @"EventID";
			 public static string EventHeading = @"EventHeading";
			 public static string EventDetail = @"EventDetail";
			 public static string EventDate = @"EventDate";
			 public static string FromTime = @"FromTime";
			 public static string ToTime = @"ToTime";
			 public static string Venue = @"Venue";
			 public static string PostedDate = @"PostedDate";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
