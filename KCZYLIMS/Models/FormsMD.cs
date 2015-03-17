          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class FormsMD : EntityMD                     
			{                       
				     
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										Int32  _Permission = 0;
							        
				public Int32 Permission 
				{ 
					get{ return _Permission;  }
					set{ _Permission = value; }
				}
                   
				  
										Int32  _FormType = 0;
							        
				public Int32 FormType 
				{ 
					get{ return _FormType;  }
					set{ _FormType = value; }
				}
                   
				  
										Int16  _MyOrder = 0;
							        
				public Int16 MyOrder 
				{ 
					get{ return _MyOrder;  }
					set{ _MyOrder = value; }
				}
                   
				  
										Int32  _JumpTo = 0;
							        
				public Int32 JumpTo 
				{ 
					get{ return _JumpTo;  }
					set{ _JumpTo = value; }
				}
                   
				  
										Int16  _MyStatus = 0;
							        
				public Int16 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										Int32  _ApprovalType = 0;
							        
				public Int32 ApprovalType 
				{ 
					get{ return _ApprovalType;  }
					set{ _ApprovalType = value; }
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
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										String  _ModifiedBy = string.Empty;
							        
				public String ModifiedBy 
				{ 
					get{ return _ModifiedBy;  }
					set{ _ModifiedBy = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Int64  _FormOrigID = 0;
							        
				public Int64 FormOrigID 
				{ 
					get{ return _FormOrigID;  }
					set{ _FormOrigID = value; }
				}
                      				        
			}               
			                   
}
 
			