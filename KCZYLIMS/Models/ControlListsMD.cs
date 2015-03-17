          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ControlListsMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
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
                   
				  
										Int32  _ListClass = 0;
							        
				public Int32 ListClass 
				{ 
					get{ return _ListClass;  }
					set{ _ListClass = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int64  _RoleID = 0;
							        
				public Int64 RoleID 
				{ 
					get{ return _RoleID;  }
					set{ _RoleID = value; }
				}
                   
				  
										Int64  _FormID = 0;
							        
				public Int64 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										Int64  _ControlID = 0;
							        
				public Int64 ControlID 
				{ 
					get{ return _ControlID;  }
					set{ _ControlID = value; }
				}
                   
				  
										String  _ControlFullName = string.Empty;
							        
				public String ControlFullName 
				{ 
					get{ return _ControlFullName;  }
					set{ _ControlFullName = value; }
				}
                   
				  
										Int16  _ControlType = 0;
							        
				public Int16 ControlType 
				{ 
					get{ return _ControlType;  }
					set{ _ControlType = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										Int64  _CreatorID = 0;
							        
				public Int64 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										Int64  _ModifierID = 0;
							        
				public Int64 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										String  _ModifiedBy = string.Empty;
							        
				public String ModifiedBy 
				{ 
					get{ return _ModifiedBy;  }
					set{ _ModifiedBy = value; }
				}
                      				        
			}               
			                   
}
 
			