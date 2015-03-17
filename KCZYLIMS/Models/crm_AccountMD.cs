          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_AccountMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
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
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										String  _ParentName = string.Empty;
							        
				public String ParentName 
				{ 
					get{ return _ParentName;  }
					set{ _ParentName = value; }
				}
                   
				  
										Int32  _AccountContactID = 0;
							        
				public Int32 AccountContactID 
				{ 
					get{ return _AccountContactID;  }
					set{ _AccountContactID = value; }
				}
                   
				  
										String  _Level = string.Empty;
							        
				public String Level 
				{ 
					get{ return _Level;  }
					set{ _Level = value; }
				}
                   
				  
										String  _Industry = string.Empty;
							        
				public String Industry 
				{ 
					get{ return _Industry;  }
					set{ _Industry = value; }
				}
                   
				  
										String  _IndustryDesc = string.Empty;
							        
				public String IndustryDesc 
				{ 
					get{ return _IndustryDesc;  }
					set{ _IndustryDesc = value; }
				}
                   
				  
										String  _Source = string.Empty;
							        
				public String Source 
				{ 
					get{ return _Source;  }
					set{ _Source = value; }
				}
                   
				  
										Int32  _PrincipalID = 0;
							        
				public Int32 PrincipalID 
				{ 
					get{ return _PrincipalID;  }
					set{ _PrincipalID = value; }
				}
                   
				  
										String  _PrincipalName = string.Empty;
							        
				public String PrincipalName 
				{ 
					get{ return _PrincipalName;  }
					set{ _PrincipalName = value; }
				}
                   
				  
										String  _AddressProvince = string.Empty;
							        
				public String AddressProvince 
				{ 
					get{ return _AddressProvince;  }
					set{ _AddressProvince = value; }
				}
                   
				  
										String  _AddressCity = string.Empty;
							        
				public String AddressCity 
				{ 
					get{ return _AddressCity;  }
					set{ _AddressCity = value; }
				}
                   
				  
										String  _AddressCountry = string.Empty;
							        
				public String AddressCountry 
				{ 
					get{ return _AddressCountry;  }
					set{ _AddressCountry = value; }
				}
                   
				  
										String  _Address = string.Empty;
							        
				public String Address 
				{ 
					get{ return _Address;  }
					set{ _Address = value; }
				}
                   
				  
										String  _DeliveryCountry = string.Empty;
							        
				public String DeliveryCountry 
				{ 
					get{ return _DeliveryCountry;  }
					set{ _DeliveryCountry = value; }
				}
                   
				  
										String  _DeliveryCity = string.Empty;
							        
				public String DeliveryCity 
				{ 
					get{ return _DeliveryCity;  }
					set{ _DeliveryCity = value; }
				}
                   
				  
										String  _Bank = string.Empty;
							        
				public String Bank 
				{ 
					get{ return _Bank;  }
					set{ _Bank = value; }
				}
                   
				  
										String  _BankAccount = string.Empty;
							        
				public String BankAccount 
				{ 
					get{ return _BankAccount;  }
					set{ _BankAccount = value; }
				}
                   
				  
										String  _Credit = string.Empty;
							        
				public String Credit 
				{ 
					get{ return _Credit;  }
					set{ _Credit = value; }
				}
                   
				  
										DateTime  _LastFollowDate = DateTime.Now;
							        
				public DateTime LastFollowDate 
				{ 
					get{ return _LastFollowDate;  }
					set{ _LastFollowDate = value; }
				}
                   
				  
										String  _Comment = string.Empty;
							        
				public String Comment 
				{ 
					get{ return _Comment;  }
					set{ _Comment = value; }
				}
                   
				  
										Decimal  _TurnOver = 0;
							        
				public Decimal TurnOver 
				{ 
					get{ return _TurnOver;  }
					set{ _TurnOver = value; }
				}
                   
				  
										String  _Url = string.Empty;
							        
				public String Url 
				{ 
					get{ return _Url;  }
					set{ _Url = value; }
				}
                   
				  
										String  _CompanyNature = string.Empty;
							        
				public String CompanyNature 
				{ 
					get{ return _CompanyNature;  }
					set{ _CompanyNature = value; }
				}
                   
				  
										String  _MyStatus = string.Empty;
							        
				public String MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										String  _MyLabel = string.Empty;
							        
				public String MyLabel 
				{ 
					get{ return _MyLabel;  }
					set{ _MyLabel = value; }
				}
                   
				  
										String  _CustomerRelation = string.Empty;
							        
				public String CustomerRelation 
				{ 
					get{ return _CustomerRelation;  }
					set{ _CustomerRelation = value; }
				}
                   
				  
										String  _CustomerPhase = string.Empty;
							        
				public String CustomerPhase 
				{ 
					get{ return _CustomerPhase;  }
					set{ _CustomerPhase = value; }
				}
                   
				  
										String  _CustomerKind = string.Empty;
							        
				public String CustomerKind 
				{ 
					get{ return _CustomerKind;  }
					set{ _CustomerKind = value; }
				}
                   
				  
										String  _IsHotSpot = string.Empty;
							        
				public String IsHotSpot 
				{ 
					get{ return _IsHotSpot;  }
					set{ _IsHotSpot = value; }
				}
                   
				  
										String  _CustomerScale = string.Empty;
							        
				public String CustomerScale 
				{ 
					get{ return _CustomerScale;  }
					set{ _CustomerScale = value; }
				}
                   
				  
										String  _GettingThere = string.Empty;
							        
				public String GettingThere 
				{ 
					get{ return _GettingThere;  }
					set{ _GettingThere = value; }
				}
                   
				  
										String  _DeliveryAddresss = string.Empty;
							        
				public String DeliveryAddresss 
				{ 
					get{ return _DeliveryAddresss;  }
					set{ _DeliveryAddresss = value; }
				}
                   
				  
										String  _PayAddress = string.Empty;
							        
				public String PayAddress 
				{ 
					get{ return _PayAddress;  }
					set{ _PayAddress = value; }
				}
                   
				  
										String  _BankPerson = string.Empty;
							        
				public String BankPerson 
				{ 
					get{ return _BankPerson;  }
					set{ _BankPerson = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _OrigItemID = 0;
							        
				public Int32 OrigItemID 
				{ 
					get{ return _OrigItemID;  }
					set{ _OrigItemID = value; }
				}
                   
				  
										String  _Post = string.Empty;
							        
				public String Post 
				{ 
					get{ return _Post;  }
					set{ _Post = value; }
				}
                      				        
			}               
			                   
}
 
			