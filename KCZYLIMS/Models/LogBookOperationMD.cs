          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class LogBookOperationMD : EntityMD                     
			{                       
				     
				  
										String  _FullName = string.Empty;
							        
				public String FullName 
				{ 
					get{ return _FullName;  }
					set{ _FullName = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                      				        
			}               
			                   
}
 
			