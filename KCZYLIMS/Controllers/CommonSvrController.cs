using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using KCZYLIMS.Models;
using SqlDataAccess;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.BLL;


namespace KCZYLIMS.Controllers
{
    public class CommonSvrController : Controller
    {
        #region 权限，提交，审批相关
        /// <summary>
        /// id是通用的id，具体的业务可能是工艺矿物学，化学分析还是物理检测
        /// 假设是工艺矿物学，获取委托单的实体之后，里面有类型判断
        /// 根据委托单再去new Module6，获取已经激活的Forms
        /// 根据当前用户，和当前活动的子Item，判断该显示 “保存”，“提交”还是“审批”,也有可能是不显示任何按钮。因为他没有权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ViewState(int intOrigID) 
        {
            long intActiveItem = 0;
            List<TwoValue> lstItems = new List<TwoValue>();
            string strStatus = string.Empty;
            var tmp = HttpContext.User.Identity.Name;

            //Models.kczy_ProjectAttorneyMD attorneyMD = new kczy_ProjectAttorneyMD();
            //attorneyMD.MyID = id;
            //var helper = new EntityHelper<kczy_ProjectAttorney>();
            //helper.GetMDInstance(attorneyMD);
            Module6Items m6 = new Module6Items(intOrigID);
            //获取当前激活的子Item
            ItemsMD activeItem = m6.GetActiveItem();
            if (activeItem == null)
                intActiveItem = 0;
            else
                intActiveItem = activeItem.ItemID;

            //获取当前已经创建的子Item
            //lstItems = m6.LstItem.Select(x => x.ItemID).ToList();
            foreach (var obj in m6.LstItem)
            {
                lstItems.Add(new TwoValue { FormID = obj.FormID, ItemID = (int)obj.ItemID });
            }
            //NoStatus = 99,
            //Approval = 5,
            //EditStatus = 2,
            //CompletedStatus = 0,
            //Wait = 1,
            //Disable = -2
            if (activeItem != null)
            {
                if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.NoStatus)
                {
                    strStatus = "NoStatus";
                }
                else if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.Approval)
                {
                    strStatus = "Approval";
                }
                else if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.EditStatus)
                {
                    strStatus = "EditStatus";
                }
                else if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.CompletedStatus)
                {
                    strStatus = "CompletedStatus";
                }
                else if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.Wait)
                {
                    strStatus = "Wait";
                }
                else if (activeItem.MyStatus == (short)ItemsBO.ItemStatus.Disable)
                {
                    strStatus = "Disable";
                }
                else
                {
                    strStatus = "NoStatus";
                }
            }//end if 
            else
            {
                strStatus = "CompletedStatus";
            }
            //获取当前活跃用户
            UsersMD currentUser = UsersBO.GetCurrentUser();
            ItemApprovalBO itemApprovalBO = new ItemApprovalBO();
            List<UsersMD>  lstActiveUsers = itemApprovalBO.GetActiveUsers((int)intActiveItem);
            
            bool blnIsActiveUserID = false;
            if(  lstActiveUsers.Select(x=>x.UserID).Contains(currentUser.UserID  )  )
                blnIsActiveUserID = true;

            return Json(new { Result = true, Items = lstItems, ActiveItem = intActiveItem, IsActiveUser = blnIsActiveUserID, Status = strStatus });
        }//end of func


        /// <summary>
        /// 获取下一步动作的相关用户，比如提交之后，就是获取一级审批者
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public JsonResult NextStepUserRoles(int ItemID)
        {   
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            List<UsersMD> lstUser = m6.NextStepUserRoles(ItemID);
            if (lstUser.Count > 0)
            {
                return Json(new {Result = true, NextUsers = lstUser});
            }
            else
            {
                return Json(new { Result = false, NextUsers = lstUser });
            }
            
        }//end of func
        /// <summary>
        /// 判断用户是否有查看权限
        /// </summary>GroupID:工艺矿物学1173，化学物相分析1174，物理检测1175.
        /// <returns>没有权限时，返回结果为真</returns>
        public JsonResult IsShowRight()
        {
            var instrumentManagementResult = false;
            var instrumentManagementCreatResult = false;
            var processMineralogyResult = false;
            var chemicalPhaseAnalysisOutSideResult = false;
            var chemicalPhaseAnalysisOutSideCreateResult = false;
            var chemicalPhaseAnalysisInSideResult = false;
            var chemicalPhaseAnalysisInSideCreateResult = false;
            var physicalDetectionOutSideResult = false;
            var physicalDetectionOutSideCreatResult = false;
            var physicalDetectionInSideResult = false;
            var physicalDetectionInSideCreatResult = false;
            var proccessMineralogyCreateResult = false;
            var searchResult = false;
            var yiBiaoPanResult = false;
            UsersMD currentUser = UsersBO.GetCurrentUser();
            //工艺矿物学查看权限
            XData.Global.roleHasRight roleProccessRight = XMain.Code.CodeFileWL.RoleHasRight("1173", "0", "6", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleProccessRight != XData.Global.roleHasRight.HasRight)
            {
                processMineralogyResult = true;
            }
            //工艺矿物学创建权限
            XData.Global.roleHasRight roleProccessCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1173", "0", "6", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleProccessCreateRight != XData.Global.roleHasRight.HasRight)
            {
                proccessMineralogyCreateResult = true;
            }
            //化学物相院外
            XData.Global.roleHasRight roleChemicalRight = XMain.Code.CodeFileWL.RoleHasRight("1174", "0", "6", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleChemicalRight != XData.Global.roleHasRight.HasRight)
            {
                chemicalPhaseAnalysisOutSideResult = true;
            }
            //化学物相院外创建权限
            XData.Global.roleHasRight roleChemicalOutSideCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1174", "0", "6", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleChemicalOutSideCreateRight != XData.Global.roleHasRight.HasRight)
            {
                chemicalPhaseAnalysisOutSideCreateResult = true;
            }
            //化学物相院内、所内
            XData.Global.roleHasRight roleChemicalInsideRight = XMain.Code.CodeFileWL.RoleHasRight("1182", "0", "6", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleChemicalInsideRight != XData.Global.roleHasRight.HasRight)
            {
                chemicalPhaseAnalysisInSideResult = true;
            }
            //化学物相院内、所内创建权限
            XData.Global.roleHasRight roleChemicalInSideCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1182", "0", "6", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleChemicalInSideCreateRight != XData.Global.roleHasRight.HasRight)
            {
                chemicalPhaseAnalysisInSideCreateResult = true;
            }
            //物理检测院外
            XData.Global.roleHasRight rolePhysicalOutSideRight = XMain.Code.CodeFileWL.RoleHasRight("1175", "0", "6", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (rolePhysicalOutSideRight != XData.Global.roleHasRight.HasRight)
            {
                physicalDetectionOutSideResult = true;
            }
            //物理检测院外创建权限
            XData.Global.roleHasRight rolePhysicalOutSideCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1175", "0", "6", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (rolePhysicalOutSideCreateRight != XData.Global.roleHasRight.HasRight)
            {
                physicalDetectionOutSideCreatResult = true;
            }
            //物理检测所内、院内
            XData.Global.roleHasRight rolePhysicalInSideRight = XMain.Code.CodeFileWL.RoleHasRight("1177", "0", "6", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (rolePhysicalInSideRight != XData.Global.roleHasRight.HasRight)
            {
                physicalDetectionInSideResult = true;
            }
            //物理检测院内、所内创建权限
            XData.Global.roleHasRight rolePhysicalInSideCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1177", "0", "6", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (rolePhysicalInSideCreateRight != XData.Global.roleHasRight.HasRight)
            {
                physicalDetectionInSideCreatResult = true;
            }
            //仪器管理查看权限
            XData.Global.roleHasRight roleInstrumentManagementRight = XMain.Code.CodeFileWL.RoleHasRight("1178", "0", "4", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleInstrumentManagementRight != XData.Global.roleHasRight.HasRight)
            {
                instrumentManagementResult = true;
            }
            //仪器管理创建权限
            XData.Global.roleHasRight roleInstrumentManagementCreateRight = XMain.Code.CodeFileWL.RoleHasRight("1178", "0", "4", (int)XData.Global.roleLevelID.AddGroupContent, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleInstrumentManagementCreateRight != XData.Global.roleHasRight.HasRight)
            {
                instrumentManagementCreatResult = true;
            }
            //统计查询查看权限
            XData.Global.roleHasRight roleSearchPanRight = XMain.Code.CodeFileWL.RoleHasRight("1183", "0", "4", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleSearchPanRight != XData.Global.roleHasRight.HasRight)
            {
                searchResult = true;
            }
            //仪表盘查看权限
            XData.Global.roleHasRight roleYiBiaoPanRight = XMain.Code.CodeFileWL.RoleHasRight("1184", "0", "4", (int)XData.Global.roleLevelID.Read, new XMain.Code.UserInfo(currentUser.UserID));
            if (roleYiBiaoPanRight != XData.Global.roleHasRight.HasRight)
            {
                yiBiaoPanResult = true;
            }
            return Json(new { processMineralogy = processMineralogyResult, chemicalPhaseAnalysisOutSide = chemicalPhaseAnalysisOutSideResult, chemicalPhaseAnalysisOutSideCreate = chemicalPhaseAnalysisOutSideCreateResult, chemicalPhaseAnalysisInSide = chemicalPhaseAnalysisInSideResult, chemicalPhaseAnalysisInSideCreate = chemicalPhaseAnalysisInSideCreateResult, physicalDetectionOutSide = physicalDetectionOutSideResult, physicalDetectionOutSideCreate = physicalDetectionOutSideCreatResult, physicalDetectionInSide = physicalDetectionInSideResult, physicalDetectionInSideCreate = physicalDetectionInSideCreatResult, proccessMineralogyCreate = proccessMineralogyCreateResult, instrumentManagement = instrumentManagementResult, instrumentManagementCreate = instrumentManagementCreatResult, search = searchResult, yiBiaoPan = yiBiaoPanResult });
        }//end of func

        /// <summary>
        /// 当前的子Item如果到了最后一步，是需要展示结果表单的(FormType = 3)
        /// 让用户选择走流程的哪个节点
        /// 如果返回true，说明到了最后一步，把NextForm返回的值做到dropdownlist里，或者类似控件
        /// 如果返回false，不用管
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public JsonResult NextForm(int ItemID)
        {
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            bool blnIsLastStep = m6.IsLastStep(ItemID);
            List<FormsMD> lstResultForm = new List<FormsMD>();
            if (blnIsLastStep)
            {
                lstResultForm = m6.NextFlowResult(ItemID);
            }

            return Json(new { Result = blnIsLastStep, NextForm = lstResultForm });
        }

        /// <summary>
        /// 获取审批历史
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public JsonResult ApprovalHistory(int ItemID)
        {
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            List<ItemApprovalMD> lstApproval = m6.ItemApprovalHistory(ItemID);
            List<ItemApprovalMDEx> lstAns = new List<ItemApprovalMDEx>();
            foreach (var obj in lstApproval)
            {
                ItemApprovalMDEx objNew = new ItemApprovalMDEx();
                objNew.ApprovalStatus = obj.ApprovalStatus;
                objNew.ItemID = obj.ItemID;
                objNew.MyID = obj.MyID;
                objNew.MyNote = obj.MyNote;
                objNew.ResultID = obj.ResultID;
                objNew.ResultText = obj.ResultText;
                objNew.SubmitDate = obj.SubmitDate;
                if (objNew.MyNote.Trim().Contains("提交"))
                    objNew.SubmitDateStr = string.Empty;
                else
                    objNew.SubmitDateStr = obj.SubmitDate.ToString("yyyy-MM-dd HH:mm");
                objNew.Type = obj.Type;
                objNew.UserID = obj.UserID;
                objNew.UserName = obj.UserName;
                lstAns.Add(objNew);
            }
            return Json(new { Result = true, History = lstAns }); 
        }//end of func


        /// <summary>
        /// ItemID是当前的子ItemID，向后台post提交这个动作，如果提交成功了，进入审批状态
        /// Notes是提交意见
        /// NextUsers是提交给谁，ID1;ID2的形式
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="Notes"></param>
        /// <param name="NextUsers"></param>
        /// <returns></returns>
        public JsonResult Submit(int ItemID, string Notes, string NextUsers)
        {
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            string[] strUserID = NextUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<long> lstUserIDs = new List<long>();
            foreach (var obj in strUserID)
            {
                long lngTmp = long.Parse(obj);
                lstUserIDs.Add(lngTmp);
            }
            UsersBO userBO = new UsersBO();
            List<UsersMD> lstNextUsers = userBO.GetInstancesByUserIDs(lstUserIDs);

            //最后一步需要创建下一个子Item
            //因为这个流程是线性的，所以就不需要用户选择了，我们自动帮忙创建
            if (m6.IsLastStep(ItemID))
            {
                List<FormsMD> lstResultForm = m6.NextFlowResult(ItemID);

                //如果为最后一个流程的最后一步    则直接运行“Approve”按钮功能
/*                if (currentItem != null && currentItem.ItemID > 0 && nextItem == null)
                {
                    m6.Approval(ItemID, lstResultForm.FirstOrDefault().FormID, UsersBO.GetCurrentUser(), "同意", Notes,
                        lstNextUsers);
                }
                else
                {*/
                    if (lstResultForm.Count > 0)
                    {
                        m6.Submit(ItemID, lstResultForm.FirstOrDefault().FormID, UsersBO.GetCurrentUser(), "已经提交", Notes, lstNextUsers);
                    }
                    else
                    {
                        m6.Submit(ItemID, 0, UsersBO.GetCurrentUser(), "已经提交", Notes, lstNextUsers);
                    }
                /*}*/
                //本矿产资源所业务紧密相关的，创建下一步流程时复制一些基本信息
                    ItemsMD currentItem = m6.LstItem.FirstOrDefault(x => x.ItemID == ItemID);
                    ItemsMD nextItem = m6.LstItem.FirstOrDefault(x => x.ParentID == currentItem.ItemID);
                if (currentItem != null && currentItem.ItemID > 0 && nextItem != null && nextItem.ItemID > 0)
                {
                    BLL.KCZYProjectBO projectBO = new KCZYProjectBO();
                    projectBO.CreateBussinessInstance(currentItem, nextItem);
                }
            }//end if
            else
            { 
                m6.Submit(ItemID, 0, UsersBO.GetCurrentUser(), "已经提交", Notes, lstNextUsers);//“已经提交这几个字其实不传进入也行，内部都固定写死”
            }
            return Json(new { Result = true });
        }

        /// <summary>
        /// 审批，如果是最后一步了，要判断是否还有下一个子Item要创建
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="Notes"></param>
        /// <param name="NextUsers"></param>
        /// <returns></returns>
        public JsonResult Approval(int ItemID, string Notes, string NextUsers)
        {
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            string[] strUserID = NextUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<long> lstUserIDs = new List<long>();
            foreach (var obj in strUserID)
            {
                long lngTmp = long.Parse(obj);
                lstUserIDs.Add(lngTmp);
            }
            UsersBO userBO = new UsersBO();
            List<UsersMD> lstNextUsers = userBO.GetInstancesByUserIDs(lstUserIDs);
            if (m6.IsLastStep(ItemID))
            {
                List<FormsMD> lstResultForm = m6.NextFlowResult(ItemID);
                if (lstResultForm.Count > 0)
                {
                    m6.Approval(ItemID, lstResultForm.FirstOrDefault().FormID, UsersBO.GetCurrentUser(), "同意", Notes, lstNextUsers);
                }//end if
                else
                {
                    m6.Approval(ItemID, 0, UsersBO.GetCurrentUser(), "同意", Notes, lstNextUsers);
                }
                //本矿产资源所业务紧密相关的，创建下一步流程时复制一些基本信息
                ItemsMD currentItem = m6.LstItem.FirstOrDefault(x => x.ItemID == ItemID);
                ItemsMD nextItem = m6.LstItem.FirstOrDefault(x => x.ParentID == currentItem.ItemID);
                if (currentItem != null && currentItem.ItemID > 0 && nextItem != null && nextItem.ItemID > 0)
                {
                    BLL.KCZYProjectBO projectBO = new KCZYProjectBO();
                    projectBO.CreateBussinessInstance(currentItem, nextItem);
                }
            }
            else
            { 
                m6.Approval(ItemID, 0, UsersBO.GetCurrentUser(), "同意", Notes, lstNextUsers);//“已经提交这几个字其实不传进入也行，内部都固定写死”
            }
            return Json(new { Result = true });
        }

        public JsonResult Reject(int ItemID, string Notes, string NextUsers)
        {
            var helper = new EntityHelper<Items>();
            var md = new ItemsMD();
            md.ItemID = ItemID;
            var itemMD = helper.GetMDInstance(md);
            BLL.Module6Items m6 = new Module6Items(itemMD.OrigID);
            string[] strUserID = NextUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<long> lstUserIDs = new List<long>();
            foreach (var obj in strUserID)
            {
                long lngTmp = long.Parse(obj);
                lstUserIDs.Add(lngTmp);
            }
            UsersBO userBO = new UsersBO();
            List<UsersMD> lstNextUsers = userBO.GetInstancesByUserIDs(lstUserIDs);
            m6.Reject(ItemID, UsersBO.GetCurrentUser(), "同意", Notes);//“已经提交这几个字其实不传进入也行，内部都固定写死”
            return Json(new { Result = true });
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        /// jquery.attachment用的api接口
        /// </summary>
        /// <param name="RelatedID"></param>
        /// <param name="RelatedType"></param>
        /// <param name="JsonVal"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        public JsonResult AttachmentAPI(int RelatedID,int RelatedType, string JsonVal, string Action)
        {
            AttachmentBO attBO = new AttachmentBO();
            if (Action.ToLower().Equals("read"))
            {
                List<AttachmentMD> lstTmp = attBO.GetInstancesByRelatedID(RelatedID, RelatedType);
                return Json(new { Result = true, Data = lstTmp });
            }
            else
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<AttachmentMDEx> lstTmp = toObject.Deserialize<List<AttachmentMDEx>>(JsonVal);

                List<int> lstMyID = lstTmp.Select(x => x.Id).ToList();
                //删除那些前台删除的
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    var linq = from tb in dc.Attachment
                               where tb.RelatedID == RelatedID && tb.RelatedType == RelatedType && !lstMyID.Contains((int)tb.AttachID)
                               select tb;
                    dc.Attachment.DeleteAllOnSubmit(linq);
                    dc.SubmitChanges();
                }
                //ID为0的才需要插入
                List<AttachmentMD> lstAns = new List<AttachmentMD>();
                foreach (var obj in lstTmp)
                {
                    AttachmentMD objMem = new AttachmentMD();
                    if( obj.Id == 0 )
                    { 
                        var currentUser = UsersBO.GetCurrentUser();
                        objMem.AttachID = 0;
                        objMem.RelatedID = RelatedID;
                        objMem.RelatedType = RelatedType;
                        objMem.RelatedModuleID = 6;
                        objMem.MyName = obj.FileName;
                        objMem.OrigPath = obj.Path;
                        //////
                        objMem.MyType = 0;
                        objMem.MyStatus = 0;
                        objMem.CreaterID = (int)currentUser.UserID;
                        objMem.CreateBy = currentUser.FullName;
                        objMem.CreateDate = System.DateTime.Now;
                        objMem.RelatedFormID = 0;                      
                        lstAns.Add(objMem);
                    }
                }
                attBO.UpdateInstances(lstAns);
            }
            return Json(new { Result = true });
        }







        //
        // GET: /CommonSvr/

        public string Index()
        {
            return "aaa";
        }
        /// <summary>
        /// 重要！！上传附件所用的通用接口
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public JsonResult Upload(HttpPostedFileBase fileData)
        {
            if (fileData != null)
            {
                try
                {                    
                    // 文件上传后的保存路径
                    string filePath = System.Configuration.ConfigurationManager.AppSettings["Upload_Path"];//Server.MapPath("~/Uploads/"); 
                    filePath += DateTime.Now.Year + "-" + DateTime.Now.Month + "/";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    string saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称

                    fileData.SaveAs(filePath + saveName);

                    return Json(new { Success = true, FileName = fileName, SavePath = filePath + saveName });
                }
                catch (Exception ex)
                {
                    return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                return Json(new { Success = false, Message = "请选择要上传的文件！" }, JsonRequestBehavior.AllowGet);
            }
        }//end of fun


        public JsonResult TestAjax(string JsonVal, string Action)
        {

            if (string.IsNullOrEmpty(JsonVal) && Action.Equals("Read"))
            {
                FourValue v1 = new FourValue(); v1.ID = "1"; v1.ProductName = "a";
                FourValue v2 = new FourValue(); v2.ID = "2"; v2.ProductName = "b";
                FourValue v3 = new FourValue(); v3.ID = "3"; v3.ProductName = "c";
                FourValue v4 = new FourValue(); v4.ID = "4"; v4.ProductName = "d";
                List<FourValue> lstAns = new List<FourValue>();
                lstAns.Add(v1);
                lstAns.Add(v2);
                lstAns.Add(v3);
                lstAns.Add(v4);

                return Json( new{Result=true,Data=lstAns} );
            }
            else if (!string.IsNullOrEmpty(JsonVal) && Action.Equals("Save"))
            {
                System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<FourValue> lstAns = toObject.Deserialize<List<FourValue>>(JsonVal);
                return Json(new { Result = true });
            }
            else
            {
                return Json(new { Result = false });
            }
             
        }//end of func

        public JsonResult TestAjax2(string jStr)
        {          
            //Request.Form["list"]能获取到
            //var tt = Request.Form.GetValues("list");
            System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<FourValue> lstAns = toObject.Deserialize<List<FourValue>>(jStr);
            return Json(new { Result = false, Data = "" });           
        }//end of func



        public JsonResult CreateProjectAttorney(kczy_ProjectAttorneyMD model)
        {            
            var projectAttorneyBO = new BLL.ProjectAttorneyBO();
            projectAttorneyBO.Insert<kczy_ProjectAttorney, kczy_ProjectAttorneyMD>(model);
            if (model.MyID>0)
            {
                return Json(new { Result = false, Data = model });         
            }
            return new JsonResult();
        }

        public JsonResult IsLastStep(int origId,int itemId)
        {
            Module6Items m6 = new Module6Items(origId);
            bool blnIsLastStep= m6.IsLastStep(itemId);
            return Json(new { Result = blnIsLastStep});
        }
    }

    public class TwoValue
    {
        public int FormID { get; set; }
        public int ItemID { get; set; }
    }

    [Serializable]
    public class FourValue
    {
        public FourValue() { }
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
    }

    [Serializable]
    public class AttachmentMDEx {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }


}
