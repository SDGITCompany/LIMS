          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class DueDateMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Byte  _RelatedType = 0;
							        
				public Byte RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Byte  _ModuleID = 0;
							        
				public Byte ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int32  _StructID = 0;
							        
				public Int32 StructID 
				{ 
					get{ return _StructID;  }
					set{ _StructID = value; }
				}
                   
				  
										Int32  _DueDays = 0;
							        
				public Int32 DueDays 
				{ 
					get{ return _DueDays;  }
					set{ _DueDays = value; }
				}
                   
				  
										DateTime  _DueDate = DateTime.Now;
							        
				public DateTime DueDate 
				{ 
					get{ return _DueDate;  }
					set{ _DueDate = value; }
				}
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										DateTime  _EndDate = DateTime.Now;
							        
				public DateTime EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										Byte  _HandleType = 0;
							        
				public Byte HandleType 
				{ 
					get{ return _HandleType;  }
					set{ _HandleType = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                      				        
			}               
			                   
}
 
			