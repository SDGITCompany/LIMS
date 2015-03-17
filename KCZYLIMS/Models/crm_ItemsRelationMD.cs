          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ItemsRelationMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int32  _ToRelatedID = 0;
							        
				public Int32 ToRelatedID 
				{ 
					get{ return _ToRelatedID;  }
					set{ _ToRelatedID = value; }
				}
                   
				  
										Int32  _ToRelatedType = 0;
							        
				public Int32 ToRelatedType 
				{ 
					get{ return _ToRelatedType;  }
					set{ _ToRelatedType = value; }
				}
                   
				  
										Int32  _ToModuleID = 0;
							        
				public Int32 ToModuleID 
				{ 
					get{ return _ToModuleID;  }
					set{ _ToModuleID = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                      				        
			}               
			                   
}
 
			