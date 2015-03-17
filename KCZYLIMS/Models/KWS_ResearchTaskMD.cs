          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class KWS_ResearchTaskMD : EntityMD                     
			{                       
				     
				  
										Int64  _MyID = 0;
							        
				public Int64 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int64  _ItemID = 0;
							        
				public Int64 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int64  _OrigID = 0;
							        
				public Int64 OrigID 
				{ 
					get{ return _OrigID;  }
					set{ _OrigID = value; }
				}
                   
				  
										DateTime  _StartDateTime = DateTime.Now;
							        
				public DateTime StartDateTime 
				{ 
					get{ return _StartDateTime;  }
					set{ _StartDateTime = value; }
				}
                   
				  
										DateTime  _EndDateTime = DateTime.Now;
							        
				public DateTime EndDateTime 
				{ 
					get{ return _EndDateTime;  }
					set{ _EndDateTime = value; }
				}
                   
				  
										String  _ResearchContent = string.Empty;
							        
				public String ResearchContent 
				{ 
					get{ return _ResearchContent;  }
					set{ _ResearchContent = value; }
				}
                   
				  
										String  _Responsors = string.Empty;
							        
				public String Responsors 
				{ 
					get{ return _Responsors;  }
					set{ _Responsors = value; }
				}
                   
				  
										Int32  _ProjectMgrID = 0;
							        
				public Int32 ProjectMgrID 
				{ 
					get{ return _ProjectMgrID;  }
					set{ _ProjectMgrID = value; }
				}
                   
				  
										DateTime  _SolutionDate = DateTime.Now;
							        
				public DateTime SolutionDate 
				{ 
					get{ return _SolutionDate;  }
					set{ _SolutionDate = value; }
				}
                   
				  
										DateTime  _MidDate = DateTime.Now;
							        
				public DateTime MidDate 
				{ 
					get{ return _MidDate;  }
					set{ _MidDate = value; }
				}
                   
				  
										String  _TechBenchmark = string.Empty;
							        
				public String TechBenchmark 
				{ 
					get{ return _TechBenchmark;  }
					set{ _TechBenchmark = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
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
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int64  _DocID = 0;
							        
				public Int64 DocID 
				{ 
					get{ return _DocID;  }
					set{ _DocID = value; }
				}
                   
				  
										Int64  _RefGroupID = 0;
							        
				public Int64 RefGroupID 
				{ 
					get{ return _RefGroupID;  }
					set{ _RefGroupID = value; }
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
                   
				  
										Int32  _CreatorID = 0;
							        
				public Int32 CreatorID 
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
                   
				  
										String  _Actor = string.Empty;
							        
				public String Actor 
				{ 
					get{ return _Actor;  }
					set{ _Actor = value; }
				}
                      				        
			}               
			                   
}
 
			