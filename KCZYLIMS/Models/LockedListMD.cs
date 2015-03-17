          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class LockedListMD : EntityMD                     
			{                       
				     
				  
										String  _IPAddress = string.Empty;
							        
				public String IPAddress 
				{ 
					get{ return _IPAddress;  }
					set{ _IPAddress = value; }
				}
                   
				  
										String  _LoginName = string.Empty;
							        
				public String LoginName 
				{ 
					get{ return _LoginName;  }
					set{ _LoginName = value; }
				}
                   
				  
										String  _PCName = string.Empty;
							        
				public String PCName 
				{ 
					get{ return _PCName;  }
					set{ _PCName = value; }
				}
                   
				  
										Int32  _UnlockType = 0;
							        
				public Int32 UnlockType 
				{ 
					get{ return _UnlockType;  }
					set{ _UnlockType = value; }
				}
                   
				  
										DateTime  _LockedTime = DateTime.Now;
							        
				public DateTime LockedTime 
				{ 
					get{ return _LockedTime;  }
					set{ _LockedTime = value; }
				}
                      				        
			}               
			                   
}
 
			