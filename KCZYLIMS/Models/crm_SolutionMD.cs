          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_SolutionMD : EntityMD                     
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
                   
				  
										String  _SolutionContent = string.Empty;
							        
				public String SolutionContent 
				{ 
					get{ return _SolutionContent;  }
					set{ _SolutionContent = value; }
				}
                   
				  
										DateTime  _LastDate = DateTime.Now;
							        
				public DateTime LastDate 
				{ 
					get{ return _LastDate;  }
					set{ _LastDate = value; }
				}
                   
				  
										Int32  _ChargeManID = 0;
							        
				public Int32 ChargeManID 
				{ 
					get{ return _ChargeManID;  }
					set{ _ChargeManID = value; }
				}
                   
				  
										String  _ChargeMan = string.Empty;
							        
				public String ChargeMan 
				{ 
					get{ return _ChargeMan;  }
					set{ _ChargeMan = value; }
				}
                   
				  
										String  _Phase = string.Empty;
							        
				public String Phase 
				{ 
					get{ return _Phase;  }
					set{ _Phase = value; }
				}
                   
				  
										String  _Feedback = string.Empty;
							        
				public String Feedback 
				{ 
					get{ return _Feedback;  }
					set{ _Feedback = value; }
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
 
			