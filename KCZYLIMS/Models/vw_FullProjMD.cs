          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_FullProjMD : EntityMD                     
			{                       
				     
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _OrigID = 0;
							        
				public Int32 OrigID 
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
                   
				  
										Int64  _FlowID = 0;
							        
				public Int64 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                   
				  
										String  _FlowName = string.Empty;
							        
				public String FlowName 
				{ 
					get{ return _FlowName;  }
					set{ _FlowName = value; }
				}
                   
				  
										Int64  _ProjID = 0;
							        
				public Int64 ProjID 
				{ 
					get{ return _ProjID;  }
					set{ _ProjID = value; }
				}
                   
				  
										String  _ProjName = string.Empty;
							        
				public String ProjName 
				{ 
					get{ return _ProjName;  }
					set{ _ProjName = value; }
				}
                      				        
			}               
			                   
}
 
			