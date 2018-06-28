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
	/// Strongly-typed collection for the TblEmployee class.
	/// </summary>
    [Serializable]
	public partial class TblEmployeeCollection : ActiveList<TblEmployee, TblEmployeeCollection>
	{	   
		public TblEmployeeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblEmployeeCollection</returns>
		public TblEmployeeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblEmployee o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_Employees table.
	/// </summary>
	[Serializable]
	public partial class TblEmployee : ActiveRecord<TblEmployee>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblEmployee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblEmployee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblEmployee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblEmployee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_Employees", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = true;
				colvarEmployeeID.IsNullable = false;
				colvarEmployeeID.IsPrimaryKey = true;
				colvarEmployeeID.IsForeignKey = false;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				colvarEmployeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmployeeID);
				
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
				
				TableSchema.TableColumn colvarEmployeeName = new TableSchema.TableColumn(schema);
				colvarEmployeeName.ColumnName = "EmployeeName";
				colvarEmployeeName.DataType = DbType.AnsiString;
				colvarEmployeeName.MaxLength = 50;
				colvarEmployeeName.AutoIncrement = false;
				colvarEmployeeName.IsNullable = true;
				colvarEmployeeName.IsPrimaryKey = false;
				colvarEmployeeName.IsForeignKey = false;
				colvarEmployeeName.IsReadOnly = false;
				colvarEmployeeName.DefaultSetting = @"";
				colvarEmployeeName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmployeeName);
				
				TableSchema.TableColumn colvarFatherName = new TableSchema.TableColumn(schema);
				colvarFatherName.ColumnName = "FatherName";
				colvarFatherName.DataType = DbType.AnsiString;
				colvarFatherName.MaxLength = 50;
				colvarFatherName.AutoIncrement = false;
				colvarFatherName.IsNullable = true;
				colvarFatherName.IsPrimaryKey = false;
				colvarFatherName.IsForeignKey = false;
				colvarFatherName.IsReadOnly = false;
				colvarFatherName.DefaultSetting = @"";
				colvarFatherName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFatherName);
				
				TableSchema.TableColumn colvarCnic = new TableSchema.TableColumn(schema);
				colvarCnic.ColumnName = "CNIC";
				colvarCnic.DataType = DbType.AnsiString;
				colvarCnic.MaxLength = 50;
				colvarCnic.AutoIncrement = false;
				colvarCnic.IsNullable = true;
				colvarCnic.IsPrimaryKey = false;
				colvarCnic.IsForeignKey = false;
				colvarCnic.IsReadOnly = false;
				colvarCnic.DefaultSetting = @"";
				colvarCnic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCnic);
				
				TableSchema.TableColumn colvarContactNo = new TableSchema.TableColumn(schema);
				colvarContactNo.ColumnName = "ContactNo";
				colvarContactNo.DataType = DbType.AnsiString;
				colvarContactNo.MaxLength = 50;
				colvarContactNo.AutoIncrement = false;
				colvarContactNo.IsNullable = true;
				colvarContactNo.IsPrimaryKey = false;
				colvarContactNo.IsForeignKey = false;
				colvarContactNo.IsReadOnly = false;
				colvarContactNo.DefaultSetting = @"";
				colvarContactNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactNo);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.AnsiString;
				colvarAddress.MaxLength = 150;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarQualification = new TableSchema.TableColumn(schema);
				colvarQualification.ColumnName = "Qualification";
				colvarQualification.DataType = DbType.AnsiString;
				colvarQualification.MaxLength = 500;
				colvarQualification.AutoIncrement = false;
				colvarQualification.IsNullable = true;
				colvarQualification.IsPrimaryKey = false;
				colvarQualification.IsForeignKey = false;
				colvarQualification.IsReadOnly = false;
				colvarQualification.DefaultSetting = @"";
				colvarQualification.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQualification);
				
				TableSchema.TableColumn colvarDob = new TableSchema.TableColumn(schema);
				colvarDob.ColumnName = "DOB";
				colvarDob.DataType = DbType.AnsiString;
				colvarDob.MaxLength = 0;
				colvarDob.AutoIncrement = false;
				colvarDob.IsNullable = true;
				colvarDob.IsPrimaryKey = false;
				colvarDob.IsForeignKey = false;
				colvarDob.IsReadOnly = false;
				colvarDob.DefaultSetting = @"";
				colvarDob.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDob);
				
				TableSchema.TableColumn colvarDoj = new TableSchema.TableColumn(schema);
				colvarDoj.ColumnName = "DOJ";
				colvarDoj.DataType = DbType.AnsiString;
				colvarDoj.MaxLength = 0;
				colvarDoj.AutoIncrement = false;
				colvarDoj.IsNullable = true;
				colvarDoj.IsPrimaryKey = false;
				colvarDoj.IsForeignKey = false;
				colvarDoj.IsReadOnly = false;
				colvarDoj.DefaultSetting = @"";
				colvarDoj.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDoj);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
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
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarUpdated = new TableSchema.TableColumn(schema);
				colvarUpdated.ColumnName = "Updated";
				colvarUpdated.DataType = DbType.AnsiString;
				colvarUpdated.MaxLength = 50;
				colvarUpdated.AutoIncrement = false;
				colvarUpdated.IsNullable = true;
				colvarUpdated.IsPrimaryKey = false;
				colvarUpdated.IsForeignKey = false;
				colvarUpdated.IsReadOnly = false;
				colvarUpdated.DefaultSetting = @"";
				colvarUpdated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdated);
				
				TableSchema.TableColumn colvarPic = new TableSchema.TableColumn(schema);
				colvarPic.ColumnName = "Pic";
				colvarPic.DataType = DbType.AnsiString;
				colvarPic.MaxLength = 50;
				colvarPic.AutoIncrement = false;
				colvarPic.IsNullable = true;
				colvarPic.IsPrimaryKey = false;
				colvarPic.IsForeignKey = false;
				colvarPic.IsReadOnly = false;
				colvarPic.DefaultSetting = @"";
				colvarPic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPic);
				
				TableSchema.TableColumn colvarDesignationID = new TableSchema.TableColumn(schema);
				colvarDesignationID.ColumnName = "DesignationID";
				colvarDesignationID.DataType = DbType.Int32;
				colvarDesignationID.MaxLength = 0;
				colvarDesignationID.AutoIncrement = false;
				colvarDesignationID.IsNullable = true;
				colvarDesignationID.IsPrimaryKey = false;
				colvarDesignationID.IsForeignKey = false;
				colvarDesignationID.IsReadOnly = false;
				colvarDesignationID.DefaultSetting = @"";
				colvarDesignationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDesignationID);
				
				TableSchema.TableColumn colvarGender = new TableSchema.TableColumn(schema);
				colvarGender.ColumnName = "Gender";
				colvarGender.DataType = DbType.AnsiString;
				colvarGender.MaxLength = 50;
				colvarGender.AutoIncrement = false;
				colvarGender.IsNullable = true;
				colvarGender.IsPrimaryKey = false;
				colvarGender.IsForeignKey = false;
				colvarGender.IsReadOnly = false;
				colvarGender.DefaultSetting = @"";
				colvarGender.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGender);
				
				TableSchema.TableColumn colvarIsTransport = new TableSchema.TableColumn(schema);
				colvarIsTransport.ColumnName = "IsTransport";
				colvarIsTransport.DataType = DbType.Boolean;
				colvarIsTransport.MaxLength = 0;
				colvarIsTransport.AutoIncrement = false;
				colvarIsTransport.IsNullable = true;
				colvarIsTransport.IsPrimaryKey = false;
				colvarIsTransport.IsForeignKey = false;
				colvarIsTransport.IsReadOnly = false;
				colvarIsTransport.DefaultSetting = @"";
				colvarIsTransport.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsTransport);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("tbl_Employees",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("EmployeeID")]
		[Bindable(true)]
		public int EmployeeID 
		{
			get { return GetColumnValue<int>(Columns.EmployeeID); }
			set { SetColumnValue(Columns.EmployeeID, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("EmployeeName")]
		[Bindable(true)]
		public string EmployeeName 
		{
			get { return GetColumnValue<string>(Columns.EmployeeName); }
			set { SetColumnValue(Columns.EmployeeName, value); }
		}
		  
		[XmlAttribute("FatherName")]
		[Bindable(true)]
		public string FatherName 
		{
			get { return GetColumnValue<string>(Columns.FatherName); }
			set { SetColumnValue(Columns.FatherName, value); }
		}
		  
		[XmlAttribute("Cnic")]
		[Bindable(true)]
		public string Cnic 
		{
			get { return GetColumnValue<string>(Columns.Cnic); }
			set { SetColumnValue(Columns.Cnic, value); }
		}
		  
		[XmlAttribute("ContactNo")]
		[Bindable(true)]
		public string ContactNo 
		{
			get { return GetColumnValue<string>(Columns.ContactNo); }
			set { SetColumnValue(Columns.ContactNo, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("Qualification")]
		[Bindable(true)]
		public string Qualification 
		{
			get { return GetColumnValue<string>(Columns.Qualification); }
			set { SetColumnValue(Columns.Qualification, value); }
		}
		  
		[XmlAttribute("Dob")]
		[Bindable(true)]
		public string Dob 
		{
			get { return GetColumnValue<string>(Columns.Dob); }
			set { SetColumnValue(Columns.Dob, value); }
		}
		  
		[XmlAttribute("Doj")]
		[Bindable(true)]
		public string Doj 
		{
			get { return GetColumnValue<string>(Columns.Doj); }
			set { SetColumnValue(Columns.Doj, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("Updated")]
		[Bindable(true)]
		public string Updated 
		{
			get { return GetColumnValue<string>(Columns.Updated); }
			set { SetColumnValue(Columns.Updated, value); }
		}
		  
		[XmlAttribute("Pic")]
		[Bindable(true)]
		public string Pic 
		{
			get { return GetColumnValue<string>(Columns.Pic); }
			set { SetColumnValue(Columns.Pic, value); }
		}
		  
		[XmlAttribute("DesignationID")]
		[Bindable(true)]
		public int? DesignationID 
		{
			get { return GetColumnValue<int?>(Columns.DesignationID); }
			set { SetColumnValue(Columns.DesignationID, value); }
		}
		  
		[XmlAttribute("Gender")]
		[Bindable(true)]
		public string Gender 
		{
			get { return GetColumnValue<string>(Columns.Gender); }
			set { SetColumnValue(Columns.Gender, value); }
		}
		  
		[XmlAttribute("IsTransport")]
		[Bindable(true)]
		public bool? IsTransport 
		{
			get { return GetColumnValue<bool?>(Columns.IsTransport); }
			set { SetColumnValue(Columns.IsTransport, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBranchID,string varEmployeeName,string varFatherName,string varCnic,string varContactNo,string varAddress,string varQualification,string varDob,string varDoj,bool? varIsActive,string varCreatedBy,string varUpdated,string varPic,int? varDesignationID,string varGender,bool? varIsTransport)
		{
			TblEmployee item = new TblEmployee();
			
			item.BranchID = varBranchID;
			
			item.EmployeeName = varEmployeeName;
			
			item.FatherName = varFatherName;
			
			item.Cnic = varCnic;
			
			item.ContactNo = varContactNo;
			
			item.Address = varAddress;
			
			item.Qualification = varQualification;
			
			item.Dob = varDob;
			
			item.Doj = varDoj;
			
			item.IsActive = varIsActive;
			
			item.CreatedBy = varCreatedBy;
			
			item.Updated = varUpdated;
			
			item.Pic = varPic;
			
			item.DesignationID = varDesignationID;
			
			item.Gender = varGender;
			
			item.IsTransport = varIsTransport;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEmployeeID,int? varBranchID,string varEmployeeName,string varFatherName,string varCnic,string varContactNo,string varAddress,string varQualification,string varDob,string varDoj,bool? varIsActive,string varCreatedBy,string varUpdated,string varPic,int? varDesignationID,string varGender,bool? varIsTransport)
		{
			TblEmployee item = new TblEmployee();
			
				item.EmployeeID = varEmployeeID;
			
				item.BranchID = varBranchID;
			
				item.EmployeeName = varEmployeeName;
			
				item.FatherName = varFatherName;
			
				item.Cnic = varCnic;
			
				item.ContactNo = varContactNo;
			
				item.Address = varAddress;
			
				item.Qualification = varQualification;
			
				item.Dob = varDob;
			
				item.Doj = varDoj;
			
				item.IsActive = varIsActive;
			
				item.CreatedBy = varCreatedBy;
			
				item.Updated = varUpdated;
			
				item.Pic = varPic;
			
				item.DesignationID = varDesignationID;
			
				item.Gender = varGender;
			
				item.IsTransport = varIsTransport;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn EmployeeIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn EmployeeNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FatherNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CnicColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactNoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn QualificationColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DobColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DojColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PicColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DesignationIDColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn GenderColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IsTransportColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string EmployeeID = @"EmployeeID";
			 public static string BranchID = @"BranchID";
			 public static string EmployeeName = @"EmployeeName";
			 public static string FatherName = @"FatherName";
			 public static string Cnic = @"CNIC";
			 public static string ContactNo = @"ContactNo";
			 public static string Address = @"Address";
			 public static string Qualification = @"Qualification";
			 public static string Dob = @"DOB";
			 public static string Doj = @"DOJ";
			 public static string IsActive = @"IsActive";
			 public static string CreatedBy = @"CreatedBy";
			 public static string Updated = @"Updated";
			 public static string Pic = @"Pic";
			 public static string DesignationID = @"DesignationID";
			 public static string Gender = @"Gender";
			 public static string IsTransport = @"IsTransport";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
