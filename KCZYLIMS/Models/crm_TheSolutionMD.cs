          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_TheSolutionMD : EntityMD                     
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
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
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
                   
				  
										Int32  _ContactID = 0;
							        
				public Int32 ContactID 
				{ 
					get{ return _ContactID;  }
					set{ _ContactID = value; }
				}
                   
				  
										String  _ContactName = string.Empty;
							        
				public String ContactName 
				{ 
					get{ return _ContactName;  }
					set{ _ContactName = value; }
				}
                   
				  
										String  _ContactPhone = string.Empty;
							        
				public String ContactPhone 
				{ 
					get{ return _ContactPhone;  }
					set{ _ContactPhone = value; }
				}
                   
				  
										String  _Email = string.Empty;
							        
				public String Email 
				{ 
					get{ return _Email;  }
					set{ _Email = value; }
				}
                   
				  
										String  _SalesCode = string.Empty;
							        
				public String SalesCode 
				{ 
					get{ return _SalesCode;  }
					set{ _SalesCode = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _OrigItemID = 0;
							        
				public Int32 OrigItemID 
				{ 
					get{ return _OrigItemID;  }
					set{ _OrigItemID = value; }
				}
                      				        
			}               
			                   
}
 
			