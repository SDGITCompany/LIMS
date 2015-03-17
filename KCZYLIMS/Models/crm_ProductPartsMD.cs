          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_ProductPartsMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Int32  _ProductPartsItemID = 0;
							        
				public Int32 ProductPartsItemID 
				{ 
					get{ return _ProductPartsItemID;  }
					set{ _ProductPartsItemID = value; }
				}
                   
				  
										String  _ProductPartsName = string.Empty;
							        
				public String ProductPartsName 
				{ 
					get{ return _ProductPartsName;  }
					set{ _ProductPartsName = value; }
				}
                   
				  
										Decimal  _Number = 0;
							        
				public Decimal Number 
				{ 
					get{ return _Number;  }
					set{ _Number = value; }
				}
                   
				  
										Decimal  _Quantity = 0;
							        
				public Decimal Quantity 
				{ 
					get{ return _Quantity;  }
					set{ _Quantity = value; }
				}
                   
				  
										Decimal  _CostPrice = 0;
							        
				public Decimal CostPrice 
				{ 
					get{ return _CostPrice;  }
					set{ _CostPrice = value; }
				}
                   
				  
										Decimal  _MarketPrice = 0;
							        
				public Decimal MarketPrice 
				{ 
					get{ return _MarketPrice;  }
					set{ _MarketPrice = value; }
				}
                   
				  
										Int32  _ProcID = 0;
							        
				public Int32 ProcID 
				{ 
					get{ return _ProcID;  }
					set{ _ProcID = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										String  _Code = string.Empty;
							        
				public String Code 
				{ 
					get{ return _Code;  }
					set{ _Code = value; }
				}
                   
				  
										String  _Unit = string.Empty;
							        
				public String Unit 
				{ 
					get{ return _Unit;  }
					set{ _Unit = value; }
				}
                   
				  
										String  _Model = string.Empty;
							        
				public String Model 
				{ 
					get{ return _Model;  }
					set{ _Model = value; }
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
                   
				  
										Int32  _MyStatus = 0;
							        
				public Int32 MyStatus 
				{ 
					get{ return _MyStatus;  }
					set{ _MyStatus = value; }
				}
                   
				  
										String  _CreateBy = string.Empty;
							        
				public String CreateBy 
				{ 
					get{ return _CreateBy;  }
					set{ _CreateBy = value; }
				}
                   
				  
										String  _ModifierBy = string.Empty;
							        
				public String ModifierBy 
				{ 
					get{ return _ModifierBy;  }
					set{ _ModifierBy = value; }
				}
                   
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _Type = 0;
							        
				public Int32 Type 
				{ 
					get{ return _Type;  }
					set{ _Type = value; }
				}
                   
				  
										Decimal  _TransactionPrice = 0;
							        
				public Decimal TransactionPrice 
				{ 
					get{ return _TransactionPrice;  }
					set{ _TransactionPrice = value; }
				}
                   
				  
										Decimal  _NormalCircle = 0;
							        
				public Decimal NormalCircle 
				{ 
					get{ return _NormalCircle;  }
					set{ _NormalCircle = value; }
				}
                   
				  
										DateTime  _StartDate = DateTime.Now;
							        
				public DateTime StartDate 
				{ 
					get{ return _StartDate;  }
					set{ _StartDate = value; }
				}
                   
				  
										String  _EndDate = string.Empty;
							        
				public String EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										Int64  _Responsor = 0;
							        
				public Int64 Responsor 
				{ 
					get{ return _Responsor;  }
					set{ _Responsor = value; }
				}
                   
				  
										String  _ResponsorName = string.Empty;
							        
				public String ResponsorName 
				{ 
					get{ return _ResponsorName;  }
					set{ _ResponsorName = value; }
				}
                   
				  
										Boolean  _Accepted = false;
							        
				public Boolean Accepted 
				{ 
					get{ return _Accepted;  }
					set{ _Accepted = value; }
				}
                   
				  
										Int32  _UserTaskID = 0;
							        
				public Int32 UserTaskID 
				{ 
					get{ return _UserTaskID;  }
					set{ _UserTaskID = value; }
				}
                   
				  
										Int64  _PPProjectID = 0;
							        
				public Int64 PPProjectID 
				{ 
					get{ return _PPProjectID;  }
					set{ _PPProjectID = value; }
				}
                      				        
			}               
			                   
}
 
			