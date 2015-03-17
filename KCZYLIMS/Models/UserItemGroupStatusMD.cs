          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class UserItemGroupStatusMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int32  _RelatedType = 0;
							        
				public Int32 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int32  _RelatedModuleID = 0;
							        
				public Int32 RelatedModuleID 
				{ 
					get{ return _RelatedModuleID;  }
					set{ _RelatedModuleID = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _MyClass = 0;
							        
				public Int32 MyClass 
				{ 
					get{ return _MyClass;  }
					set{ _MyClass = value; }
				}
                   
				  
										Int32  _Status = 0;
							        
				public Int32 Status 
				{ 
					get{ return _Status;  }
					set{ _Status = value; }
				}
                   
				  
										DateTime  _StatusDate = DateTime.Now;
							        
				public DateTime StatusDate 
				{ 
					get{ return _StatusDate;  }
					set{ _StatusDate = value; }
				}
                      				        
			}               
			                   
}
 
			