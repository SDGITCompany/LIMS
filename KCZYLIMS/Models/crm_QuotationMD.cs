          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_QuotationMD : EntityMD                     
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
                   
				  
										Int32  _OpportunityID = 0;
							        
				public Int32 OpportunityID 
				{ 
					get{ return _OpportunityID;  }
					set{ _OpportunityID = value; }
				}
                   
				  
										String  _OpportunityName = string.Empty;
							        
				public String OpportunityName 
				{ 
					get{ return _OpportunityName;  }
					set{ _OpportunityName = value; }
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
                   
				  
										String  _Code = string.Empty;
							        
				public String Code 
				{ 
					get{ return _Code;  }
					set{ _Code = value; }
				}
                   
				  
										Int16  _Status = 0;
							        
				public Int16 Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
				}
                   
				  
										Int32  _QuoterID = 0;
							        
				public Int32 QuoterID 
				{ 
					get{ return _QuoterID;  }
					set{ _QuoterID = value; }
				}
                   
				  
										String  _QuoterName = string.Empty;
							        
				public String QuoterName 
				{ 
					get{ return _QuoterName;  }
					set{ _QuoterName = value; }
				}
                   
				  
										Int32  _ChargeDepID = 0;
							        
				public Int32 ChargeDepID 
				{ 
					get{ return _ChargeDepID;  }
					set{ _ChargeDepID = value; }
				}
                   
				  
										String  _ChargeDep = string.Empty;
							        
				public String ChargeDep 
				{ 
					get{ return _ChargeDep;  }
					set{ _ChargeDep = value; }
				}
                   
				  
										Decimal  _Amount = 0;
							        
				public Decimal Amount 
				{ 
					get{ return _Amount;  }
					set{ _Amount = value; }
				}
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										DateTime  _DueDate = DateTime.Now;
							        
				public DateTime DueDate 
				{ 
					get{ return _DueDate;  }
					set{ _DueDate = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Int16  _IsOrder = 0;
							        
				public Int16 IsOrder 
				{ 
					get{ return _IsOrder;  }
					set{ _IsOrder = value; }
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
                   
				  
										Int32  _SolutionID = 0;
							        
				public Int32 SolutionID 
				{ 
					get{ return _SolutionID;  }
					set{ _SolutionID = value; }
				}
                   
				  
										String  _SolutionName = string.Empty;
							        
				public String SolutionName 
				{ 
					get{ return _SolutionName;  }
					set{ _SolutionName = value; }
				}
                   
				  
										String  _SalesCode = string.Empty;
							        
				public String SalesCode 
				{ 
					get{ return _SalesCode;  }
					set{ _SalesCode = value; }
				}
                      				        
			}               
			                   
}
 
			