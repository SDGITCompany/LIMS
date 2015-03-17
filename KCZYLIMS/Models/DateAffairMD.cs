          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class DateAffairMD : EntityMD                     
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
                   
				  
										Int32  _RelatedModuleID = 0;
							        
				public Int32 RelatedModuleID 
				{ 
					get{ return _RelatedModuleID;  }
					set{ _RelatedModuleID = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int32  _RelatedType = 0;
							        
				public Int32 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int32  _SetType = 0;
							        
				public Int32 SetType 
				{ 
					get{ return _SetType;  }
					set{ _SetType = value; }
				}
                   
				  
										String  _SetOption = string.Empty;
							        
				public String SetOption 
				{ 
					get{ return _SetOption;  }
					set{ _SetOption = value; }
				}
                   
				  
										Int32  _MyPriority = 0;
							        
				public Int32 MyPriority 
				{ 
					get{ return _MyPriority;  }
					set{ _MyPriority = value; }
				}
                   
				  
										Int32  _DataType = 0;
							        
				public Int32 DataType 
				{ 
					get{ return _DataType;  }
					set{ _DataType = value; }
				}
                   
				  
										DateTime  _DataValue = DateTime.Now;
							        
				public DateTime DataValue 
				{ 
					get{ return _DataValue;  }
					set{ _DataValue = value; }
				}
                   
				  
										Int32  _RepeatNumber = 0;
							        
				public Int32 RepeatNumber 
				{ 
					get{ return _RepeatNumber;  }
					set{ _RepeatNumber = value; }
				}
                   
				  
										Int32  _IntervalNum = 0;
							        
				public Int32 IntervalNum 
				{ 
					get{ return _IntervalNum;  }
					set{ _IntervalNum = value; }
				}
                   
				  
										Int32  _IntervalType = 0;
							        
				public Int32 IntervalType 
				{ 
					get{ return _IntervalType;  }
					set{ _IntervalType = value; }
				}
                   
				  
										Int32  _TriggerNum = 0;
							        
				public Int32 TriggerNum 
				{ 
					get{ return _TriggerNum;  }
					set{ _TriggerNum = value; }
				}
                   
				  
										Int32  _TriggerType = 0;
							        
				public Int32 TriggerType 
				{ 
					get{ return _TriggerType;  }
					set{ _TriggerType = value; }
				}
                   
				  
										DateTime  _TriggerDate = DateTime.Now;
							        
				public DateTime TriggerDate 
				{ 
					get{ return _TriggerDate;  }
					set{ _TriggerDate = value; }
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
                   
				  
										Int32  _DaysToComplete = 0;
							        
				public Int32 DaysToComplete 
				{ 
					get{ return _DaysToComplete;  }
					set{ _DaysToComplete = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										DateTime  _RepeatStartDate = DateTime.Now;
							        
				public DateTime RepeatStartDate 
				{ 
					get{ return _RepeatStartDate;  }
					set{ _RepeatStartDate = value; }
				}
                   
				  
										DateTime  _RepeatEndDate = DateTime.Now;
							        
				public DateTime RepeatEndDate 
				{ 
					get{ return _RepeatEndDate;  }
					set{ _RepeatEndDate = value; }
				}
                   
				  
										Int32  _RepeatStartDateDelay = 0;
							        
				public Int32 RepeatStartDateDelay 
				{ 
					get{ return _RepeatStartDateDelay;  }
					set{ _RepeatStartDateDelay = value; }
				}
                   
				  
										Int32  _RepeatEndDateDelay = 0;
							        
				public Int32 RepeatEndDateDelay 
				{ 
					get{ return _RepeatEndDateDelay;  }
					set{ _RepeatEndDateDelay = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										DateTime  _LastModify = DateTime.Now;
							        
				public DateTime LastModify 
				{ 
					get{ return _LastModify;  }
					set{ _LastModify = value; }
				}
                   
				  
										String  _ModifierBy = string.Empty;
							        
				public String ModifierBy 
				{ 
					get{ return _ModifierBy;  }
					set{ _ModifierBy = value; }
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
                      				        
			}               
			                   
}
 
			