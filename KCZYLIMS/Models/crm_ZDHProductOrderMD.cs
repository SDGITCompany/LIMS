          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ZDHProductOrderMD : EntityMD                     
			{                       
				     
				  
										Int64  _ID = 0;
							        
				public Int64 ID 
				{ 
					get{ return _ID;  }
					set{ _ID = value; }
				}
                   
				  
										String  _ContractID = string.Empty;
							        
				public String ContractID 
				{ 
					get{ return _ContractID;  }
					set{ _ContractID = value; }
				}
                   
				  
										String  _ContractType = string.Empty;
							        
				public String ContractType 
				{ 
					get{ return _ContractType;  }
					set{ _ContractType = value; }
				}
                   
				  
										String  _ContractLaunchCond = string.Empty;
							        
				public String ContractLaunchCond 
				{ 
					get{ return _ContractLaunchCond;  }
					set{ _ContractLaunchCond = value; }
				}
                   
				  
										String  _FirstMoneyStat = string.Empty;
							        
				public String FirstMoneyStat 
				{ 
					get{ return _FirstMoneyStat;  }
					set{ _FirstMoneyStat = value; }
				}
                   
				  
										Boolean  _IsBatch = false;
							        
				public Boolean IsBatch 
				{ 
					get{ return _IsBatch;  }
					set{ _IsBatch = value; }
				}
                   
				  
										Int32  _Priority = 0;
							        
				public Int32 Priority 
				{ 
					get{ return _Priority;  }
					set{ _Priority = value; }
				}
                   
				  
										Int64  _CreatorID = 0;
							        
				public Int64 CreatorID 
				{ 
					get{ return _CreatorID;  }
					set{ _CreatorID = value; }
				}
                   
				  
										String  _CreatorFullName = string.Empty;
							        
				public String CreatorFullName 
				{ 
					get{ return _CreatorFullName;  }
					set{ _CreatorFullName = value; }
				}
                   
				  
										DateTime  _CreateDate = DateTime.Now;
							        
				public DateTime CreateDate 
				{ 
					get{ return _CreateDate;  }
					set{ _CreateDate = value; }
				}
                   
				  
										String  _MyStatus = string.Empty;
							        
				public String MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                      				        
			}               
			                   
}
 
			