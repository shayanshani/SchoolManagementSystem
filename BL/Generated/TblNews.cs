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
	/// Strongly-typed collection for the TblNews class.
	/// </summary>
    [Serializable]
	public partial class TblNewsCollection : ActiveList<TblNews, TblNewsCollection>
	{	   
		public TblNewsCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblNewsCollection</returns>
		public TblNewsCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblNews o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_News table.
	/// </summary>
	[Serializable]
	public partial class TblNews : ActiveRecord<TblNews>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblNews()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblNews(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblNews(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblNews(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_News", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNewsID = new TableSchema.TableColumn(schema);
				colvarNewsID.ColumnName = "NewsID";
				colvarNewsID.DataType = DbType.Int32;
				colvarNewsID.MaxLength = 0;
				colvarNewsID.AutoIncrement = true;
				colvarNewsID.IsNullable = false;
				colvarNewsID.IsPrimaryKey = true;
				colvarNewsID.IsForeignKey = false;
				colvarNewsID.IsReadOnly = false;
				colvarNewsID.DefaultSetting = @"";
				colvarNewsID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNewsID);
				
				TableSchema.TableColumn colvarHeading = new TableSchema.TableColumn(schema);
				colvarHeading.ColumnName = "Heading";
				colvarHeading.DataType = DbType.AnsiString;
				colvarHeading.MaxLength = -1;
				colvarHeading.AutoIncrement = false;
				colvarHeading.IsNullable = true;
				colvarHeading.IsPrimaryKey = false;
				colvarHeading.IsForeignKey = false;
				colvarHeading.IsReadOnly = false;
				colvarHeading.DefaultSetting = @"";
				colvarHeading.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHeading);
				
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
				
				TableSchema.TableColumn colvarExpiryDate = new TableSchema.TableColumn(schema);
				colvarExpiryDate.ColumnName = "ExpiryDate";
				colvarExpiryDate.DataType = DbType.DateTime;
				colvarExpiryDate.MaxLength = 0;
				colvarExpiryDate.AutoIncrement = false;
				colvarExpiryDate.IsNullable = true;
				colvarExpiryDate.IsPrimaryKey = false;
				colvarExpiryDate.IsForeignKey = false;
				colvarExpiryDate.IsReadOnly = false;
				colvarExpiryDate.DefaultSetting = @"";
				colvarExpiryDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpiryDate);
				
				TableSchema.TableColumn colvarImage = new TableSchema.TableColumn(schema);
				colvarImage.ColumnName = "Image";
				colvarImage.DataType = DbType.AnsiString;
				colvarImage.MaxLength = -1;
				colvarImage.AutoIncrement = false;
				colvarImage.IsNullable = true;
				colvarImage.IsPrimaryKey = false;
				colvarImage.IsForeignKey = false;
				colvarImage.IsReadOnly = false;
				colvarImage.DefaultSetting = @"";
				colvarImage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImage);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_News",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("NewsID")]
		[Bindable(true)]
		public int NewsID 
		{
			get { return GetColumnValue<int>(Columns.NewsID); }
			set { SetColumnValue(Columns.NewsID, value); }
		}
		  
		[XmlAttribute("Heading")]
		[Bindable(true)]
		public string Heading 
		{
			get { return GetColumnValue<string>(Columns.Heading); }
			set { SetColumnValue(Columns.Heading, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("PostedDate")]
		[Bindable(true)]
		public DateTime? PostedDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.PostedDate); }
			set { SetColumnValue(Columns.PostedDate, value); }
		}
		  
		[XmlAttribute("ExpiryDate")]
		[Bindable(true)]
		public DateTime? ExpiryDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ExpiryDate); }
			set { SetColumnValue(Columns.ExpiryDate, value); }
		}
		  
		[XmlAttribute("Image")]
		[Bindable(true)]
		public string Image 
		{
			get { return GetColumnValue<string>(Columns.Image); }
			set { SetColumnValue(Columns.Image, value); }
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
		public static void Insert(string varHeading,string varDescription,DateTime? varPostedDate,DateTime? varExpiryDate,string varImage,bool? varIsActive)
		{
			TblNews item = new TblNews();
			
			item.Heading = varHeading;
			
			item.Description = varDescription;
			
			item.PostedDate = varPostedDate;
			
			item.ExpiryDate = varExpiryDate;
			
			item.Image = varImage;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varNewsID,string varHeading,string varDescription,DateTime? varPostedDate,DateTime? varExpiryDate,string varImage,bool? varIsActive)
		{
			TblNews item = new TblNews();
			
				item.NewsID = varNewsID;
			
				item.Heading = varHeading;
			
				item.Description = varDescription;
			
				item.PostedDate = varPostedDate;
			
				item.ExpiryDate = varExpiryDate;
			
				item.Image = varImage;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn NewsIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HeadingColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PostedDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpiryDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string NewsID = @"NewsID";
			 public static string Heading = @"Heading";
			 public static string Description = @"Description";
			 public static string PostedDate = @"PostedDate";
			 public static string ExpiryDate = @"ExpiryDate";
			 public static string Image = @"Image";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
