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
	/// Strongly-typed collection for the TblClassInformation class.
	/// </summary>
    [Serializable]
	public partial class TblClassInformationCollection : ActiveList<TblClassInformation, TblClassInformationCollection>
	{	   
		public TblClassInformationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblClassInformationCollection</returns>
		public TblClassInformationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblClassInformation o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ClassInformation table.
	/// </summary>
	[Serializable]
	public partial class TblClassInformation : ActiveRecord<TblClassInformation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblClassInformation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblClassInformation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblClassInformation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblClassInformation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ClassInformation", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarClassNo = new TableSchema.TableColumn(schema);
				colvarClassNo.ColumnName = "ClassNo";
				colvarClassNo.DataType = DbType.Int32;
				colvarClassNo.MaxLength = 0;
				colvarClassNo.AutoIncrement = true;
				colvarClassNo.IsNullable = false;
				colvarClassNo.IsPrimaryKey = true;
				colvarClassNo.IsForeignKey = false;
				colvarClassNo.IsReadOnly = false;
				colvarClassNo.DefaultSetting = @"";
				colvarClassNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassNo);
				
				TableSchema.TableColumn colvarClassName = new TableSchema.TableColumn(schema);
				colvarClassName.ColumnName = "ClassName";
				colvarClassName.DataType = DbType.AnsiString;
				colvarClassName.MaxLength = 50;
				colvarClassName.AutoIncrement = false;
				colvarClassName.IsNullable = true;
				colvarClassName.IsPrimaryKey = false;
				colvarClassName.IsForeignKey = false;
				colvarClassName.IsReadOnly = false;
				colvarClassName.DefaultSetting = @"";
				colvarClassName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassName);
				
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
				
				TableSchema.TableColumn colvarLevelID = new TableSchema.TableColumn(schema);
				colvarLevelID.ColumnName = "LevelID";
				colvarLevelID.DataType = DbType.Int32;
				colvarLevelID.MaxLength = 0;
				colvarLevelID.AutoIncrement = false;
				colvarLevelID.IsNullable = true;
				colvarLevelID.IsPrimaryKey = false;
				colvarLevelID.IsForeignKey = false;
				colvarLevelID.IsReadOnly = false;
				colvarLevelID.DefaultSetting = @"";
				colvarLevelID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLevelID);
				
				TableSchema.TableColumn colvarAdmissionFee = new TableSchema.TableColumn(schema);
				colvarAdmissionFee.ColumnName = "AdmissionFee";
				colvarAdmissionFee.DataType = DbType.Int32;
				colvarAdmissionFee.MaxLength = 0;
				colvarAdmissionFee.AutoIncrement = false;
				colvarAdmissionFee.IsNullable = true;
				colvarAdmissionFee.IsPrimaryKey = false;
				colvarAdmissionFee.IsForeignKey = false;
				colvarAdmissionFee.IsReadOnly = false;
				colvarAdmissionFee.DefaultSetting = @"";
				colvarAdmissionFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdmissionFee);
				
				TableSchema.TableColumn colvarMothlyFee = new TableSchema.TableColumn(schema);
				colvarMothlyFee.ColumnName = "MothlyFee";
				colvarMothlyFee.DataType = DbType.Int32;
				colvarMothlyFee.MaxLength = 0;
				colvarMothlyFee.AutoIncrement = false;
				colvarMothlyFee.IsNullable = true;
				colvarMothlyFee.IsPrimaryKey = false;
				colvarMothlyFee.IsForeignKey = false;
				colvarMothlyFee.IsReadOnly = false;
				colvarMothlyFee.DefaultSetting = @"";
				colvarMothlyFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMothlyFee);
				
				TableSchema.TableColumn colvarCreateBy = new TableSchema.TableColumn(schema);
				colvarCreateBy.ColumnName = "CreateBy";
				colvarCreateBy.DataType = DbType.AnsiString;
				colvarCreateBy.MaxLength = 50;
				colvarCreateBy.AutoIncrement = false;
				colvarCreateBy.IsNullable = true;
				colvarCreateBy.IsPrimaryKey = false;
				colvarCreateBy.IsForeignKey = false;
				colvarCreateBy.IsReadOnly = false;
				colvarCreateBy.DefaultSetting = @"";
				colvarCreateBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreateBy);
				
				TableSchema.TableColumn colvarUpdatedBy = new TableSchema.TableColumn(schema);
				colvarUpdatedBy.ColumnName = "UpdatedBy";
				colvarUpdatedBy.DataType = DbType.AnsiString;
				colvarUpdatedBy.MaxLength = 50;
				colvarUpdatedBy.AutoIncrement = false;
				colvarUpdatedBy.IsNullable = true;
				colvarUpdatedBy.IsPrimaryKey = false;
				colvarUpdatedBy.IsForeignKey = false;
				colvarUpdatedBy.IsReadOnly = false;
				colvarUpdatedBy.DefaultSetting = @"";
				colvarUpdatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedBy);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ClassInformation",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ClassNo")]
		[Bindable(true)]
		public int ClassNo 
		{
			get { return GetColumnValue<int>(Columns.ClassNo); }
			set { SetColumnValue(Columns.ClassNo, value); }
		}
		  
		[XmlAttribute("ClassName")]
		[Bindable(true)]
		public string ClassName 
		{
			get { return GetColumnValue<string>(Columns.ClassName); }
			set { SetColumnValue(Columns.ClassName, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("LevelID")]
		[Bindable(true)]
		public int? LevelID 
		{
			get { return GetColumnValue<int?>(Columns.LevelID); }
			set { SetColumnValue(Columns.LevelID, value); }
		}
		  
		[XmlAttribute("AdmissionFee")]
		[Bindable(true)]
		public int? AdmissionFee 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionFee); }
			set { SetColumnValue(Columns.AdmissionFee, value); }
		}
		  
		[XmlAttribute("MothlyFee")]
		[Bindable(true)]
		public int? MothlyFee 
		{
			get { return GetColumnValue<int?>(Columns.MothlyFee); }
			set { SetColumnValue(Columns.MothlyFee, value); }
		}
		  
		[XmlAttribute("CreateBy")]
		[Bindable(true)]
		public string CreateBy 
		{
			get { return GetColumnValue<string>(Columns.CreateBy); }
			set { SetColumnValue(Columns.CreateBy, value); }
		}
		  
		[XmlAttribute("UpdatedBy")]
		[Bindable(true)]
		public string UpdatedBy 
		{
			get { return GetColumnValue<string>(Columns.UpdatedBy); }
			set { SetColumnValue(Columns.UpdatedBy, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varClassName,int? varBranchID,int? varLevelID,int? varAdmissionFee,int? varMothlyFee,string varCreateBy,string varUpdatedBy)
		{
			TblClassInformation item = new TblClassInformation();
			
			item.ClassName = varClassName;
			
			item.BranchID = varBranchID;
			
			item.LevelID = varLevelID;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.MothlyFee = varMothlyFee;
			
			item.CreateBy = varCreateBy;
			
			item.UpdatedBy = varUpdatedBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varClassNo,string varClassName,int? varBranchID,int? varLevelID,int? varAdmissionFee,int? varMothlyFee,string varCreateBy,string varUpdatedBy)
		{
			TblClassInformation item = new TblClassInformation();
			
				item.ClassNo = varClassNo;
			
				item.ClassName = varClassName;
			
				item.BranchID = varBranchID;
			
				item.LevelID = varLevelID;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.MothlyFee = varMothlyFee;
			
				item.CreateBy = varCreateBy;
			
				item.UpdatedBy = varUpdatedBy;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ClassNoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn MothlyFeeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ClassNo = @"ClassNo";
			 public static string ClassName = @"ClassName";
			 public static string BranchID = @"BranchID";
			 public static string LevelID = @"LevelID";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string MothlyFee = @"MothlyFee";
			 public static string CreateBy = @"CreateBy";
			 public static string UpdatedBy = @"UpdatedBy";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
