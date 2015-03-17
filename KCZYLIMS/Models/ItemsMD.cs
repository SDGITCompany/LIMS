          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class ItemsMD : EntityMD                     
			{                       
				     
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
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
                   
				  
										Int32  _ParentID = 0;
							        
				public Int32 ParentID 
				{ 
					get{ return _ParentID;  }
					set{ _ParentID = value; }
				}
                   
				  
										Int32  _ResultFormID = 0;
							        
				public Int32 ResultFormID 
				{ 
					get{ return _ResultFormID;  }
					set{ _ResultFormID = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
										Int32  _ModuleID = 0;
							        
				public Int32 ModuleID 
				{ 
					get{ return _ModuleID;  }
					set{ _ModuleID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _Permission = 0;
							        
				public Int32 Permission 
				{ 
					get{ return _Permission;  }
					set{ _Permission = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										Int32  _TypeID = 0;
							        
				public Int32 TypeID 
				{ 
					get{ return _TypeID;  }
					set{ _TypeID = value; }
				}
                   
				  
										Int16  _HasLink = 0;
							        
				public Int16 HasLink 
				{ 
					get{ return _HasLink;  }
					set{ _HasLink = value; }
				}
                   
				  
										Int16  _MyStatus = 0;
							        
				public Int16 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										Int16  _TotalStatus = 0;
							        
				public Int16 TotalStatus 
				{ 
					get{ return _TotalStatus;  }
					set{ _TotalStatus = value; }
				}
                   
				  
										Int16  _ApprovalStatus = 0;
							        
				public Int16 ApprovalStatus 
				{ 
					get{ return _ApprovalStatus;  }
					set{ _ApprovalStatus = value; }
				}
                   
				  
										String  _MyVersion = string.Empty;
							        
				public String MyVersion 
				{ 
					get{ return _MyVersion;  }
					set{ _MyVersion = value; }
				}
                   
				  
										Int16  _IsCheckedOut = 0;
							        
				public Int16 IsCheckedOut 
				{ 
					get{ return _IsCheckedOut;  }
					set{ _IsCheckedOut = value; }
				}
                   
				  
										String  _CheckedOutBy = string.Empty;
							        
				public String CheckedOutBy 
				{ 
					get{ return _CheckedOutBy;  }
					set{ _CheckedOutBy = value; }
				}
                   
				  
										Int32  _CheckedOutID = 0;
							        
				public Int32 CheckedOutID 
				{ 
					get{ return _CheckedOutID;  }
					set{ _CheckedOutID = value; }
				}
                   
				  
										String  _CheckedOutDate = string.Empty;
							        
				public String CheckedOutDate 
				{ 
					get{ return _CheckedOutDate;  }
					set{ _CheckedOutDate = value; }
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
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
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
                   
				  
										Int32  _ModifierID = 0;
							        
				public Int32 ModifierID 
				{ 
					get{ return _ModifierID;  }
					set{ _ModifierID = value; }
				}
                   
				  
										String  _OptionSet = string.Empty;
							        
				public String OptionSet 
				{ 
					get{ return _OptionSet;  }
					set{ _OptionSet = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Double  _MySize = 0;
							        
				public Double MySize 
				{ 
					get{ return _MySize;  }
					set{ _MySize = value; }
				}
                   
				  
										Int32  _ProjID = 0;
							        
				public Int32 ProjID 
				{ 
					get{ return _ProjID;  }
					set{ _ProjID = value; }
				}
                   
				  
										Int32  _ProjOrigID = 0;
							        
				public Int32 ProjOrigID 
				{ 
					get{ return _ProjOrigID;  }
					set{ _ProjOrigID = value; }
				}
                   
				  
										Int32  _FlowID = 0;
							        
				public Int32 FlowID 
				{ 
					get{ return _FlowID;  }
					set{ _FlowID = value; }
				}
                   
				  
										String  _ApprovalSteps = string.Empty;
							        
				public String ApprovalSteps 
				{ 
					get{ return _ApprovalSteps;  }
					set{ _ApprovalSteps = value; }
				}
                   
				  
										Int32  _MyClass = 0;
							        
				public Int32 MyClass 
				{ 
					get{ return _MyClass;  }
					set{ _MyClass = value; }
				}
                   
				  
										String  _MyLabel = string.Empty;
							        
				public String MyLabel 
				{ 
					get{ return _MyLabel;  }
					set{ _MyLabel = value; }
				}
                   
				  
										Int32  _PrintNo = 0;
							        
				public Int32 PrintNo 
				{ 
					get{ return _PrintNo;  }
					set{ _PrintNo = value; }
				}
                   
				  
										String  _AddInfo = string.Empty;
							        
				public String AddInfo 
				{ 
					get{ return _AddInfo;  }
					set{ _AddInfo = value; }
				}
                   
				  
										Int32  _PPID = 0;
							        
				public Int32 PPID 
				{ 
					get{ return _PPID;  }
					set{ _PPID = value; }
				}
                   
				  
										Int32  _PPOrigID = 0;
							        
				public Int32 PPOrigID 
				{ 
					get{ return _PPOrigID;  }
					set{ _PPOrigID = value; }
				}
                   
				  
										Int32  _ProductNumber = 0;
							        
				public Int32 ProductNumber 
				{ 
					get{ return _ProductNumber;  }
					set{ _ProductNumber = value; }
				}
                   
				  
										Int32  _MyOrder = 0;
							        
				public Int32 MyOrder 
				{ 
					get{ return _MyOrder;  }
					set{ _MyOrder = value; }
				}
                      				        
			}               
			                   
}
 
			