          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class Contract_ScientificMD : EntityMD                     
			{                       
				     
				  
										String  _Id = string.Empty;
							        
				public String Id 
				{ 
					get{ return _Id;  }
					set{ _Id = value; }
				}
                   
				  
										String  _WriterId = string.Empty;
							        
				public String WriterId 
				{ 
					get{ return _WriterId;  }
					set{ _WriterId = value; }
				}
                   
				  
										String  _WriterName = string.Empty;
							        
				public String WriterName 
				{ 
					get{ return _WriterName;  }
					set{ _WriterName = value; }
				}
                   
				  
										DateTime  _WriteDate = DateTime.Now;
							        
				public DateTime WriteDate 
				{ 
					get{ return _WriteDate;  }
					set{ _WriteDate = value; }
				}
                   
				  
										Int32  _PublicSealCount = 0;
							        
				public Int32 PublicSealCount 
				{ 
					get{ return _PublicSealCount;  }
					set{ _PublicSealCount = value; }
				}
                   
				  
										Int32  _ContractSealCount = 0;
							        
				public Int32 ContractSealCount 
				{ 
					get{ return _ContractSealCount;  }
					set{ _ContractSealCount = value; }
				}
                   
				  
										Int32  _LawSealCount = 0;
							        
				public Int32 LawSealCount 
				{ 
					get{ return _LawSealCount;  }
					set{ _LawSealCount = value; }
				}
                   
				  
										String  _Client = string.Empty;
							        
				public String Client 
				{ 
					get{ return _Client;  }
					set{ _Client = value; }
				}
                   
				  
										String  _AcceptTakeOutType = string.Empty;
							        
				public String AcceptTakeOutType 
				{ 
					get{ return _AcceptTakeOutType;  }
					set{ _AcceptTakeOutType = value; }
				}
                   
				  
										DateTime  _DocumentDate = DateTime.Now;
							        
				public DateTime DocumentDate 
				{ 
					get{ return _DocumentDate;  }
					set{ _DocumentDate = value; }
				}
                   
				  
										DateTime  _ContractSignDate = DateTime.Now;
							        
				public DateTime ContractSignDate 
				{ 
					get{ return _ContractSignDate;  }
					set{ _ContractSignDate = value; }
				}
                   
				  
										String  _PerformTimeLimit = string.Empty;
							        
				public String PerformTimeLimit 
				{ 
					get{ return _PerformTimeLimit;  }
					set{ _PerformTimeLimit = value; }
				}
                   
				  
										String  _PrjManagerId = string.Empty;
							        
				public String PrjManagerId 
				{ 
					get{ return _PrjManagerId;  }
					set{ _PrjManagerId = value; }
				}
                   
				  
										String  _PrjManagerName = string.Empty;
							        
				public String PrjManagerName 
				{ 
					get{ return _PrjManagerName;  }
					set{ _PrjManagerName = value; }
				}
                   
				  
										String  _PrjManagerLink = string.Empty;
							        
				public String PrjManagerLink 
				{ 
					get{ return _PrjManagerLink;  }
					set{ _PrjManagerLink = value; }
				}
                   
				  
										String  _UndertakerId = string.Empty;
							        
				public String UndertakerId 
				{ 
					get{ return _UndertakerId;  }
					set{ _UndertakerId = value; }
				}
                   
				  
										String  _UndertakerName = string.Empty;
							        
				public String UndertakerName 
				{ 
					get{ return _UndertakerName;  }
					set{ _UndertakerName = value; }
				}
                   
				  
										String  _UndertakeLink = string.Empty;
							        
				public String UndertakeLink 
				{ 
					get{ return _UndertakeLink;  }
					set{ _UndertakeLink = value; }
				}
                   
				  
										String  _UndertakeDepterId = string.Empty;
							        
				public String UndertakeDepterId 
				{ 
					get{ return _UndertakeDepterId;  }
					set{ _UndertakeDepterId = value; }
				}
                   
				  
										String  _UndertakeDepterName = string.Empty;
							        
				public String UndertakeDepterName 
				{ 
					get{ return _UndertakeDepterName;  }
					set{ _UndertakeDepterName = value; }
				}
                   
				  
										String  _ContractName = string.Empty;
							        
				public String ContractName 
				{ 
					get{ return _ContractName;  }
					set{ _ContractName = value; }
				}
                   
				  
										String  _ContractNo = string.Empty;
							        
				public String ContractNo 
				{ 
					get{ return _ContractNo;  }
					set{ _ContractNo = value; }
				}
                   
				  
										String  _ContractNoId = string.Empty;
							        
				public String ContractNoId 
				{ 
					get{ return _ContractNoId;  }
					set{ _ContractNoId = value; }
				}
                   
				  
										DateTime  _ContractNoDate = DateTime.Now;
							        
				public DateTime ContractNoDate 
				{ 
					get{ return _ContractNoDate;  }
					set{ _ContractNoDate = value; }
				}
                   
				  
										String  _ContractLawUserId = string.Empty;
							        
				public String ContractLawUserId 
				{ 
					get{ return _ContractLawUserId;  }
					set{ _ContractLawUserId = value; }
				}
                   
				  
										String  _ContractLawUserName = string.Empty;
							        
				public String ContractLawUserName 
				{ 
					get{ return _ContractLawUserName;  }
					set{ _ContractLawUserName = value; }
				}
                   
				  
										String  _ContractType = string.Empty;
							        
				public String ContractType 
				{ 
					get{ return _ContractType;  }
					set{ _ContractType = value; }
				}
                   
				  
										String  _ProjectName = string.Empty;
							        
				public String ProjectName 
				{ 
					get{ return _ProjectName;  }
					set{ _ProjectName = value; }
				}
                   
				  
										String  _StatuteNo = string.Empty;
							        
				public String StatuteNo 
				{ 
					get{ return _StatuteNo;  }
					set{ _StatuteNo = value; }
				}
                   
				  
										Int32  _RunNo = 0;
							        
				public Int32 RunNo 
				{ 
					get{ return _RunNo;  }
					set{ _RunNo = value; }
				}
                   
				  
										String  _RunStr = string.Empty;
							        
				public String RunStr 
				{ 
					get{ return _RunStr;  }
					set{ _RunStr = value; }
				}
                   
				  
										Decimal  _ContractTotal = 0;
							        
				public Decimal ContractTotal 
				{ 
					get{ return _ContractTotal;  }
					set{ _ContractTotal = value; }
				}
                   
				  
										Decimal  _RMB = 0;
							        
				public Decimal RMB 
				{ 
					get{ return _RMB;  }
					set{ _RMB = value; }
				}
                   
				  
										String  _ChineseMoney = string.Empty;
							        
				public String ChineseMoney 
				{ 
					get{ return _ChineseMoney;  }
					set{ _ChineseMoney = value; }
				}
                   
				  
										String  _ContractBid = string.Empty;
							        
				public String ContractBid 
				{ 
					get{ return _ContractBid;  }
					set{ _ContractBid = value; }
				}
                   
				  
										Decimal  _TaxRate = 0;
							        
				public Decimal TaxRate 
				{ 
					get{ return _TaxRate;  }
					set{ _TaxRate = value; }
				}
                   
				  
										Decimal  _Taxes = 0;
							        
				public Decimal Taxes 
				{ 
					get{ return _Taxes;  }
					set{ _Taxes = value; }
				}
                   
				  
										String  _ContractRetnState = string.Empty;
							        
				public String ContractRetnState 
				{ 
					get{ return _ContractRetnState;  }
					set{ _ContractRetnState = value; }
				}
                   
				  
										DateTime  _ContractRetnDate = DateTime.Now;
							        
				public DateTime ContractRetnDate 
				{ 
					get{ return _ContractRetnDate;  }
					set{ _ContractRetnDate = value; }
				}
                   
				  
										String  _IsOut = string.Empty;
							        
				public String IsOut 
				{ 
					get{ return _IsOut;  }
					set{ _IsOut = value; }
				}
                   
				  
										String  _IsSeal = string.Empty;
							        
				public String IsSeal 
				{ 
					get{ return _IsSeal;  }
					set{ _IsSeal = value; }
				}
                   
				  
										DateTime  _FirstTrialDate = DateTime.Now;
							        
				public DateTime FirstTrialDate 
				{ 
					get{ return _FirstTrialDate;  }
					set{ _FirstTrialDate = value; }
				}
                   
				  
										String  _FirstTrialerId = string.Empty;
							        
				public String FirstTrialerId 
				{ 
					get{ return _FirstTrialerId;  }
					set{ _FirstTrialerId = value; }
				}
                   
				  
										String  _FirstTrialName = string.Empty;
							        
				public String FirstTrialName 
				{ 
					get{ return _FirstTrialName;  }
					set{ _FirstTrialName = value; }
				}
                   
				  
										Int32  _PrintCount = 0;
							        
				public Int32 PrintCount 
				{ 
					get{ return _PrintCount;  }
					set{ _PrintCount = value; }
				}
                   
				  
										String  _MoneyType = string.Empty;
							        
				public String MoneyType 
				{ 
					get{ return _MoneyType;  }
					set{ _MoneyType = value; }
				}
                   
				  
										String  _UsePrinterId = string.Empty;
							        
				public String UsePrinterId 
				{ 
					get{ return _UsePrinterId;  }
					set{ _UsePrinterId = value; }
				}
                   
				  
										String  _UsePrinterName = string.Empty;
							        
				public String UsePrinterName 
				{ 
					get{ return _UsePrinterName;  }
					set{ _UsePrinterName = value; }
				}
                   
				  
										DateTime  _UsePrintDate = DateTime.Now;
							        
				public DateTime UsePrintDate 
				{ 
					get{ return _UsePrintDate;  }
					set{ _UsePrintDate = value; }
				}
                   
				  
										String  _ContractGeterId = string.Empty;
							        
				public String ContractGeterId 
				{ 
					get{ return _ContractGeterId;  }
					set{ _ContractGeterId = value; }
				}
                   
				  
										String  _ContractGeterName = string.Empty;
							        
				public String ContractGeterName 
				{ 
					get{ return _ContractGeterName;  }
					set{ _ContractGeterName = value; }
				}
                   
				  
										DateTime  _ContractGeterDate = DateTime.Now;
							        
				public DateTime ContractGeterDate 
				{ 
					get{ return _ContractGeterDate;  }
					set{ _ContractGeterDate = value; }
				}
                   
				  
										String  _ContractGeteSit = string.Empty;
							        
				public String ContractGeteSit 
				{ 
					get{ return _ContractGeteSit;  }
					set{ _ContractGeteSit = value; }
				}
                   
				  
										String  _SendConterId = string.Empty;
							        
				public String SendConterId 
				{ 
					get{ return _SendConterId;  }
					set{ _SendConterId = value; }
				}
                   
				  
										String  _SendConterName = string.Empty;
							        
				public String SendConterName 
				{ 
					get{ return _SendConterName;  }
					set{ _SendConterName = value; }
				}
                   
				  
										DateTime  _SendConteDate = DateTime.Now;
							        
				public DateTime SendConteDate 
				{ 
					get{ return _SendConteDate;  }
					set{ _SendConteDate = value; }
				}
                   
				  
										Int32  _SendConteCount = 0;
							        
				public Int32 SendConteCount 
				{ 
					get{ return _SendConteCount;  }
					set{ _SendConteCount = value; }
				}
                   
				  
										String  _Files = string.Empty;
							        
				public String Files 
				{ 
					get{ return _Files;  }
					set{ _Files = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
				}
                   
				  
										String  _State = string.Empty;
							        
				public String State 
				{ 
					get{ return _State;  }
					set{ _State = value; }
				}
                   
				  
										DateTime  _StartChuSDate = DateTime.Now;
							        
				public DateTime StartChuSDate 
				{ 
					get{ return _StartChuSDate;  }
					set{ _StartChuSDate = value; }
				}
                   
				  
										DateTime  _EndChuSDate = DateTime.Now;
							        
				public DateTime EndChuSDate 
				{ 
					get{ return _EndChuSDate;  }
					set{ _EndChuSDate = value; }
				}
                   
				  
										DateTime  _StartFuSDate = DateTime.Now;
							        
				public DateTime StartFuSDate 
				{ 
					get{ return _StartFuSDate;  }
					set{ _StartFuSDate = value; }
				}
                   
				  
										DateTime  _EndFuSDate = DateTime.Now;
							        
				public DateTime EndFuSDate 
				{ 
					get{ return _EndFuSDate;  }
					set{ _EndFuSDate = value; }
				}
                   
				  
										DateTime  _StartLDSDate = DateTime.Now;
							        
				public DateTime StartLDSDate 
				{ 
					get{ return _StartLDSDate;  }
					set{ _StartLDSDate = value; }
				}
                   
				  
										DateTime  _EndLDSDate = DateTime.Now;
							        
				public DateTime EndLDSDate 
				{ 
					get{ return _EndLDSDate;  }
					set{ _EndLDSDate = value; }
				}
                   
				  
										DateTime  _StartGDDate = DateTime.Now;
							        
				public DateTime StartGDDate 
				{ 
					get{ return _StartGDDate;  }
					set{ _StartGDDate = value; }
				}
                   
				  
										DateTime  _EndGDDate = DateTime.Now;
							        
				public DateTime EndGDDate 
				{ 
					get{ return _EndGDDate;  }
					set{ _EndGDDate = value; }
				}
                   
				  
										String  _FlowId = string.Empty;
							        
				public String FlowId 
				{ 
					get{ return _FlowId;  }
					set{ _FlowId = value; }
				}
                   
				  
										String  _IsDept = string.Empty;
							        
				public String IsDept 
				{ 
					get{ return _IsDept;  }
					set{ _IsDept = value; }
				}
                   
				  
										Int32  _Weight = 0;
							        
				public Int32 Weight 
				{ 
					get{ return _Weight;  }
					set{ _Weight = value; }
				}
                   
				  
										String  _ChuSPersonId = string.Empty;
							        
				public String ChuSPersonId 
				{ 
					get{ return _ChuSPersonId;  }
					set{ _ChuSPersonId = value; }
				}
                   
				  
										String  _ChuSPersonName = string.Empty;
							        
				public String ChuSPersonName 
				{ 
					get{ return _ChuSPersonName;  }
					set{ _ChuSPersonName = value; }
				}
                   
				  
										String  _FuSPersonId = string.Empty;
							        
				public String FuSPersonId 
				{ 
					get{ return _FuSPersonId;  }
					set{ _FuSPersonId = value; }
				}
                   
				  
										String  _FuSPersonName = string.Empty;
							        
				public String FuSPersonName 
				{ 
					get{ return _FuSPersonName;  }
					set{ _FuSPersonName = value; }
				}
                   
				  
										String  _LDPersonId = string.Empty;
							        
				public String LDPersonId 
				{ 
					get{ return _LDPersonId;  }
					set{ _LDPersonId = value; }
				}
                   
				  
										String  _LDPersonName = string.Empty;
							        
				public String LDPersonName 
				{ 
					get{ return _LDPersonName;  }
					set{ _LDPersonName = value; }
				}
                   
				  
										String  _GUIDPersonId = string.Empty;
							        
				public String GUIDPersonId 
				{ 
					get{ return _GUIDPersonId;  }
					set{ _GUIDPersonId = value; }
				}
                   
				  
										String  _GUIDPersonName = string.Empty;
							        
				public String GUIDPersonName 
				{ 
					get{ return _GUIDPersonName;  }
					set{ _GUIDPersonName = value; }
				}
                   
				  
										String  _IdeaId = string.Empty;
							        
				public String IdeaId 
				{ 
					get{ return _IdeaId;  }
					set{ _IdeaId = value; }
				}
                   
				  
										String  _AAAAAAAAAAAAAAAAA = string.Empty;
							        
				public String AAAAAAAAAAAAAAAAA 
				{ 
					get{ return _AAAAAAAAAAAAAAAAA;  }
					set{ _AAAAAAAAAAAAAAAAA = value; }
				}
                   
				  
										String  _PrjName = string.Empty;
							        
				public String PrjName 
				{ 
					get{ return _PrjName;  }
					set{ _PrjName = value; }
				}
                   
				  
										String  _PayOutItem = string.Empty;
							        
				public String PayOutItem 
				{ 
					get{ return _PayOutItem;  }
					set{ _PayOutItem = value; }
				}
                   
				  
										String  _ClientPhone = string.Empty;
							        
				public String ClientPhone 
				{ 
					get{ return _ClientPhone;  }
					set{ _ClientPhone = value; }
				}
                   
				  
										String  _ClientLinkMan = string.Empty;
							        
				public String ClientLinkMan 
				{ 
					get{ return _ClientLinkMan;  }
					set{ _ClientLinkMan = value; }
				}
                   
				  
										String  _ScientificType = string.Empty;
							        
				public String ScientificType 
				{ 
					get{ return _ScientificType;  }
					set{ _ScientificType = value; }
				}
                   
				  
										String  _OtherType = string.Empty;
							        
				public String OtherType 
				{ 
					get{ return _OtherType;  }
					set{ _OtherType = value; }
				}
                   
				  
										DateTime  _ContractStart = DateTime.Now;
							        
				public DateTime ContractStart 
				{ 
					get{ return _ContractStart;  }
					set{ _ContractStart = value; }
				}
                   
				  
										DateTime  _ContractEnd = DateTime.Now;
							        
				public DateTime ContractEnd 
				{ 
					get{ return _ContractEnd;  }
					set{ _ContractEnd = value; }
				}
                   
				  
										String  _FundsSource = string.Empty;
							        
				public String FundsSource 
				{ 
					get{ return _FundsSource;  }
					set{ _FundsSource = value; }
				}
                   
				  
										String  _MoneyPayWay = string.Empty;
							        
				public String MoneyPayWay 
				{ 
					get{ return _MoneyPayWay;  }
					set{ _MoneyPayWay = value; }
				}
                   
				  
										String  _ContractObjectId = string.Empty;
							        
				public String ContractObjectId 
				{ 
					get{ return _ContractObjectId;  }
					set{ _ContractObjectId = value; }
				}
                   
				  
										String  _ContractObjectName = string.Empty;
							        
				public String ContractObjectName 
				{ 
					get{ return _ContractObjectName;  }
					set{ _ContractObjectName = value; }
				}
                   
				  
										Decimal  _TotalSum = 0;
							        
				public Decimal TotalSum 
				{ 
					get{ return _TotalSum;  }
					set{ _TotalSum = value; }
				}
                   
				  
										String  _TotalSumType = string.Empty;
							        
				public String TotalSumType 
				{ 
					get{ return _TotalSumType;  }
					set{ _TotalSumType = value; }
				}
                   
				  
										String  _LaboratoryName = string.Empty;
							        
				public String LaboratoryName 
				{ 
					get{ return _LaboratoryName;  }
					set{ _LaboratoryName = value; }
				}
                   
				  
										String  _LaboratoryId = string.Empty;
							        
				public String LaboratoryId 
				{ 
					get{ return _LaboratoryId;  }
					set{ _LaboratoryId = value; }
				}
                   
				  
										String  _MainJoinerId = string.Empty;
							        
				public String MainJoinerId 
				{ 
					get{ return _MainJoinerId;  }
					set{ _MainJoinerId = value; }
				}
                   
				  
										String  _MainJoinerName = string.Empty;
							        
				public String MainJoinerName 
				{ 
					get{ return _MainJoinerName;  }
					set{ _MainJoinerName = value; }
				}
                   
				  
										Int32  _JoinerCount = 0;
							        
				public Int32 JoinerCount 
				{ 
					get{ return _JoinerCount;  }
					set{ _JoinerCount = value; }
				}
                   
				  
										Int32  _StudyCount = 0;
							        
				public Int32 StudyCount 
				{ 
					get{ return _StudyCount;  }
					set{ _StudyCount = value; }
				}
                   
				  
										Int32  _TechCount = 0;
							        
				public Int32 TechCount 
				{ 
					get{ return _TechCount;  }
					set{ _TechCount = value; }
				}
                   
				  
										Int32  _AssistCount = 0;
							        
				public Int32 AssistCount 
				{ 
					get{ return _AssistCount;  }
					set{ _AssistCount = value; }
				}
                   
				  
										String  _Country = string.Empty;
							        
				public String Country 
				{ 
					get{ return _Country;  }
					set{ _Country = value; }
				}
                   
				  
										String  _Province = string.Empty;
							        
				public String Province 
				{ 
					get{ return _Province;  }
					set{ _Province = value; }
				}
                   
				  
										String  _City = string.Empty;
							        
				public String City 
				{ 
					get{ return _City;  }
					set{ _City = value; }
				}
                   
				  
										String  _County = string.Empty;
							        
				public String County 
				{ 
					get{ return _County;  }
					set{ _County = value; }
				}
                   
				  
										String  _OtherCountry = string.Empty;
							        
				public String OtherCountry 
				{ 
					get{ return _OtherCountry;  }
					set{ _OtherCountry = value; }
				}
                   
				  
										String  _MessageAddress = string.Empty;
							        
				public String MessageAddress 
				{ 
					get{ return _MessageAddress;  }
					set{ _MessageAddress = value; }
				}
                   
				  
										String  _LawerName = string.Empty;
							        
				public String LawerName 
				{ 
					get{ return _LawerName;  }
					set{ _LawerName = value; }
				}
                   
				  
										String  _LawPhone = string.Empty;
							        
				public String LawPhone 
				{ 
					get{ return _LawPhone;  }
					set{ _LawPhone = value; }
				}
                   
				  
										String  _ClientManager = string.Empty;
							        
				public String ClientManager 
				{ 
					get{ return _ClientManager;  }
					set{ _ClientManager = value; }
				}
                   
				  
										String  _ClientManagerPhone = string.Empty;
							        
				public String ClientManagerPhone 
				{ 
					get{ return _ClientManagerPhone;  }
					set{ _ClientManagerPhone = value; }
				}
                   
				  
										String  _TechnoExplain = string.Empty;
							        
				public String TechnoExplain 
				{ 
					get{ return _TechnoExplain;  }
					set{ _TechnoExplain = value; }
				}
                   
				  
										String  _ItemName = string.Empty;
							        
				public String ItemName 
				{ 
					get{ return _ItemName;  }
					set{ _ItemName = value; }
				}
                   
				  
										String  _ItemNumber = string.Empty;
							        
				public String ItemNumber 
				{ 
					get{ return _ItemNumber;  }
					set{ _ItemNumber = value; }
				}
                   
				  
										String  _OtherMoneyCome = string.Empty;
							        
				public String OtherMoneyCome 
				{ 
					get{ return _OtherMoneyCome;  }
					set{ _OtherMoneyCome = value; }
				}
                   
				  
										String  _PostCode = string.Empty;
							        
				public String PostCode 
				{ 
					get{ return _PostCode;  }
					set{ _PostCode = value; }
				}
                   
				  
										String  _ByDepartmentName = string.Empty;
							        
				public String ByDepartmentName 
				{ 
					get{ return _ByDepartmentName;  }
					set{ _ByDepartmentName = value; }
				}
                   
				  
										String  _ByDepartmentId = string.Empty;
							        
				public String ByDepartmentId 
				{ 
					get{ return _ByDepartmentId;  }
					set{ _ByDepartmentId = value; }
				}
                   
				  
										String  _HGSupplier = string.Empty;
							        
				public String HGSupplier 
				{ 
					get{ return _HGSupplier;  }
					set{ _HGSupplier = value; }
				}
                   
				  
										String  _BBBBBBBBBBBBBBBBBB = string.Empty;
							        
				public String BBBBBBBBBBBBBBBBBB 
				{ 
					get{ return _BBBBBBBBBBBBBBBBBB;  }
					set{ _BBBBBBBBBBBBBBBBBB = value; }
				}
                   
				  
										String  _IsApply_CDBMLD = string.Empty;
							        
				public String IsApply_CDBMLD 
				{ 
					get{ return _IsApply_CDBMLD;  }
					set{ _IsApply_CDBMLD = value; }
				}
                   
				  
										String  _IsApply_CDBMLD_Idear = string.Empty;
							        
				public String IsApply_CDBMLD_Idear 
				{ 
					get{ return _IsApply_CDBMLD_Idear;  }
					set{ _IsApply_CDBMLD_Idear = value; }
				}
                   
				  
										String  _IsApply_GJBLD = string.Empty;
							        
				public String IsApply_GJBLD 
				{ 
					get{ return _IsApply_GJBLD;  }
					set{ _IsApply_GJBLD = value; }
				}
                   
				  
										String  _IsApply_GJBLD_Idear = string.Empty;
							        
				public String IsApply_GJBLD_Idear 
				{ 
					get{ return _IsApply_GJBLD_Idear;  }
					set{ _IsApply_GJBLD_Idear = value; }
				}
                   
				  
										String  _IsApply_GKBMLD = string.Empty;
							        
				public String IsApply_GKBMLD 
				{ 
					get{ return _IsApply_GKBMLD;  }
					set{ _IsApply_GKBMLD = value; }
				}
                   
				  
										String  _IsApply_GKBMLD_Idear = string.Empty;
							        
				public String IsApply_GKBMLD_Idear 
				{ 
					get{ return _IsApply_GKBMLD_Idear;  }
					set{ _IsApply_GKBMLD_Idear = value; }
				}
                   
				  
										String  _IsApply_FSBLD = string.Empty;
							        
				public String IsApply_FSBLD 
				{ 
					get{ return _IsApply_FSBLD;  }
					set{ _IsApply_FSBLD = value; }
				}
                   
				  
										String  _IsApply_FSBLD_Idear = string.Empty;
							        
				public String IsApply_FSBLD_Idear 
				{ 
					get{ return _IsApply_FSBLD_Idear;  }
					set{ _IsApply_FSBLD_Idear = value; }
				}
                   
				  
										String  _IsApply_YWBLD = string.Empty;
							        
				public String IsApply_YWBLD 
				{ 
					get{ return _IsApply_YWBLD;  }
					set{ _IsApply_YWBLD = value; }
				}
                   
				  
										String  _IsApply_YWBLD_Idear = string.Empty;
							        
				public String IsApply_YWBLD_Idear 
				{ 
					get{ return _IsApply_YWBLD_Idear;  }
					set{ _IsApply_YWBLD_Idear = value; }
				}
                   
				  
										String  _Law_Idea = string.Empty;
							        
				public String Law_Idea 
				{ 
					get{ return _Law_Idea;  }
					set{ _Law_Idea = value; }
				}
                   
				  
										String  _Law_IsSonContract = string.Empty;
							        
				public String Law_IsSonContract 
				{ 
					get{ return _Law_IsSonContract;  }
					set{ _Law_IsSonContract = value; }
				}
                   
				  
										String  _Law_OriginalNum = string.Empty;
							        
				public String Law_OriginalNum 
				{ 
					get{ return _Law_OriginalNum;  }
					set{ _Law_OriginalNum = value; }
				}
                   
				  
										String  _Law_Subunit = string.Empty;
							        
				public String Law_Subunit 
				{ 
					get{ return _Law_Subunit;  }
					set{ _Law_Subunit = value; }
				}
                   
				  
										DateTime  _KY_CompleteDate = DateTime.Now;
							        
				public DateTime KY_CompleteDate 
				{ 
					get{ return _KY_CompleteDate;  }
					set{ _KY_CompleteDate = value; }
				}
                   
				  
										String  _Law_ContractSort = string.Empty;
							        
				public String Law_ContractSort 
				{ 
					get{ return _Law_ContractSort;  }
					set{ _Law_ContractSort = value; }
				}
                   
				  
										String  _MainJoinerId2 = string.Empty;
							        
				public String MainJoinerId2 
				{ 
					get{ return _MainJoinerId2;  }
					set{ _MainJoinerId2 = value; }
				}
                   
				  
										String  _OtherSort = string.Empty;
							        
				public String OtherSort 
				{ 
					get{ return _OtherSort;  }
					set{ _OtherSort = value; }
				}
                   
				  
										String  _ProblemSort = string.Empty;
							        
				public String ProblemSort 
				{ 
					get{ return _ProblemSort;  }
					set{ _ProblemSort = value; }
				}
                   
				  
										String  _ProblemOtherSort = string.Empty;
							        
				public String ProblemOtherSort 
				{ 
					get{ return _ProblemOtherSort;  }
					set{ _ProblemOtherSort = value; }
				}
                   
				  
										String  _ProblemNumber = string.Empty;
							        
				public String ProblemNumber 
				{ 
					get{ return _ProblemNumber;  }
					set{ _ProblemNumber = value; }
				}
                   
				  
										String  _BelongProjectName = string.Empty;
							        
				public String BelongProjectName 
				{ 
					get{ return _BelongProjectName;  }
					set{ _BelongProjectName = value; }
				}
                   
				  
										Decimal  _SelfExpenditure = 0;
							        
				public Decimal SelfExpenditure 
				{ 
					get{ return _SelfExpenditure;  }
					set{ _SelfExpenditure = value; }
				}
                   
				  
										String  _BelongProjectNumber = string.Empty;
							        
				public String BelongProjectNumber 
				{ 
					get{ return _BelongProjectNumber;  }
					set{ _BelongProjectNumber = value; }
				}
                   
				  
										String  _MoneyTypeSE = string.Empty;
							        
				public String MoneyTypeSE 
				{ 
					get{ return _MoneyTypeSE;  }
					set{ _MoneyTypeSE = value; }
				}
                   
				  
										String  _Sync = string.Empty;
							        
				public String Sync 
				{ 
					get{ return _Sync;  }
					set{ _Sync = value; }
				}
                   
				  
										String  _TaxRateType = string.Empty;
							        
				public String TaxRateType 
				{ 
					get{ return _TaxRateType;  }
					set{ _TaxRateType = value; }
				}
                      				        
			}               
			                   
}
 
			