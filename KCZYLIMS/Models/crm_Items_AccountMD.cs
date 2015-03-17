          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_Items_AccountMD : EntityMD                     
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
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										String  _RelatedType = string.Empty;
							        
				public String RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										String  _DeliveryCycle = string.Empty;
							        
				public String DeliveryCycle 
				{ 
					get{ return _DeliveryCycle;  }
					set{ _DeliveryCycle = value; }
				}
                   
				  
										String  _RelatedName = string.Empty;
							        
				public String RelatedName 
				{ 
					get{ return _RelatedName;  }
					set{ _RelatedName = value; }
				}
                   
				  
										Decimal  _DeliveryPrice = 0;
							        
				public Decimal DeliveryPrice 
				{ 
					get{ return _DeliveryPrice;  }
					set{ _DeliveryPrice = value; }
				}
                   
				  
										String  _DeliveryMothed = string.Empty;
							        
				public String DeliveryMothed 
				{ 
					get{ return _DeliveryMothed;  }
					set{ _DeliveryMothed = value; }
				}
                   
				  
										String  _DeliveryPriceKind = string.Empty;
							        
				public String DeliveryPriceKind 
				{ 
					get{ return _DeliveryPriceKind;  }
					set{ _DeliveryPriceKind = value; }
				}
                      				        
			}               
			                   
}
 
			