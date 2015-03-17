          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_AccountActionMD : EntityMD                     
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
                   
				  
										String  _MyType = string.Empty;
							        
				public String MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										String  _ActionMode = string.Empty;
							        
				public String ActionMode 
				{ 
					get{ return _ActionMode;  }
					set{ _ActionMode = value; }
				}
                   
				  
										String  _ImportanceDegree = string.Empty;
							        
				public String ImportanceDegree 
				{ 
					get{ return _ImportanceDegree;  }
					set{ _ImportanceDegree = value; }
				}
                   
				  
										String  _ContactType = string.Empty;
							        
				public String ContactType 
				{ 
					get{ return _ContactType;  }
					set{ _ContactType = value; }
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
                   
				  
										DateTime  _ContactDate = DateTime.Now;
							        
				public DateTime ContactDate 
				{ 
					get{ return _ContactDate;  }
					set{ _ContactDate = value; }
				}
                   
				  
										DateTime  _ContactNextDate = DateTime.Now;
							        
				public DateTime ContactNextDate 
				{ 
					get{ return _ContactNextDate;  }
					set{ _ContactNextDate = value; }
				}
                   
				  
										String  _ContactContent = string.Empty;
							        
				public String ContactContent 
				{ 
					get{ return _ContactContent;  }
					set{ _ContactContent = value; }
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
                   
				  
										Int32  _ArrangerID = 0;
							        
				public Int32 ArrangerID 
				{ 
					get{ return _ArrangerID;  }
					set{ _ArrangerID = value; }
				}
                   
				  
										String  _ArrangerName = string.Empty;
							        
				public String ArrangerName 
				{ 
					get{ return _ArrangerName;  }
					set{ _ArrangerName = value; }
				}
                   
				  
										DateTime  _ArrangerTime = DateTime.Now;
							        
				public DateTime ArrangerTime 
				{ 
					get{ return _ArrangerTime;  }
					set{ _ArrangerTime = value; }
				}
                   
				  
										String  _Content = string.Empty;
							        
				public String Content 
				{ 
					get{ return _Content;  }
					set{ _Content = value; }
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
                   
				  
										DateTime  _PlanBeginTime = DateTime.Now;
							        
				public DateTime PlanBeginTime 
				{ 
					get{ return _PlanBeginTime;  }
					set{ _PlanBeginTime = value; }
				}
                   
				  
										DateTime  _PlanEndTime = DateTime.Now;
							        
				public DateTime PlanEndTime 
				{ 
					get{ return _PlanEndTime;  }
					set{ _PlanEndTime = value; }
				}
                   
				  
										String  _Location = string.Empty;
							        
				public String Location 
				{ 
					get{ return _Location;  }
					set{ _Location = value; }
				}
                   
				  
										String  _ExecuteStatus = string.Empty;
							        
				public String ExecuteStatus 
				{ 
					get{ return _ExecuteStatus;  }
					set{ _ExecuteStatus = value; }
				}
                   
				  
										String  _Status = string.Empty;
							        
				public String Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
				}
                   
				  
										String  _Summary = string.Empty;
							        
				public String Summary 
				{ 
					get{ return _Summary;  }
					set{ _Summary = value; }
				}
                   
				  
										String  _Evaluation = string.Empty;
							        
				public String Evaluation 
				{ 
					get{ return _Evaluation;  }
					set{ _Evaluation = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                      				        
			}               
			                   
}
 
			