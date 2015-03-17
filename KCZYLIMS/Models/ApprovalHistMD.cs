          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ApprovalHistMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										Int64  _RelatedID = 0;
							        
				public Int64 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										String  _Type = string.Empty;
							        
				public String Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _UserFullName = string.Empty;
							        
				public String UserFullName 
				{ 
					get{ return _UserFullName;  }
					set{ _UserFullName = value; }
				}
                   
				  
										String  _Result = string.Empty;
							        
				public String Result 
				{ 
					get{ return _Result;  }
					set{ _Result = value; }
				}
                   
				  
										DateTime  _ModifiedDateTime = DateTime.Now;
							        
				public DateTime ModifiedDateTime 
				{ 
					get{ return _ModifiedDateTime;  }
					set{ _ModifiedDateTime = value; }
				}
                      				        
			}               
			                   
}
 
			