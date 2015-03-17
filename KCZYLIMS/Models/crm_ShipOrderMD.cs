          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ShipOrderMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										String  _CreatBy = string.Empty;
							        
				public String CreatBy 
				{ 
					get{ return _CreatBy;  }
					set{ _CreatBy = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
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
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _ShipOrderID = string.Empty;
							        
				public String ShipOrderID 
				{ 
					get{ return _ShipOrderID;  }
					set{ _ShipOrderID = value; }
				}
                   
				  
										DateTime  _ShipDate = DateTime.Now;
							        
				public DateTime ShipDate 
				{ 
					get{ return _ShipDate;  }
					set{ _ShipDate = value; }
				}
                   
				  
										Int32  _Quantity = 0;
							        
				public Int32 Quantity 
				{ 
					get{ return _Quantity;  }
					set{ _Quantity = value; }
				}
                   
				  
										String  _Unit = string.Empty;
							        
				public String Unit 
				{ 
					get{ return _Unit;  }
					set{ _Unit = value; }
				}
                   
				  
										String  _TotalWeight = string.Empty;
							        
				public String TotalWeight 
				{ 
					get{ return _TotalWeight;  }
					set{ _TotalWeight = value; }
				}
                   
				  
										Int32  _DeliveryCustomerID = 0;
							        
				public Int32 DeliveryCustomerID 
				{ 
					get{ return _DeliveryCustomerID;  }
					set{ _DeliveryCustomerID = value; }
				}
                   
				  
										String  _DeliveryCustomer = string.Empty;
							        
				public String DeliveryCustomer 
				{ 
					get{ return _DeliveryCustomer;  }
					set{ _DeliveryCustomer = value; }
				}
                   
				  
										String  _DeliveryAddress = string.Empty;
							        
				public String DeliveryAddress 
				{ 
					get{ return _DeliveryAddress;  }
					set{ _DeliveryAddress = value; }
				}
                   
				  
										String  _DeliveryAccount = string.Empty;
							        
				public String DeliveryAccount 
				{ 
					get{ return _DeliveryAccount;  }
					set{ _DeliveryAccount = value; }
				}
                   
				  
										String  _DeliveryPhone = string.Empty;
							        
				public String DeliveryPhone 
				{ 
					get{ return _DeliveryPhone;  }
					set{ _DeliveryPhone = value; }
				}
                   
				  
										String  _TransportCompany = string.Empty;
							        
				public String TransportCompany 
				{ 
					get{ return _TransportCompany;  }
					set{ _TransportCompany = value; }
				}
                   
				  
										String  _PickupContact = string.Empty;
							        
				public String PickupContact 
				{ 
					get{ return _PickupContact;  }
					set{ _PickupContact = value; }
				}
                   
				  
										String  _Freight = string.Empty;
							        
				public String Freight 
				{ 
					get{ return _Freight;  }
					set{ _Freight = value; }
				}
                   
				  
										String  _PackRequirement = string.Empty;
							        
				public String PackRequirement 
				{ 
					get{ return _PackRequirement;  }
					set{ _PackRequirement = value; }
				}
                   
				  
										Int32  _AccountID = 0;
							        
				public Int32 AccountID 
				{ 
					get{ return _AccountID;  }
					set{ _AccountID = value; }
				}
                   
				  
										String  _AccountName = string.Empty;
							        
				public String AccountName 
				{ 
					get{ return _AccountName;  }
					set{ _AccountName = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
				}
                   
				  
										String  _MarketingDep = string.Empty;
							        
				public String MarketingDep 
				{ 
					get{ return _MarketingDep;  }
					set{ _MarketingDep = value; }
				}
                   
				  
										String  _IntegratedDep = string.Empty;
							        
				public String IntegratedDep 
				{ 
					get{ return _IntegratedDep;  }
					set{ _IntegratedDep = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _OrigID = 0;
							        
				public Int32 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                      				        
			}               
			                   
}
 
			