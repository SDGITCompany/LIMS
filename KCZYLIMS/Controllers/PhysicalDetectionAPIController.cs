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
    public class PhysicalDetectionAPIController : Controller
    {
        //
        // GET: /PhysicalDetectionAPI/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CreateProjectAttorney(kczy_ProjectAttorneyMD model)
        {
            var sysInfo = new SystemSettingsBO();

            var groupID = Convert.ToInt64(sysInfo["KCZYS_PhysicalDetection"].Value1);
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
                                                    && m.FormID != 28);

                if (result != null)
                {
                    context.ControlLists.DeleteAllOnSubmit(result);
                    context.SubmitChanges();
                }
            }
            //创建实验记录、收费登记、分析报告
            ItemsBO itemsBo = new ItemsBO();
            var controlBo = new ControlListsBO();
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
                var instrument =new kczy_InstrumentAppointmentMD();
                instrument.MyID = model.RelatedID;
                instrument.GetInstance<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
                instrument.ItemID = model.ItemID;
                instrument.OrigID = model.OrigID;
                instrument.RelatedID = model.MyID;
                instrument.Update<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(instrument);
            }
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            return Json(new { Result = false });
        }//end of func
        //物理检测所内、院内的创建方法
        public JsonResult CreateProjectAttorneyInside(kczy_ProjectAttorneyMD model)
        {
            var sysInfo = new SystemSettingsBO();

            var groupID = Convert.ToInt64(sysInfo["KCZYS_PhysicalDetectionInside"].Value1);
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
            model.Principal = currentUser.FullName;
            model.PrincipalID = (int)currentUser.UserID;
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
                                                    && m.FormID != 37);

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
        public JsonResult UpdateRegistration(kczy_RegistrationMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_Registration>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        /// <summary>
        /// 保存测试费用的接口
        /// </summary>
        /// <param name="JVal"></param>
        /// <returns></returns>
        public JsonResult ExperimentAmountRecord(int ItemID, string JsonVal, string Action)
        {
            KCZYExperimentAmountBO experimentAmountBO = new KCZYExperimentAmountBO();
            if (Action.ToLower().Equals("read"))
            {
                List<kczy_ExperimentAmountMD> lstTmp = experimentAmountBO.GetInstancesByItemID(ItemID);
                List<kczy_ExperimentAmountMD> lstAns = new List<kczy_ExperimentAmountMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_ExperimentAmountMD objMem = new kczy_ExperimentAmountMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);                    
                    lstAns.Add(objMem);
                }
                return Json(new { Result = true, Data = lstAns });
            }
            else
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<kczy_ExperimentAmountMD> lstTmp = toObject.Deserialize<List<kczy_ExperimentAmountMD>>(JsonVal);
                List<kczy_ExperimentAmountMD> lstAns = new List<kczy_ExperimentAmountMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_ExperimentAmountMD objMem = new kczy_ExperimentAmountMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    objMem.ItemID = ItemID;                    
                    obj.ItemID = ItemID;
                    lstAns.Add(objMem);
                }
                experimentAmountBO.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }
        public JsonResult SearchAppointDate(kczy_ProjectAttorneyMD model)
        {
            var rst = false;
            var type = "";
            var date = "";
            var instrumentBase = new InstrumentAppointmentBO();
            if (model.RelatedID != 0)
            {
                var obj = instrumentBase.GetInstrumentByRelatedID(model.RelatedID);
                if (obj != null)
                {
                    rst = true;

                    if (obj.AppointType == 1)
                    {
                        type = "--上午--";
                    }
                    if (obj.AppointType == 2)
                    {
                        type = "--下午--";
                    }
                    date = obj.AppointDate.ToString("yyyy-MM-dd");

                }
            }
            return Json(new { Result = rst,Date=date,appType=type });
            
        }//end of func



    }
}
