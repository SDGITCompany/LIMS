          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class PP_OrderRequisitionMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _PPName = string.Empty;
							        
				public String PPName 
				{ 
					get{ return _PPName;  }
					set{ _PPName = value; }
				}
                   
				  
										Int32  _PPID = 0;
							        
				public Int32 PPID 
				{ 
					get{ return _PPID;  }
					set{ _PPID = value; }
				}
                   
				  
										String  _SupplierName = string.Empty;
							        
				public String SupplierName 
				{ 
					get{ return _SupplierName;  }
					set{ _SupplierName = value; }
				}
                   
				  
										Int32  _SupplierID = 0;
							        
				public Int32 SupplierID 
				{ 
					get{ return _SupplierID;  }
					set{ _SupplierID = value; }
				}
                   
				  
										Decimal  _Price = 0;
							        
				public Decimal Price 
				{ 
					get{ return _Price;  }
					set{ _Price = value; }
				}
                   
				  
										Int32  _PPOrigID = 0;
							        
				public Int32 PPOrigID 
				{ 
					get{ return _PPOrigID;  }
					set{ _PPOrigID = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										String  _MyStatus = string.Empty;
							        
				public String MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										DateTime  _DueDate = DateTime.Now;
							        
				public DateTime DueDate 
				{ 
					get{ return _DueDate;  }
					set{ _DueDate = value; }
				}
                   
				  
										DateTime  _EndDate = DateTime.Now;
							        
				public DateTime EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										Decimal  _RealPrice = 0;
							        
				public Decimal RealPrice 
				{ 
					get{ return _RealPrice;  }
					set{ _RealPrice = value; }
				}
                   
				  
										String  _SpecialUserName = string.Empty;
							        
				public String SpecialUserName 
				{ 
					get{ return _SpecialUserName;  }
					set{ _SpecialUserName = value; }
				}
                   
				  
										Int32  _SpecialUserID = 0;
							        
				public Int32 SpecialUserID 
				{ 
					get{ return _SpecialUserID;  }
					set{ _SpecialUserID = value; }
				}
                      				        
			}               
			                   
}
 
			