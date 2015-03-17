          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class RecordsDataMD : EntityMD                     
			{                       
				     
				  
										Int32  _ItemID = 0;
							        
				public Int32 ItemID 
				{ 
					get{ return _ItemID;  }
					set{ _ItemID = value; }
				}
                   
				  
										Int32  _RecordID = 0;
							        
				public Int32 RecordID 
				{ 
					get{ return _RecordID;  }
					set{ _RecordID = value; }
				}
                   
				  
										Int32  _FieldID = 0;
							        
				public Int32 FieldID 
				{ 
					get{ return _FieldID;  }
					set{ _FieldID = value; }
				}
                   
				  
										Double  _NumData = 0;
							        
				public Double NumData 
				{ 
					get{ return _NumData;  }
					set{ _NumData = value; }
				}
                   
				  
										String  _TextData = string.Empty;
							        
				public String TextData 
				{ 
					get{ return _TextData;  }
					set{ _TextData = value; }
				}
                   
				  
										String  _MemoData = string.Empty;
							        
				public String MemoData 
				{ 
					get{ return _MemoData;  }
					set{ _MemoData = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Boolean  _CheckedData = false;
							        
				public Boolean CheckedData 
				{ 
					get{ return _CheckedData;  }
					set{ _CheckedData = value; }
				}
                   
				  
										String  _TagName = string.Empty;
							        
				public String TagName 
				{ 
					get{ return _TagName;  }
					set{ _TagName = value; }
				}
                   
				  
										String  _DataType = string.Empty;
							        
				public String DataType 
				{ 
					get{ return _DataType;  }
					set{ _DataType = value; }
				}
                      				        
			}               
			                   
}
 
			