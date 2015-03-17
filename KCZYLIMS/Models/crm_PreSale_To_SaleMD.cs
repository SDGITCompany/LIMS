          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_PreSale_To_SaleMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										Int32  _PreSaleItemOrigID = 0;
							        
				public Int32 PreSaleItemOrigID 
				{ 
					get{ return _PreSaleItemOrigID;  }
					set{ _PreSaleItemOrigID = value; }
				}
                   
				  
										String  _PreSaleItemName = string.Empty;
							        
				public String PreSaleItemName 
				{ 
					get{ return _PreSaleItemName;  }
					set{ _PreSaleItemName = value; }
				}
                   
				  
										Int32  _SaleItemOrigID = 0;
							        
				public Int32 SaleItemOrigID 
				{ 
					get{ return _SaleItemOrigID;  }
					set{ _SaleItemOrigID = value; }
				}
                   
				  
										String  _SaleItemName = string.Empty;
							        
				public String SaleItemName 
				{ 
					get{ return _SaleItemName;  }
					set{ _SaleItemName = value; }
				}
                      				        
			}               
			                   
}
 
			