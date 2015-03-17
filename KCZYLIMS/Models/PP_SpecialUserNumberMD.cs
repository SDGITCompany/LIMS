          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class PP_SpecialUserNumberMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _PPID = 0;
							        
				public Int32 PPID 
				{ 
					get{ return _PPID;  }
					set{ _PPID = value; }
				}
                   
				  
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
                   
				  
										Int32  _SpecialUserNumber = 0;
							        
				public Int32 SpecialUserNumber 
				{ 
					get{ return _SpecialUserNumber;  }
					set{ _SpecialUserNumber = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										Int32  _PPOrigID = 0;
							        
				public Int32 PPOrigID 
				{ 
					get{ return _PPOrigID;  }
					set{ _PPOrigID = value; }
				}
                      				        
			}               
			                   
}
 
			