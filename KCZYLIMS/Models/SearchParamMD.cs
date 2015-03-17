          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SearchParamMD : EntityMD                     
			{                       
				     
				  
										Int32  _SearchReportID = 0;
							        
				public Int32 SearchReportID 
				{ 
					get{ return _SearchReportID;  }
					set{ _SearchReportID = value; }
				}
                   
				  
										String  _HtmlContent = string.Empty;
							        
				public String HtmlContent 
				{ 
					get{ return _HtmlContent;  }
					set{ _HtmlContent = value; }
				}
                   
				  
										String  _Params = string.Empty;
							        
				public String Params 
				{ 
					get{ return _Params;  }
					set{ _Params = value; }
				}
                      				        
			}               
			                   
}
 
			