          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ItemApprovalMD : EntityMD                     
			{                       
				     
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int16  _ApprovalStatus = 0;
							        
				public Int16 ApprovalStatus 
				{ 
					get{ return _ApprovalStatus;  }
					set{ _ApprovalStatus = value; }
				}
                   
				  
										Int32  _Type = 0;
							        
				public Int32 Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                   
				  
										String  _ResultText = string.Empty;
							        
				public String ResultText 
				{ 
					get{ return _ResultText;  }
					set{ _ResultText = value; }
				}
                   
				  
										Int64  _ResultID = 0;
							        
				public Int64 ResultID 
				{ 
					get{ return _ResultID;  }
					set{ _ResultID = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										String  _UserName = string.Empty;
							        
				public String UserName 
				{ 
					get{ return _UserName;  }
					set{ _UserName = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										DateTime  _SubmitDate = DateTime.Now;
							        
				public DateTime SubmitDate 
				{ 
					get{ return _SubmitDate;  }
					set{ _SubmitDate = value; }
				}
                   
				  
										Int64  _MyID = 0;
							        
				public Int64 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                      				        
			}               
			                   
}
 
			