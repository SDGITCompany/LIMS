          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SystemCodeMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _CodeType = string.Empty;
							        
				public String CodeType 
				{ 
					get{ return _CodeType;  }
					set{ _CodeType = value; }
				}
                   
				  
										String  _CodeNo = string.Empty;
							        
				public String CodeNo 
				{ 
					get{ return _CodeNo;  }
					set{ _CodeNo = value; }
				}
                   
				  
										Int32  _Order = 0;
							        
				public Int32 Order 
				{ 
					get{ return _Order;  }
					set{ _Order = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                      				        
			}               
			                   
}
 
			