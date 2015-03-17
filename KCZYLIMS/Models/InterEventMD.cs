          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class InterEventMD : EntityMD                     
			{                       
				     
				  
										Int32  _ID = 0;
							        
				public Int32 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										Int32  _EventID = 0;
							        
				public Int32 EventID 
				{ 
					get{ return _EventID;  }
					set{ _EventID = value; }
				}
                   
				  
										String  _EventName = string.Empty;
							        
				public String EventName 
				{ 
					get{ return _EventName;  }
					set{ _EventName = value; }
				}
                   
				  
										Int32  _FieldID = 0;
							        
				public Int32 FieldID 
				{ 
					get{ return _FieldID;  }
					set{ _FieldID = value; }
				}
                   
				  
										Int32  _FieldType = 0;
							        
				public Int32 FieldType 
				{ 
					get{ return _FieldType;  }
					set{ _FieldType = value; }
				}
                   
				  
										String  _TrigComp = string.Empty;
							        
				public String TrigComp 
				{ 
					get{ return _TrigComp;  }
					set{ _TrigComp = value; }
				}
                   
				  
										String  _CompText = string.Empty;
							        
				public String CompText 
				{ 
					get{ return _CompText;  }
					set{ _CompText = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                      				        
			}               
			                   
}
 
			