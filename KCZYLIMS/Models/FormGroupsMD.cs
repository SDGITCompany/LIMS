          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class FormGroupsMD : EntityMD                     
			{                       
				     
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										Int32  _ParentGroupID = 0;
							        
				public Int32 ParentGroupID 
				{ 
					get{ return _ParentGroupID;  }
					set{ _ParentGroupID = value; }
				}
                   
				  
										Int16  _ModuleID = 0;
							        
				public Int16 ModuleID 
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
                   
				  
										Int32  _Permission = 0;
							        
				public Int32 Permission 
				{ 
					get{ return _Permission;  }
					set{ _Permission = value; }
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
                      				        
			}               
			                   
}
 
			