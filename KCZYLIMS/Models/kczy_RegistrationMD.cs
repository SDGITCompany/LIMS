          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_RegistrationMD : EntityMD                     
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
                   
				  
										Decimal  _TotalCost = 0;
							        
				public Decimal TotalCost 
				{ 
					get{ return _TotalCost;  }
					set{ _TotalCost = value; }
				}
                   
				  
										Decimal  _Amount = 0;
							        
				public Decimal Amount 
				{ 
					get{ return _Amount;  }
					set{ _Amount = value; }
				}
                   
				  
										String  _Client = string.Empty;
							        
				public String Client 
				{ 
					get{ return _Client;  }
					set{ _Client = value; }
				}
                   
				  
										Int32  _ClientID = 0;
							        
				public Int32 ClientID 
				{ 
					get{ return _ClientID;  }
					set{ _ClientID = value; }
				}
                   
				  
										String  _SubClient = string.Empty;
							        
				public String SubClient 
				{ 
					get{ return _SubClient;  }
					set{ _SubClient = value; }
				}
                   
				  
										Int32  _SubClientID = 0;
							        
				public Int32 SubClientID 
				{ 
					get{ return _SubClientID;  }
					set{ _SubClientID = value; }
				}
                   
				  
										String  _Collecter = string.Empty;
							        
				public String Collecter 
				{ 
					get{ return _Collecter;  }
					set{ _Collecter = value; }
				}
                   
				  
										Int32  _CollecterID = 0;
							        
				public Int32 CollecterID 
				{ 
					get{ return _CollecterID;  }
					set{ _CollecterID = value; }
				}
                   
				  
										DateTime  _CollectDate = DateTime.Now;
							        
				public DateTime CollectDate 
				{ 
					get{ return _CollectDate;  }
					set{ _CollectDate = value; }
				}
                   
				  
										Decimal  _Balance = 0;
							        
				public Decimal Balance 
				{ 
					get{ return _Balance;  }
					set{ _Balance = value; }
				}
                   
				  
										DateTime  _ApproveDate = DateTime.Now;
							        
				public DateTime ApproveDate 
				{ 
					get{ return _ApproveDate;  }
					set{ _ApproveDate = value; }
				}
                   
				  
										Boolean  _IsCompleted = false;
							        
				public Boolean IsCompleted 
				{ 
					get{ return _IsCompleted;  }
					set{ _IsCompleted = value; }
				}
                   
				  
										Boolean  _IsPatented = false;
							        
				public Boolean IsPatented 
				{ 
					get{ return _IsPatented;  }
					set{ _IsPatented = value; }
				}
                   
				  
										Boolean  _IsChecked = false;
							        
				public Boolean IsChecked 
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
 
			