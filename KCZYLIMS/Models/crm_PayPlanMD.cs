          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_PayPlanMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _ContractID = 0;
							        
				public Int32 ContractID 
				{ 
					get{ return _ContractID;  }
					set{ _ContractID = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
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
                   
				  
										Int32  _Periods = 0;
							        
				public Int32 Periods 
				{ 
					get{ return _Periods;  }
					set{ _Periods = value; }
				}
                   
				  
										Int32  _PrincipalID = 0;
							        
				public Int32 PrincipalID 
				{ 
					get{ return _PrincipalID;  }
					set{ _PrincipalID = value; }
				}
                   
				  
										String  _PrincipalName = string.Empty;
							        
				public String PrincipalName 
				{ 
					get{ return _PrincipalName;  }
					set{ _PrincipalName = value; }
				}
                   
				  
										DateTime  _PayDate = DateTime.Now;
							        
				public DateTime PayDate 
				{ 
					get{ return _PayDate;  }
					set{ _PayDate = value; }
				}
                   
				  
										Decimal  _PayAmount = 0;
							        
				public Decimal PayAmount 
				{ 
					get{ return _PayAmount;  }
					set{ _PayAmount = value; }
				}
                   
				  
										Decimal  _PayedAmount = 0;
							        
				public Decimal PayedAmount 
				{ 
					get{ return _PayedAmount;  }
					set{ _PayedAmount = value; }
				}
                   
				  
										Boolean  _IsPayed = false;
							        
				public Boolean IsPayed 
				{ 
					get{ return _IsPayed;  }
					set{ _IsPayed = value; }
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
 
			