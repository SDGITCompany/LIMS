          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class LoginRecordsMD : EntityMD                     
			{                       
				     
				  
										Int32  _UserID = 0;
							        
				public Int32 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _LoginIP = string.Empty;
							        
				public String LoginIP 
				{ 
					get{ return _LoginIP;  }
					set{ _LoginIP = value; }
				}
                   
				  
										DateTime  _LoginTime = DateTime.Now;
							        
				public DateTime LoginTime 
				{ 
					get{ return _LoginTime;  }
					set{ _LoginTime = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                      				        
			}               
			                   
}
 
			