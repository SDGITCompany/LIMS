          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SystemSettingsMD : EntityMD                     
			{                       
				     
				  
										String  _XFKey = string.Empty;
							        
				public String XFKey 
				{ 
					get{ return _XFKey;  }
					set{ _XFKey = value; }
				}
                   
				  
										String  _Value1 = string.Empty;
							        
				public String Value1 
				{ 
					get{ return _Value1;  }
					set{ _Value1 = value; }
				}
                   
				  
										String  _Value2 = string.Empty;
							        
				public String Value2 
				{ 
					get{ return _Value2;  }
					set{ _Value2 = value; }
				}
                      				        
			}               
			                   
}
 
			