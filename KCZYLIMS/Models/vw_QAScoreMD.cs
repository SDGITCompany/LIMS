          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_QAScoreMD : EntityMD                     
			{                       
				     
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Double  _score = 0;
							        
				public Double score 
				{ 
					get{ return _score;  }
					set{ _score = value; }
				}
                      				        
			}               
			                   
}
 
			