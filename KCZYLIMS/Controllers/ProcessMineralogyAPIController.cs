using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office.CustomUI;
using KCZYLIMS.Models;
using SqlDataAccess;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using XData.LinqToSqlClass;
using XMain.Code;
using ControlLists = SqlDataAccess.ControlLists;

namespace KCZYLIMS.Controllers
{
    public class ProcessMineralogyAPIController : Controller
    {
        //
        // GET: /ProcessMineralogyControllerAPI/

        public ActionResult Index()
        {
            return View();
        }//end of func

        /// <summary>
        /// 创建委托单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateProjectAttorney(kczy_ProjectAttorneyMD model)
        {
            var sysInfo = new SystemSettingsBO();
            var controlBo = new ControlListsBO();
            var groupID = Convert.ToInt64(sysInfo["KCZYS_ProcessMineralogy"].Value1);
            var m6 = new Module6(groupID);
            var currentUser = UsersBO.GetCurrentUser();

            var origItemID =  m6.CreateItem(model.MyName, currentUser);
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
                                                    &&m.FormID!=12);

                if (result != null)
                {
                    context.ControlLists.DeleteAllOnSubmit(result);
                    context.SubmitChanges();
                }
            }
            //创建项目策划、实验记录、项目审批填表人
            ItemsBO itemsBo=new ItemsBO();
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

