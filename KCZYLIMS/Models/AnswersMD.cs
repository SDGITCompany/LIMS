          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class AnswersMD : EntityMD                     
			{                       
				     
				  
										Int32  _AID = 0;
							        
				public Int32 AID 
				{ 
					get{ return _AID;  }
					set{ _AID = value; }
				}
                   
				  
										Int32  _QID = 0;
							        
				public Int32 QID 
				{ 
					get{ return _QID;  }
					set{ _QID = value; }
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
                   
				  
										Boolean  _IsAnswer = false;
							        
				public Boolean IsAnswer 
				{ 
					get{ return _IsAnswer;  }
					set{ _IsAnswer = value; }
				}
                   
				  
										Int32  _Percent = 0;
							        
				public Int32 Percent 
				{ 
					get{ return _Percent;  }
					set{ _Percent = value; }
				}
                      				        
			}               
			                   
}
 
			