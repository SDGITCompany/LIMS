          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_ExperimentRecordsMD : EntityMD                     
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
                   
				  
										String  _Analyst = string.Empty;
							        
				public String Analyst 
				{ 
					get{ return _Analyst;  }
					set{ _Analyst = value; }
				}
                   
				  
										Int32  _AnalystID = 0;
							        
				public Int32 AnalystID 
				{ 
					get{ return _AnalystID;  }
					set{ _AnalystID = value; }
				}
                   
				  
										String  _InstrumentName = string.Empty;
							        
				public String InstrumentName 
				{ 
					get{ return _InstrumentName;  }
					set{ _InstrumentName = value; }
				}
                   
				  
										String  _InstrumentCode = string.Empty;
							        
				public String InstrumentCode 
				{ 
					get{ return _InstrumentCode;  }
					set{ _InstrumentCode = value; }
				}
                   
				  
										String  _SampleName = string.Empty;
							        
				public String SampleName 
				{ 
					get{ return _SampleName;  }
					set{ _SampleName = value; }
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
                   
				  
										Int32  _BeiginStatus = 0;
							        
				public Int32 BeiginStatus 
				{ 
					get{ return _BeiginStatus;  }
					set{ _BeiginStatus = value; }
				}
                   
				  
										Int32  _EndStatus = 0;
							        
				public Int32 EndStatus 
				{ 
					get{ return _EndStatus;  }
					set{ _EndStatus = value; }
				}
                   
				  
										Int32  _Specialty = 0;
							        
				public Int32 Specialty 
				{ 
					get{ return _Specialty;  }
					set{ _Specialty = value; }
				}
                   
				  
										String  _Records = string.Empty;
							        
				public String Records 
				{ 
					get{ return _Records;  }
					set{ _Records = value; }
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
                      				        
			}               
			                   
}
 
			