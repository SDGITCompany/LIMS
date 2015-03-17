          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SmartMarkMD : EntityMD                     
			{                       
				     
				  
										Int32  _MarkID = 0;
							        
				public Int32 MarkID 
				{ 
					get{ return _MarkID;  }
					set{ _MarkID = value; }
				}
                   
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _OrigID = 0;
							        
				public Int32 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										String  _MarkCaption = string.Empty;
							        
				public String MarkCaption 
				{ 
					get{ return _MarkCaption;  }
					set{ _MarkCaption = value; }
				}
                   
				  
										String  _MarkName = string.Empty;
							        
				public String MarkName 
				{ 
					get{ return _MarkName;  }
					set{ _MarkName = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										Int32  _CreaterID = 0;
							        
				public Int32 CreaterID 
				{ 
					get{ return _CreaterID;  }
					set{ _CreaterID = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                      				        
			}               
			                   
}
 
			