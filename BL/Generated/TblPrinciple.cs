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
	/// Strongly-typed collection for the TblPrinciple class.
	/// </summary>
    [Serializable]
	public partial class TblPrincipleCollection : ActiveList<TblPrinciple, TblPrincipleCollection>
	{	   
		public TblPrincipleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblPrincipleCollection</returns>
		public TblPrincipleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblPrinciple o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Principles table.
	/// </summary>
	[Serializable]
	public partial class TblPrinciple : ActiveRecord<TblPrinciple>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblPrinciple()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblPrinciple(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblPrinciple(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblPrinciple(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Principles", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPrincipalID = new TableSchema.TableColumn(schema);
				colvarPrincipalID.ColumnName = "PrincipalID";
				colvarPrincipalID.DataType = DbType.Int32;
				colvarPrincipalID.MaxLength = 0;
				colvarPrincipalID.AutoIncrement = true;
				colvarPrincipalID.IsNullable = false;
				colvarPrincipalID.IsPrimaryKey = true;
				colvarPrincipalID.IsForeignKey = false;
				colvarPrincipalID.IsReadOnly = false;
				colvarPrincipalID.DefaultSetting = @"";
				colvarPrincipalID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipalID);
				
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
				
				TableSchema.TableColumn colvarPrincipalName = new TableSchema.TableColumn(schema);
				colvarPrincipalName.ColumnName = "PrincipalName";
				colvarPrincipalName.DataType = DbType.AnsiString;
				colvarPrincipalName.MaxLength = 250;
				colvarPrincipalName.AutoIncrement = false;
				colvarPrincipalName.IsNullable = true;
				colvarPrincipalName.IsPrimaryKey = false;
				colvarPrincipalName.IsForeignKey = false;
				colvarPrincipalName.IsReadOnly = false;
				colvarPrincipalName.DefaultSetting = @"";
				colvarPrincipalName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipalName);
				
				TableSchema.TableColumn colvarPrincipalMobile = new TableSchema.TableColumn(schema);
				colvarPrincipalMobile.ColumnName = "PrincipalMobile";
				colvarPrincipalMobile.DataType = DbType.AnsiString;
				colvarPrincipalMobile.MaxLength = 250;
				colvarPrincipalMobile.AutoIncrement = false;
				colvarPrincipalMobile.IsNullable = true;
				colvarPrincipalMobile.IsPrimaryKey = false;
				colvarPrincipalMobile.IsForeignKey = false;
				colvarPrincipalMobile.IsReadOnly = false;
				colvarPrincipalMobile.DefaultSetting = @"";
				colvarPrincipalMobile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipalMobile);
				
				TableSchema.TableColumn colvarPrincipalEmail = new TableSchema.TableColumn(schema);
				colvarPrincipalEmail.ColumnName = "PrincipalEmail";
				colvarPrincipalEmail.DataType = DbType.AnsiString;
				colvarPrincipalEmail.MaxLength = 250;
				colvarPrincipalEmail.AutoIncrement = false;
				colvarPrincipalEmail.IsNullable = true;
				colvarPrincipalEmail.IsPrimaryKey = false;
				colvarPrincipalEmail.IsForeignKey = false;
				colvarPrincipalEmail.IsReadOnly = false;
				colvarPrincipalEmail.DefaultSetting = @"";
				colvarPrincipalEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipalEmail);
				
				TableSchema.TableColumn colvarPrincipleImage = new TableSchema.TableColumn(schema);
				colvarPrincipleImage.ColumnName = "PrincipleImage";
				colvarPrincipleImage.DataType = DbType.AnsiString;
				colvarPrincipleImage.MaxLength = -1;
				colvarPrincipleImage.AutoIncrement = false;
				colvarPrincipleImage.IsNullable = true;
				colvarPrincipleImage.IsPrimaryKey = false;
				colvarPrincipleImage.IsForeignKey = false;
				colvarPrincipleImage.IsReadOnly = false;
				colvarPrincipleImage.DefaultSetting = @"";
				colvarPrincipleImage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrincipleImage);
				
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
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Principles",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PrincipalID")]
		[Bindable(true)]
		public int PrincipalID 
		{
			get { return GetColumnValue<int>(Columns.PrincipalID); }
			set { SetColumnValue(Columns.PrincipalID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("PrincipalName")]
		[Bindable(true)]
		public string PrincipalName 
		{
			get { return GetColumnValue<string>(Columns.PrincipalName); }
			set { SetColumnValue(Columns.PrincipalName, value); }
		}
		  
		[XmlAttribute("PrincipalMobile")]
		[Bindable(true)]
		public string PrincipalMobile 
		{
			get { return GetColumnValue<string>(Columns.PrincipalMobile); }
			set { SetColumnValue(Columns.PrincipalMobile, value); }
		}
		  
		[XmlAttribute("PrincipalEmail")]
		[Bindable(true)]
		public string PrincipalEmail 
		{
			get { return GetColumnValue<string>(Columns.PrincipalEmail); }
			set { SetColumnValue(Columns.PrincipalEmail, value); }
		}
		  
		[XmlAttribute("PrincipleImage")]
		[Bindable(true)]
		public string PrincipleImage 
		{
			get { return GetColumnValue<string>(Columns.PrincipleImage); }
			set { SetColumnValue(Columns.PrincipleImage, value); }
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
		public static void Insert(int? varBranchID,string varPrincipalName,string varPrincipalMobile,string varPrincipalEmail,string varPrincipleImage,bool? varIsActive)
		{
			TblPrinciple item = new TblPrinciple();
			
			item.BranchID = varBranchID;
			
			item.PrincipalName = varPrincipalName;
			
			item.PrincipalMobile = varPrincipalMobile;
			
			item.PrincipalEmail = varPrincipalEmail;
			
			item.PrincipleImage = varPrincipleImage;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPrincipalID,int? varBranchID,string varPrincipalName,string varPrincipalMobile,string varPrincipalEmail,string varPrincipleImage,bool? varIsActive)
		{
			TblPrinciple item = new TblPrinciple();
			
				item.PrincipalID = varPrincipalID;
			
				item.BranchID = varBranchID;
			
				item.PrincipalName = varPrincipalName;
			
				item.PrincipalMobile = varPrincipalMobile;
			
				item.PrincipalEmail = varPrincipalEmail;
			
				item.PrincipleImage = varPrincipleImage;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PrincipalIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PrincipalNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PrincipalMobileColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PrincipalEmailColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PrincipleImageColumn
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
			 public static string PrincipalID = @"PrincipalID";
			 public static string BranchID = @"BranchID";
			 public static string PrincipalName = @"PrincipalName";
			 public static string PrincipalMobile = @"PrincipalMobile";
			 public static string PrincipalEmail = @"PrincipalEmail";
			 public static string PrincipleImage = @"PrincipleImage";
			 public static string IsActive = @"isActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
