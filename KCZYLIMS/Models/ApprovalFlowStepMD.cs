          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalFlowStepMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										Int64  _OrigID = 0;
							        
				public Int64 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										String  _Name = string.Empty;
							        
				public String Name 
				{ 
					get{ return _Name;  }
					set{ _Name = value; }
				}
                   
				  
										String  _Type = string.Empty;
							        
				public String Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                   
				  
										Boolean  _IsActive = false;
							        
				public Boolean IsActive 
				{ 
					get{ return _IsActive;  }
					set{ _IsActive = value; }
				}
                   
				  
										DateTime  _ActiveTime = DateTime.Now;
							        
				public DateTime ActiveTime 
				{ 
					get{ return _ActiveTime;  }
					set{ _ActiveTime = value; }
				}
                   
				  
										DateTime  _CompleteTime = DateTime.Now;
							        
				public DateTime CompleteTime 
				{ 
					get{ return _CompleteTime;  }
					set{ _CompleteTime = value; }
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
                   
				  
										String  _Status = string.Empty;
							        
				public String Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
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
                   
				  
										String  _History = string.Empty;
							        
				public String History 
				{ 
					get{ return _History;  }
					set{ _History = value; }
				}
                   
				  
										Int64  _TplID = 0;
							        
				public Int64 TplID 
				{ 
					get{ return _TplID;  }
					set{ _TplID = value; }
				}
                   
				  
										String  _PageTpl = string.Empty;
							        
				public String PageTpl 
				{ 
					get{ return _PageTpl;  }
					set{ _PageTpl = value; }
				}
                      				        
			}               
			                   
}
 
			