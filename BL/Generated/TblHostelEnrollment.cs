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
	/// Strongly-typed collection for the TblHostelEnrollment class.
	/// </summary>
    [Serializable]
	public partial class TblHostelEnrollmentCollection : ActiveList<TblHostelEnrollment, TblHostelEnrollmentCollection>
	{	   
		public TblHostelEnrollmentCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblHostelEnrollmentCollection</returns>
		public TblHostelEnrollmentCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblHostelEnrollment o = this[i];
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
	/// This is an ActiveRecord class which wraps the TblHostelEnrollment table.
	/// </summary>
	[Serializable]
	public partial class TblHostelEnrollment : ActiveRecord<TblHostelEnrollment>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblHostelEnrollment()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblHostelEnrollment(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblHostelEnrollment(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblHostelEnrollment(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TblHostelEnrollment", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarHEnrollID = new TableSchema.TableColumn(schema);
				colvarHEnrollID.ColumnName = "HEnrollID";
				colvarHEnrollID.DataType = DbType.Int32;
				colvarHEnrollID.MaxLength = 0;
				colvarHEnrollID.AutoIncrement = true;
				colvarHEnrollID.IsNullable = false;
				colvarHEnrollID.IsPrimaryKey = true;
				colvarHEnrollID.IsForeignKey = false;
				colvarHEnrollID.IsReadOnly = false;
				colvarHEnrollID.DefaultSetting = @"";
				colvarHEnrollID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHEnrollID);
				
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
				
				TableSchema.TableColumn colvarHostelID = new TableSchema.TableColumn(schema);
				colvarHostelID.ColumnName = "HostelID";
				colvarHostelID.DataType = DbType.Int32;
				colvarHostelID.MaxLength = 0;
				colvarHostelID.AutoIncrement = false;
				colvarHostelID.IsNullable = true;
				colvarHostelID.IsPrimaryKey = false;
				colvarHostelID.IsForeignKey = false;
				colvarHostelID.IsReadOnly = false;
				colvarHostelID.DefaultSetting = @"";
				colvarHostelID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostelID);
				
				TableSchema.TableColumn colvarHAdmissionDate = new TableSchema.TableColumn(schema);
				colvarHAdmissionDate.ColumnName = "HAdmissionDate";
				colvarHAdmissionDate.DataType = DbType.DateTime;
				colvarHAdmissionDate.MaxLength = 0;
				colvarHAdmissionDate.AutoIncrement = false;
				colvarHAdmissionDate.IsNullable = true;
				colvarHAdmissionDate.IsPrimaryKey = false;
				colvarHAdmissionDate.IsForeignKey = false;
				colvarHAdmissionDate.IsReadOnly = false;
				colvarHAdmissionDate.DefaultSetting = @"";
				colvarHAdmissionDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHAdmissionDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("TblHostelEnrollment",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("HEnrollID")]
		[Bindable(true)]
		public int HEnrollID 
		{
			get { return GetColumnValue<int>(Columns.HEnrollID); }
			set { SetColumnValue(Columns.HEnrollID, value); }
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
		  
		[XmlAttribute("HostelID")]
		[Bindable(true)]
		public int? HostelID 
		{
			get { return GetColumnValue<int?>(Columns.HostelID); }
			set { SetColumnValue(Columns.HostelID, value); }
		}
		  
		[XmlAttribute("HAdmissionDate")]
		[Bindable(true)]
		public DateTime? HAdmissionDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.HAdmissionDate); }
			set { SetColumnValue(Columns.HAdmissionDate, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varMemberID,bool? varMemberType,int? varHostelID,DateTime? varHAdmissionDate)
		{
			TblHostelEnrollment item = new TblHostelEnrollment();
			
			item.MemberID = varMemberID;
			
			item.MemberType = varMemberType;
			
			item.HostelID = varHostelID;
			
			item.HAdmissionDate = varHAdmissionDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHEnrollID,int? varMemberID,bool? varMemberType,int? varHostelID,DateTime? varHAdmissionDate)
		{
			TblHostelEnrollment item = new TblHostelEnrollment();
			
				item.HEnrollID = varHEnrollID;
			
				item.MemberID = varMemberID;
			
				item.MemberType = varMemberType;
			
				item.HostelID = varHostelID;
			
				item.HAdmissionDate = varHAdmissionDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HEnrollIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn MemberIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MemberTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HostelIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HAdmissionDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string HEnrollID = @"HEnrollID";
			 public static string MemberID = @"MemberID";
			 public static string MemberType = @"MemberType";
			 public static string HostelID = @"HostelID";
			 public static string HAdmissionDate = @"HAdmissionDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
