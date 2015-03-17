          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalFlowStepTplMD : EntityMD                     
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
                   
				  
										String  _InCondition = string.Empty;
							        
				public String InCondition 
				{ 
					get{ return _InCondition;  }
					set{ _InCondition = value; }
				}
                   
				  
										String  _OutCondition = string.Empty;
							        
				public String OutCondition 
				{ 
					get{ return _OutCondition;  }
					set{ _OutCondition = value; }
				}
                   
				  
										Int64  _FlowID = 0;
							        
				public Int64 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                      				        
			}               
			                   
}
 
			