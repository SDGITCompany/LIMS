          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class EventSetMD : EntityMD                     
			{                       
				     
				  
										Int32  _EventID = 0;
							        
				public Int32 EventID 
				{ 
					get{ return _EventID;  }
					set{ _EventID = value; }
				}
                   
				  
										Int32  _OrigID = 0;
							        
				public Int32 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int32  _EventType = 0;
							        
				public Int32 EventType 
				{ 
					get{ return _EventType;  }
					set{ _EventType = value; }
				}
                   
				  
										Int32  _EventIndexID = 0;
							        
				public Int32 EventIndexID 
				{ 
					get{ return _EventIndexID;  }
					set{ _EventIndexID = value; }
				}
                   
				  
										String  _Details = string.Empty;
							        
				public String Details 
				{ 
					get{ return _Details;  }
					set{ _Details = value; }
				}
                   
				  
										Int32  _MyPriority = 0;
							        
				public Int32 MyPriority 
				{ 
					get{ return _MyPriority;  }
					set{ _MyPriority = value; }
				}
                   
				  
										Int32  _DaysToComplete = 0;
							        
				public Int32 DaysToComplete 
				{ 
					get{ return _DaysToComplete;  }
					set{ _DaysToComplete = value; }
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
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										String  _ModifiedBy = string.Empty;
							        
				public String ModifiedBy 
				{ 
					get{ return _ModifiedBy;  }
					set{ _ModifiedBy = value; }
				}
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int16  _RelatedModuleID = 0;
							        
				public Int16 RelatedModuleID 
				{ 
					get{ return _RelatedModuleID;  }
					set{ _RelatedModuleID = value; }
				}
                   
				  
										Int16  _RelatedType = 0;
							        
				public Int16 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int32  _DateID = 0;
							        
				public Int32 DateID 
				{ 
					get{ return _DateID;  }
					set{ _DateID = value; }
				}
                   
				  
										DateTime  _TriggerDate = DateTime.Now;
							        
				public DateTime TriggerDate 
				{ 
					get{ return _TriggerDate;  }
					set{ _TriggerDate = value; }
				}
                   
				  
										Int32  _Repeat = 0;
							        
				public Int32 Repeat 
				{ 
					get{ return _Repeat;  }
					set{ _Repeat = value; }
				}
                   
				  
										Int32  _IntervalType = 0;
							        
				public Int32 IntervalType 
				{ 
					get{ return _IntervalType;  }
					set{ _IntervalType = value; }
				}
                   
				  
										Int32  _IntervalNum = 0;
							        
				public Int32 IntervalNum 
				{ 
					get{ return _IntervalNum;  }
					set{ _IntervalNum = value; }
				}
                   
				  
										DateTime  _UntilDate = DateTime.Now;
							        
				public DateTime UntilDate 
				{ 
					get{ return _UntilDate;  }
					set{ _UntilDate = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                      				        
			}               
			                   
}
 
			