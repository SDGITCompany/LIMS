          
			                                                  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.Models
{                    
                                                                 
			public partial class kczy_ProjectAttorneyMD : EntityMD                     
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
                   
				  
										String  _SampleName = string.Empty;
							        
				public String SampleName 
				{ 
					get{ return _SampleName;  }
					set{ _SampleName = value; }
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
                   
				  
										String  _SpecialAccount = string.Empty;
							        
				public String SpecialAccount 
				{ 
					get{ return _SpecialAccount;  }
					set{ _SpecialAccount = value; }
				}
                   
				  
										Int32  _MyType = 0;
							        
				public Int32 MyType 
				{ 
					get{ return _MyType;  }
					set{ _MyType = value; }
				}
                   
				  
										Int32  _Specialty = 0;
							        
				public Int32 Specialty 
				{ 
					get{ return _Specialty;  }
					set{ _Specialty = value; }
				}
                   
				  
										DateTime  _BeginDate = DateTime.Now;
							        
				public DateTime BeginDate 
				{ 
					get{ return _BeginDate;  }
					set{ _BeginDate = value; }
				}
                   
				  
										DateTime  _EndDate = DateTime.Now;
							        
				public DateTime EndDate 
				{ 
					get{ return _EndDate;  }
					set{ _EndDate = value; }
				}
                   
				  
										String  _Principal = string.Empty;
							        
				public String Principal 
				{ 
					get{ return _Principal;  }
					set{ _Principal = value; }
				}
                   
				  
										Int32  _PrincipalID = 0;
							        
				public Int32 PrincipalID 
				{ 
					get{ return _PrincipalID;  }
					set{ _PrincipalID = value; }
				}
                   
				  
										String  _Participants = string.Empty;
							        
				public String Participants 
				{ 
					get{ return _Participants;  }
					set{ _Participants = value; }
				}
                   
				  
										String  _ParticipantsID = string.Empty;
							        
				public String ParticipantsID 
				{ 
					get{ return _ParticipantsID;  }
					set{ _ParticipantsID = value; }
				}
                   
				  
										DateTime  _SampleDate = DateTime.Now;
							        
				public DateTime SampleDate 
				{ 
					get{ return _SampleDate;  }
					set{ _SampleDate = value; }
				}
                   
				  
										String  _Sampler = string.Empty;
							        
				public String Sampler 
				{ 
					get{ return _Sampler;  }
					set{ _Sampler = value; }
				}
                   
				  
										Int32  _SamplerID = 0;
							        
				public Int32 SamplerID 
				{ 
					get{ return _SamplerID;  }
					set{ _SamplerID = value; }
				}
                   
				  
										String  _Telephone = string.Empty;
							        
				public String Telephone 
				{ 
					get{ return _Telephone;  }
					set{ _Telephone = value; }
				}
                   
				  
										String  _Email = string.Empty;
							        
				public String Email 
				{ 
					get{ return _Email;  }
					set{ _Email = value; }
				}
                   
				  
										String  _Fax = string.Empty;
							        
				public String Fax 
				{ 
					get{ return _Fax;  }
					set{ _Fax = value; }
				}
                   
				  
										String  _Address = string.Empty;
							        
				public String Address 
				{ 
					get{ return _Address;  }
					set{ _Address = value; }
				}
                   
				  
										String  _Postcode = string.Empty;
							        
				public String Postcode 
				{ 
					get{ return _Postcode;  }
					set{ _Postcode = value; }
				}
                   
				  
										Int32  _GetReportMethod = 0;
							        
				public Int32 GetReportMethod 
				{ 
					get{ return _GetReportMethod;  }
					set{ _GetReportMethod = value; }
				}
                   
				  
										Int32  _PaymentMethod = 0;
							        
				public Int32 PaymentMethod 
				{ 
					get{ return _PaymentMethod;  }
					set{ _PaymentMethod = value; }
				}
                   
				  
										Int32  _SampleNum = 0;
							        
				public Int32 SampleNum 
				{ 
					get{ return _SampleNum;  }
					set{ _SampleNum = value; }
				}
                   
				  
										Int32  _PhaseNum = 0;
							        
				public Int32 PhaseNum 
				{ 
					get{ return _PhaseNum;  }
					set{ _PhaseNum = value; }
				}
                   
				  
										String  _Recipients = string.Empty;
							        
				public String Recipients 
				{ 
					get{ return _Recipients;  }
					set{ _Recipients = value; }
				}
                   
				  
										Int32  _RecipientID = 0;
							        
				public Int32 RecipientID 
				{ 
					get{ return _RecipientID;  }
					set{ _RecipientID = value; }
				}
                   
				  
										Int32  _SampleHandlingMethod = 0;
							        
				public Int32 SampleHandlingMethod 
				{ 
					get{ return _SampleHandlingMethod;  }
					set{ _SampleHandlingMethod = value; }
				}
                   
				  
										String  _SampleTexture = string.Empty;
							        
				public String SampleTexture 
				{ 
					get{ return _SampleTexture;  }
					set{ _SampleTexture = value; }
				}
                   
				  
										String  _WorkRequirement = string.Empty;
							        
				public String WorkRequirement 
				{ 
					get{ return _WorkRequirement;  }
					set{ _WorkRequirement = value; }
				}
                   
				  
										String  _Remark = string.Empty;
							        
				public String Remark 
				{ 
					get{ return _Remark;  }
					set{ _Remark = value; }
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
                   
				  
										Boolean  _IsDeleted = false;
							        
				public Boolean IsDeleted 
				{ 
					get{ return _IsDeleted;  }
					set{ _IsDeleted = value; }
				}
                   
				  
										Int32  _RelatedID = 0;
							        
				public Int32 RelatedID 
				{ 
					get{ return _RelatedID;  }
					set{ _RelatedID = value; }
				}
                      				        
			}               
			                   
}
 
			