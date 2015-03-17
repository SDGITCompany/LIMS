          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_InstrumentServiceMD : EntityMD                     
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
                   
				  
										Int32  _OrigID = 0;
							        
				public Int32 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										String  _MyCode = string.Empty;
							        
				public String MyCode 
				{ 
					get{ return _MyCode;  }
					set{ _MyCode = value; }
				}
                   
				  
										DateTime  _Date = DateTime.Now;
							        
				public DateTime Date 
				{ 
					get{ return _Date;  }
					set{ _Date = value; }
				}
                   
				  
										String  _Reason = string.Empty;
							        
				public String Reason 
				{ 
					get{ return _Reason;  }
					set{ _Reason = value; }
				}
                   
				  
										Int32  _BeginStatus = 0;
							        
				public Int32 BeginStatus 
				{ 
					get{ return _BeginStatus;  }
					set{ _BeginStatus = value; }
				}
                   
				  
										Int32  _EndStatus = 0;
							        
				public Int32 EndStatus 
				{ 
					get{ return _EndStatus;  }
					set{ _EndStatus = value; }
				}
                   
				  
										String  _Result = string.Empty;
							        
				public String Result 
				{ 
					get{ return _Result;  }
					set{ _Result = value; }
				}
                   
				  
										Int32  _OperaterID = 0;
							        
				public Int32 OperaterID 
				{ 
					get{ return _OperaterID;  }
					set{ _OperaterID = value; }
				}
                   
				  
										String  _Operater = string.Empty;
							        
				public String Operater 
				{ 
					get{ return _Operater;  }
					set{ _Operater = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
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
                   
				  
										Boolean  _Isdeleted = false;
							        
				public Boolean Isdeleted 
				{ 
					get{ return _Isdeleted;  }
					set{ _Isdeleted = value; }
				}
                      				        
			}               
			                   
}
 
			