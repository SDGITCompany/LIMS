          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_InstrumentUsageMD : EntityMD                     
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
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
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
                   
				  
										String  _ProjectName = string.Empty;
							        
				public String ProjectName 
				{ 
					get{ return _ProjectName;  }
					set{ _ProjectName = value; }
				}
                   
				  
										String  _ProjectCode = string.Empty;
							        
				public String ProjectCode 
				{ 
					get{ return _ProjectCode;  }
					set{ _ProjectCode = value; }
				}
                   
				  
										DateTime  _BeginTime = DateTime.Now;
							        
				public DateTime BeginTime 
				{ 
					get{ return _BeginTime;  }
					set{ _BeginTime = value; }
				}
                   
				  
										DateTime  _EndTime = DateTime.Now;
							        
				public DateTime EndTime 
				{ 
					get{ return _EndTime;  }
					set{ _EndTime = value; }
				}
                   
				  
										String  _Operater = string.Empty;
							        
				public String Operater 
				{ 
					get{ return _Operater;  }
					set{ _Operater = value; }
				}
                   
				  
										Int32  _OperaterID = 0;
							        
				public Int32 OperaterID 
				{ 
					get{ return _OperaterID;  }
					set{ _OperaterID = value; }
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
 
			