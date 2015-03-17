          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class UserTaskMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int16  _MyType = 0;
							        
				public Int16 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _Details = string.Empty;
							        
				public String Details 
				{ 
					get{ return _Details;  }
					set{ _Details = value; }
				}
                   
				  
										Int16  _MyStatus = 0;
							        
				public Int16 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										Int32  _EventID = 0;
							        
				public Int32 EventID 
				{ 
					get{ return _EventID;  }
					set{ _EventID = value; }
				}
                   
				  
										Int32  _ParentEventID = 0;
							        
				public Int32 ParentEventID 
				{ 
					get{ return _ParentEventID;  }
					set{ _ParentEventID = value; }
				}
                   
				  
										Int32  _ResultID = 0;
							        
				public Int32 ResultID 
				{ 
					get{ return _ResultID;  }
					set{ _ResultID = value; }
				}
                   
				  
										String  _ResultName = string.Empty;
							        
				public String ResultName 
				{ 
					get{ return _ResultName;  }
					set{ _ResultName = value; }
				}
                   
				  
										Int32  _RecepientID = 0;
							        
				public Int32 RecepientID 
				{ 
					get{ return _RecepientID;  }
					set{ _RecepientID = value; }
				}
                   
				  
										String  _RecepientName = string.Empty;
							        
				public String RecepientName 
				{ 
					get{ return _RecepientName;  }
					set{ _RecepientName = value; }
				}
                   
				  
										Int32  _SenderID = 0;
							        
				public Int32 SenderID 
				{ 
					get{ return _SenderID;  }
					set{ _SenderID = value; }
				}
                   
				  
										String  _SenderName = string.Empty;
							        
				public String SenderName 
				{ 
					get{ return _SenderName;  }
					set{ _SenderName = value; }
				}
                   
				  
										DateTime  _SendDate = DateTime.Now;
							        
				public DateTime SendDate 
				{ 
					get{ return _SendDate;  }
					set{ _SendDate = value; }
				}
                   
				  
										DateTime  _DateDue = DateTime.Now;
							        
				public DateTime DateDue 
				{ 
					get{ return _DateDue;  }
					set{ _DateDue = value; }
				}
                   
				  
										Int16  _Priority = 0;
							        
				public Int16 Priority 
				{ 
					get{ return _Priority;  }
					set{ _Priority = value; }
				}
                   
				  
										DateTime  _CompleteDate = DateTime.Now;
							        
				public DateTime CompleteDate 
				{ 
					get{ return _CompleteDate;  }
					set{ _CompleteDate = value; }
				}
                   
				  
										String  _Comments = string.Empty;
							        
				public String Comments 
				{ 
					get{ return _Comments;  }
					set{ _Comments = value; }
				}
                   
				  
										Boolean  _ShowMeEnabled = false;
							        
				public Boolean ShowMeEnabled 
				{ 
					get{ return _ShowMeEnabled;  }
					set{ _ShowMeEnabled = value; }
				}
                   
				  
										Int32  _ShowGroupID = 0;
							        
				public Int32 ShowGroupID 
				{ 
					get{ return _ShowGroupID;  }
					set{ _ShowGroupID = value; }
				}
                   
				  
										Int32  _ShowID = 0;
							        
				public Int32 ShowID 
				{ 
					get{ return _ShowID;  }
					set{ _ShowID = value; }
				}
                   
				  
										Int16  _ShowType = 0;
							        
				public Int16 ShowType 
				{ 
					get{ return _ShowType;  }
					set{ _ShowType = value; }
				}
                   
				  
										Int16  _ShowModuleID = 0;
							        
				public Int16 ShowModuleID 
				{ 
					get{ return _ShowModuleID;  }
					set{ _ShowModuleID = value; }
				}
                   
				  
										Int16  _ShowAction = 0;
							        
				public Int16 ShowAction 
				{ 
					get{ return _ShowAction;  }
					set{ _ShowAction = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Int16  _NotifiedStatus = 0;
							        
				public Int16 NotifiedStatus 
				{ 
					get{ return _NotifiedStatus;  }
					set{ _NotifiedStatus = value; }
				}
                   
				  
										Int16  _EscalateStatus = 0;
							        
				public Int16 EscalateStatus 
				{ 
					get{ return _EscalateStatus;  }
					set{ _EscalateStatus = value; }
				}
                   
				  
										DateTime  _EscalateDate = DateTime.Now;
							        
				public DateTime EscalateDate 
				{ 
					get{ return _EscalateDate;  }
					set{ _EscalateDate = value; }
				}
                   
				  
										Boolean  _IsRecvDeleted = false;
							        
				public Boolean IsRecvDeleted 
				{ 
					get{ return _IsRecvDeleted;  }
					set{ _IsRecvDeleted = value; }
				}
                   
				  
										Boolean  _IsSendDeleted = false;
							        
				public Boolean IsSendDeleted 
				{ 
					get{ return _IsSendDeleted;  }
					set{ _IsSendDeleted = value; }
				}
                   
				  
										Boolean  _IsRecvDeleted_True = false;
							        
				public Boolean IsRecvDeleted_True 
				{ 
					get{ return _IsRecvDeleted_True;  }
					set{ _IsRecvDeleted_True = value; }
				}
                   
				  
										Boolean  _IsSendDeleted_True = false;
							        
				public Boolean IsSendDeleted_True 
				{ 
					get{ return _IsSendDeleted_True;  }
					set{ _IsSendDeleted_True = value; }
				}
                      				        
			}               
			                   
}
 
			