          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ProductParts_ExpandMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _PPID = 0;
							        
				public Int32 PPID 
				{ 
					get{ return _PPID;  }
					set{ _PPID = value; }
				}
                   
				  
										String  _Status = string.Empty;
							        
				public String Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
				}
                      				        
			}               
			                   
}
 
			