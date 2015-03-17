using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlDataAccess;
using KCZYLIMS.Models;
using KCZYLIMS.BLL.Utility;

namespace KCZYLIMS.BLL
{
    /// <summary>
    /// 工艺矿物学业务逻辑，从关联item及其formid信息创建对应的业务实体
    /// </summary>
    public class KCZYProjectBO
    {
        readonly int 工艺矿物学项目委托FormID = 12;
        readonly int 工艺矿物学项目策划FormID = 14;
        readonly int 工艺矿物学实验原始记录FormID = 16;
        readonly int 工艺矿物学项目审批FormID = 18;
        readonly int 化学物相院外分析测试委托FormID = 21;
        readonly int 化学物相院外实验原始记录FormID = 23;
        readonly int 化学物相院外分析报告FormID = 25;
        readonly int 化学物相院内分析测试委托FormID = 50;
        readonly int 化学物相院内实验原始记录FormID = 52;
        readonly int 化学物相院内分析报告FormID = 54;
        readonly int 物理检测分析测试委托单FormID = 28;
        readonly int 物理检测实验原始记录FormID = 30;
        readonly int 物理检测收费登记FormID = 32;
        readonly int 物理检测分析报告FormID = 34;
        readonly int 物理检测分析测试委托单对内FormID = 37;
        readonly int 物理检测实验原始记录对内FormID = 40;
        readonly int 物理检测分析报告对内FormID = 42;
        public void CreateBussinessInstance(ItemsMD currentItem, ItemsMD nextItem)
        {
            UsersMD user = UsersBO.GetCurrentUser(); 
            bool blnAns = true;
            if (nextItem.FormID == 工艺矿物学项目策划FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ProjectPlanBaseInfo>();
                var md = new kczy_ProjectPlanBaseInfoMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == currentItem.ItemID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                }
                helper.AddMDInstance(md);
            }
            else if (nextItem.FormID == 工艺矿物学实验原始记录FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ExperimentsRecordBaseInfo>();
                var md = new kczy_ExperimentsRecordBaseInfoMD();

                var helperStatus = new EntityHelper<kczy_ExperimentStatusBaseInfo>();
                var mdStatus = new kczy_ExperimentStatusBaseInfoMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    for (int i = 1; i < 4; i++)
                    {
                    mdStatus.ItemID = (int)nextItem.ItemID;
                    mdStatus.OrigID = nextItem.OrigID;
                    mdStatus.IsSubmit = false;
                    mdStatus.Type = i;
                    mdStatus.CreateBy = user.FullName;
                    mdStatus.CreateDate = System.DateTime.Now;
                    mdStatus.CreatorID = (int)user.UserID;
                    mdStatus.ModifiedBy = user.FullName;
                    mdStatus.LastModified = mdStatus.CreateDate;
                    mdStatus.ModifierID = (int)user.UserID;
                    helperStatus.AddMDInstance(mdStatus);
                    }
                }
                helper.AddMDInstance(md);

            }
            else if (nextItem.FormID == 工艺矿物学项目审批FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ProjectApprove>();
                var md = new kczy_ProjectApproveMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.BeginDate = 委托单.BeginDate;
                    md.EndDate = 委托单.EndDate;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                }
                helper.AddMDInstance(md);
            }
            else if (nextItem.FormID == 化学物相院外实验原始记录FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ExperimentRecords>();
                var md = new kczy_ExperimentRecordsMD();
                var helperUsage = new EntityHelper<kczy_InstrumentUsage>();
                var mdUsage = new kczy_InstrumentUsageMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == currentItem.ItemID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);



                    mdUsage.RelatedID = md.ItemID;
                    mdUsage.CreateBy = md.CreateBy;
                    mdUsage.CreateDate = md.CreateDate;
                    mdUsage.CreatorID = md.CreatorID;
                    mdUsage.ModifiedBy = md.ModifiedBy;
                    mdUsage.LastModified = md.CreateDate;
                    mdUsage.ModifierID = md.ModifierID;
                    helperUsage.AddMDInstance(mdUsage);
                }
                
            }
            else if (nextItem.FormID == 化学物相院外分析报告FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_AnalysisReport>();
                var md = new kczy_AnalysisReportMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.Specialty = 委托单.Specialty;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);



                }
                
            }
            else if (nextItem.FormID == 化学物相院内实验原始记录FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ExperimentRecords>();
                var md = new kczy_ExperimentRecordsMD();
                var helperUsage = new EntityHelper<kczy_InstrumentUsage>();
                var mdUsage = new kczy_InstrumentUsageMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == currentItem.ItemID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);



                    mdUsage.RelatedID = md.ItemID;
                    mdUsage.CreateBy = md.CreateBy;
                    mdUsage.CreateDate = md.CreateDate;
                    mdUsage.CreatorID = md.CreatorID;
                    mdUsage.ModifiedBy = md.ModifiedBy;
                    mdUsage.LastModified = md.CreateDate;
                    mdUsage.ModifierID = md.ModifierID;
                    helperUsage.AddMDInstance(mdUsage);
                }

            }
            else if (nextItem.FormID == 化学物相院内分析报告FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_AnalysisReport>();
                var md = new kczy_AnalysisReportMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.Specialty = 委托单.Specialty;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);



                }

            }
            else if (nextItem.FormID == 物理检测实验原始记录FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ExperimentRecords>();
                var md = new kczy_ExperimentRecordsMD();
                var helperUsage = new EntityHelper<kczy_InstrumentUsage>();
                var mdUsage = new kczy_InstrumentUsageMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == currentItem.ItemID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);

                    mdUsage.RelatedID = md.ItemID;
                    mdUsage.CreateBy = md.CreateBy;
                    mdUsage.CreateDate = md.CreateDate;
                    mdUsage.CreatorID = md.CreatorID;
                    mdUsage.ModifiedBy = md.ModifiedBy;
                    mdUsage.LastModified = md.CreateDate;
                    mdUsage.ModifierID = md.ModifierID;
                    helperUsage.AddMDInstance(mdUsage);
                    md.InstrumentUsageMyID = mdUsage.MyID;
                }
                
            }
            else if (nextItem.FormID == 物理检测收费登记FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_Registration>();
                var md = new kczy_RegistrationMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID== currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                }
                helper.AddMDInstance(md);
            }
            else if (nextItem.FormID == 物理检测分析报告FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_AnalysisReport>();
                var md = new kczy_AnalysisReportMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.Specialty = 委托单.Specialty;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                }
                helper.AddMDInstance(md);
            }
            else if (nextItem.FormID == 物理检测实验原始记录对内FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_ExperimentRecords>();
                var md = new kczy_ExperimentRecordsMD();
                var helperUsage = new EntityHelper<kczy_InstrumentUsage>();
                var mdUsage = new kczy_InstrumentUsageMD();
                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == currentItem.ItemID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                    helper.AddMDInstance(md);

                    mdUsage.RelatedID = md.ItemID;
                    mdUsage.CreateBy = md.CreateBy;
                    mdUsage.CreateDate = md.CreateDate;
                    mdUsage.CreatorID = md.CreatorID;
                    mdUsage.ModifiedBy = md.ModifiedBy;
                    mdUsage.LastModified = md.CreateDate;
                    mdUsage.ModifierID = md.ModifierID;
                    helperUsage.AddMDInstance(mdUsage);
                }
               
            }
            else if (nextItem.FormID == 物理检测分析报告对内FormID)
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                var helper = new EntityHelper<kczy_AnalysisReport>();
                var md = new kczy_AnalysisReportMD();

                var 委托单 = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.OrigID == currentItem.OrigID);
                if (委托单 != null)
                {
                    md.ItemID = (int)nextItem.ItemID;
                    md.OrigID = nextItem.OrigID;
                    md.MyName = 委托单.MyName;
                    md.MyCode = 委托单.MyCode;
                    md.Specialty = 委托单.Specialty;
                    md.CreateBy = user.FullName;
                    md.CreateDate = System.DateTime.Now;
                    md.CreatorID = (int)user.UserID;
                    md.ModifiedBy = user.FullName;
                    md.LastModified = md.CreateDate;
                    md.ModifierID = (int)user.UserID;
                }
                helper.AddMDInstance(md);
            }
            else
            {
                blnAns = false;
            }
        }//end of func

    }
}