          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_PP_Items_PP_TreeMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int16  _MyType = 0;
							        
				public Int16 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _DefaultGroupID = 0;
							        
				public Int32 DefaultGroupID 
				{ 
					get{ return _DefaultGroupID;  }
					set{ _DefaultGroupID = value; }
				}
                   
				  
										Int32  _DefaultInGroupID = 0;
							        
				public Int32 DefaultInGroupID 
				{ 
					get{ return _DefaultInGroupID;  }
					set{ _DefaultInGroupID = value; }
				}
                   
				  
										Int32  _DefaultOutGroupID = 0;
							        
				public Int32 DefaultOutGroupID 
				{ 
					get{ return _DefaultOutGroupID;  }
					set{ _DefaultOutGroupID = value; }
				}
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										String  _NameFormula = string.Empty;
							        
				public String NameFormula 
				{ 
					get{ return _NameFormula;  }
					set{ _NameFormula = value; }
				}
                   
				  
										Int32  _StartDelay = 0;
							        
				public Int32 StartDelay 
				{ 
					get{ return _StartDelay;  }
					set{ _StartDelay = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _ItemPPID = 0;
							        
				public Int32 ItemPPID 
				{ 
					get{ return _ItemPPID;  }
					set{ _ItemPPID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _RequiredNumber = 0;
							        
				public Int32 RequiredNumber 
				{ 
					get{ return _RequiredNumber;  }
					set{ _RequiredNumber = value; }
				}
                      				        
			}               
			                   
}
 
			