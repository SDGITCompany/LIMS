          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ContractMD : EntityMD                     
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
                   
				  
										String  _Code = string.Empty;
							        
				public String Code 
				{ 
					get{ return _Code;  }
					set{ _Code = value; }
				}
                   
				  
										String  _ContractStatus = string.Empty;
							        
				public String ContractStatus 
				{ 
					get{ return _ContractStatus;  }
					set{ _ContractStatus = value; }
				}
                   
				  
										String  _AccountName = string.Empty;
							        
				public String AccountName 
				{ 
					get{ return _AccountName;  }
					set{ _AccountName = value; }
				}
                   
				  
										Int32  _AccountID = 0;
							        
				public Int32 AccountID 
				{ 
					get{ return _AccountID;  }
					set{ _AccountID = value; }
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
                   
				  
										DateTime  _SigningDate = DateTime.Now;
							        
				public DateTime SigningDate 
				{ 
					get{ return _SigningDate;  }
					set{ _SigningDate = value; }
				}
                   
				  
										String  _AttachmentID = string.Empty;
							        
				public String AttachmentID 
				{ 
					get{ return _AttachmentID;  }
					set{ _AttachmentID = value; }
				}
                   
				  
										String  _AttachmentName = string.Empty;
							        
				public String AttachmentName 
				{ 
					get{ return _AttachmentName;  }
					set{ _AttachmentName = value; }
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
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										DateTime  _EndDate = DateTime.Now;
							        
				public DateTime EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										Decimal  _PayAmount = 0;
							        
				public Decimal PayAmount 
				{ 
					get{ return _PayAmount;  }
					set{ _PayAmount = value; }
				}
                   
				  
										String  _PayMode = string.Empty;
							        
				public String PayMode 
				{ 
					get{ return _PayMode;  }
					set{ _PayMode = value; }
				}
                   
				  
										String  _PayLocation = string.Empty;
							        
				public String PayLocation 
				{ 
					get{ return _PayLocation;  }
					set{ _PayLocation = value; }
				}
                   
				  
										Int32  _PayPartAUserID = 0;
							        
				public Int32 PayPartAUserID 
				{ 
					get{ return _PayPartAUserID;  }
					set{ _PayPartAUserID = value; }
				}
                   
				  
										String  _PayPartAUserName = string.Empty;
							        
				public String PayPartAUserName 
				{ 
					get{ return _PayPartAUserName;  }
					set{ _PayPartAUserName = value; }
				}
                   
				  
										String  _PayPartBName = string.Empty;
							        
				public String PayPartBName 
				{ 
					get{ return _PayPartBName;  }
					set{ _PayPartBName = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										String  _ContractCategory = string.Empty;
							        
				public String ContractCategory 
				{ 
					get{ return _ContractCategory;  }
					set{ _ContractCategory = value; }
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
                   
				  
										Decimal  _Amount = 0;
							        
				public Decimal Amount 
				{ 
					get{ return _Amount;  }
					set{ _Amount = value; }
				}
                   
				  
										String  _SalesCode = string.Empty;
							        
				public String SalesCode 
				{ 
					get{ return _SalesCode;  }
					set{ _SalesCode = value; }
				}
                      				        
			}               
			                   
}
 
			