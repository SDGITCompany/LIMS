          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class MyDatesMD : EntityMD                     
			{                       
				     
				  
										Int32  _DateID = 0;
							        
				public Int32 DateID 
				{ 
					get{ return _DateID;  }
					set{ _DateID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										Int16  _SetType = 0;
							        
				public Int16 SetType 
				{ 
					get{ return _SetType;  }
					set{ _SetType = value; }
				}
                   
				  
										Int16  _DateType = 0;
							        
				public Int16 DateType 
				{ 
					get{ return _DateType;  }
					set{ _DateType = value; }
				}
                   
				  
										Int32  _IntervalNum = 0;
							        
				public Int32 IntervalNum 
				{ 
					get{ return _IntervalNum;  }
					set{ _IntervalNum = value; }
				}
                   
				  
										Int32  _IntervalType = 0;
							        
				public Int32 IntervalType 
				{ 
					get{ return _IntervalType;  }
					set{ _IntervalType = value; }
				}
                   
				  
										DateTime  _DateValue = DateTime.Now;
							        
				public DateTime DateValue 
				{ 
					get{ return _DateValue;  }
					set{ _DateValue = value; }
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
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                      				        
			}               
			                   
}
 
			