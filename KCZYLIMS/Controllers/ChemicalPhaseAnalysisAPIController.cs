using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
using XMain.Code;

namespace KCZYLIMS.Controllers
{
    public class ChemicalPhaseAnalysisAPIController : Controller
    {
        //
        // GET: /ChemicalPhaseAnalysisAPI/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CreateProjectAttorney(kczy_ProjectAttorneyMD model)
        {
            var sysInfo = new SystemSettingsBO();

            var groupID = Convert.ToInt64(sysInfo["KCZYS_ChemicalPhaseAnalysis"].Value1);
            var m6 = new Module6(groupID);
            var currentUser = UsersBO.GetCurrentUser();
            var origItemID = m6.CreateItem(model.MyName, currentUser);

            //把该主Item下的所有的填表人替换为model返回的负责人，如果有参与人也加进来
            //CodeFileWL.SpecialRoleDelUserWithRoleID(origItemID, 1, 6, -2);
            //using (XData.LinqToSqlClass.XFormDataClassesDataContext context = new XFormDataClassesDataContext())
            using (DataClassesKCZYSDataContext context = new DataClassesKCZYSDataContext())
            {
                var result =
                    context.ControlLists.Where(m => m.RelatedID == origItemID
                                                    && m.RelatedType == 1
                                                    && m.ModuleID == 6
                                                    && m.RoleID == -2
                                                    && m.FormID != 21);

                if (result != null)
                {
                    context.ControlLists.DeleteAllOnSubmit(result);
                    context.SubmitChanges();
                }
            }
            //创建实验记录、分析报告填表人
            var controlBo = new ControlListsBO();
            ItemsBO itemsBo = new ItemsBO();
            var listItems = itemsBo.GetItemsByOrigID(origItemID);
            if (listItems == null)
            {
                return Json(new { Result = false });
            }
            for (int i = 0; i < listItems.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (i == 1 && model.Participants != null)
                {
                    var parts = model.Participants.Split('#');
                    for (var j = 0; j < parts.Count(); j++)
                    {
                        var users = parts[j].Split('|');
                        if (users != null && users.Length == 3)
                        {
                            controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, XConvert.ToInt32(users[0]), users[2], currentUser);

                        }
                    }
                    controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);


                }
                else
                {
                    controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);

                }
            }


            var m6Item = new Module6Items(origItemID);
            var subItem = m6Item.LstItem[0];
            //更新model的关联item
            var projectAttorneyBo = new ProjectAttorneyBO();
            if (m6Item.MainForm != null)
                model.OrigID = (int)m6Item.MainItem.ItemID;
            else
                model.OrigID = 0;
            if (m6Item.LstItem.Count > 0)
                model.ItemID = (int)m6Item.LstItem.FirstOrDefault().ItemID;
            else
                model.ItemID = 0;

            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;

            projectAttorneyBo.Insert<kczy_ProjectAttorney, kczy_ProjectAttorneyMD>(model);
            
            if (model.RelatedID > 0)
            {
                //反向关联
                var instrument = new kczy_InstrumentAppointmentMD();
                instrument.MyID = model.RelatedID;
                instrument.GetInstance<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
                instrument.ItemID = model.ItemID;
                instrument.OrigID = model.OrigID;
                instrument.RelatedID = model.MyID;
                instrument.Update<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
            }
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult CreateProjectAttorneyInside(kczy_ProjectAttorneyMD model)
        {
            var sysInfo = new SystemSettingsBO();

            var groupID = Convert.ToInt64(sysInfo["KCZYS_ChemicalPhaseAnalysisInside"].Value1);
            var m6 = new Module6(groupID);
            var currentUser = UsersBO.GetCurrentUser();
            var origItemID = m6.CreateItem(model.MyName, currentUser);
            var m6Item = new Module6Items(origItemID);
            var subItem = m6Item.LstItem[0];

            //更新model的关联item
            var projectAttorneyBo = new ProjectAttorneyBO();
            if (m6Item.MainForm != null)
                model.OrigID = (int)m6Item.MainItem.ItemID;
            else
                model.OrigID = 0;
            if (m6Item.LstItem.Count > 0)
                model.ItemID = (int)m6Item.LstItem.FirstOrDefault().ItemID;
            else
                model.ItemID = 0;

            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            //默认将负责人设定为当前创建人
           /* model.Principal = currentUser.FullName;
            model.PrincipalID = (int)currentUser.UserID;*/
            projectAttorneyBo.Insert<kczy_ProjectAttorney, kczy_ProjectAttorneyMD>(model);
            //把该主Item下的所有的填表人替换为model返回的负责人，如果有参与人也加进来
            //CodeFileWL.SpecialRoleDelUserWithRoleID(origItemID, 1, 6, -2);
            //using (XData.LinqToSqlClass.XFormDataClassesDataContext context = new XFormDataClassesDataContext())
            using (DataClassesKCZYSDataContext context = new DataClassesKCZYSDataContext())
            {
                var result =
                    context.ControlLists.Where(m => m.RelatedID == origItemID
                                                    && m.RelatedType == 1
                                                    && m.ModuleID == 6
                                                    && m.RoleID == -2
                                                    && m.FormID != 50);

                if (result != null)
                {
                    context.ControlLists.DeleteAllOnSubmit(result);
                    context.SubmitChanges();
                }
            }
            //创建实验记录、分析报告填表人
            var controlBo = new ControlListsBO();
            ItemsBO itemsBo = new ItemsBO();
            var listItems = itemsBo.GetItemsByOrigID(origItemID);
            if (listItems == null)
            {
                return Json(new { Result = false });
            }
            for (int i = 0; i < listItems.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (i == 1 && model.Participants != null)
                {
                    var parts = model.Participants.Split('#');
                    for (var j = 0; j < parts.Count(); j++)
                    {
                        var users = parts[j].Split('|');
                        if (users != null && users.Length == 3)
                        {
                            controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, XConvert.ToInt32(users[0]), users[2], currentUser);

                        }
                    }
                    controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);


                }
                else
                {
                    controlBo.CreateControlList(origItemID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);

                }
            }
            if (model.RelatedID > 0)
            {
                //反向关联
                var instrument = new kczy_InstrumentAppointmentMD();
                instrument.MyID = model.RelatedID;
                instrument.GetInstance<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
                instrument.ItemID = model.ItemID;
                instrument.OrigID = model.OrigID;
                instrument.RelatedID = model.MyID;
                instrument.Update<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
            }
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        /// <summary>
        /// 保存更新API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateExperimentRecords(kczy_ExperimentRecordsMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ExperimentRecords>();
            var rst = helper.UpdateMDInstance(model);



            InstrumentUsageBO obj=new InstrumentUsageBO();
            var mdUsage = obj.GetInstrumentByRelatedID(model.ItemID);
            mdUsage.ItemID = model.InstrumentUsageItemID+1;
            mdUsage.OrigID = mdUsage.ItemID - 1;
            mdUsage.ModifiedBy = model.ModifiedBy;
            mdUsage.LastModified = model.CreateDate;
            mdUsage.ModifierID = model.ModifierID;
            mdUsage.MyName = model.InstrumentName;
            mdUsage.MyCode = model.InstrumentCode;
            mdUsage.ProjectName = model.MyName;
            mdUsage.ProjectCode = model.MyCode;
            mdUsage.BeginTime = model.BeginDate;
            mdUsage.EndTime = model.EndDate;
            mdUsage.OperaterID = model.AnalystID;
            mdUsage.Operater = model.Analyst;
            mdUsage.BeginStatus = model.BeiginStatus;
            mdUsage.EndStatus = model.EndStatus;

            var instrumentUsagehelper = new EntityHelper<kczy_InstrumentUsage>();
            var rst1 = instrumentUsagehelper.UpdateMDInstance(mdUsage);
            
            return Json(new { Result = (rst&&rst1) });
        }//end of func
        public JsonResult UpdateAnalysisReport(kczy_AnalysisReportMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_AnalysisReport>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
    }
}
