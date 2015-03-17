          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_OpportunityMD : EntityMD                     
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
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										String  _ModifierBy = string.Empty;
							        
				public String ModifierBy 
				{ 
					get{ return _ModifierBy;  }
					set{ _ModifierBy = value; }
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
                   
				  
										Int32  _ContactID = 0;
							        
				public Int32 ContactID 
				{ 
					get{ return _ContactID;  }
					set{ _ContactID = value; }
				}
                   
				  
										String  _ContactName = string.Empty;
							        
				public String ContactName 
				{ 
					get{ return _ContactName;  }
					set{ _ContactName = value; }
				}
                   
				  
										DateTime  _LastFlollowTime = DateTime.Now;
							        
				public DateTime LastFlollowTime 
				{ 
					get{ return _LastFlollowTime;  }
					set{ _LastFlollowTime = value; }
				}
                   
				  
										String  _Type = string.Empty;
							        
				public String Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                   
				  
										String  _Phase = string.Empty;
							        
				public String Phase 
				{ 
					get{ return _Phase;  }
					set{ _Phase = value; }
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
                   
				  
										Int32  _ProviderUserID = 0;
							        
				public Int32 ProviderUserID 
				{ 
					get{ return _ProviderUserID;  }
					set{ _ProviderUserID = value; }
				}
                   
				  
										String  _ProviderName = string.Empty;
							        
				public String ProviderName 
				{ 
					get{ return _ProviderName;  }
					set{ _ProviderName = value; }
				}
                   
				  
										Int32  _PrincipalDepID = 0;
							        
				public Int32 PrincipalDepID 
				{ 
					get{ return _PrincipalDepID;  }
					set{ _PrincipalDepID = value; }
				}
                   
				  
										String  _PrincipalDep = string.Empty;
							        
				public String PrincipalDep 
				{ 
					get{ return _PrincipalDep;  }
					set{ _PrincipalDep = value; }
				}
                   
				  
										String  _Probability = string.Empty;
							        
				public String Probability 
				{ 
					get{ return _Probability;  }
					set{ _Probability = value; }
				}
                   
				  
										String  _Status = string.Empty;
							        
				public String Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
				}
                   
				  
										String  _Description = string.Empty;
							        
				public String Description 
				{ 
					get{ return _Description;  }
					set{ _Description = value; }
				}
                   
				  
										DateTime  _ExpectedDealTtime = DateTime.Now;
							        
				public DateTime ExpectedDealTtime 
				{ 
					get{ return _ExpectedDealTtime;  }
					set{ _ExpectedDealTtime = value; }
				}
                   
				  
										Decimal  _ExpectedTurnover = 0;
							        
				public Decimal ExpectedTurnover 
				{ 
					get{ return _ExpectedTurnover;  }
					set{ _ExpectedTurnover = value; }
				}
                   
				  
										DateTime  _DealTime = DateTime.Now;
							        
				public DateTime DealTime 
				{ 
					get{ return _DealTime;  }
					set{ _DealTime = value; }
				}
                   
				  
										Decimal  _Turnover = 0;
							        
				public Decimal Turnover 
				{ 
					get{ return _Turnover;  }
					set{ _Turnover = value; }
				}
                   
				  
										Int32  _QuotationID = 0;
							        
				public Int32 QuotationID 
				{ 
					get{ return _QuotationID;  }
					set{ _QuotationID = value; }
				}
                   
				  
										String  _QuotationName = string.Empty;
							        
				public String QuotationName 
				{ 
					get{ return _QuotationName;  }
					set{ _QuotationName = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Int32  _OrigItemID = 0;
							        
				public Int32 OrigItemID 
				{ 
					get{ return _OrigItemID;  }
					set{ _OrigItemID = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										String  _SalesCode = string.Empty;
							        
				public String SalesCode 
				{ 
					get{ return _SalesCode;  }
					set{ _SalesCode = value; }
				}
                      				        
			}               
			                   
}
 
			