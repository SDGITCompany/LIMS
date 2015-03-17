          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class AttachmentMD : EntityMD                     
			{                       
				     
				  
										Int64  _AttachID = 0;
							        
				public Int64 AttachID 
				{ 
					get{ return _AttachID;  }
					set{ _AttachID = value; }
				}
                   
				  
										Int64  _ParentID = 0;
							        
				public Int64 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int64  _RelatedID = 0;
							        
				public Int64 RelatedID 
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
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _MyStatus = 0;
							        
				public Int32 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										Double  _MySize = 0;
							        
				public Double MySize 
				{ 
					get{ return _MySize;  }
					set{ _MySize = value; }
				}
                   
				  
										Int16  _Permission = 0;
							        
				public Int16 Permission 
				{ 
					get{ return _Permission;  }
					set{ _Permission = value; }
				}
                   
				  
										String  _OrigPath = string.Empty;
							        
				public String OrigPath 
				{ 
					get{ return _OrigPath;  }
					set{ _OrigPath = value; }
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
                   
				  
										Int64  _CreaterID = 0;
							        
				public Int64 CreaterID 
				{ 
					get{ return _CreaterID;  }
					set{ _CreaterID = value; }
				}
                   
				  
										Int64  _RelatedFormID = 0;
							        
				public Int64 RelatedFormID 
				{ 
					get{ return _RelatedFormID;  }
					set{ _RelatedFormID = value; }
				}
                      				        
			}               
			                   
}
 
			