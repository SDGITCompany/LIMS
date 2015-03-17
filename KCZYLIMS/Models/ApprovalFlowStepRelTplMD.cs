          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalFlowStepRelTplMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										Int64  _FlowID = 0;
							        
				public Int64 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                   
				  
										Int64  _CurID = 0;
							        
				public Int64 CurID 
				{ 
					get{ return _CurID;  }
					set{ _CurID = value; }
				}
                   
				  
										Int64  _PrevID = 0;
							        
				public Int64 PrevID 
				{ 
					get{ return _PrevID;  }
					set{ _PrevID = value; }
				}
                   
				  
										Int64  _NextID = 0;
							        
				public Int64 NextID 
				{ 
					get{ return _NextID;  }
					set{ _NextID = value; }
				}
                   
				  
										String  _Type = string.Empty;
							        
				public String Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                      				        
			}               
			                   
}
 
			