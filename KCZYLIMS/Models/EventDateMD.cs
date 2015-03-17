          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class EventDateMD : EntityMD                     
			{                       
				     
				  
										Int32  _DateID = 0;
							        
				public Int32 DateID 
				{ 
					get{ return _DateID;  }
					set{ _DateID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int16  _SetType = 0;
							        
				public Int16 SetType 
				{ 
					get{ return _SetType;  }
					set{ _SetType = value; }
				}
                   
				  
										Int16  _DateType = 0;
							        
				public Int16 DateType 
				{ 
					get{ return _DateType;  }
					set{ _DateType = value; }
				}
                   
				  
										Int32  _Repeat = 0;
							        
				public Int32 Repeat 
				{ 
					get{ return _Repeat;  }
					set{ _Repeat = value; }
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
                   
				  
										DateTime  _DateValue = DateTime.Now;
							        
				public DateTime DateValue 
				{ 
					get{ return _DateValue;  }
					set{ _DateValue = value; }
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
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
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
                   
				  
										Int32  _FieldID = 0;
							        
				public Int32 FieldID 
				{ 
					get{ return _FieldID;  }
					set{ _FieldID = value; }
				}
                   
				  
										Boolean  _IsTriggered = false;
							        
				public Boolean IsTriggered 
				{ 
					get{ return _IsTriggered;  }
					set{ _IsTriggered = value; }
				}
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                      				        
			}               
			                   
}
 
			