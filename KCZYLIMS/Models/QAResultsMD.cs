          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class QAResultsMD : EntityMD                     
			{                       
				     
				  
										Int64  _ResultID = 0;
							        
				public Int64 ResultID 
				{ 
					get{ return _ResultID;  }
					set{ _ResultID = value; }
				}
                   
				  
										Int32  _SerialNo = 0;
							        
				public Int32 SerialNo 
				{ 
					get{ return _SerialNo;  }
					set{ _SerialNo = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										Int32  _AID = 0;
							        
				public Int32 AID 
				{ 
					get{ return _AID;  }
					set{ _AID = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										DateTime  _ADate = DateTime.Now;
							        
				public DateTime ADate 
				{ 
					get{ return _ADate;  }
					set{ _ADate = value; }
				}
                      				        
			}               
			                   
}
 
			