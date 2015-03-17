          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class RoleSecurityMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _RoleID = 0;
							        
				public Int32 RoleID 
				{ 
					get{ return _RoleID;  }
					set{ _RoleID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int16  _LevelID = 0;
							        
				public Int16 LevelID 
				{ 
					get{ return _LevelID;  }
					set{ _LevelID = value; }
				}
                   
				  
										Int16  _LevelValue = 0;
							        
				public Int16 LevelValue 
				{ 
					get{ return _LevelValue;  }
					set{ _LevelValue = value; }
				}
                      				        
			}               
			                   
}
 
			