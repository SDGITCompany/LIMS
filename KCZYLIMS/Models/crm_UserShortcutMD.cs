          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_UserShortcutMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _PersonalDesktopIcons = string.Empty;
							        
				public String PersonalDesktopIcons 
				{ 
					get{ return _PersonalDesktopIcons;  }
					set{ _PersonalDesktopIcons = value; }
				}
                      				        
			}               
			                   
}
 
			