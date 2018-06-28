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
	/// Strongly-typed collection for the TblProgramFee class.
	/// </summary>
    [Serializable]
	public partial class TblProgramFeeCollection : ActiveList<TblProgramFee, TblProgramFeeCollection>
	{	   
		public TblProgramFeeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblProgramFeeCollection</returns>
		public TblProgramFeeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblProgramFee o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ProgramFee table.
	/// </summary>
	[Serializable]
	public partial class TblProgramFee : ActiveRecord<TblProgramFee>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblProgramFee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblProgramFee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblProgramFee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblProgramFee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ProgramFee", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSsid = new TableSchema.TableColumn(schema);
				colvarSsid.ColumnName = "SSID";
				colvarSsid.DataType = DbType.Int32;
				colvarSsid.MaxLength = 0;
				colvarSsid.AutoIncrement = true;
				colvarSsid.IsNullable = false;
				colvarSsid.IsPrimaryKey = true;
				colvarSsid.IsForeignKey = false;
				colvarSsid.IsReadOnly = false;
				colvarSsid.DefaultSetting = @"";
				colvarSsid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSsid);
				
				TableSchema.TableColumn colvarProgram = new TableSchema.TableColumn(schema);
				colvarProgram.ColumnName = "Program";
				colvarProgram.DataType = DbType.AnsiString;
				colvarProgram.MaxLength = 50;
				colvarProgram.AutoIncrement = false;
				colvarProgram.IsNullable = true;
				colvarProgram.IsPrimaryKey = false;
				colvarProgram.IsForeignKey = false;
				colvarProgram.IsReadOnly = false;
				colvarProgram.DefaultSetting = @"";
				colvarProgram.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProgram);
				
				TableSchema.TableColumn colvarTotalFee = new TableSchema.TableColumn(schema);
				colvarTotalFee.ColumnName = "TotalFee";
				colvarTotalFee.DataType = DbType.Int32;
				colvarTotalFee.MaxLength = 0;
				colvarTotalFee.AutoIncrement = false;
				colvarTotalFee.IsNullable = true;
				colvarTotalFee.IsPrimaryKey = false;
				colvarTotalFee.IsForeignKey = false;
				colvarTotalFee.IsReadOnly = false;
				colvarTotalFee.DefaultSetting = @"";
				colvarTotalFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalFee);
				
				TableSchema.TableColumn colvarMise = new TableSchema.TableColumn(schema);
				colvarMise.ColumnName = "Mise";
				colvarMise.DataType = DbType.Int32;
				colvarMise.MaxLength = 0;
				colvarMise.AutoIncrement = false;
				colvarMise.IsNullable = true;
				colvarMise.IsPrimaryKey = false;
				colvarMise.IsForeignKey = false;
				colvarMise.IsReadOnly = false;
				colvarMise.DefaultSetting = @"";
				colvarMise.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMise);
				
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
				
				TableSchema.TableColumn colvarTuitionFee = new TableSchema.TableColumn(schema);
				colvarTuitionFee.ColumnName = "TuitionFee";
				colvarTuitionFee.DataType = DbType.Int32;
				colvarTuitionFee.MaxLength = 0;
				colvarTuitionFee.AutoIncrement = false;
				colvarTuitionFee.IsNullable = true;
				colvarTuitionFee.IsPrimaryKey = false;
				colvarTuitionFee.IsForeignKey = false;
				colvarTuitionFee.IsReadOnly = false;
				colvarTuitionFee.DefaultSetting = @"";
				colvarTuitionFee.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTuitionFee);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ProgramFee",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Ssid")]
		[Bindable(true)]
		public int Ssid 
		{
			get { return GetColumnValue<int>(Columns.Ssid); }
			set { SetColumnValue(Columns.Ssid, value); }
		}
		  
		[XmlAttribute("Program")]
		[Bindable(true)]
		public string Program 
		{
			get { return GetColumnValue<string>(Columns.Program); }
			set { SetColumnValue(Columns.Program, value); }
		}
		  
		[XmlAttribute("TotalFee")]
		[Bindable(true)]
		public int? TotalFee 
		{
			get { return GetColumnValue<int?>(Columns.TotalFee); }
			set { SetColumnValue(Columns.TotalFee, value); }
		}
		  
		[XmlAttribute("Mise")]
		[Bindable(true)]
		public int? Mise 
		{
			get { return GetColumnValue<int?>(Columns.Mise); }
			set { SetColumnValue(Columns.Mise, value); }
		}
		  
		[XmlAttribute("AdmissionFee")]
		[Bindable(true)]
		public int? AdmissionFee 
		{
			get { return GetColumnValue<int?>(Columns.AdmissionFee); }
			set { SetColumnValue(Columns.AdmissionFee, value); }
		}
		  
		[XmlAttribute("TuitionFee")]
		[Bindable(true)]
		public int? TuitionFee 
		{
			get { return GetColumnValue<int?>(Columns.TuitionFee); }
			set { SetColumnValue(Columns.TuitionFee, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varProgram,int? varTotalFee,int? varMise,int? varAdmissionFee,int? varTuitionFee)
		{
			TblProgramFee item = new TblProgramFee();
			
			item.Program = varProgram;
			
			item.TotalFee = varTotalFee;
			
			item.Mise = varMise;
			
			item.AdmissionFee = varAdmissionFee;
			
			item.TuitionFee = varTuitionFee;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSsid,string varProgram,int? varTotalFee,int? varMise,int? varAdmissionFee,int? varTuitionFee)
		{
			TblProgramFee item = new TblProgramFee();
			
				item.Ssid = varSsid;
			
				item.Program = varProgram;
			
				item.TotalFee = varTotalFee;
			
				item.Mise = varMise;
			
				item.AdmissionFee = varAdmissionFee;
			
				item.TuitionFee = varTuitionFee;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SsidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProgramColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalFeeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MiseColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AdmissionFeeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TuitionFeeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Ssid = @"SSID";
			 public static string Program = @"Program";
			 public static string TotalFee = @"TotalFee";
			 public static string Mise = @"Mise";
			 public static string AdmissionFee = @"AdmissionFee";
			 public static string TuitionFee = @"TuitionFee";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
