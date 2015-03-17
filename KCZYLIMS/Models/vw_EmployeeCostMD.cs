          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class vw_EmployeeCostMD : EntityMD                     
			{                       
				     
				  
										Int32  _Psid = 0;
							        
				public Int32 Psid 
				{ 
					get{ return _Psid;  }
					set{ _Psid = value; }
				}
                   
				  
										Int32  _PsOrigID = 0;
							        
				public Int32 PsOrigID 
				{ 
					get{ return _PsOrigID;  }
					set{ _PsOrigID = value; }
				}
                   
				  
										String  _PsName = string.Empty;
							        
				public String PsName 
				{ 
					get{ return _PsName;  }
					set{ _PsName = value; }
				}
                   
				  
										Int32  _GroupID = 0;
							        
				public Int32 GroupID 
				{ 
					get{ return _GroupID;  }
					set{ _GroupID = value; }
				}
                   
				  
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
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										String  _ItemName = string.Empty;
							        
				public String ItemName 
				{ 
					get{ return _ItemName;  }
					set{ _ItemName = value; }
				}
                   
				  
										Int32  _Gs = 0;
							        
				public Int32 Gs 
				{ 
					get{ return _Gs;  }
					set{ _Gs = value; }
				}
                   
				  
										Decimal  _workhour = 0;
							        
				public Decimal workhour 
				{ 
					get{ return _workhour;  }
					set{ _workhour = value; }
				}
                   
				  
										String  _FullName = string.Empty;
							        
				public String FullName 
				{ 
					get{ return _FullName;  }
					set{ _FullName = value; }
				}
                   
				  
										Int32  _ActureNumber = 0;
							        
				public Int32 ActureNumber 
				{ 
					get{ return _ActureNumber;  }
					set{ _ActureNumber = value; }
				}
                   
				  
										Int64  _UserID = 0;
							        
				public Int64 UserID 
				{ 
					get{ return _UserID;  }
					set{ _UserID = value; }
				}
                      				        
			}               
			                   
}
 
			