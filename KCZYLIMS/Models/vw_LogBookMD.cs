          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_LogBookMD : EntityMD                     
			{                       
				     
				  
										Int64  _LogID = 0;
							        
				public Int64 LogID 
				{ 
					get{ return _LogID;  }
					set{ _LogID = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                   
				  
										Int64  _RelatedID = 0;
							        
				public Int64 RelatedID 
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
                   
				  
										Int64  _ProjID = 0;
							        
				public Int64 ProjID 
				{ 
					get{ return _ProjID;  }
					set{ _ProjID = value; }
				}
                   
				  
										Int64  _ProjOrigID = 0;
							        
				public Int64 ProjOrigID 
				{ 
					get{ return _ProjOrigID;  }
					set{ _ProjOrigID = value; }
				}
                   
				  
										DateTime  _StartDayTime = DateTime.Now;
							        
				public DateTime StartDayTime 
				{ 
					get{ return _StartDayTime;  }
					set{ _StartDayTime = value; }
				}
                   
				  
										DateTime  _EndDayTime = DateTime.Now;
							        
				public DateTime EndDayTime 
				{ 
					get{ return _EndDayTime;  }
					set{ _EndDayTime = value; }
				}
                   
				  
										Decimal  _workhour = 0;
							        
				public Decimal workhour 
				{ 
					get{ return _workhour;  }
					set{ _workhour = value; }
				}
                   
				  
										String  _address = string.Empty;
							        
				public String address 
				{ 
					get{ return _address;  }
					set{ _address = value; }
				}
                   
				  
										Int32  _workclass = 0;
							        
				public Int32 workclass 
				{ 
					get{ return _workclass;  }
					set{ _workclass = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										Byte  _week = 0;
							        
				public Byte week 
				{ 
					get{ return _week;  }
					set{ _week = value; }
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
                   
				  
										Int32  _addressType = 0;
							        
				public Int32 addressType 
				{ 
					get{ return _addressType;  }
					set{ _addressType = value; }
				}
                   
				  
										Int32  _year = 0;
							        
				public Int32 year 
				{ 
					get{ return _year;  }
					set{ _year = value; }
				}
                   
				  
										Int32  _month = 0;
							        
				public Int32 month 
				{ 
					get{ return _month;  }
					set{ _month = value; }
				}
                   
				  
										Int32  _day = 0;
							        
				public Int32 day 
				{ 
					get{ return _day;  }
					set{ _day = value; }
				}
                   
				  
										Boolean  _IsReWork = false;
							        
				public Boolean IsReWork 
				{ 
					get{ return _IsReWork;  }
					set{ _IsReWork = value; }
				}
                      				        
			}               
			                   
}
 
			