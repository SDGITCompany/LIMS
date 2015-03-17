          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_CustomerServiceMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
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
                   
				  
										String  _ModifierBy = string.Empty;
							        
				public String ModifierBy 
				{ 
					get{ return _ModifierBy;  }
					set{ _ModifierBy = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										String  _ServiceTitle = string.Empty;
							        
				public String ServiceTitle 
				{ 
					get{ return _ServiceTitle;  }
					set{ _ServiceTitle = value; }
				}
                   
				  
										Int32  _AccountID = 0;
							        
				public Int32 AccountID 
				{ 
					get{ return _AccountID;  }
					set{ _AccountID = value; }
				}
                   
				  
										String  _AccountName = string.Empty;
							        
				public String AccountName 
				{ 
					get{ return _AccountName;  }
					set{ _AccountName = value; }
				}
                   
				  
										String  _ServiceType = string.Empty;
							        
				public String ServiceType 
				{ 
					get{ return _ServiceType;  }
					set{ _ServiceType = value; }
				}
                   
				  
										String  _ServiceMode = string.Empty;
							        
				public String ServiceMode 
				{ 
					get{ return _ServiceMode;  }
					set{ _ServiceMode = value; }
				}
                   
				  
										DateTime  _ServiceDate = DateTime.Now;
							        
				public DateTime ServiceDate 
				{ 
					get{ return _ServiceDate;  }
					set{ _ServiceDate = value; }
				}
                   
				  
										String  _ContactName = string.Empty;
							        
				public String ContactName 
				{ 
					get{ return _ContactName;  }
					set{ _ContactName = value; }
				}
                   
				  
										String  _ServiceStatus = string.Empty;
							        
				public String ServiceStatus 
				{ 
					get{ return _ServiceStatus;  }
					set{ _ServiceStatus = value; }
				}
                   
				  
										String  _ServiceContent = string.Empty;
							        
				public String ServiceContent 
				{ 
					get{ return _ServiceContent;  }
					set{ _ServiceContent = value; }
				}
                   
				  
										Int32  _ChargeManID = 0;
							        
				public Int32 ChargeManID 
				{ 
					get{ return _ChargeManID;  }
					set{ _ChargeManID = value; }
				}
                   
				  
										String  _ChargeManName = string.Empty;
							        
				public String ChargeManName 
				{ 
					get{ return _ChargeManName;  }
					set{ _ChargeManName = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
				}
                   
				  
										DateTime  _EndTime = DateTime.Now;
							        
				public DateTime EndTime 
				{ 
					get{ return _EndTime;  }
					set{ _EndTime = value; }
				}
                   
				  
										String  _FeedBack = string.Empty;
							        
				public String FeedBack 
				{ 
					get{ return _FeedBack;  }
					set{ _FeedBack = value; }
				}
                   
				  
										Int32  _ContactID = 0;
							        
				public Int32 ContactID 
				{ 
					get{ return _ContactID;  }
					set{ _ContactID = value; }
				}
                   
				  
										String  _SalesCode = string.Empty;
							        
				public String SalesCode 
				{ 
					get{ return _SalesCode;  }
					set{ _SalesCode = value; }
				}
                      				        
			}               
			                   
}
 
			