                if (i == 2 && model.Participants != null)
                {
                      var parts = model.Participants.Split('#');
                        for (var j = 0; j < parts.Count(); j++)
                        {
                            var users = parts[j].Split('|');
                            if (users != null && users.Length == 3)
                            {
                                controlBo.CreateControlList(origItemID, -2, listItems[i].FormID,XConvert.ToInt32(users[0]),users[2], currentUser);

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

           // model.Recipients
            if(model.MyID>0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func

        /// <summary>
        /// 保存更新API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateProjectAttorney(kczy_ProjectAttorneyMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ProjectAttorney>();
            var rst = helper.UpdateMDInstance(model);


            ControlListsBO control=new ControlListsBO();
            ItemsBO itemsBo = new ItemsBO();
            var listItems = itemsBo.GetItemsByOrigID(model.OrigID);
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
                var listPPlan = control.GetControlLists(model.OrigID, -2, listItems[i].FormID);
                if (listPPlan.Count > 0)
                {
                    var helper1 = new EntityHelper<ControlLists>();
                    foreach (var obj in listPPlan)
                    {
                        helper1.DeleteMDInstance(obj);
                    }
                }
            }
            var controlBo = new ControlListsBO();

            for (int i = 0; i < listItems.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (i==1&&model.Participants != null)
                {
                    var parts = model.Participants.Split('#');
                    for (var j = 0; j < parts.Count(); j++)
                    {
                        var users = parts[j].Split('|');
                        if (users != null && users.Length == 3)
                        {
                            controlBo.CreateControlList(model.OrigID, -2, listItems[i].FormID, XConvert.ToInt32(users[0]), users[2], currentUser);

                        }
                    }
                    controlBo.CreateControlList(model.OrigID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);


                }
                else
                {
                    controlBo.CreateControlList(model.OrigID, -2, listItems[i].FormID, model.PrincipalID, model.Principal, currentUser);

                }
            }
            return Json(new { Result = rst });
        }//end of func
        public JsonResult UpdatePlanBaseInfo(kczy_ProjectPlanBaseInfoMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ProjectPlanBaseInfo>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        public JsonResult UpdateExperimentStatusBaseInfo(kczy_ExperimentStatusBaseInfoMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ExperimentStatusBaseInfo>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        public JsonResult SubmitExperimentStatusBaseInfo(kczy_ExperimentStatusBaseInfoMD model)
        {
            model.IsSubmit = true;
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ExperimentStatusBaseInfo>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        public JsonResult UpdateProjectApproval(kczy_ProjectApproveMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_ProjectApprove>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        /// <summary>
        /// 保存项目策划的接口
        /// </summary>
        /// <param name="JVal"></param>
        /// <returns></returns>
        public JsonResult ProjectPlanRowRecord(int ItemID, string JsonVal,string Action)
        {

            kczyProjectPlanBO projectPlanBO = new kczyProjectPlanBO();
            if (Action.ToLower().Equals("read"))
            {
                List<kczy_ProjectPlanMD> lstTmp = projectPlanBO.GetInstancesByItemID(ItemID);
                List<kczy_ProjectPlanMDEx> lstAns = new List<kczy_ProjectPlanMDEx>();
                foreach (var obj in lstTmp)
                {
                    kczy_ProjectPlanMDEx objMem = new kczy_ProjectPlanMDEx();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    if (objMem.BeginDate != null)
                        objMem.BeginDateStr = objMem.BeginDate.ToString("yyyy-MM-dd");
                    else
                        objMem.BeginDateStr = string.Empty;
                    if (objMem.EndDate != null)
                        objMem.EndDateStr = objMem.EndDate.ToString("yyyy-MM-dd");
                    else
                        objMem.EndDateStr = string.Empty;


                    lstAns.Add(objMem);
                }
                return Json(new { Result = true, Data = lstAns });
            }
            else
            { 
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<kczy_ProjectPlanMDEx> lstTmp = toObject.Deserialize<List<kczy_ProjectPlanMDEx>>(JsonVal);

                List<int> lstMyID = lstTmp.Select(x => x.MyID).ToList();
                //删除那些前台删除的
                using(DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    var linq = from tb in dc.kczy_ProjectPlan
                               where tb.ItemID == ItemID && !lstMyID.Contains(tb.MyID)
                               select tb;
                    dc.kczy_ProjectPlan.DeleteAllOnSubmit(linq);
                    dc.SubmitChanges();
                }

                List<kczy_ProjectPlanMD> lstAns = new List<kczy_ProjectPlanMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_ProjectPlanMD objMem = new kczy_ProjectPlanMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    var currentUser = UsersBO.GetCurrentUser();
                    objMem.CreatorID = (int)currentUser.UserID;
                    objMem.CreateBy = currentUser.FullName;
                    objMem.CreateDate = System.DateTime.Now;
                    objMem.LastModified = objMem.CreateDate;
                    objMem.ModifiedBy = currentUser.FullName;
                    objMem.ModifierID = (int)currentUser.UserID;
                    objMem.ItemID = ItemID;
                    DateTime dtm = DateTime.Now;
                    if (!string.IsNullOrEmpty(obj.BeginDateStr) && DateTime.TryParse(obj.BeginDateStr, out dtm))
                    {
                        objMem.BeginDate = dtm;
                    }
                    if (!string.IsNullOrEmpty(obj.EndDateStr) && DateTime.TryParse(obj.EndDateStr, out dtm))
                    {
                        objMem.EndDate = dtm;
                    }
                    obj.ItemID = ItemID;
                    lstAns.Add(objMem);
                }
                projectPlanBO.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }

        /// <summary>
        /// 保存化学分析的接口
        /// </summary>
        /// <param name="JVal"></param>
        /// <returns></returns>
        public JsonResult PhaseAnalysisRecord(int ItemID, string JsonVal, string Action)
        {
            KCZYPhaseAnalysisBO experiment = new KCZYPhaseAnalysisBO();
            if (Action.ToLower().Equals("read"))
            {
                List<kczy_PhaseAnalysisMD> lstTmp = experiment.GetInstancesByItemID(ItemID);
                List<kczy_PhaseAnalysisMD> lstAns = new List<kczy_PhaseAnalysisMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_PhaseAnalysisMD objMem = new kczy_PhaseAnalysisMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    lstAns.Add(objMem);
                }
                return Json(new { Result = true, Data = lstAns });
            }
            else
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<kczy_PhaseAnalysisMD> lstTmp = toObject.Deserialize<List<kczy_PhaseAnalysisMD>>(JsonVal);

                List<int> lstMyID = lstTmp.Select(x => x.MyID).ToList();
                //删除那些前台删除的
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    var linq = from tb in dc.kczy_PhaseAnalysis
                               where tb.ItemID == ItemID && !lstMyID.Contains(tb.MyID)
                               select tb;
                    dc.kczy_PhaseAnalysis.DeleteAllOnSubmit(linq);
                    dc.SubmitChanges();
                }

                List<kczy_PhaseAnalysisMD> lstAns = new List<kczy_PhaseAnalysisMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_PhaseAnalysisMD objMem = new kczy_PhaseAnalysisMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    var currentUser = UsersBO.GetCurrentUser();
                    objMem.CreatorID = (int)currentUser.UserID;
                    objMem.CreateBy = currentUser.FullName;
                    objMem.CreateDate = System.DateTime.Now;
                    objMem.LastModified = objMem.CreateDate;
                    objMem.ModifiedBy = currentUser.FullName;
                    objMem.ModifierID = (int)currentUser.UserID;
                    objMem.ItemID = ItemID;
                    obj.ItemID = ItemID;
                    lstAns.Add(objMem);
                }
                experiment.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }
        /// <summary>
        /// 保存化学物相分析的接口
        /// </summary>
        /// <param name="JVal"></param>
        /// <returns></returns>
        public JsonResult ChemicalPhaseAnalysisRecord(int ItemID, string JsonVal, string Action)
        {
            KCZYChemicalPhaseAnalysisBO experiment = new KCZYChemicalPhaseAnalysisBO();
            if (Action.ToLower().Equals("read"))
            {
                List<kczy_ChemicalPhaseAnalysisMD> lstTmp = experiment.GetInstancesByItemID(ItemID);
                List<kczy_ChemicalPhaseAnalysisMD> lstAns = new List<kczy_ChemicalPhaseAnalysisMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_ChemicalPhaseAnalysisMD objMem = new kczy_ChemicalPhaseAnalysisMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    lstAns.Add(objMem);
                }
                return Json(new { Result = true, Data = lstAns });
            }
            else
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<kczy_ChemicalPhaseAnalysisMD> lstTmp = toObject.Deserialize<List<kczy_ChemicalPhaseAnalysisMD>>(JsonVal);
                List<kczy_ChemicalPhaseAnalysisMD> lstAns = new List<kczy_ChemicalPhaseAnalysisMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_ChemicalPhaseAnalysisMD objMem = new kczy_ChemicalPhaseAnalysisMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    var currentUser = UsersBO.GetCurrentUser();
                    objMem.CreatorID = (int)currentUser.UserID;
                    objMem.CreateBy = currentUser.FullName;
                    objMem.CreateDate = System.DateTime.Now;
                    objMem.LastModified = objMem.CreateDate;
                    objMem.ModifiedBy = currentUser.FullName;
                    objMem.ModifierID = (int)currentUser.UserID;
                    objMem.ItemID = ItemID;
                    obj.ItemID = ItemID;
                    lstAns.Add(objMem);
                }
                experiment.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }
        /// <summary>
        /// 保存显微镜特征描述的接口
        /// </summary>
        /// <param name="JVal"></param>
        /// <returns></returns>
        public JsonResult CharacteristicRecord(int ItemID, string JsonVal, string Action)
        {
            KCZYCharacteristicBO experiment = new KCZYCharacteristicBO();
            if (Action.ToLower().Equals("read"))
            {
                List<kczy_MicroscopeMD> lstTmp = experiment.GetInstancesByItemID(ItemID);
                List<kczy_MicroscopeMD> lstAns = new List<kczy_MicroscopeMD>();
                foreach (var obj in lstTmp)
                {
                    kczy_MicroscopeMD objMem = new kczy_MicroscopeMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    lstAns.Add(objMem);
                }
                return Json(new { Result = true, Data = lstAns });
            }
            else
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<kczy_MicroscopeMD> lstTmp = toObject.Deserialize<List<kczy_MicroscopeMD>>(JsonVal);
                List<kczy_MicroscopeMD> lstAns = new List<kczy_MicroscopeMD>();
                var currentUser = UsersBO.GetCurrentUser();
                foreach (var obj in lstTmp)
                {
                    kczy_MicroscopeMD objMem = new kczy_MicroscopeMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, obj);                    
                    objMem.CreatorID = (int)currentUser.UserID;
                    objMem.CreateBy = currentUser.FullName;
                    objMem.CreateDate = System.DateTime.Now;
                    objMem.LastModified = objMem.CreateDate;
                    objMem.ModifiedBy = currentUser.FullName;
                    objMem.ModifierID = (int)currentUser.UserID;
                    objMem.ItemID = ItemID;
                    obj.ItemID = ItemID;
                    lstAns.Add(objMem);
                }
                experiment.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }

