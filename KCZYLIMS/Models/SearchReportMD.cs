          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SearchReportMD : EntityMD                     
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
                   
				  
										Byte  _MyType = 0;
							        
				public Byte MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										String  _StrSQL = string.Empty;
							        
				public String StrSQL 
				{ 
					get{ return _StrSQL;  }
					set{ _StrSQL = value; }
				}
                   
				  
										Int32  _UserID = 0;
							        
				public Int32 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										String  _UserName = string.Empty;
							        
				public String UserName 
				{ 
					get{ return _UserName;  }
					set{ _UserName = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										Byte  _ShareType = 0;
							        
				public Byte ShareType 
				{ 
					get{ return _ShareType;  }
					set{ _ShareType = value; }
				}
                   
				  
										Int32  _ResultID = 0;
							        
				public Int32 ResultID 
				{ 
					get{ return _ResultID;  }
					set{ _ResultID = value; }
				}
                      				        
			}               
			                   
}
 
			