          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ProjFlowMD : EntityMD                     
			{                       
				     
				  
										Int32  _JumpTo = 0;
							        
				public Int32 JumpTo 
				{ 
					get{ return _JumpTo;  }
					set{ _JumpTo = value; }
				}
                   
				  
										Int32  _FlowID = 0;
							        
				public Int32 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
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
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										Int32  _DefaultGroupID = 0;
							        
				public Int32 DefaultGroupID 
				{ 
					get{ return _DefaultGroupID;  }
					set{ _DefaultGroupID = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                      				        
			}               
			                   
}
 
			