          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class UsersMD : EntityMD                     
			{                       
				     
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _LoginName = string.Empty;
							        
				public String LoginName 
				{ 
					get{ return _LoginName;  }
					set{ _LoginName = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										String  _FirstName = string.Empty;
							        
				public String FirstName 
				{ 
					get{ return _FirstName;  }
					set{ _FirstName = value; }
				}
                   
				  
										String  _LastName = string.Empty;
							        
				public String LastName 
				{ 
					get{ return _LastName;  }
					set{ _LastName = value; }
				}
                   
				  
										String  _FullName = string.Empty;
							        
				public String FullName 
				{ 
					get{ return _FullName;  }
					set{ _FullName = value; }
				}
                   
				  
										Int16  _Gender = 0;
							        
				public Int16 Gender 
				{ 
					get{ return _Gender;  }
					set{ _Gender = value; }
				}
                   
				  
										String  _MyTitle = string.Empty;
							        
				public String MyTitle 
				{ 
					get{ return _MyTitle;  }
					set{ _MyTitle = value; }
				}
                   
				  
										String  _PassWord = string.Empty;
							        
				public String PassWord 
				{ 
					get{ return _PassWord;  }
					set{ _PassWord = value; }
				}
                   
				  
										String  _Email = string.Empty;
							        
				public String Email 
				{ 
					get{ return _Email;  }
					set{ _Email = value; }
				}
                   
				  
										Int32  _AccountStatus = 0;
							        
				public Int32 AccountStatus 
				{ 
					get{ return _AccountStatus;  }
					set{ _AccountStatus = value; }
				}
                   
				  
										Int16  _PasswordStatus = 0;
							        
				public Int16 PasswordStatus 
				{ 
					get{ return _PasswordStatus;  }
					set{ _PasswordStatus = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										String  _ModuleSet = string.Empty;
							        
				public String ModuleSet 
				{ 
					get{ return _ModuleSet;  }
					set{ _ModuleSet = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										Int32  _CreaterID = 0;
							        
				public Int32 CreaterID 
				{ 
					get{ return _CreaterID;  }
					set{ _CreaterID = value; }
				}
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										String  _ModifiedBy = string.Empty;
							        
				public String ModifiedBy 
				{ 
					get{ return _ModifiedBy;  }
					set{ _ModifiedBy = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										Byte  _IsDeleted = 0;
							        
				public Byte IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Int64  _DisplayOrder = 0;
							        
				public Int64 DisplayOrder 
				{ 
					get{ return _DisplayOrder;  }
					set{ _DisplayOrder = value; }
				}
                   
				  
										Decimal  _RiskMortgageFee = 0;
							        
				public Decimal RiskMortgageFee 
				{ 
					get{ return _RiskMortgageFee;  }
					set{ _RiskMortgageFee = value; }
				}
                   
				  
										String  _RegisteredResidenceType = string.Empty;
							        
				public String RegisteredResidenceType 
				{ 
					get{ return _RegisteredResidenceType;  }
					set{ _RegisteredResidenceType = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										String  _StaffNo = string.Empty;
							        
				public String StaffNo 
				{ 
					get{ return _StaffNo;  }
					set{ _StaffNo = value; }
				}
                   
				  
										DateTime  _Birthday = DateTime.Now;
							        
				public DateTime Birthday 
				{ 
					get{ return _Birthday;  }
					set{ _Birthday = value; }
				}
                   
				  
										String  _Department = string.Empty;
							        
				public String Department 
				{ 
					get{ return _Department;  }
					set{ _Department = value; }
				}
                   
				  
										String  _JobPosition = string.Empty;
							        
				public String JobPosition 
				{ 
					get{ return _JobPosition;  }
					set{ _JobPosition = value; }
				}
                   
				  
										String  _JobType = string.Empty;
							        
				public String JobType 
				{ 
					get{ return _JobType;  }
					set{ _JobType = value; }
				}
                   
				  
										String  _Nation = string.Empty;
							        
				public String Nation 
				{ 
					get{ return _Nation;  }
					set{ _Nation = value; }
				}
                   
				  
										DateTime  _BeginJobDate = DateTime.Now;
							        
				public DateTime BeginJobDate 
				{ 
					get{ return _BeginJobDate;  }
					set{ _BeginJobDate = value; }
				}
                   
				  
										DateTime  _BeginNowJobDate = DateTime.Now;
							        
				public DateTime BeginNowJobDate 
				{ 
					get{ return _BeginNowJobDate;  }
					set{ _BeginNowJobDate = value; }
				}
                   
				  
										String  _PoliticalStatus = string.Empty;
							        
				public String PoliticalStatus 
				{ 
					get{ return _PoliticalStatus;  }
					set{ _PoliticalStatus = value; }
				}
                   
				  
										String  _TopEducation = string.Empty;
							        
				public String TopEducation 
				{ 
					get{ return _TopEducation;  }
					set{ _TopEducation = value; }
				}
                   
				  
										String  _TopDegree = string.Empty;
							        
				public String TopDegree 
				{ 
					get{ return _TopDegree;  }
					set{ _TopDegree = value; }
				}
                   
				  
										String  _Technicaltitle = string.Empty;
							        
				public String Technicaltitle 
				{ 
					get{ return _Technicaltitle;  }
					set{ _Technicaltitle = value; }
				}
                   
				  
										String  _Birthplace = string.Empty;
							        
				public String Birthplace 
				{ 
					get{ return _Birthplace;  }
					set{ _Birthplace = value; }
				}
                   
				  
										String  _HomeAddress = string.Empty;
							        
				public String HomeAddress 
				{ 
					get{ return _HomeAddress;  }
					set{ _HomeAddress = value; }
				}
                   
				  
										String  _RegisteredResidenceAddress = string.Empty;
							        
				public String RegisteredResidenceAddress 
				{ 
					get{ return _RegisteredResidenceAddress;  }
					set{ _RegisteredResidenceAddress = value; }
				}
                   
				  
										String  _SocialInsuranceNo = string.Empty;
							        
				public String SocialInsuranceNo 
				{ 
					get{ return _SocialInsuranceNo;  }
					set{ _SocialInsuranceNo = value; }
				}
                   
				  
										String  _HealthStatus = string.Empty;
							        
				public String HealthStatus 
				{ 
					get{ return _HealthStatus;  }
					set{ _HealthStatus = value; }
				}
                   
				  
										String  _Contact = string.Empty;
							        
				public String Contact 
				{ 
					get{ return _Contact;  }
					set{ _Contact = value; }
				}
                   
				  
										String  _OfficeTelNo = string.Empty;
							        
				public String OfficeTelNo 
				{ 
					get{ return _OfficeTelNo;  }
					set{ _OfficeTelNo = value; }
				}
                   
				  
										String  _MobileNo = string.Empty;
							        
				public String MobileNo 
				{ 
					get{ return _MobileNo;  }
					set{ _MobileNo = value; }
				}
                   
				  
										String  _QQNo = string.Empty;
							        
				public String QQNo 
				{ 
					get{ return _QQNo;  }
					set{ _QQNo = value; }
				}
                   
				  
										DateTime  _ContractDate = DateTime.Now;
							        
				public DateTime ContractDate 
				{ 
					get{ return _ContractDate;  }
					set{ _ContractDate = value; }
				}
                   
				  
										String  _Photo = string.Empty;
							        
				public String Photo 
				{ 
					get{ return _Photo;  }
					set{ _Photo = value; }
				}
                   
				  
										String  _IdCardNo = string.Empty;
							        
				public String IdCardNo 
				{ 
					get{ return _IdCardNo;  }
					set{ _IdCardNo = value; }
				}
                   
				  
										DateTime  _ContractEndDate = DateTime.Now;
							        
				public DateTime ContractEndDate 
				{ 
					get{ return _ContractEndDate;  }
					set{ _ContractEndDate = value; }
				}
                   
				  
										String  _Speciality = string.Empty;
							        
				public String Speciality 
				{ 
					get{ return _Speciality;  }
					set{ _Speciality = value; }
				}
                   
				  
										String  _Interest = string.Empty;
							        
				public String Interest 
				{ 
					get{ return _Interest;  }
					set{ _Interest = value; }
				}
                   
				  
										String  _ForeignLanguage = string.Empty;
							        
				public String ForeignLanguage 
				{ 
					get{ return _ForeignLanguage;  }
					set{ _ForeignLanguage = value; }
				}
                   
				  
										String  _SalaryCardNo = string.Empty;
							        
				public String SalaryCardNo 
				{ 
					get{ return _SalaryCardNo;  }
					set{ _SalaryCardNo = value; }
				}
                   
				  
										Decimal  _BasicSalary = 0;
							        
				public Decimal BasicSalary 
				{ 
					get{ return _BasicSalary;  }
					set{ _BasicSalary = value; }
				}
                   
				  
										Decimal  _SenioritySalary = 0;
							        
				public Decimal SenioritySalary 
				{ 
					get{ return _SenioritySalary;  }
					set{ _SenioritySalary = value; }
				}
                   
				  
										Decimal  _WorkingPerYearPay = 0;
							        
				public Decimal WorkingPerYearPay 
				{ 
					get{ return _WorkingPerYearPay;  }
					set{ _WorkingPerYearPay = value; }
				}
                   
				  
										Decimal  _BeforeGroupWorkYear = 0;
							        
				public Decimal BeforeGroupWorkYear 
				{ 
					get{ return _BeforeGroupWorkYear;  }
					set{ _BeforeGroupWorkYear = value; }
				}
                   
				  
										Decimal  _AddGroupWorkYear = 0;
							        
				public Decimal AddGroupWorkYear 
				{ 
					get{ return _AddGroupWorkYear;  }
					set{ _AddGroupWorkYear = value; }
				}
                   
				  
										Decimal  _JobAllowance = 0;
							        
				public Decimal JobAllowance 
				{ 
					get{ return _JobAllowance;  }
					set{ _JobAllowance = value; }
				}
                   
				  
										Decimal  _OtherSubsides = 0;
							        
				public Decimal OtherSubsides 
				{ 
					get{ return _OtherSubsides;  }
					set{ _OtherSubsides = value; }
				}
                   
				  
										Decimal  _HouseFee = 0;
							        
				public Decimal HouseFee 
				{ 
					get{ return _HouseFee;  }
					set{ _HouseFee = value; }
				}
                   
				  
										Decimal  _TelPhoneFee = 0;
							        
				public Decimal TelPhoneFee 
				{ 
					get{ return _TelPhoneFee;  }
					set{ _TelPhoneFee = value; }
				}
                   
				  
										Decimal  _WaterAndPowerFee = 0;
							        
				public Decimal WaterAndPowerFee 
				{ 
					get{ return _WaterAndPowerFee;  }
					set{ _WaterAndPowerFee = value; }
				}
                   
				  
										Decimal  _PayCardinality = 0;
							        
				public Decimal PayCardinality 
				{ 
					get{ return _PayCardinality;  }
					set{ _PayCardinality = value; }
				}
                      				        
			}               
			                   
}
 
			