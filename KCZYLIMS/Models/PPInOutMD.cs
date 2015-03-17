          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class PPInOutMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _MyStatus = 0;
							        
				public Int32 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										Double  _Quantity = 0;
							        
				public Double Quantity 
				{ 
					get{ return _Quantity;  }
					set{ _Quantity = value; }
				}
                   
				  
										Double  _UnitPrice = 0;
							        
				public Double UnitPrice 
				{ 
					get{ return _UnitPrice;  }
					set{ _UnitPrice = value; }
				}
                   
				  
										String  _BatchNumber = string.Empty;
							        
				public String BatchNumber 
				{ 
					get{ return _BatchNumber;  }
					set{ _BatchNumber = value; }
				}
                   
				  
										String  _SerialNumber = string.Empty;
							        
				public String SerialNumber 
				{ 
					get{ return _SerialNumber;  }
					set{ _SerialNumber = value; }
				}
                   
				  
										Int32  _UserID = 0;
							        
				public Int32 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _UserName = string.Empty;
							        
				public String UserName 
				{ 
					get{ return _UserName;  }
					set{ _UserName = value; }
				}
                   
				  
										DateTime  _UserTime = DateTime.Now;
							        
				public DateTime UserTime 
				{ 
					get{ return _UserTime;  }
					set{ _UserTime = value; }
				}
                   
				  
										Int32  _OperatorID = 0;
							        
				public Int32 OperatorID 
				{ 
					get{ return _OperatorID;  }
					set{ _OperatorID = value; }
				}
                   
				  
										String  _OperatorName = string.Empty;
							        
				public String OperatorName 
				{ 
					get{ return _OperatorName;  }
					set{ _OperatorName = value; }
				}
                   
				  
										DateTime  _OperatingTime = DateTime.Now;
							        
				public DateTime OperatingTime 
				{ 
					get{ return _OperatingTime;  }
					set{ _OperatingTime = value; }
				}
                   
				  
										Int32  _LinkedFromID = 0;
							        
				public Int32 LinkedFromID 
				{ 
					get{ return _LinkedFromID;  }
					set{ _LinkedFromID = value; }
				}
                   
				  
										String  _LinkedFromFullName = string.Empty;
							        
				public String LinkedFromFullName 
				{ 
					get{ return _LinkedFromFullName;  }
					set{ _LinkedFromFullName = value; }
				}
                   
				  
										Int32  _LinkedFromType = 0;
							        
				public Int32 LinkedFromType 
				{ 
					get{ return _LinkedFromType;  }
					set{ _LinkedFromType = value; }
				}
                   
				  
										Byte  _LinkedFromModuleID = 0;
							        
				public Byte LinkedFromModuleID 
				{ 
					get{ return _LinkedFromModuleID;  }
					set{ _LinkedFromModuleID = value; }
				}
                   
				  
										Int32  _LinkedToID = 0;
							        
				public Int32 LinkedToID 
				{ 
					get{ return _LinkedToID;  }
					set{ _LinkedToID = value; }
				}
                   
				  
										String  _LinkedToFullName = string.Empty;
							        
				public String LinkedToFullName 
				{ 
					get{ return _LinkedToFullName;  }
					set{ _LinkedToFullName = value; }
				}
                   
				  
										Int32  _LinkedToType = 0;
							        
				public Int32 LinkedToType 
				{ 
					get{ return _LinkedToType;  }
					set{ _LinkedToType = value; }
				}
                   
				  
										Byte  _LinkedToModuleID = 0;
							        
				public Byte LinkedToModuleID 
				{ 
					get{ return _LinkedToModuleID;  }
					set{ _LinkedToModuleID = value; }
				}
                   
				  
										DateTime  _DateOfManufacture = DateTime.Now;
							        
				public DateTime DateOfManufacture 
				{ 
					get{ return _DateOfManufacture;  }
					set{ _DateOfManufacture = value; }
				}
                   
				  
										Int32  _SupplierID = 0;
							        
				public Int32 SupplierID 
				{ 
					get{ return _SupplierID;  }
					set{ _SupplierID = value; }
				}
                   
				  
										String  _SupplierName = string.Empty;
							        
				public String SupplierName 
				{ 
					get{ return _SupplierName;  }
					set{ _SupplierName = value; }
				}
                   
				  
										String  _StockHouseName = string.Empty;
							        
				public String StockHouseName 
				{ 
					get{ return _StockHouseName;  }
					set{ _StockHouseName = value; }
				}
                   
				  
										String  _StockRackName = string.Empty;
							        
				public String StockRackName 
				{ 
					get{ return _StockRackName;  }
					set{ _StockRackName = value; }
				}
                   
				  
										Decimal  _PackageLength = 0;
							        
				public Decimal PackageLength 
				{ 
					get{ return _PackageLength;  }
					set{ _PackageLength = value; }
				}
                   
				  
										Decimal  _PackageWidth = 0;
							        
				public Decimal PackageWidth 
				{ 
					get{ return _PackageWidth;  }
					set{ _PackageWidth = value; }
				}
                   
				  
										Decimal  _PackageHeight = 0;
							        
				public Decimal PackageHeight 
				{ 
					get{ return _PackageHeight;  }
					set{ _PackageHeight = value; }
				}
                   
				  
										Int32  _PackageSizeUnit = 0;
							        
				public Int32 PackageSizeUnit 
				{ 
					get{ return _PackageSizeUnit;  }
					set{ _PackageSizeUnit = value; }
				}
                   
				  
										Decimal  _PackageWeight = 0;
							        
				public Decimal PackageWeight 
				{ 
					get{ return _PackageWeight;  }
					set{ _PackageWeight = value; }
				}
                   
				  
										Int32  _PackageWeightUnit = 0;
							        
				public Int32 PackageWeightUnit 
				{ 
					get{ return _PackageWeightUnit;  }
					set{ _PackageWeightUnit = value; }
				}
                   
				  
										String  _OutSet = string.Empty;
							        
				public String OutSet 
				{ 
					get{ return _OutSet;  }
					set{ _OutSet = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Int32  _ProcID = 0;
							        
				public Int32 ProcID 
				{ 
					get{ return _ProcID;  }
					set{ _ProcID = value; }
				}
                   
				  
										Int32  _ProcType = 0;
							        
				public Int32 ProcType 
				{ 
					get{ return _ProcType;  }
					set{ _ProcType = value; }
				}
                   
				  
										Int32  _ProcModuleID = 0;
							        
				public Int32 ProcModuleID 
				{ 
					get{ return _ProcModuleID;  }
					set{ _ProcModuleID = value; }
				}
                   
				  
										Int32  _IsCompleted = 0;
							        
				public Int32 IsCompleted 
				{ 
					get{ return _IsCompleted;  }
					set{ _IsCompleted = value; }
				}
                   
				  
										DateTime  _RealTime = DateTime.Now;
							        
				public DateTime RealTime 
				{ 
					get{ return _RealTime;  }
					set{ _RealTime = value; }
				}
                   
				  
										Double  _OtherQuantity = 0;
							        
				public Double OtherQuantity 
				{ 
					get{ return _OtherQuantity;  }
					set{ _OtherQuantity = value; }
				}
                   
				  
										String  _OtherMyNote = string.Empty;
							        
				public String OtherMyNote 
				{ 
					get{ return _OtherMyNote;  }
					set{ _OtherMyNote = value; }
				}
                   
				  
										String  _FixedAssetsCode = string.Empty;
							        
				public String FixedAssetsCode 
				{ 
					get{ return _FixedAssetsCode;  }
					set{ _FixedAssetsCode = value; }
				}
                   
				  
										String  _CardCode = string.Empty;
							        
				public String CardCode 
				{ 
					get{ return _CardCode;  }
					set{ _CardCode = value; }
				}
                   
				  
										Int32  _ProcurementApplicantID = 0;
							        
				public Int32 ProcurementApplicantID 
				{ 
					get{ return _ProcurementApplicantID;  }
					set{ _ProcurementApplicantID = value; }
				}
                   
				  
										String  _ProcurementApplicantFullName = string.Empty;
							        
				public String ProcurementApplicantFullName 
				{ 
					get{ return _ProcurementApplicantFullName;  }
					set{ _ProcurementApplicantFullName = value; }
				}
                   
				  
										String  _RoomNumber = string.Empty;
							        
				public String RoomNumber 
				{ 
					get{ return _RoomNumber;  }
					set{ _RoomNumber = value; }
				}
                   
				  
										DateTime  _UseDate = DateTime.Now;
							        
				public DateTime UseDate 
				{ 
					get{ return _UseDate;  }
					set{ _UseDate = value; }
				}
                   
				  
										Int16  _IsTotalAsset = 0;
							        
				public Int16 IsTotalAsset 
				{ 
					get{ return _IsTotalAsset;  }
					set{ _IsTotalAsset = value; }
				}
                   
				  
										Int32  _HolderID = 0;
							        
				public Int32 HolderID 
				{ 
					get{ return _HolderID;  }
					set{ _HolderID = value; }
				}
                   
				  
										String  _HolderFullName = string.Empty;
							        
				public String HolderFullName 
				{ 
					get{ return _HolderFullName;  }
					set{ _HolderFullName = value; }
				}
                   
				  
										Int32  _UseState = 0;
							        
				public Int32 UseState 
				{ 
					get{ return _UseState;  }
					set{ _UseState = value; }
				}
                   
				  
										String  _PurchaseContractNo = string.Empty;
							        
				public String PurchaseContractNo 
				{ 
					get{ return _PurchaseContractNo;  }
					set{ _PurchaseContractNo = value; }
				}
                   
				  
										String  _salesContractNo = string.Empty;
							        
				public String salesContractNo 
				{ 
					get{ return _salesContractNo;  }
					set{ _salesContractNo = value; }
				}
                   
				  
										Double  _NeedQuantity = 0;
							        
				public Double NeedQuantity 
				{ 
					get{ return _NeedQuantity;  }
					set{ _NeedQuantity = value; }
				}
                      				        
			}               
			                   
}
 
			