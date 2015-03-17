          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class SmartLinkMD : EntityMD                     
			{                       
				     
				  
										Int32  _LinkID = 0;
							        
				public Int32 LinkID 
				{ 
					get{ return _LinkID;  }
					set{ _LinkID = value; }
				}
                   
				  
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
                   
				  
										Int16  _TypeID = 0;
							        
				public Int16 TypeID 
				{ 
					get{ return _TypeID;  }
					set{ _TypeID = value; }
				}
                   
				  
										Byte  _IncludeSub = 0;
							        
				public Byte IncludeSub 
				{ 
					get{ return _IncludeSub;  }
					set{ _IncludeSub = value; }
				}
                   
				  
										Int32  _FieldID = 0;
							        
				public Int32 FieldID 
				{ 
					get{ return _FieldID;  }
					set{ _FieldID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int32  _MarkID = 0;
							        
				public Int32 MarkID 
				{ 
					get{ return _MarkID;  }
					set{ _MarkID = value; }
				}
                   
				  
										Int32  _LinkedID = 0;
							        
				public Int32 LinkedID 
				{ 
					get{ return _LinkedID;  }
					set{ _LinkedID = value; }
				}
                   
				  
										Int32  _LinkedOrigID = 0;
							        
				public Int32 LinkedOrigID 
				{ 
					get{ return _LinkedOrigID;  }
					set{ _LinkedOrigID = value; }
				}
                   
				  
										Int16  _LinkedType = 0;
							        
				public Int16 LinkedType 
				{ 
					get{ return _LinkedType;  }
					set{ _LinkedType = value; }
				}
                   
				  
										Int32  _LinkedFieldID = 0;
							        
				public Int32 LinkedFieldID 
				{ 
					get{ return _LinkedFieldID;  }
					set{ _LinkedFieldID = value; }
				}
                   
				  
										Int32  _LinkedModuleID = 0;
							        
				public Int32 LinkedModuleID 
				{ 
					get{ return _LinkedModuleID;  }
					set{ _LinkedModuleID = value; }
				}
                   
				  
										Int32  _LinkedMarkID = 0;
							        
				public Int32 LinkedMarkID 
				{ 
					get{ return _LinkedMarkID;  }
					set{ _LinkedMarkID = value; }
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
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										String  _Url = string.Empty;
							        
				public String Url 
				{ 
					get{ return _Url;  }
					set{ _Url = value; }
				}
                      				        
			}               
			                   
}
 
			