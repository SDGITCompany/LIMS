          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_ProjectApproveMD : EntityMD                     
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
                   
				  
										String  _Writer = string.Empty;
							        
				public String Writer 
				{ 
					get{ return _Writer;  }
					set{ _Writer = value; }
				}
                   
				  
										Int32  _WriterID = 0;
							        
				public Int32 WriterID 
				{ 
					get{ return _WriterID;  }
					set{ _WriterID = value; }
				}
                   
				  
										DateTime  _BeginDate = DateTime.Now;
							        
				public DateTime BeginDate 
				{ 
					get{ return _BeginDate;  }
					set{ _BeginDate = value; }
				}
                   
				  
										DateTime  _EndDate = DateTime.Now;
							        
				public DateTime EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										DateTime  _ApproveDate = DateTime.Now;
							        
				public DateTime ApproveDate 
				{ 
					get{ return _ApproveDate;  }
					set{ _ApproveDate = value; }
				}
                   
				  
										Int32  _IsCompleted = 0;
							        
				public Int32 IsCompleted 
				{ 
					get{ return _IsCompleted;  }
					set{ _IsCompleted = value; }
				}
                   
				  
										Int32  _IsPatented = 0;
							        
				public Int32 IsPatented 
				{ 
					get{ return _IsPatented;  }
					set{ _IsPatented = value; }
				}
                   
				  
										Int32  _IsChecked = 0;
							        
				public Int32 IsChecked 
				{ 
					get{ return _IsChecked;  }
					set{ _IsChecked = value; }
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
                      				        
			}               
			                   
}
 
			