          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ProductPartsMD : EntityMD                     
			{                       
				     
				  
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
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int16  _RelatedType = 0;
							        
				public Int16 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int16  _RelatedModuleID = 0;
							        
				public Int16 RelatedModuleID 
				{ 
					get{ return _RelatedModuleID;  }
					set{ _RelatedModuleID = value; }
				}
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int16  _MyType = 0;
							        
				public Int16 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
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
                   
				  
										Int32  _RequiredTime = 0;
							        
				public Int32 RequiredTime 
				{ 
					get{ return _RequiredTime;  }
					set{ _RequiredTime = value; }
				}
                   
				  
										Int32  _TimeType = 0;
							        
				public Int32 TimeType 
				{ 
					get{ return _TimeType;  }
					set{ _TimeType = value; }
				}
                   
				  
										Int32  _StartDelay = 0;
							        
				public Int32 StartDelay 
				{ 
					get{ return _StartDelay;  }
					set{ _StartDelay = value; }
				}
                   
				  
										Int32  _LinkedPPID = 0;
							        
				public Int32 LinkedPPID 
				{ 
					get{ return _LinkedPPID;  }
					set{ _LinkedPPID = value; }
				}
                   
				  
										Int32  _LinkedPPOrigID = 0;
							        
				public Int32 LinkedPPOrigID 
				{ 
					get{ return _LinkedPPOrigID;  }
					set{ _LinkedPPOrigID = value; }
				}
                   
				  
										Int32  _ActureNumber = 0;
							        
				public Int32 ActureNumber 
				{ 
					get{ return _ActureNumber;  }
					set{ _ActureNumber = value; }
				}
                   
				  
										Int32  _RequiredNumber = 0;
							        
				public Int32 RequiredNumber 
				{ 
					get{ return _RequiredNumber;  }
					set{ _RequiredNumber = value; }
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
                      				        
			}               
			                   
}
 
			