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
	/// Strongly-typed collection for the TblClassIncharge class.
	/// </summary>
    [Serializable]
	public partial class TblClassInchargeCollection : ActiveList<TblClassIncharge, TblClassInchargeCollection>
	{	   
		public TblClassInchargeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblClassInchargeCollection</returns>
		public TblClassInchargeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblClassIncharge o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ClassIncharge table.
	/// </summary>
	[Serializable]
	public partial class TblClassIncharge : ActiveRecord<TblClassIncharge>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblClassIncharge()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblClassIncharge(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblClassIncharge(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblClassIncharge(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ClassIncharge", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSno = new TableSchema.TableColumn(schema);
				colvarSno.ColumnName = "Sno";
				colvarSno.DataType = DbType.Int32;
				colvarSno.MaxLength = 0;
				colvarSno.AutoIncrement = true;
				colvarSno.IsNullable = false;
				colvarSno.IsPrimaryKey = true;
				colvarSno.IsForeignKey = false;
				colvarSno.IsReadOnly = false;
				colvarSno.DefaultSetting = @"";
				colvarSno.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSno);
				
				TableSchema.TableColumn colvarClassID = new TableSchema.TableColumn(schema);
				colvarClassID.ColumnName = "ClassID";
				colvarClassID.DataType = DbType.Int32;
				colvarClassID.MaxLength = 0;
				colvarClassID.AutoIncrement = false;
				colvarClassID.IsNullable = true;
				colvarClassID.IsPrimaryKey = false;
				colvarClassID.IsForeignKey = false;
				colvarClassID.IsReadOnly = false;
				colvarClassID.DefaultSetting = @"";
				colvarClassID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassID);
				
				TableSchema.TableColumn colvarInchargeID = new TableSchema.TableColumn(schema);
				colvarInchargeID.ColumnName = "InchargeID";
				colvarInchargeID.DataType = DbType.Int32;
				colvarInchargeID.MaxLength = 0;
				colvarInchargeID.AutoIncrement = false;
				colvarInchargeID.IsNullable = true;
				colvarInchargeID.IsPrimaryKey = false;
				colvarInchargeID.IsForeignKey = false;
				colvarInchargeID.IsReadOnly = false;
				colvarInchargeID.DefaultSetting = @"";
				colvarInchargeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInchargeID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_ClassIncharge",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Sno")]
		[Bindable(true)]
		public int Sno 
		{
			get { return GetColumnValue<int>(Columns.Sno); }
			set { SetColumnValue(Columns.Sno, value); }
		}
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int? ClassID 
		{
			get { return GetColumnValue<int?>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("InchargeID")]
		[Bindable(true)]
		public int? InchargeID 
		{
			get { return GetColumnValue<int?>(Columns.InchargeID); }
			set { SetColumnValue(Columns.InchargeID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varClassID,int? varInchargeID)
		{
			TblClassIncharge item = new TblClassIncharge();
			
			item.ClassID = varClassID;
			
			item.InchargeID = varInchargeID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSno,int? varClassID,int? varInchargeID)
		{
			TblClassIncharge item = new TblClassIncharge();
			
				item.Sno = varSno;
			
				item.ClassID = varClassID;
			
				item.InchargeID = varInchargeID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SnoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn InchargeIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Sno = @"Sno";
			 public static string ClassID = @"ClassID";
			 public static string InchargeID = @"InchargeID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