        /// <summary>
        /// 逐行更新，会调用多次，很不好。为了把活干完，没时间优化了
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="MyID"></param>
        /// <param name="Code"></param>
        /// <param name="Describe"></param>
        /// <returns></returns>
        public JsonResult CharacteristicRecordOneRow(int ItemID, int MyID, string Code, string Describe)
        {
            var currentUser = UsersBO.GetCurrentUser();
            kczy_MicroscopeMD objMem = new kczy_MicroscopeMD();
            KCZYCharacteristicBO experiment = new KCZYCharacteristicBO();
            List<kczy_MicroscopeMD> lstAns = new List<kczy_MicroscopeMD>();
            objMem.MyID = MyID;
            objMem.Code = Code;
            objMem.Describe = Describe;
            objMem.CreatorID = (int)currentUser.UserID;
            objMem.CreateBy = currentUser.FullName;
            objMem.CreateDate = System.DateTime.Now;
            objMem.LastModified = objMem.CreateDate;
            objMem.ModifiedBy = currentUser.FullName;
            objMem.ModifierID = (int)currentUser.UserID;
            objMem.ItemID = ItemID;
            lstAns.Add(objMem);
            experiment.UpdateInstances(lstAns);
            return Json(new { Data = objMem });
        }

        /// <summary>
        /// 删除id不在strMyIds里的记录
        /// </summary>
        /// <param name="strMyIds"></param>
        /// <returns></returns>
        public JsonResult CharacteristicRecordDelete(string MyIds)
        {
            KCZYCharacteristicBO experiment = new KCZYCharacteristicBO();
            experiment.DeleteRecords(MyIds);
            return Json(new { Result = true });
        }


        public JsonResult DeleteItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_ProjectAttorney.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
                    if (q != null)
                    {
                        q.IsDeleted = true;
                    }
                }
                try
                {
                    db.SubmitChanges();
                    isSuccess = true;
                }
                catch (Exception)
                {
                    isSuccess = false;
                }
            }
            var rst = isSuccess;
            return Json(new { Result = rst });


        }//end of func
        public JsonResult IsAllExperimentSubmited(int itemID)
        {
            bool rst = false;
            var experiment=new ExperimentStatusBaseInfoBO();
            var count = experiment.GetSubmitedCount(itemID);
            if (count == 3)
            {
                rst = true;
            }
            return Json(new { Result = rst });
        }
    }
}
