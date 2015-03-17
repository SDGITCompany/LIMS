          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_CancelPPInOutMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _ProductName = string.Empty;
							        
				public String ProductName 
				{ 
					get{ return _ProductName;  }
					set{ _ProductName = value; }
				}
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										String  _ProjectName = string.Empty;
							        
				public String ProjectName 
				{ 
					get{ return _ProjectName;  }
					set{ _ProjectName = value; }
				}
                   
				  
										String  _FlowName = string.Empty;
							        
				public String FlowName 
				{ 
					get{ return _FlowName;  }
					set{ _FlowName = value; }
				}
                      				        
			}               
			                   
}
 
			