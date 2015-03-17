          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalFlowMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										String  _Name = string.Empty;
							        
				public String Name 
				{ 
					get{ return _Name;  }
					set{ _Name = value; }
				}
                   
				  
										String  _Description = string.Empty;
							        
				public String Description 
				{ 
					get{ return _Description;  }
					set{ _Description = value; }
				}
                      				        
			}               
			                   
}
 
			