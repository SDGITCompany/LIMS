          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_SmartLink_ItemsMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _LinkedID = 0;
							        
				public Int32 LinkedID 
				{ 
					get{ return _LinkedID;  }
					set{ _LinkedID = value; }
				}
                   
				  
										Int16  _LinkedType = 0;
							        
				public Int16 LinkedType 
				{ 
					get{ return _LinkedType;  }
					set{ _LinkedType = value; }
				}
                   
				  
										String  _Url = string.Empty;
							        
				public String Url 
				{ 
					get{ return _Url;  }
					set{ _Url = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                      				        
			}               
			                   
}
 
			