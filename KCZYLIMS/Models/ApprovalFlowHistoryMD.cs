          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalFlowHistoryMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										Int64  _ApprovalFlowStepID = 0;
							        
				public Int64 ApprovalFlowStepID 
				{ 
					get{ return _ApprovalFlowStepID;  }
					set{ _ApprovalFlowStepID = value; }
				}
                   
				  
										String  _Result = string.Empty;
							        
				public String Result 
				{ 
					get{ return _Result;  }
					set{ _Result = value; }
				}
                   
				  
										Int64  _LastModifier = 0;
							        
				public Int64 LastModifier 
				{ 
					get{ return _LastModifier;  }
					set{ _LastModifier = value; }
				}
                   
				  
										DateTime  _LastModifiedTime = DateTime.Now;
							        
				public DateTime LastModifiedTime 
				{ 
					get{ return _LastModifiedTime;  }
					set{ _LastModifiedTime = value; }
				}
                      				        
			}               
			                   
}
 
			