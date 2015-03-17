          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_WeekReportMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _Value = string.Empty;
							        
				public String Value 
				{ 
					get{ return _Value;  }
					set{ _Value = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
				}
                   
				  
										Int32  _BusinessType = 0;
							        
				public Int32 BusinessType 
				{ 
					get{ return _BusinessType;  }
					set{ _BusinessType = value; }
				}
                   
				  
										Int32  _Phase = 0;
							        
				public Int32 Phase 
				{ 
					get{ return _Phase;  }
					set{ _Phase = value; }
				}
                   
				  
										String  _Department = string.Empty;
							        
				public String Department 
				{ 
					get{ return _Department;  }
					set{ _Department = value; }
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
                      				        
			}               
			                   
}
 
			