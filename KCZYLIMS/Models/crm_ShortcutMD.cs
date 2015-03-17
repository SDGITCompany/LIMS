          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ShortcutMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _ShortcutName = string.Empty;
							        
				public String ShortcutName 
				{ 
					get{ return _ShortcutName;  }
					set{ _ShortcutName = value; }
				}
                   
				  
										String  _ShortcutAddress = string.Empty;
							        
				public String ShortcutAddress 
				{ 
					get{ return _ShortcutAddress;  }
					set{ _ShortcutAddress = value; }
				}
                   
				  
										String  _ShortcutIcon = string.Empty;
							        
				public String ShortcutIcon 
				{ 
					get{ return _ShortcutIcon;  }
					set{ _ShortcutIcon = value; }
				}
                      				        
			}               
			                   
}
 
			