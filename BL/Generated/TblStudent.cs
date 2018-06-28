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
	/// Strongly-typed collection for the TblStudent class.
	/// </summary>
    [Serializable]
	public partial class TblStudentCollection : ActiveList<TblStudent, TblStudentCollection>
	{	   
		public TblStudentCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblStudentCollection</returns>
		public TblStudentCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblStudent o = this[i];
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
	/// This is an ActiveRecord class which wraps the TblStudents table.
	/// </summary>
	[Serializable]
	public partial class TblStudent : ActiveRecord<TblStudent>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblStudent()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblStudent(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblStudent(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblStudent(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TblStudents", TableType.Table, DataService.GetInstance("SchoolManagementSystem"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarStudentID = new TableSchema.TableColumn(schema);
				colvarStudentID.ColumnName = "StudentID";
				colvarStudentID.DataType = DbType.Int32;
				colvarStudentID.MaxLength = 0;
				colvarStudentID.AutoIncrement = true;
				colvarStudentID.IsNullable = false;
				colvarStudentID.IsPrimaryKey = true;
				colvarStudentID.IsForeignKey = false;
				colvarStudentID.IsReadOnly = false;
				colvarStudentID.DefaultSetting = @"";
				colvarStudentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStudentID);
				
				TableSchema.TableColumn colvarStudentName = new TableSchema.TableColumn(schema);
				colvarStudentName.ColumnName = "StudentName";
				colvarStudentName.DataType = DbType.AnsiString;
				colvarStudentName.MaxLength = 50;
				colvarStudentName.AutoIncrement = false;
				colvarStudentName.IsNullable = true;
				colvarStudentName.IsPrimaryKey = false;
				colvarStudentName.IsForeignKey = false;
				colvarStudentName.IsReadOnly = false;
				colvarStudentName.DefaultSetting = @"";
				colvarStudentName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStudentName);
				
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
				
				TableSchema.TableColumn colvarRegistrationNo = new TableSchema.TableColumn(schema);
				colvarRegistrationNo.ColumnName = "RegistrationNo";
				colvarRegistrationNo.DataType = DbType.AnsiString;
				colvarRegistrationNo.MaxLength = 50;
				colvarRegistrationNo.AutoIncrement = false;
				colvarRegistrationNo.IsNullable = true;
				colvarRegistrationNo.IsPrimaryKey = false;
				colvarRegistrationNo.IsForeignKey = false;
				colvarRegistrationNo.IsReadOnly = false;
				colvarRegistrationNo.DefaultSetting = @"";
				colvarRegistrationNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegistrationNo);
				
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
				
				TableSchema.TableColumn colvarSession = new TableSchema.TableColumn(schema);
				colvarSession.ColumnName = "Session";
				colvarSession.DataType = DbType.AnsiString;
				colvarSession.MaxLength = 50;
				colvarSession.AutoIncrement = false;
				colvarSession.IsNullable = true;
				colvarSession.IsPrimaryKey = false;
				colvarSession.IsForeignKey = false;
				colvarSession.IsReadOnly = false;
				colvarSession.DefaultSetting = @"";
				colvarSession.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSession);
				
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
				
				TableSchema.TableColumn colvarDateofAdmission = new TableSchema.TableColumn(schema);
				colvarDateofAdmission.ColumnName = "DateofAdmission";
				colvarDateofAdmission.DataType = DbType.DateTime;
				colvarDateofAdmission.MaxLength = 0;
				colvarDateofAdmission.AutoIncrement = false;
				colvarDateofAdmission.IsNullable = true;
				colvarDateofAdmission.IsPrimaryKey = false;
				colvarDateofAdmission.IsForeignKey = false;
				colvarDateofAdmission.IsReadOnly = false;
				colvarDateofAdmission.DefaultSetting = @"";
				colvarDateofAdmission.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateofAdmission);
				
				TableSchema.TableColumn colvarPic = new TableSchema.TableColumn(schema);
				colvarPic.ColumnName = "Pic";
				colvarPic.DataType = DbType.AnsiString;
				colvarPic.MaxLength = 500;
				colvarPic.AutoIncrement = false;
				colvarPic.IsNullable = true;
				colvarPic.IsPrimaryKey = false;
				colvarPic.IsForeignKey = false;
				colvarPic.IsReadOnly = false;
				colvarPic.DefaultSetting = @"";
				colvarPic.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPic);
				
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
				
				TableSchema.TableColumn colvarNationality = new TableSchema.TableColumn(schema);
				colvarNationality.ColumnName = "Nationality";
				colvarNationality.DataType = DbType.AnsiString;
				colvarNationality.MaxLength = 50;
				colvarNationality.AutoIncrement = false;
				colvarNationality.IsNullable = true;
				colvarNationality.IsPrimaryKey = false;
				colvarNationality.IsForeignKey = false;
				colvarNationality.IsReadOnly = false;
				colvarNationality.DefaultSetting = @"";
				colvarNationality.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNationality);
				
				TableSchema.TableColumn colvarDomicile = new TableSchema.TableColumn(schema);
				colvarDomicile.ColumnName = "Domicile";
				colvarDomicile.DataType = DbType.AnsiString;
				colvarDomicile.MaxLength = 50;
				colvarDomicile.AutoIncrement = false;
				colvarDomicile.IsNullable = true;
				colvarDomicile.IsPrimaryKey = false;
				colvarDomicile.IsForeignKey = false;
				colvarDomicile.IsReadOnly = false;
				colvarDomicile.DefaultSetting = @"";
				colvarDomicile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDomicile);
				
				TableSchema.TableColumn colvarReligion = new TableSchema.TableColumn(schema);
				colvarReligion.ColumnName = "Religion";
				colvarReligion.DataType = DbType.AnsiString;
				colvarReligion.MaxLength = 50;
				colvarReligion.AutoIncrement = false;
				colvarReligion.IsNullable = true;
				colvarReligion.IsPrimaryKey = false;
				colvarReligion.IsForeignKey = false;
				colvarReligion.IsReadOnly = false;
				colvarReligion.DefaultSetting = @"";
				colvarReligion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReligion);
				
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
				
				TableSchema.TableColumn colvarDob = new TableSchema.TableColumn(schema);
				colvarDob.ColumnName = "DOB";
				colvarDob.DataType = DbType.DateTime;
				colvarDob.MaxLength = 0;
				colvarDob.AutoIncrement = false;
				colvarDob.IsNullable = true;
				colvarDob.IsPrimaryKey = false;
				colvarDob.IsForeignKey = false;
				colvarDob.IsReadOnly = false;
				colvarDob.DefaultSetting = @"";
				colvarDob.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDob);
				
				TableSchema.TableColumn colvarPlaceofBirth = new TableSchema.TableColumn(schema);
				colvarPlaceofBirth.ColumnName = "PlaceofBirth";
				colvarPlaceofBirth.DataType = DbType.AnsiString;
				colvarPlaceofBirth.MaxLength = 500;
				colvarPlaceofBirth.AutoIncrement = false;
				colvarPlaceofBirth.IsNullable = true;
				colvarPlaceofBirth.IsPrimaryKey = false;
				colvarPlaceofBirth.IsForeignKey = false;
				colvarPlaceofBirth.IsReadOnly = false;
				colvarPlaceofBirth.DefaultSetting = @"";
				colvarPlaceofBirth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlaceofBirth);
				
				TableSchema.TableColumn colvarSEmail = new TableSchema.TableColumn(schema);
				colvarSEmail.ColumnName = "SEmail";
				colvarSEmail.DataType = DbType.AnsiString;
				colvarSEmail.MaxLength = 50;
				colvarSEmail.AutoIncrement = false;
				colvarSEmail.IsNullable = true;
				colvarSEmail.IsPrimaryKey = false;
				colvarSEmail.IsForeignKey = false;
				colvarSEmail.IsReadOnly = false;
				colvarSEmail.DefaultSetting = @"";
				colvarSEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSEmail);
				
				TableSchema.TableColumn colvarSCellNo = new TableSchema.TableColumn(schema);
				colvarSCellNo.ColumnName = "SCellNo";
				colvarSCellNo.DataType = DbType.AnsiString;
				colvarSCellNo.MaxLength = 50;
				colvarSCellNo.AutoIncrement = false;
				colvarSCellNo.IsNullable = true;
				colvarSCellNo.IsPrimaryKey = false;
				colvarSCellNo.IsForeignKey = false;
				colvarSCellNo.IsReadOnly = false;
				colvarSCellNo.DefaultSetting = @"";
				colvarSCellNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSCellNo);
				
				TableSchema.TableColumn colvarSHomePhone = new TableSchema.TableColumn(schema);
				colvarSHomePhone.ColumnName = "SHomePhone";
				colvarSHomePhone.DataType = DbType.AnsiString;
				colvarSHomePhone.MaxLength = 50;
				colvarSHomePhone.AutoIncrement = false;
				colvarSHomePhone.IsNullable = true;
				colvarSHomePhone.IsPrimaryKey = false;
				colvarSHomePhone.IsForeignKey = false;
				colvarSHomePhone.IsReadOnly = false;
				colvarSHomePhone.DefaultSetting = @"";
				colvarSHomePhone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSHomePhone);
				
				TableSchema.TableColumn colvarSAddress = new TableSchema.TableColumn(schema);
				colvarSAddress.ColumnName = "SAddress";
				colvarSAddress.DataType = DbType.AnsiString;
				colvarSAddress.MaxLength = 50;
				colvarSAddress.AutoIncrement = false;
				colvarSAddress.IsNullable = true;
				colvarSAddress.IsPrimaryKey = false;
				colvarSAddress.IsForeignKey = false;
				colvarSAddress.IsReadOnly = false;
				colvarSAddress.DefaultSetting = @"";
				colvarSAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSAddress);
				
				TableSchema.TableColumn colvarIsTrannsport = new TableSchema.TableColumn(schema);
				colvarIsTrannsport.ColumnName = "IsTrannsport";
				colvarIsTrannsport.DataType = DbType.Boolean;
				colvarIsTrannsport.MaxLength = 0;
				colvarIsTrannsport.AutoIncrement = false;
				colvarIsTrannsport.IsNullable = true;
				colvarIsTrannsport.IsPrimaryKey = false;
				colvarIsTrannsport.IsForeignKey = false;
				colvarIsTrannsport.IsReadOnly = false;
				colvarIsTrannsport.DefaultSetting = @"";
				colvarIsTrannsport.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsTrannsport);
				
				TableSchema.TableColumn colvarIsHostel = new TableSchema.TableColumn(schema);
				colvarIsHostel.ColumnName = "IsHostel";
				colvarIsHostel.DataType = DbType.Boolean;
				colvarIsHostel.MaxLength = 0;
				colvarIsHostel.AutoIncrement = false;
				colvarIsHostel.IsNullable = true;
				colvarIsHostel.IsPrimaryKey = false;
				colvarIsHostel.IsForeignKey = false;
				colvarIsHostel.IsReadOnly = false;
				colvarIsHostel.DefaultSetting = @"";
				colvarIsHostel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsHostel);
				
				TableSchema.TableColumn colvarGName = new TableSchema.TableColumn(schema);
				colvarGName.ColumnName = "GName";
				colvarGName.DataType = DbType.AnsiString;
				colvarGName.MaxLength = 50;
				colvarGName.AutoIncrement = false;
				colvarGName.IsNullable = true;
				colvarGName.IsPrimaryKey = false;
				colvarGName.IsForeignKey = false;
				colvarGName.IsReadOnly = false;
				colvarGName.DefaultSetting = @"";
				colvarGName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGName);
				
				TableSchema.TableColumn colvarGRelationship = new TableSchema.TableColumn(schema);
				colvarGRelationship.ColumnName = "GRelationship";
				colvarGRelationship.DataType = DbType.AnsiString;
				colvarGRelationship.MaxLength = 50;
				colvarGRelationship.AutoIncrement = false;
				colvarGRelationship.IsNullable = true;
				colvarGRelationship.IsPrimaryKey = false;
				colvarGRelationship.IsForeignKey = false;
				colvarGRelationship.IsReadOnly = false;
				colvarGRelationship.DefaultSetting = @"";
				colvarGRelationship.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGRelationship);
				
				TableSchema.TableColumn colvarGAddress = new TableSchema.TableColumn(schema);
				colvarGAddress.ColumnName = "GAddress";
				colvarGAddress.DataType = DbType.AnsiString;
				colvarGAddress.MaxLength = 500;
				colvarGAddress.AutoIncrement = false;
				colvarGAddress.IsNullable = true;
				colvarGAddress.IsPrimaryKey = false;
				colvarGAddress.IsForeignKey = false;
				colvarGAddress.IsReadOnly = false;
				colvarGAddress.DefaultSetting = @"";
				colvarGAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGAddress);
				
				TableSchema.TableColumn colvarGEmail = new TableSchema.TableColumn(schema);
				colvarGEmail.ColumnName = "GEmail";
				colvarGEmail.DataType = DbType.AnsiString;
				colvarGEmail.MaxLength = 50;
				colvarGEmail.AutoIncrement = false;
				colvarGEmail.IsNullable = true;
				colvarGEmail.IsPrimaryKey = false;
				colvarGEmail.IsForeignKey = false;
				colvarGEmail.IsReadOnly = false;
				colvarGEmail.DefaultSetting = @"";
				colvarGEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGEmail);
				
				TableSchema.TableColumn colvarGOccupation = new TableSchema.TableColumn(schema);
				colvarGOccupation.ColumnName = "GOccupation";
				colvarGOccupation.DataType = DbType.AnsiString;
				colvarGOccupation.MaxLength = 50;
				colvarGOccupation.AutoIncrement = false;
				colvarGOccupation.IsNullable = true;
				colvarGOccupation.IsPrimaryKey = false;
				colvarGOccupation.IsForeignKey = false;
				colvarGOccupation.IsReadOnly = false;
				colvarGOccupation.DefaultSetting = @"";
				colvarGOccupation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGOccupation);
				
				TableSchema.TableColumn colvarGMonthlyIncome = new TableSchema.TableColumn(schema);
				colvarGMonthlyIncome.ColumnName = "GMonthlyIncome";
				colvarGMonthlyIncome.DataType = DbType.Currency;
				colvarGMonthlyIncome.MaxLength = 0;
				colvarGMonthlyIncome.AutoIncrement = false;
				colvarGMonthlyIncome.IsNullable = true;
				colvarGMonthlyIncome.IsPrimaryKey = false;
				colvarGMonthlyIncome.IsForeignKey = false;
				colvarGMonthlyIncome.IsReadOnly = false;
				colvarGMonthlyIncome.DefaultSetting = @"";
				colvarGMonthlyIncome.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGMonthlyIncome);
				
				TableSchema.TableColumn colvarGCellNo = new TableSchema.TableColumn(schema);
				colvarGCellNo.ColumnName = "GCellNo";
				colvarGCellNo.DataType = DbType.AnsiString;
				colvarGCellNo.MaxLength = 50;
				colvarGCellNo.AutoIncrement = false;
				colvarGCellNo.IsNullable = true;
				colvarGCellNo.IsPrimaryKey = false;
				colvarGCellNo.IsForeignKey = false;
				colvarGCellNo.IsReadOnly = false;
				colvarGCellNo.DefaultSetting = @"";
				colvarGCellNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGCellNo);
				
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
				
				TableSchema.TableColumn colvarGroupID = new TableSchema.TableColumn(schema);
				colvarGroupID.ColumnName = "GroupID";
				colvarGroupID.DataType = DbType.Int32;
				colvarGroupID.MaxLength = 0;
				colvarGroupID.AutoIncrement = false;
				colvarGroupID.IsNullable = true;
				colvarGroupID.IsPrimaryKey = false;
				colvarGroupID.IsForeignKey = false;
				colvarGroupID.IsReadOnly = false;
				colvarGroupID.DefaultSetting = @"";
				colvarGroupID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SchoolManagementSystem"].AddSchema("TblStudents",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("StudentID")]
		[Bindable(true)]
		public int StudentID 
		{
			get { return GetColumnValue<int>(Columns.StudentID); }
			set { SetColumnValue(Columns.StudentID, value); }
		}
		  
		[XmlAttribute("StudentName")]
		[Bindable(true)]
		public string StudentName 
		{
			get { return GetColumnValue<string>(Columns.StudentName); }
			set { SetColumnValue(Columns.StudentName, value); }
		}
		  
		[XmlAttribute("FatherName")]
		[Bindable(true)]
		public string FatherName 
		{
			get { return GetColumnValue<string>(Columns.FatherName); }
			set { SetColumnValue(Columns.FatherName, value); }
		}
		  
		[XmlAttribute("RegistrationNo")]
		[Bindable(true)]
		public string RegistrationNo 
		{
			get { return GetColumnValue<string>(Columns.RegistrationNo); }
			set { SetColumnValue(Columns.RegistrationNo, value); }
		}
		  
		[XmlAttribute("LevelID")]
		[Bindable(true)]
		public int? LevelID 
		{
			get { return GetColumnValue<int?>(Columns.LevelID); }
			set { SetColumnValue(Columns.LevelID, value); }
		}
		  
		[XmlAttribute("Program")]
		[Bindable(true)]
		public string Program 
		{
			get { return GetColumnValue<string>(Columns.Program); }
			set { SetColumnValue(Columns.Program, value); }
		}
		  
		[XmlAttribute("Session")]
		[Bindable(true)]
		public string Session 
		{
			get { return GetColumnValue<string>(Columns.Session); }
			set { SetColumnValue(Columns.Session, value); }
		}
		  
		[XmlAttribute("BranchID")]
		[Bindable(true)]
		public int? BranchID 
		{
			get { return GetColumnValue<int?>(Columns.BranchID); }
			set { SetColumnValue(Columns.BranchID, value); }
		}
		  
		[XmlAttribute("DateofAdmission")]
		[Bindable(true)]
		public DateTime? DateofAdmission 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateofAdmission); }
			set { SetColumnValue(Columns.DateofAdmission, value); }
		}
		  
		[XmlAttribute("Pic")]
		[Bindable(true)]
		public string Pic 
		{
			get { return GetColumnValue<string>(Columns.Pic); }
			set { SetColumnValue(Columns.Pic, value); }
		}
		  
		[XmlAttribute("Gender")]
		[Bindable(true)]
		public string Gender 
		{
			get { return GetColumnValue<string>(Columns.Gender); }
			set { SetColumnValue(Columns.Gender, value); }
		}
		  
		[XmlAttribute("Nationality")]
		[Bindable(true)]
		public string Nationality 
		{
			get { return GetColumnValue<string>(Columns.Nationality); }
			set { SetColumnValue(Columns.Nationality, value); }
		}
		  
		[XmlAttribute("Domicile")]
		[Bindable(true)]
		public string Domicile 
		{
			get { return GetColumnValue<string>(Columns.Domicile); }
			set { SetColumnValue(Columns.Domicile, value); }
		}
		  
		[XmlAttribute("Religion")]
		[Bindable(true)]
		public string Religion 
		{
			get { return GetColumnValue<string>(Columns.Religion); }
			set { SetColumnValue(Columns.Religion, value); }
		}
		  
		[XmlAttribute("Cnic")]
		[Bindable(true)]
		public string Cnic 
		{
			get { return GetColumnValue<string>(Columns.Cnic); }
			set { SetColumnValue(Columns.Cnic, value); }
		}
		  
		[XmlAttribute("Dob")]
		[Bindable(true)]
		public DateTime? Dob 
		{
			get { return GetColumnValue<DateTime?>(Columns.Dob); }
			set { SetColumnValue(Columns.Dob, value); }
		}
		  
		[XmlAttribute("PlaceofBirth")]
		[Bindable(true)]
		public string PlaceofBirth 
		{
			get { return GetColumnValue<string>(Columns.PlaceofBirth); }
			set { SetColumnValue(Columns.PlaceofBirth, value); }
		}
		  
		[XmlAttribute("SEmail")]
		[Bindable(true)]
		public string SEmail 
		{
			get { return GetColumnValue<string>(Columns.SEmail); }
			set { SetColumnValue(Columns.SEmail, value); }
		}
		  
		[XmlAttribute("SCellNo")]
		[Bindable(true)]
		public string SCellNo 
		{
			get { return GetColumnValue<string>(Columns.SCellNo); }
			set { SetColumnValue(Columns.SCellNo, value); }
		}
		  
		[XmlAttribute("SHomePhone")]
		[Bindable(true)]
		public string SHomePhone 
		{
			get { return GetColumnValue<string>(Columns.SHomePhone); }
			set { SetColumnValue(Columns.SHomePhone, value); }
		}
		  
		[XmlAttribute("SAddress")]
		[Bindable(true)]
		public string SAddress 
		{
			get { return GetColumnValue<string>(Columns.SAddress); }
			set { SetColumnValue(Columns.SAddress, value); }
		}
		  
		[XmlAttribute("IsTrannsport")]
		[Bindable(true)]
		public bool? IsTrannsport 
		{
			get { return GetColumnValue<bool?>(Columns.IsTrannsport); }
			set { SetColumnValue(Columns.IsTrannsport, value); }
		}
		  
		[XmlAttribute("IsHostel")]
		[Bindable(true)]
		public bool? IsHostel 
		{
			get { return GetColumnValue<bool?>(Columns.IsHostel); }
			set { SetColumnValue(Columns.IsHostel, value); }
		}
		  
		[XmlAttribute("GName")]
		[Bindable(true)]
		public string GName 
		{
			get { return GetColumnValue<string>(Columns.GName); }
			set { SetColumnValue(Columns.GName, value); }
		}
		  
		[XmlAttribute("GRelationship")]
		[Bindable(true)]
		public string GRelationship 
		{
			get { return GetColumnValue<string>(Columns.GRelationship); }
			set { SetColumnValue(Columns.GRelationship, value); }
		}
		  
		[XmlAttribute("GAddress")]
		[Bindable(true)]
		public string GAddress 
		{
			get { return GetColumnValue<string>(Columns.GAddress); }
			set { SetColumnValue(Columns.GAddress, value); }
		}
		  
		[XmlAttribute("GEmail")]
		[Bindable(true)]
		public string GEmail 
		{
			get { return GetColumnValue<string>(Columns.GEmail); }
			set { SetColumnValue(Columns.GEmail, value); }
		}
		  
		[XmlAttribute("GOccupation")]
		[Bindable(true)]
		public string GOccupation 
		{
			get { return GetColumnValue<string>(Columns.GOccupation); }
			set { SetColumnValue(Columns.GOccupation, value); }
		}
		  
		[XmlAttribute("GMonthlyIncome")]
		[Bindable(true)]
		public decimal? GMonthlyIncome 
		{
			get { return GetColumnValue<decimal?>(Columns.GMonthlyIncome); }
			set { SetColumnValue(Columns.GMonthlyIncome, value); }
		}
		  
		[XmlAttribute("GCellNo")]
		[Bindable(true)]
		public string GCellNo 
		{
			get { return GetColumnValue<string>(Columns.GCellNo); }
			set { SetColumnValue(Columns.GCellNo, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
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
		  
		[XmlAttribute("ClassNo")]
		[Bindable(true)]
		public int? ClassNo 
		{
			get { return GetColumnValue<int?>(Columns.ClassNo); }
			set { SetColumnValue(Columns.ClassNo, value); }
		}
		  
		[XmlAttribute("GroupID")]
		[Bindable(true)]
		public int? GroupID 
		{
			get { return GetColumnValue<int?>(Columns.GroupID); }
			set { SetColumnValue(Columns.GroupID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varStudentName,string varFatherName,string varRegistrationNo,int? varLevelID,string varProgram,string varSession,int? varBranchID,DateTime? varDateofAdmission,string varPic,string varGender,string varNationality,string varDomicile,string varReligion,string varCnic,DateTime? varDob,string varPlaceofBirth,string varSEmail,string varSCellNo,string varSHomePhone,string varSAddress,bool? varIsTrannsport,bool? varIsHostel,string varGName,string varGRelationship,string varGAddress,string varGEmail,string varGOccupation,decimal? varGMonthlyIncome,string varGCellNo,bool? varIsActive,string varCreateBy,string varUpdatedBy,int? varClassNo,int? varGroupID)
		{
			TblStudent item = new TblStudent();
			
			item.StudentName = varStudentName;
			
			item.FatherName = varFatherName;
			
			item.RegistrationNo = varRegistrationNo;
			
			item.LevelID = varLevelID;
			
			item.Program = varProgram;
			
			item.Session = varSession;
			
			item.BranchID = varBranchID;
			
			item.DateofAdmission = varDateofAdmission;
			
			item.Pic = varPic;
			
			item.Gender = varGender;
			
			item.Nationality = varNationality;
			
			item.Domicile = varDomicile;
			
			item.Religion = varReligion;
			
			item.Cnic = varCnic;
			
			item.Dob = varDob;
			
			item.PlaceofBirth = varPlaceofBirth;
			
			item.SEmail = varSEmail;
			
			item.SCellNo = varSCellNo;
			
			item.SHomePhone = varSHomePhone;
			
			item.SAddress = varSAddress;
			
			item.IsTrannsport = varIsTrannsport;
			
			item.IsHostel = varIsHostel;
			
			item.GName = varGName;
			
			item.GRelationship = varGRelationship;
			
			item.GAddress = varGAddress;
			
			item.GEmail = varGEmail;
			
			item.GOccupation = varGOccupation;
			
			item.GMonthlyIncome = varGMonthlyIncome;
			
			item.GCellNo = varGCellNo;
			
			item.IsActive = varIsActive;
			
			item.CreateBy = varCreateBy;
			
			item.UpdatedBy = varUpdatedBy;
			
			item.ClassNo = varClassNo;
			
			item.GroupID = varGroupID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varStudentID,string varStudentName,string varFatherName,string varRegistrationNo,int? varLevelID,string varProgram,string varSession,int? varBranchID,DateTime? varDateofAdmission,string varPic,string varGender,string varNationality,string varDomicile,string varReligion,string varCnic,DateTime? varDob,string varPlaceofBirth,string varSEmail,string varSCellNo,string varSHomePhone,string varSAddress,bool? varIsTrannsport,bool? varIsHostel,string varGName,string varGRelationship,string varGAddress,string varGEmail,string varGOccupation,decimal? varGMonthlyIncome,string varGCellNo,bool? varIsActive,string varCreateBy,string varUpdatedBy,int? varClassNo,int? varGroupID)
		{
			TblStudent item = new TblStudent();
			
				item.StudentID = varStudentID;
			
				item.StudentName = varStudentName;
			
				item.FatherName = varFatherName;
			
				item.RegistrationNo = varRegistrationNo;
			
				item.LevelID = varLevelID;
			
				item.Program = varProgram;
			
				item.Session = varSession;
			
				item.BranchID = varBranchID;
			
				item.DateofAdmission = varDateofAdmission;
			
				item.Pic = varPic;
			
				item.Gender = varGender;
			
				item.Nationality = varNationality;
			
				item.Domicile = varDomicile;
			
				item.Religion = varReligion;
			
				item.Cnic = varCnic;
			
				item.Dob = varDob;
			
				item.PlaceofBirth = varPlaceofBirth;
			
				item.SEmail = varSEmail;
			
				item.SCellNo = varSCellNo;
			
				item.SHomePhone = varSHomePhone;
			
				item.SAddress = varSAddress;
			
				item.IsTrannsport = varIsTrannsport;
			
				item.IsHostel = varIsHostel;
			
				item.GName = varGName;
			
				item.GRelationship = varGRelationship;
			
				item.GAddress = varGAddress;
			
				item.GEmail = varGEmail;
			
				item.GOccupation = varGOccupation;
			
				item.GMonthlyIncome = varGMonthlyIncome;
			
				item.GCellNo = varGCellNo;
			
				item.IsActive = varIsActive;
			
				item.CreateBy = varCreateBy;
			
				item.UpdatedBy = varUpdatedBy;
			
				item.ClassNo = varClassNo;
			
				item.GroupID = varGroupID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn StudentIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StudentNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FatherNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RegistrationNoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LevelIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ProgramColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SessionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn BranchIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateofAdmissionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn PicColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn GenderColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NationalityColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DomicileColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ReligionColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn CnicColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DobColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn PlaceofBirthColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn SEmailColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn SCellNoColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn SHomePhoneColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn SAddressColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn IsTrannsportColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn IsHostelColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn GNameColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn GRelationshipColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn GAddressColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn GEmailColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn GOccupationColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn GMonthlyIncomeColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn GCellNoColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn CreateByColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNoColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn GroupIDColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string StudentID = @"StudentID";
			 public static string StudentName = @"StudentName";
			 public static string FatherName = @"FatherName";
			 public static string RegistrationNo = @"RegistrationNo";
			 public static string LevelID = @"LevelID";
			 public static string Program = @"Program";
			 public static string Session = @"Session";
			 public static string BranchID = @"BranchID";
			 public static string DateofAdmission = @"DateofAdmission";
			 public static string Pic = @"Pic";
			 public static string Gender = @"Gender";
			 public static string Nationality = @"Nationality";
			 public static string Domicile = @"Domicile";
			 public static string Religion = @"Religion";
			 public static string Cnic = @"CNIC";
			 public static string Dob = @"DOB";
			 public static string PlaceofBirth = @"PlaceofBirth";
			 public static string SEmail = @"SEmail";
			 public static string SCellNo = @"SCellNo";
			 public static string SHomePhone = @"SHomePhone";
			 public static string SAddress = @"SAddress";
			 public static string IsTrannsport = @"IsTrannsport";
			 public static string IsHostel = @"IsHostel";
			 public static string GName = @"GName";
			 public static string GRelationship = @"GRelationship";
			 public static string GAddress = @"GAddress";
			 public static string GEmail = @"GEmail";
			 public static string GOccupation = @"GOccupation";
			 public static string GMonthlyIncome = @"GMonthlyIncome";
			 public static string GCellNo = @"GCellNo";
			 public static string IsActive = @"IsActive";
			 public static string CreateBy = @"CreateBy";
			 public static string UpdatedBy = @"UpdatedBy";
			 public static string ClassNo = @"ClassNo";
			 public static string GroupID = @"GroupID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
