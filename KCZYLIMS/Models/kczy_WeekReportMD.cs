          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_WeekReportMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _ContentCurrent = string.Empty;
							        
				public String ContentCurrent 
				{ 
					get{ return _ContentCurrent;  }
					set{ _ContentCurrent = value; }
				}
                   
				  
										String  _ContentLast = string.Empty;
							        
				public String ContentLast 
				{ 
					get{ return _ContentLast;  }
					set{ _ContentLast = value; }
				}
                   
				  
										String  _ContentNext = string.Empty;
							        
				public String ContentNext 
				{ 
					get{ return _ContentNext;  }
					set{ _ContentNext = value; }
				}
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
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
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										String  _ModifiedBy = string.Empty;
							        
				public String ModifiedBy 
				{ 
					get{ return _ModifiedBy;  }
					set{ _ModifiedBy = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										Int32  _WeekYear = 0;
							        
				public Int32 WeekYear 
				{ 
					get{ return _WeekYear;  }
					set{ _WeekYear = value; }
				}
                   
				  
										Int32  _WeekNum = 0;
							        
				public Int32 WeekNum 
				{ 
					get{ return _WeekNum;  }
					set{ _WeekNum = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                      				        
			}               
			                   
}
 
			