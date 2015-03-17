          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class MyHistoryMD : EntityMD                     
			{                       
				     
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int32  _RelatedOrigID = 0;
							        
				public Int32 RelatedOrigID 
				{ 
					get{ return _RelatedOrigID;  }
					set{ _RelatedOrigID = value; }
				}
                   
				  
										Int32  _RelatedType = 0;
							        
				public Int32 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Byte  _MyClass = 0;
							        
				public Byte MyClass 
				{ 
					get{ return _MyClass;  }
					set{ _MyClass = value; }
				}
                   
				  
										String  _MemoData = string.Empty;
							        
				public String MemoData 
				{ 
					get{ return _MemoData;  }
					set{ _MemoData = value; }
				}
                      				        
			}               
			                   
}
 
			