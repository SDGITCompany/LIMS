          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class PPKeyInfoMD : EntityMD                     
			{                       
				     
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										String  _PPLabel = string.Empty;
							        
				public String PPLabel 
				{ 
					get{ return _PPLabel;  }
					set{ _PPLabel = value; }
				}
                   
				  
										Boolean  _IsKeyPP = false;
							        
				public Boolean IsKeyPP 
				{ 
					get{ return _IsKeyPP;  }
					set{ _IsKeyPP = value; }
				}
                   
				  
										Boolean  _Enabled = false;
							        
				public Boolean Enabled 
				{ 
					get{ return _Enabled;  }
					set{ _Enabled = value; }
				}
                   
				  
										Decimal  _RatedStock = 0;
							        
				public Decimal RatedStock 
				{ 
					get{ return _RatedStock;  }
					set{ _RatedStock = value; }
				}
                   
				  
										String  _StockArea = string.Empty;
							        
				public String StockArea 
				{ 
					get{ return _StockArea;  }
					set{ _StockArea = value; }
				}
                   
				  
										Decimal  _ReferencePrice = 0;
							        
				public Decimal ReferencePrice 
				{ 
					get{ return _ReferencePrice;  }
					set{ _ReferencePrice = value; }
				}
                   
				  
										Byte  _UnitType = 0;
							        
				public Byte UnitType 
				{ 
					get{ return _UnitType;  }
					set{ _UnitType = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										Decimal  _MinStock = 0;
							        
				public Decimal MinStock 
				{ 
					get{ return _MinStock;  }
					set{ _MinStock = value; }
				}
                   
				  
										Decimal  _MaxStock = 0;
							        
				public Decimal MaxStock 
				{ 
					get{ return _MaxStock;  }
					set{ _MaxStock = value; }
				}
                   
				  
										Decimal  _StandardLength = 0;
							        
				public Decimal StandardLength 
				{ 
					get{ return _StandardLength;  }
					set{ _StandardLength = value; }
				}
                   
				  
										Decimal  _StandardWidth = 0;
							        
				public Decimal StandardWidth 
				{ 
					get{ return _StandardWidth;  }
					set{ _StandardWidth = value; }
				}
                   
				  
										Decimal  _StandardHeight = 0;
							        
				public Decimal StandardHeight 
				{ 
					get{ return _StandardHeight;  }
					set{ _StandardHeight = value; }
				}
                   
				  
										Byte  _StandardSizeUnit = 0;
							        
				public Byte StandardSizeUnit 
				{ 
					get{ return _StandardSizeUnit;  }
					set{ _StandardSizeUnit = value; }
				}
                   
				  
										Decimal  _StandardWeight = 0;
							        
				public Decimal StandardWeight 
				{ 
					get{ return _StandardWeight;  }
					set{ _StandardWeight = value; }
				}
                   
				  
										Byte  _StandardWeightUnit = 0;
							        
				public Byte StandardWeightUnit 
				{ 
					get{ return _StandardWeightUnit;  }
					set{ _StandardWeightUnit = value; }
				}
                   
				  
										Decimal  _ShelfLife = 0;
							        
				public Decimal ShelfLife 
				{ 
					get{ return _ShelfLife;  }
					set{ _ShelfLife = value; }
				}
                   
				  
										Byte  _ShelfLifeUnit = 0;
							        
				public Byte ShelfLifeUnit 
				{ 
					get{ return _ShelfLifeUnit;  }
					set{ _ShelfLifeUnit = value; }
				}
                   
				  
										Byte  _ShelfLifeType = 0;
							        
				public Byte ShelfLifeType 
				{ 
					get{ return _ShelfLifeType;  }
					set{ _ShelfLifeType = value; }
				}
                   
				  
										Byte  _PhysicalState = 0;
							        
				public Byte PhysicalState 
				{ 
					get{ return _PhysicalState;  }
					set{ _PhysicalState = value; }
				}
                   
				  
										Decimal  _StockLife = 0;
							        
				public Decimal StockLife 
				{ 
					get{ return _StockLife;  }
					set{ _StockLife = value; }
				}
                   
				  
										Decimal  _ReferenceBuyPrice = 0;
							        
				public Decimal ReferenceBuyPrice 
				{ 
					get{ return _ReferenceBuyPrice;  }
					set{ _ReferenceBuyPrice = value; }
				}
                   
				  
										Decimal  _ReferenceProvidePrice = 0;
							        
				public Decimal ReferenceProvidePrice 
				{ 
					get{ return _ReferenceProvidePrice;  }
					set{ _ReferenceProvidePrice = value; }
				}
                   
				  
										Decimal  _ReferenceProductPrice = 0;
							        
				public Decimal ReferenceProductPrice 
				{ 
					get{ return _ReferenceProductPrice;  }
					set{ _ReferenceProductPrice = value; }
				}
                   
				  
										Decimal  _ReferenceBuyLife = 0;
							        
				public Decimal ReferenceBuyLife 
				{ 
					get{ return _ReferenceBuyLife;  }
					set{ _ReferenceBuyLife = value; }
				}
                   
				  
										Decimal  _ReferenceProvideLife = 0;
							        
				public Decimal ReferenceProvideLife 
				{ 
					get{ return _ReferenceProvideLife;  }
					set{ _ReferenceProvideLife = value; }
				}
                   
				  
										Decimal  _ReferenceProductLife = 0;
							        
				public Decimal ReferenceProductLife 
				{ 
					get{ return _ReferenceProductLife;  }
					set{ _ReferenceProductLife = value; }
				}
                   
				  
										String  _RackArea = string.Empty;
							        
				public String RackArea 
				{ 
					get{ return _RackArea;  }
					set{ _RackArea = value; }
				}
                   
				  
										String  _Aliases = string.Empty;
							        
				public String Aliases 
				{ 
					get{ return _Aliases;  }
					set{ _Aliases = value; }
				}
                   
				  
										String  _PercentageOfEffective = string.Empty;
							        
				public String PercentageOfEffective 
				{ 
					get{ return _PercentageOfEffective;  }
					set{ _PercentageOfEffective = value; }
				}
                   
				  
										String  _PackingSpecification = string.Empty;
							        
				public String PackingSpecification 
				{ 
					get{ return _PackingSpecification;  }
					set{ _PackingSpecification = value; }
				}
                      				        
			}               
			                   
}
 
			