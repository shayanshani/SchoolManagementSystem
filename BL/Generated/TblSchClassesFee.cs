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
	/// Strongly-typed collection for the TblSchClassesFee class.
	/// </summary>
    [Serializable]
	public partial class TblSchClassesFeeCollection : ActiveList<TblSchClassesFee, TblSchClassesFeeCollection>
	{	   
		public TblSchClassesFeeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblSchClassesFeeCollection</returns>
		public TblSchClassesFeeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblSchClassesFee o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_SchClassesFee table.
	/// </summary>
	[Serializable]
	public partial class TblSchClassesFee : ActiveRecord<TblSchClassesFee>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblSchClassesFee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblSchClassesFee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblSchClassesFee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblSchClassesFee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_SchClassesFee", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSchoolFeeId = new TableSchema.TableColumn(schema);
				colvarSchoolFeeId.ColumnName = "SchoolFeeId";
				colvarSchoolFeeId.DataType = DbType.Int32;
				colvarSchoolFeeId.MaxLength = 0;
				colvarSchoolFeeId.AutoIncrement = true;
				colvarSchoolFeeId.IsNullable = false;
				colvarSchoolFeeId.IsPrimaryKey = true;
				colvarSchoolFeeId.IsForeignKey = false;
				colvarSchoolFeeId.IsReadOnly = false;
				colvarSchoolFeeId.DefaultSetting = @"";
				colvarSchoolFeeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSchoolFeeId);
				
				TableSchema.TableColumn colvarClassNo = new TableSchema.TableColumn(schema);
				colvarClassNo.ColumnName = "ClassNo";
				colvarClassNo.DataType = DbType.Int32;
				colvarClassNo.MaxLength = 0;
				colvarClassNo.AutoIncrement = false;
				colvarClassNo.IsNullable = true;
				colvarClassNo.IsPrimaryKey = false;
				colvarClassNo.IsForeignKey = false;
				colvarClassNo.IsReadOnly = false;
				colvarClassNo.DefaultSetting = @"";
				colvarClassNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassNo);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_SchClassesFee",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SchoolFeeId")]
		[Bindable(true)]
		public int SchoolFeeId 
		{
			get { return GetColumnValue<int>(Columns.SchoolFeeId); }
			set { SetColumnValue(Columns.SchoolFeeId, value); }
		}
		  
		[XmlAttribute("ClassNo")]
		[Bindable(true)]
		public int? ClassNo 
		{
			get { return GetColumnValue<int?>(Columns.ClassNo); }
			set { SetColumnValue(Columns.ClassNo, value); }
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
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varClassNo,int? varAdmissionFee,int? varMothlyFee)
		{
			TblSchClassesFee item = new TblSchClassesFee();
			
			item.ClassNo = varClassNo;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.MothlyFee = varMothlyFee;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSchoolFeeId,int? varClassNo,int? varAdmissionFee,int? varMothlyFee)
		{
			TblSchClassesFee item = new TblSchClassesFee();
			
				item.SchoolFeeId = varSchoolFeeId;
			
				item.ClassNo = varClassNo;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.MothlyFee = varMothlyFee;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SchoolFeeIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MothlyFeeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SchoolFeeId = @"SchoolFeeId";
			 public static string ClassNo = @"ClassNo";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string MothlyFee = @"MothlyFee";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
