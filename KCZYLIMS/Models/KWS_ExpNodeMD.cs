          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class KWS_ExpNodeMD : EntityMD                     
			{                       
				     
				  
										Int64  _MyID = 0;
							        
				public Int64 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int64  _ParentNodeID = 0;
							        
				public Int64 ParentNodeID 
				{ 
					get{ return _ParentNodeID;  }
					set{ _ParentNodeID = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int64  _OrigID = 0;
							        
				public Int64 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int16  _MyType = 0;
							        
				public Int16 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										String  _Detail = string.Empty;
							        
				public String Detail 
				{ 
					get{ return _Detail;  }
					set{ _Detail = value; }
				}
                   
				  
										Int64  _MyOrder = 0;
							        
				public Int64 MyOrder 
				{ 
					get{ return _MyOrder;  }
					set{ _MyOrder = value; }
				}
                      				        
			}               
			                   
}
 
			