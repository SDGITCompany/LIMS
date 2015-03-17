          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class QuestionsMD : EntityMD                     
			{                       
				     
				  
										Int32  _QID = 0;
							        
				public Int32 QID 
				{ 
					get{ return _QID;  }
					set{ _QID = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                   
				  
										Int16  _RelatedType = 0;
							        
				public Int16 RelatedType 
				{ 
					get{ return _RelatedType;  }
					set{ _RelatedType = value; }
				}
                   
				  
										Int16  _RelatedModuleID = 0;
							        
				public Int16 RelatedModuleID 
				{ 
					get{ return _RelatedModuleID;  }
					set{ _RelatedModuleID = value; }
				}
                   
				  
										Int32  _FormID = 0;
							        
				public Int32 FormID 
				{ 
					get{ return _FormID;  }
					set{ _FormID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int16  _MyType = 0;
							        
				public Int16 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int16  _MyLevel = 0;
							        
				public Int16 MyLevel 
				{ 
					get{ return _MyLevel;  }
					set{ _MyLevel = value; }
				}
                   
				  
										Int16  _MyOrder = 0;
							        
				public Int16 MyOrder 
				{ 
					get{ return _MyOrder;  }
					set{ _MyOrder = value; }
				}
                   
				  
										String  _MyNotes = string.Empty;
							        
				public String MyNotes 
				{ 
					get{ return _MyNotes;  }
					set{ _MyNotes = value; }
				}
                   
				  
										Int16  _MyScore = 0;
							        
				public Int16 MyScore 
				{ 
					get{ return _MyScore;  }
					set{ _MyScore = value; }
				}
                      				        
			}               
			                   
}
 
			