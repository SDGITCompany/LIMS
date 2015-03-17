          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class crm_AccountContactMD : EntityMD                     
			{                       
				     
				  
										Int32  _MyID = 0;
							        
				public Int32 MyID 
				{ 
					get{ return _MyID;  }
					set{ _MyID = value; }
				}
                   
				  
										String  _MyName = string.Empty;
							        
				public String MyName 
				{ 
					get{ return _MyName;  }
					set{ _MyName = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _AccountID = 0;
							        
				public Int32 AccountID 
				{ 
					get{ return _AccountID;  }
					set{ _AccountID = value; }
				}
                   
				  
										String  _AccountName = string.Empty;
							        
				public String AccountName 
				{ 
					get{ return _AccountName;  }
					set{ _AccountName = value; }
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
                   
				  
										String  _ModifierBy = string.Empty;
							        
				public String ModifierBy 
				{ 
					get{ return _ModifierBy;  }
					set{ _ModifierBy = value; }
				}
                   
				  
										DateTime  _LastModified = DateTime.Now;
							        
				public DateTime LastModified 
				{ 
					get{ return _LastModified;  }
					set{ _LastModified = value; }
				}
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										String  _Sex = string.Empty;
							        
				public String Sex 
				{ 
					get{ return _Sex;  }
					set{ _Sex = value; }
				}
                   
				  
										String  _Kind = string.Empty;
							        
				public String Kind 
				{ 
					get{ return _Kind;  }
					set{ _Kind = value; }
				}
                   
				  
										String  _Business = string.Empty;
							        
				public String Business 
				{ 
					get{ return _Business;  }
					set{ _Business = value; }
				}
                   
				  
										String  _Dept = string.Empty;
							        
				public String Dept 
				{ 
					get{ return _Dept;  }
					set{ _Dept = value; }
				}
                   
				  
										String  _Position = string.Empty;
							        
				public String Position 
				{ 
					get{ return _Position;  }
					set{ _Position = value; }
				}
                   
				  
										String  _Salutation = string.Empty;
							        
				public String Salutation 
				{ 
					get{ return _Salutation;  }
					set{ _Salutation = value; }
				}
                   
				  
										String  _Phone = string.Empty;
							        
				public String Phone 
				{ 
					get{ return _Phone;  }
					set{ _Phone = value; }
				}
                   
				  
										String  _Email = string.Empty;
							        
				public String Email 
				{ 
					get{ return _Email;  }
					set{ _Email = value; }
				}
                   
				  
										String  _QQ = string.Empty;
							        
				public String QQ 
				{ 
					get{ return _QQ;  }
					set{ _QQ = value; }
				}
                   
				  
										String  _Fax = string.Empty;
							        
				public String Fax 
				{ 
					get{ return _Fax;  }
					set{ _Fax = value; }
				}
                   
				  
										String  _Mobile = string.Empty;
							        
				public String Mobile 
				{ 
					get{ return _Mobile;  }
					set{ _Mobile = value; }
				}
                   
				  
										String  _Post = string.Empty;
							        
				public String Post 
				{ 
					get{ return _Post;  }
					set{ _Post = value; }
				}
                   
				  
										String  _Address = string.Empty;
							        
				public String Address 
				{ 
					get{ return _Address;  }
					set{ _Address = value; }
				}
                   
				  
										DateTime  _Birthday = DateTime.Now;
							        
				public DateTime Birthday 
				{ 
					get{ return _Birthday;  }
					set{ _Birthday = value; }
				}
                   
				  
										String  _Interest = string.Empty;
							        
				public String Interest 
				{ 
					get{ return _Interest;  }
					set{ _Interest = value; }
				}
                   
				  
										Int16  _CertificateType = 0;
							        
				public Int16 CertificateType 
				{ 
					get{ return _CertificateType;  }
					set{ _CertificateType = value; }
				}
                   
				  
										String  _CerificateCode = string.Empty;
							        
				public String CerificateCode 
				{ 
					get{ return _CerificateCode;  }
					set{ _CerificateCode = value; }
				}
                   
				  
										String  _MyNote = string.Empty;
							        
				public String MyNote 
				{ 
					get{ return _MyNote;  }
					set{ _MyNote = value; }
				}
                   
				  
										String  _AttachmentID = string.Empty;
							        
				public String AttachmentID 
				{ 
					get{ return _AttachmentID;  }
					set{ _AttachmentID = value; }
				}
                   
				  
										String  _AttachmentID_text = string.Empty;
							        
				public String AttachmentID_text 
				{ 
					get{ return _AttachmentID_text;  }
					set{ _AttachmentID_text = value; }
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
 
			