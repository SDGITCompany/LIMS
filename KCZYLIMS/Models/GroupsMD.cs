          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class GroupsMD : EntityMD                     
			{                       
				     
				  
										Int64  _GroupID = 0;
							        
				public Int64 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										Int64  _ParentGroupID = 0;
							        
				public Int64 ParentGroupID 
				{ 
					get{ return _ParentGroupID;  }
					set{ _ParentGroupID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int16  _ModuleType = 0;
							        
				public Int16 ModuleType 
				{ 
					get{ return _ModuleType;  }
					set{ _ModuleType = value; }
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
                   
				  
										Int64  _FormID = 0;
							        
				public Int64 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										Int32  _TypeID = 0;
							        
				public Int32 TypeID 
				{ 
					get{ return _TypeID;  }
					set{ _TypeID = value; }
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
                   
				  
										String  _ModuleSet = string.Empty;
							        
				public String ModuleSet 
				{ 
					get{ return _ModuleSet;  }
					set{ _ModuleSet = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Int64  _FlowID = 0;
							        
				public Int64 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                   
				  
										Int32  _MyClass = 0;
							        
				public Int32 MyClass 
				{ 
					get{ return _MyClass;  }
					set{ _MyClass = value; }
				}
                   
				  
										String  _ApprovalStepSet = string.Empty;
							        
				public String ApprovalStepSet 
				{ 
					get{ return _ApprovalStepSet;  }
					set{ _ApprovalStepSet = value; }
				}
                   
				  
										String  _NameFormula = string.Empty;
							        
				public String NameFormula 
				{ 
					get{ return _NameFormula;  }
					set{ _NameFormula = value; }
				}
                   
				  
										Int64  _MyOrder = 0;
							        
				public Int64 MyOrder 
				{ 
					get{ return _MyOrder;  }
					set{ _MyOrder = value; }
				}
                      				        
			}               
			                   
}
 
			