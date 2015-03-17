          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_OrderMD : EntityMD                     
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
                   
				  
										Int16  _Kind = 0;
							        
				public Int16 Kind 
				{ 
					get{ return _Kind;  }
					set{ _Kind = value; }
				}
                   
				  
										DateTime  _SignDate = DateTime.Now;
							        
				public DateTime SignDate 
				{ 
					get{ return _SignDate;  }
					set{ _SignDate = value; }
				}
                   
				  
										DateTime  _Amount = DateTime.Now;
							        
				public DateTime Amount 
				{ 
					get{ return _Amount;  }
					set{ _Amount = value; }
				}
                   
				  
										DateTime  _LastDate = DateTime.Now;
							        
				public DateTime LastDate 
				{ 
					get{ return _LastDate;  }
					set{ _LastDate = value; }
				}
                   
				  
										Decimal  _PayAmount = 0;
							        
				public Decimal PayAmount 
				{ 
					get{ return _PayAmount;  }
					set{ _PayAmount = value; }
				}
                   
				  
										String  _AttachmentIDs = string.Empty;
							        
				public String AttachmentIDs 
				{ 
					get{ return _AttachmentIDs;  }
					set{ _AttachmentIDs = value; }
				}
                   
				  
										String  _AttachmentNames = string.Empty;
							        
				public String AttachmentNames 
				{ 
					get{ return _AttachmentNames;  }
					set{ _AttachmentNames = value; }
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
                   
				  
										String  _OrderFacilitateMan = string.Empty;
							        
				public String OrderFacilitateMan 
				{ 
					get{ return _OrderFacilitateMan;  }
					set{ _OrderFacilitateMan = value; }
				}
                   
				  
										Int32  _OrderFacilitateID = 0;
							        
				public Int32 OrderFacilitateID 
				{ 
					get{ return _OrderFacilitateID;  }
					set{ _OrderFacilitateID = value; }
				}
                   
				  
										DateTime  _OrderLastDate = DateTime.Now;
							        
				public DateTime OrderLastDate 
				{ 
					get{ return _OrderLastDate;  }
					set{ _OrderLastDate = value; }
				}
                      				        
			}               
			                   
}
 
			