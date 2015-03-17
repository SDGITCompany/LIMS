using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Spreadsheet;
using KCZYLIMS.BLL.Utility;
using SqlDataAccess;
using KCZYLIMS.Models;
using System.Data;
using System.Data.Sql;
using System.Web.Mvc;
using XMain.Code;
using Groups = SqlDataAccess.Groups;
using Items = SqlDataAccess.Items;
using Users = SqlDataAccess.Users;

namespace KCZYLIMS.BLL
{



    /// <summary>
    /// 首先你得给group id，不然怎么创建
    /// 提供创建item的功能
    /// 提供审批功能
    /// 提供打开某个tab的功能
    /// 提供提交功能
    /// 提供驳回功能
    /// 集成发任务通知
    /// 集成controllist
    /// </summary>
    public class Module6
    {
        public bool IsCorrect { get; set; }
        Forms MainForm;
        /// <summary>
        /// 包括普通表单和结果
        /// </summary>
        List<Forms> SubForms;
        Groups CurrentGroup;

        private  enum BuildInAccountType
        {
            //创建人
            Creator = 53,

            //指派负责人
            SubResponsbility = 54
        }
        /// <summary>
        /// Module6是一个框，首先得有个forms结构，然后再有一个group绑定该forms结果。
        /// 在改group下创建的item都具备这个forms结构
        /// </summary>
        /// <param name="lngGroupID"></param>
        public Module6(long lngGroupID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                CurrentGroup = dc.Groups.FirstOrDefault(x => x.GroupID == lngGroupID);
                if (CurrentGroup == null)
                    IsCorrect = false;
                else
                {
                    int intFormID = (int)CurrentGroup.FormID;
                    MainForm = dc.Forms.FirstOrDefault(x => x.FormID == intFormID);
                    List<int> lstPids = new List<int>();
                    lstPids.Add(intFormID);
                    SubForms = GetSubFormRecursive(lstPids, dc).ToList();

                }
            }//end of using
        }


        /// <summary>
        /// 给一个Item的实名，创建主Item和第一个子Item
        /// 老代码参考SubFlowFormNode的Create
        /// </summary>
        /// <param name="strMyName"></param>
        /// <returns></returns>
        public int 
            CreateItem(string strMyName, UsersMD creator)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                Items mainItem = new Items();
                Items subItem = new Items();
                mainItem.GroupID = subItem.GroupID = (int)CurrentGroup.GroupID;
                mainItem.ParentID = subItem.ParentID = 0;//OrigItem嘛
                mainItem.ModuleID = subItem.ModuleID = 6;
                mainItem.MyName = subItem.MyName = strMyName;
                mainItem.FormID = MainForm.FormID;
                mainItem.MyStatus = subItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
                mainItem.TotalStatus = subItem.TotalStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
                mainItem.ApprovalStatus = subItem.ApprovalStatus = 0;//未进入审批程序
                mainItem.TypeID = subItem.TypeID = CurrentGroup.TypeID;
                mainItem.IsDeleted = subItem.IsDeleted = false;
                mainItem.CreatorID = subItem.CreatorID = (int)creator.UserID;
                mainItem.CreateBy = subItem.CreateBy = creator.FullName;
                mainItem.CreateDate =subItem.CreateDate= DateTime.Now;
                //代码默认值会溢出
                EntityHelper<object>.SetInstanceDefaultValue(mainItem);
                EntityHelper<object>.SetInstanceDefaultValue(subItem);
                dc.Items.InsertOnSubmit(mainItem);
                dc.Items.InsertOnSubmit(subItem);

                dc.SubmitChanges();

                //更新OrigID第一个子Item
                var tmp = SubForms.FirstOrDefault(x => x.ParentID == MainForm.FormID);
                var strTmp = tmp != null ? tmp.MyName : string.Empty;

                mainItem.OrigID = (int)mainItem.ItemID;
                subItem.OrigID = (int)mainItem.ItemID;
                subItem.ParentID = (int)mainItem.ItemID;
                subItem.FormID = tmp.FormID;
                subItem.MyName = mainItem.MyName + "(" + strTmp + ")";
                EntityHelper<object>.SetInstanceDefaultValue(mainItem);
                EntityHelper<object>.SetInstanceDefaultValue(subItem);
                dc.SubmitChanges();

                //插入第一个游标
                var itemCurrentState = new ItemApproval
                {
                    ItemID = (int)subItem.ItemID,
                    ApprovalStatus = (short)subItem.ApprovalStatus,
                    Type = (int)ItemApprovalBO.TypeStatus.Iterator,//相当于最新游标
                    ResultText = "等待提交",
                    ResultID = (int)Module6Items.ResultFormEnum.Submit,//0是提交,在最新游标的情况下，其实用什么都无所谓
                    MyNote = "",
                    UserName = creator.FullName,
                    UserID = creator.UserID,
                    SubmitDate = DateTime.Now
                };
                dc.ItemApproval.InsertOnSubmit(itemCurrentState);
                dc.SubmitChanges();

                long[] lngNewIDs = new long[1];
                lngNewIDs[0] = (long)mainItem.OrigID;                
                //复制权限
                XMain.Code.CodeFileWL.CopySpecialRoleFromOldToNew(CurrentGroup.GroupID, int.Parse(XData.Global.roleRelatedTypeGroup),
                    lngNewIDs, int.Parse(XData.Global.roleRelatedTypeOrig), 6, creator.FullName, creator.UserID);
                XMain.Code.CodeFileWL.CopyRoleFromOldToNew(CurrentGroup.GroupID, int.Parse(XData.Global.roleRelatedTypeGroup),
                 lngNewIDs, int.Parse(XData.Global.roleRelatedTypeOrig), 6, creator.FullName, creator.UserID);

                
                GroupInfo creatorAccount = GroupInfo.GetGroupWithType((int)Module6.BuildInAccountType.Creator);
                CodeFileWL.UpdateControllistForControl(mainItem.OrigID, (int)RelatedType.Orig,
                                                                   6,
                                                                   (int)Module6.BuildInAccountType.Creator,
                                                                   creatorAccount.Name, (int)ControlType.Orgnization,
                                                                   creator.UserID, creator.FullName, (int)ControlType.User);

                return (int)mainItem.OrigID;
            }//end of using            
        }//end of func


        /// <summary>
        /// 传入一个formid，获取所有的form结构
        /// </summary>
        /// <param name="lstPids"> 一开始你把当前form id添加到list里就OK </param>
        /// <param name="dc"> 在外面创建一个dataContext </param>
        /// <returns> 子Forms id的list集合 </returns>
        public static IEnumerable<Forms> GetSubFormRecursive(List<int> lstPids, DataClassesKCZYSDataContext dc)
        {
            var query = from tb in dc.Forms
                        where lstPids.Contains(Convert.ToInt32(tb.ParentID))
                        select tb;
            if (query.Count() > 0)
            {
                List<int> lstCurrent = query.Select(x => x.FormID).ToList();
                return query.ToList().Concat(GetSubFormRecursive(lstCurrent, dc));
            }
            else
            {
                return query.ToList();
            }
        }//end of func



    }//end of class



    public class Module6Items
    {

        public enum ResultFormEnum
        {
            Submit = 0,
            Agree = -1,
            Reject = -2,
            Abort = -3,
            Complete = -4
        }

        /// <summary>
        /// 主Item单拿出来
        /// </summary>
        //public Items MainItem { get; set; } //直接用这个有问题,体现在数据同步和往数据库回写上
        public ItemsMD MainItem { get; set; }
        public FormsMD MainForm { get; set; }
        /// <summary>
        /// 所有子Item都放内存里，如果你要查，可以通过lambda表达式查
        /// </summary>        
        public List<ItemsMD> LstItem { get; set; }
        /// <summary>
        /// 所有的子form都放在这
        /// </summary>
        public List<FormsMD> LstForm { get; set; }

        /// <summary>
        /// 推荐用法，传入一个主ItemID，获取所有的Item和form
        /// </summary>
        /// <param name="intOrigItemID"></param>
        public Module6Items(int intOrigItemID)
        {
            MainItem = new ItemsMD();
            MainForm = new FormsMD();
            LstItem = new List<ItemsMD>();
            LstForm = new List<FormsMD>();

            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                //主item和主form
                var _MainItemDb = dc.Items.FirstOrDefault(x => x.OrigID == intOrigItemID && x.ItemID == x.OrigID);
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(MainItem, _MainItemDb);
                var _MainFormDb = dc.Forms.FirstOrDefault(x => x.FormID == MainItem.FormID);
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(MainItem, _MainFormDb);
                

                //找子item和对应的form
                var _LstItem = dc.Items.Where(x => x.OrigID == intOrigItemID && x.ItemID != x.OrigID).OrderBy(x => x.ItemID).ToList();
                foreach (var objDb in _LstItem)
                {
                    var newObj = new ItemsMD();
                    //EntityBO.SetProperties<Items, ItemsMD>(obj, newObj);
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(newObj, objDb);
                    LstItem.Add(newObj);
                }
                if (LstItem.Count >= 1 && LstItem[0].FormID > 0)
                {
                    var _LstForm = dc.Forms.Where(x => x.FormOrigID == MainItem.FormID && x.FormID != x.FormOrigID).ToList();
                    foreach (var objDb in _LstForm)
                    {
                        var newObj = new FormsMD();
                        BLL.Utility.EntityHelper<object>.SetInstanceProperties(newObj, objDb);
                        LstForm.Add(newObj);
                    }
                }//end if
            }//end of using
        }//end of func

        /// <summary>
        /// 把Item同步到数据库，我们操作的绝大部分时候都在内存中
        /// </summary>
        /// <param name="item"></param>
        private void UpdateToDb(ItemsMD item)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var itemDb = dc.Items.FirstOrDefault(x => x.ItemID == item.ItemID);         
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(itemDb, item);
                dc.SubmitChanges();
            }//end of using
        }//end of func
        /// <summary>
        /// 同上
        /// </summary>
        /// <param name="lstItem"></param>
        private void UpdateToDb(List<ItemsMD> lstItem)
        {
            List<long> lstItemIDs = lstItem.Select(x => x.ItemID).ToList();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.Items
                           where lstItemIDs.Contains((int)tb.ItemID)
                           select tb;
                foreach (var obj in linq)
                {
                    var objInMem = lstItem.FirstOrDefault(x => x.ItemID == obj.ItemID);
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(obj, objInMem);                  
                }//end foreach
                dc.SubmitChanges();
            }//end of using
        }

        /// <summary>
        /// 老代码参考 SubFlowFormNode的public bool SubmitWithoutCondition
        /// </summary>
        /// <param name="intSubItemID">以子Item为入口创建</param>
        /// <param name="intResultFormID">如果这个提交时最后一步了，要选择下一个结果子Form的，根据实际情况来。默认传0即可</param>
        /// <param name="userOperator">当前操作人，用UsersMD</param>
        /// <param name="strActionName">本次提交的动作，比如就传入"提交"，"强势插入"等等</param>
        /// <param name="strNotes">本次提交意见，有可能会逼逼两句</param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus Submit(int intSubItemID, int intResultFormID, UsersMD userOperator, string strActionName, string strNotes, List<UsersMD> lstNext)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();          

            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            var curForm = LstForm.FirstOrDefault(x => x.FormID == curItem.FormID);
            if (curItem == null)
                return BLL.ItemsBO.ItemStatus.NoStatus;
            //处于编辑状态才能提交
            if (curItem.MyStatus != (short?)BLL.ItemsBO.ItemStatus.EditStatus)
                return BLL.ItemsBO.ItemStatus.NoStatus;

            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.Approval;
            curItem.ApprovalStatus = (short)(curItem.ApprovalStatus + 1);
            UpdateToDb(curItem);
            //插入操作历史
            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = (int)ItemApprovalBO.TypeStatus.History,//当前
                ResultText = "已经提交",//strActionName,//被改成固定文本了
                ResultID = (int)ResultFormEnum.Submit,//0是提交
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();


            //数据的更新都在if else里,因为那里还有状态要判断

            //可以完成了.如果Form的ApprovalType，那么是仅提交，无审批。从0加到1，完成
            //如果Form的ApprovalType是2，那么是一层审批，ApprovalStatus=1时是提交了，等1级审批。
            //                                      ApprovalStatus=2时是一级审批过了，等2级审批，如果Form的ApprovalType=3，那么这会也该完成了。
            //Form的      ApprovalType = n，那么本表单就是n-1级审批                                                      
            if (curItem.ApprovalStatus == curForm.ApprovalType)
            {
                //这时候ResultID就有用了。
                curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                curItem.ApprovalStatus = 0;
                curItem.ResultFormID = intResultFormID;

                UpdateToDb(curItem);

                //看看result后是否还有form
                var nextForm = LstForm.FirstOrDefault(x => x.ParentID == intResultFormID);
                //该全部完成了，不用再建子item了
                if (nextForm == null)
                {
                    MainItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                    MainItem.ApprovalStatus = (int)0;
                    UpdateToDb(MainItem);

                    foreach (var obj in LstItem)
                    {
                        if (obj.ItemID == curItem.ItemID)
                            continue;

                        obj.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                        obj.ApprovalStatus = (int)0;
                        UpdateToDb(obj);
                    }//end foreach

                }//end if
                else //本Item的审批都完事了，根据nextForm创建子item
                {
                    //下一步的人就有用了
                    //以前module6的创建下一个子Item做法，其实是工作流。
                    //不应该混合在审批里
                    var nextItem = new Items();
                    EntityHelper<object>.SetInstanceDefaultValue(nextItem);

                    {
                        nextItem.ModuleID = MainItem.ModuleID;
                        nextItem.GroupID = MainItem.GroupID;
                        nextItem.OrigID = MainItem.OrigID;
                        nextItem.ProjID = MainItem.ProjID;
                        nextItem.ProjOrigID = curItem.ProjOrigID;
                        nextItem.MyName = MainItem.MyName + "(" + nextForm.MyName + ")";
                        nextItem.MyClass = MainItem.MyClass;
                        nextItem.TypeID = MainItem.TypeID;
                        nextItem.ResultFormID = 0;
                        nextItem.Permission = 0;
                        nextItem.ApprovalStatus = 0;
                        nextItem.IsDeleted = false;
                        //设置ParentID
                        nextItem.ParentID = (int) curItem.ItemID;
                        nextItem.MyStatus = (int) BLL.ItemsBO.ItemStatus.EditStatus;
                        nextItem.TotalStatus = (int) BLL.ItemsBO.ItemStatus.EditStatus;
                        nextItem.FormID = nextForm.FormID;
                        nextItem.CreatorID = (int) lstNext[0].UserID;
                        nextItem.CreateBy = lstNext[0].FullName;
                    }
                    //EntityHelper<object>.SetInstanceDefaultValue(nextItem);
                    dc.Items.InsertOnSubmit(nextItem);
                    dc.SubmitChanges();
                    ItemsMD itemMem = new ItemsMD();
                    EntityHelper<object>.SetInstanceProperties(itemMem, nextItem);
                    LstItem.Add(itemMem);


                    //删除老负责人游标，插入新的负责人游标
                    UpdateCurrentRoleIterator(lstNext, curItem, nextItem, "等待提交", strNotes, (int)ResultFormEnum.Submit);

                    //发通知
                    //string strMessage = "<a href=''>详情请查看</a>";
                    //SendNotice(nextItem.ItemID,XData.Global.specialRoleSubmitRoleID,"你有新的流程要处理："+nextForm.MyName,strMessage,null);
                }//end if                                
            }
            else if (curItem.ApprovalStatus < curForm.ApprovalType) //还没到尾巴
            {
                //删除老游标
                UpdateCurrentRoleIterator(lstNext, curItem, "等待审批", strNotes, (int)ResultFormEnum.Submit);
                //**通知下一级的相关人员
                //var nextRole = 0 - curItem.ApprovalStatus - 2;

            }
            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }

        /// <summary>
        /// 撤销操作，这个函数的逻辑绝对有问题，先记下来。撤销暂时不用
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <param name="intResultFormID"></param>
        /// <param name="userOperator"></param>
        /// <param name="strActionName"></param>
        /// <param name="strNotes"></param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus Undo(int intSubItemID,
            int intResultFormID,
            UsersMD userOperator,
            string strActionName,
            string strNotes)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);

            if (curItem == null)
                return BLL.ItemsBO.ItemStatus.NoStatus;
            //处于审批状态才能撤回
            if (curItem.MyStatus != (short?)BLL.ItemsBO.ItemStatus.Approval)
                return BLL.ItemsBO.ItemStatus.NoStatus;

            //还原
            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
            curItem.ApprovalStatus = 0;
            UpdateToDb(curItem);


            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = 0,//当前
                ResultText = strActionName,
                ResultID = -2,//-2是驳回
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = (int)userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();
            //删掉游标
            //插入当前游标        
            var _lstNext = (from tb in dc.Users
                           where tb.UserID == curItem.CreatorID
                           select tb).ToList();
            List<UsersMD> lstNext = new List<UsersMD>();
            foreach (var objDb in _lstNext)
            {
                UsersMD objMem = new UsersMD();
                EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                lstNext.Add(objMem);
            }

            UpdateCurrentRoleIterator(lstNext, curItem, "等待", "提交", intResultFormID);

            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }//end of func


        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="intSubItemID">以子Item为入口创建</param>
        /// <param name="intResultFormID">如果这个提交时最后一步了，要选择下一个结果子Form的，根据实际情况来。默认传0即可</param>
        /// <param name="userOperator">当前操作人，用UsersMD</param>
        /// <param name="strActionName">本次提交的动作，比较就传入"提交"，"强势插入"等等</param>
        /// <param name="strNotes">本次提交意见，有可能会逼逼两句</param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus Approval(int intSubItemID, int intResultFormID, UsersMD userOperator, string strActionName, string strNotes, List<UsersMD> lstNextUser)
        {
            //处于审批状态才能审批
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            if (curItem == null || curItem.MyStatus != (short?)BLL.ItemsBO.ItemStatus.Approval)
                return BLL.ItemsBO.ItemStatus.NoStatus;

            var curForm = LstForm.FirstOrDefault(x => x.FormID == curItem.FormID);
            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.Approval;
            curItem.ApprovalStatus = (short)(curItem.ApprovalStatus + 1);
            UpdateToDb(curItem);
            ///操作历史
            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = (int)ItemApprovalBO.TypeStatus.History,//操作历史
                ResultText = "同意",
                ResultID = intResultFormID > 0 ? intResultFormID : (int)Module6Items.ResultFormEnum.Agree,//-1是同意
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = (int)userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();

            //可以完成了.如果Form的ApprovalType，那么是仅提交，无审批。从0加到1，完成
            //如果Form的ApprovalType是2，那么是一层审批，ApprovalStatus=1时是提交了，等1级审批。
            //                                      ApprovalStatus=2时是一级审批过了，等2级审批，如果Form的ApprovalType=3，那么这会也该完成了。
            //Form的      ApprovalType = n，那么本表单就是n-1级审批                                                      
            if (curItem.ApprovalStatus == curForm.ApprovalType)
            {
                curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                curItem.ApprovalStatus = 0;
                curItem.ResultFormID = intResultFormID;

                UpdateToDb(curItem);

                //看看result后是否还有form
                var nextForm = LstForm.FirstOrDefault(x => x.ParentID == intResultFormID);
                //整个item都该完成
                if (nextForm == null)
                {
                    MainItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                    MainItem.ApprovalStatus = (int)0;
                    UpdateToDb(MainItem);

                    foreach (var obj in LstItem)
                    {
                        if (obj.ItemID == curItem.ItemID)
                            continue;
                        obj.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                        obj.ApprovalStatus = (int)0;
                        UpdateToDb(obj);
                    }//end foreach

                    //删除游标
                    var linq = from tb in dc.ItemApproval
                               where tb.Type == (int)ItemApprovalBO.TypeStatus.Iterator && tb.ItemID == intSubItemID
                               select tb;
                    dc.ItemApproval.DeleteAllOnSubmit(linq);
                    dc.SubmitChanges();

                    //**通知大家已经完成了。
                }//end if 
                else
                {
                    //还有下一个item，创建之
                    var nextItem = new Items
                    {
                        ModuleID = MainItem.ModuleID,
                        GroupID = MainItem.GroupID,
                        OrigID = (int)MainItem.OrigID,
                        ProjID = (int)MainItem.ProjID,
                        ProjOrigID = (int)curItem.ProjOrigID,
                        MyName = MainItem.MyName + "(" + nextForm.MyName + ")",
                        MyClass = MainItem.MyClass,
                        TypeID = (int)MainItem.TypeID,
                        ResultFormID = 0,
                        Permission = 0,
                        ApprovalStatus = 0,
                        IsDeleted = false,
                        //设置ParentID
                        ParentID = (int)curItem.ItemID,
                        MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus,
                        TotalStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus,
                        FormID = nextForm.FormID
                    };
                    EntityHelper<object>.SetInstanceDefaultValue(nextItem);
                    dc.Items.InsertOnSubmit(nextItem);
                    dc.SubmitChanges();
                    ItemsMD itemMem = new ItemsMD();
                    EntityHelper<object>.SetInstanceProperties(itemMem, nextItem);
                    LstItem.Add(itemMem);

                    UpdateCurrentRoleIterator(lstNextUser, curItem, nextItem, "等待提交", strNotes, (int)ResultFormEnum.Agree);
                    //**通知新表单的填写人

                }//end if               
            }
            else if (curItem.ApprovalStatus < curForm.ApprovalType) //还没到尾巴
            {
                //删除老游标
                UpdateCurrentRoleIterator(lstNextUser, curItem, "等待审批", strNotes, (int)ResultFormEnum.Agree);
                //**通知下一级的相关人员
            }
            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }


        //打回，院里的系统就叫打回到xxxx
        //打回到哪是个很麻烦的问题
        //和高工讨论的结果是一般都是打到提交人，因为中途审批人断然是不会去该文档，填表单的。
        public BLL.ItemsBO.ItemStatus Reject(int intSubItemID, UsersMD userOperator, string strActionName, string strNotes)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);

            if (curItem == null)
                return BLL.ItemsBO.ItemStatus.NoStatus;
            //处于审批状态才能驳回
            if (curItem.MyStatus != (short?)BLL.ItemsBO.ItemStatus.Approval)
                return BLL.ItemsBO.ItemStatus.NoStatus;


            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
            curItem.ApprovalStatus = 0;

            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = (int)ItemApprovalBO.TypeStatus.History,//当前
                ResultText = "驳回",
                ResultID = (int)Module6Items.ResultFormEnum.Reject,//-2是驳回
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = (int)userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();

            UpdateToDb(curItem);

            //删除老游标
            var _lstNextUser = (from tb in dc.Users
                               where tb.UserID == curItem.CreatorID
                               select tb).ToList();

            List<UsersMD> lstNextUser = new List<UsersMD>();
            foreach (var objDb in _lstNextUser)
            {
                UsersMD objMem = new UsersMD();
                EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                lstNextUser.Add(objMem);
            }
            UpdateCurrentRoleIterator(lstNextUser, curItem, "等待提交", strNotes, (int)ResultFormEnum.Reject);

            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }

        /// <summary>
        /// 流程终止
        /// </summary>
        /// <param name="intSubItemID">以子Item为入口创建</param>
        /// <param name="userOperator">当前操作人，用UsersMD</param>
        /// <param name="strActionName">本次终止的动作，比较就传入"废弃"，"终止。。。"等等</param>
        /// <param name="strNotes">本次终止意见，有可能会逼逼两句</param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus Abort(int intSubItemID, UsersMD userOperator, string strActionName, string strNotes)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            if (curItem == null)
                return BLL.ItemsBO.ItemStatus.NoStatus;
            //让本子Item完成
            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.Disable;
            curItem.ApprovalStatus = 0;

            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = 0,//当前
                ResultText = strActionName,
                ResultID = -3,//-3是不同意，流程结束
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = (int)userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();

            UpdateToDb(curItem);

            //删除老游标
            var linq = from tb in dc.ItemApproval
                       where tb.ItemID == intSubItemID && tb.Type == 2
                       select tb;
            dc.ItemApproval.DeleteAllOnSubmit(linq);
            dc.SubmitChanges();

            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }//end of func

        /// <summary>
        /// 很多人还是提出了这个要求，实际是要求流程灵活，比如审批到了部门经理这里，部门经理觉得
        /// 这事不那么重要，或者合同金额很小。部门经理就直接完成了。
        /// </summary>
        /// <param name="intSubItemID">子ItemID</param>
        /// <param name="intResultFormID">下一个Form的结果id，线性审批暂时不用</param>
        /// <param name="userOperator">操作者</param>
        /// <param name="strActionName">动作</param>
        /// <param name="strNotes">配合动作的文字说明</param>
        /// <param name="lstNextUser"></param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus Complete(int intSubItemID, int intResultFormID, UsersMD userOperator, string strActionName, string strNotes, List<UsersMD> lstNextUser)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            if (curItem == null)
                return BLL.ItemsBO.ItemStatus.NoStatus;
            //让本子Item完成
            curItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
            curItem.ApprovalStatus = 0;
            curItem.ResultFormID = intResultFormID;

            var itemSubmitHistory = new ItemApproval
            {
                ItemID = intSubItemID,
                ApprovalStatus = (short)curItem.ApprovalStatus,
                Type = (int)ItemApprovalBO.TypeStatus.History,//当前
                ResultText = strActionName,
                ResultID = intResultFormID > 0 ? intResultFormID : (int)Module6Items.ResultFormEnum.Complete,//-4是没走完全流程，完成流程
                MyNote = strNotes,
                UserName = userOperator.FullName,
                UserID = (int)userOperator.UserID,
                SubmitDate = DateTime.Now
            };
            dc.ItemApproval.InsertOnSubmit(itemSubmitHistory);
            dc.SubmitChanges();

            UpdateToDb(curItem);

            //删除老游标
            var linq = from tb in dc.ItemApproval
                       where tb.ItemID == intSubItemID && tb.Type == 2
                       select tb;
            dc.ItemApproval.DeleteAllOnSubmit(linq);
            dc.SubmitChanges();


            //看看result后是否还有form
            var nextForm = LstForm.FirstOrDefault(x => x.ParentID == intResultFormID);
            //整个item都该完成
            if (nextForm == null)
            {
                MainItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                MainItem.ApprovalStatus = (int)0;
                UpdateToDb(MainItem);
                foreach (var obj in LstItem)
                {
                    if (obj.ItemID == curItem.ItemID)
                        continue;
                    obj.MyStatus = (int)BLL.ItemsBO.ItemStatus.CompletedStatus;
                    obj.ApprovalStatus = (int)0;
                    UpdateToDb(obj);
                }//end foreach  
            }//end if 
            else
            {
                //还有下一个item，创建之
                var nextItem = new Items
                {
                    ModuleID = MainItem.ModuleID,
                    GroupID = MainItem.GroupID,
                    OrigID = (int)MainItem.OrigID,
                    ProjID = (int)MainItem.ProjID,
                    ProjOrigID = (int)curItem.ProjOrigID,
                    MyName = MainItem.MyName + "(" + nextForm.MyName + ")",
                    MyClass = MainItem.MyClass,
                    TypeID = (int)MainItem.TypeID,
                    ResultFormID = 0,
                    Permission = 0,
                    ApprovalStatus = 0,
                    IsDeleted = false,
                    //设置ParentID
                    ParentID = (int)curItem.ItemID,
                    MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus,
                    TotalStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus,
                    FormID = nextForm.FormID
                };
                dc.Items.InsertOnSubmit(nextItem);
                dc.SubmitChanges();

                UpdateCurrentRoleIterator(lstNextUser, curItem, "等待", "提交", (int)ResultFormEnum.Reject);
            }//end if    
            return (BLL.ItemsBO.ItemStatus)curItem.MyStatus;
        }//end of func



        /// <summary>
        /// 获取审批历史
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public List<ItemApprovalMD> ItemApprovalHistory(int intSubItemID)
        {
            List<ItemApprovalMD> lstItemApproval = new List<ItemApprovalMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.ItemApproval
                           where tb.ItemID == intSubItemID
                           orderby tb.SubmitDate descending
                           select tb;
                foreach (var objDb in linq)
                {
                    var objNew = new ItemApprovalMD();
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objNew, objDb);
                    lstItemApproval.Add(objNew);
                }
            }
            return lstItemApproval;
        }//end of func

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <param name="strRoleID">-2是提交人，-1是总负责人，-3是1级别审批人，-4是二级审批，-5是三级审批，-102是通知人(抄送者)</param>
        /// <returns></returns>
        public List<Users>  ItemRols(int intSubItemID, string strRoleID)
        {
            var subItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            string strError = string.Empty;
            XMain.Code.SpecialRoleUser spe = new XMain.Code.SpecialRoleUser();
            List<XMain.Code.GroupSystemObject> lstUids = spe.GetUserIDWithMainItemIDFormIDRoleID(MainItem.OrigID.ToString(),
                XData.Global.roleRelatedTypeOrig,
                MainItem.ModuleID.ToString(),
                subItem.FormID.ToString(),
                strRoleID,
                ref strError);

            List<XMain.Code.SelectUser> UserTable = new List<XMain.Code.SelectUser>();

            foreach (var obj in lstUids)
            {
                var su = new XMain.Code.SelectUser
                {
                    ID = obj.ObjectID,
                    Name = obj.ObjectName,
                    Type = obj.ObjectType == XMain.Code.GroupSystemObject.Type.GroupContent ? (long)XMain.Code.SelectUser.SelectUserType.User : (long)XMain.Code.SelectUser.SelectUserType.Organization
                };
                UserTable.Add(su);
            }//end foreach

            //获取接受者
            XMain.Code.XEvent xEvt = new XMain.Code.XEvent();
            DataTable dtblReceivers = xEvt.ResolveControlListToUsers(UserTable, "0", "0", "0", ref strError);
            List<int> lstUsersId = new List<int>();
            foreach (DataRow dr in dtblReceivers.Rows)
            {
                lstUsersId.Add(Convert.ToInt32(dr["UserID"].ToString()));
            }
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var linq = from tb in dc.Users
                       where lstUsersId.Contains((int)tb.UserID)
                       select tb;
            return linq.ToList();
        }//end of func

        /// <summary>
        /// 更新人员游标
        /// </summary>
        /// <param name="lstNextUser"></param>
        /// <param name="curItem"></param>
        /// <param name="nextItem"></param>
        /// <param name="strAction"></param>
        /// <param name="strNotes"></param>
        /// <param name="intResultFormID"></param>
        protected void UpdateCurrentRoleIterator(List<UsersMD> lstNextUser,
            ItemsMD curItem,
            Items nextItem,
            string strAction, string strNotes, int intResultFormID)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            //删除老游标
            var linq = from tb in dc.ItemApproval
                       where tb.ItemID == curItem.ItemID && tb.Type == (int)ItemApprovalBO.TypeStatus.Iterator
                       select tb;
            dc.ItemApproval.DeleteAllOnSubmit(linq);
            dc.SubmitChanges();

            //插入当前游标
            foreach (var obj in lstNextUser)
            {
                var itemCurrentState = new ItemApproval
                {
                    ItemID = (int)nextItem.ItemID,
                    ApprovalStatus = (short)curItem.ApprovalStatus,
                    Type = (int)ItemApprovalBO.TypeStatus.Iterator,//相当于最新游标
                    ResultText = strAction,
                    ResultID = intResultFormID,//0是提交
                    MyNote = strNotes,
                    UserName = obj.FullName,
                    UserID = (int)obj.UserID,
                    SubmitDate = DateTime.Now
                };
                dc.ItemApproval.InsertOnSubmit(itemCurrentState);
            }
            dc.SubmitChanges();
        }

        /// <summary>
        /// 更新人员游标
        /// </summary>
        /// <param name="lstNextUser"></param>
        /// <param name="curItem"></param>
        /// <param name="strAction"></param>
        /// <param name="strNotes"></param>
        /// <param name="intResultFormID"></param>
        protected void UpdateCurrentRoleIterator(List<UsersMD> lstNextUser,
            ItemsMD curItem,
            string strAction, string strNotes, int intResultFormID)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            //删除老游标
            var linq = from tb in dc.ItemApproval
                       where tb.ItemID == curItem.ItemID && tb.Type == (int)ItemApprovalBO.TypeStatus.Iterator
                       select tb;
            dc.ItemApproval.DeleteAllOnSubmit(linq);
            dc.SubmitChanges();

            if (lstNextUser != null)
            {
                //插入当前游标
                foreach (var obj in lstNextUser)
                {
                    var itemCurrentState = new ItemApproval
                    {
                        ItemID = (int)curItem.ItemID,
                        ApprovalStatus = (short)curItem.ApprovalStatus,
                        Type = (int)ItemApprovalBO.TypeStatus.Iterator,//相当于最新游标
                        ResultText = strAction,
                        ResultID = intResultFormID,//0是提交
                        MyNote = strNotes,
                        UserName = obj.FullName,
                        UserID = (int)obj.UserID,
                        SubmitDate = DateTime.Now
                    };
                    dc.ItemApproval.InsertOnSubmit(itemCurrentState);
                }
                dc.SubmitChanges();
            }
        }//end of func

        /// <summary>
        /// 这就是当前需要干活的人了，如果不在这些人里。不能动页面上的任何交互操作。
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public List<UsersMD> CurrentUserRoles(int intSubItemID)
        {
            DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
            var linq = (from tb in dc.ItemApproval
                        from utable in dc.Users
                        where tb.ItemID == intSubItemID && tb.Type == 2 && tb.UserID == utable.UserID
                        select utable).ToList();
            List<UsersMD> lstAns = new List<UsersMD>();
            foreach (var objDb in linq)
            {
                UsersMD objNew = new UsersMD();
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(objNew, objDb);
                lstAns.Add(objNew);
            }
            return lstAns;
        }//end of func


        /// <summary>
        /// 下一阶段的人，比如提交那么下一阶段的就是一级审批人。1级别审批人审批中，那么下一阶段的就是2级审批人
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public List<UsersMD> NextStepUserRoles(int intSubItemID)
        {
            
            var curItem = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            var curForm = LstForm.FirstOrDefault(x => x.FormID == curItem.FormID);
            //最后一步，看看还要不要建子Item
            if (curItem.ApprovalStatus == curForm.ApprovalType - 1)
            {
                var nextResultForm = LstForm.FirstOrDefault(x => x.ParentID == curForm.FormID);
                FormsMD nextForm = null;
                if (nextResultForm != null)
                    nextForm = LstForm.FirstOrDefault(x => x.ParentID == nextResultForm.FormID);
                ControlListsBO controBO = new ControlListsBO();
                List<UsersMD> lstAns =new List<UsersMD>();
                if (nextForm != null)
                {
                  lstAns=  controBO.GetFormRoles((int)MainItem.ItemID, nextForm.FormID, -2);
                }
                return lstAns;
            }
            else
            {
                var roleID = (0 - curItem.ApprovalStatus - 3).ToString();
                //得到下一步的负责人list
                var approvalPeople = this.ItemRols(intSubItemID, roleID);
                List<UsersMD> lstAns = new List<UsersMD>();
                foreach (var obj in approvalPeople)
                {
                    UsersMD objMem = new UsersMD();
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, obj);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }
        }//end of func

        /// <summary>
        /// 获取Item的状态
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public BLL.ItemsBO.ItemStatus ItemStatus(int intSubItemID)
        {
            return (BLL.ItemsBO.ItemStatus)LstItem.FirstOrDefault(x => x.ItemID == intSubItemID).MyStatus;
        }

        /// <summary>
        /// 获取当前Item
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public ItemsMD GetItem(int intSubItemID)
        {
            return LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
        }
        /// <summary>
        /// 获取当前子Item的表单
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public FormsMD GetForm(int intSubItemID)
        {
            var item = GetItem(intSubItemID);
            if (item != null)
            {
                return LstForm.FirstOrDefault(x => x.FormID == item.FormID);
            }
            else
                return new FormsMD();
        }

        /// <summary>
        /// 获取当前活跃的Item
        /// </summary>
        /// <returns></returns>
        public ItemsMD GetActiveItem()
        {
            ItemsMD activeItem = null;
            var linq = LstItem.OrderBy(x => x.ItemID).ToList();//升序地排
            for (int i = 0; i < linq.Count; i++)
            {
                if (linq[i].MyStatus != (short)BLL.ItemsBO.ItemStatus.CompletedStatus)
                {
                    activeItem = linq[i];
                    break;
                }
            }
            return activeItem;
        }

        /// <summary>
        /// 判断是否为最后一步，如果只需提交。那当然也是最后一步。
        /// 如果是1级别审批，提交之后ApprovalStatus是1，Form的ApprovalType是2。那也是最后一步了。
        ///
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public bool IsLastStep(int intSubItemID)
        {
            var item = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            var form = LstForm.FirstOrDefault(x => x.FormID == item.FormID);
            if (form.ApprovalType - 1 == (int?)item.ApprovalStatus)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 下一步工作流
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns></returns>
        public List<FormsMD> NextFlowResult(int intSubItemID)
        {
            var item = LstItem.FirstOrDefault(x => x.ItemID == intSubItemID);
            var form = LstForm.FirstOrDefault(x => x.FormID == item.FormID);
            var linq = (from tb in LstForm
                        where tb.ParentID == form.FormID
                        select tb).ToList();
            return linq;
        }

        /// <summary>
        /// 获取当前Item的审批状态
        /// </summary>
        /// <param name="intSubItemID"></param>
        /// <returns> 
        /// 0未进入审批程序，或不需要审批，或最终审批通过
        /// 1是提交后等待1级别审批；2是1级审批过后等待2级审批；3是2级审批通过等待3级审批</returns>
        public int ItemApprovalStatus(int intSubItemID)
        {
            return (int)LstItem.FirstOrDefault(x => x.ItemID == intSubItemID).ApprovalStatus;
        }




    }//end of class



    public class Module4
    { 
        public bool IsCorrect { get; set; }
        Forms MainForm;
        /// <summary>
        /// 包括普通表单和结果
        /// </summary>
        List<Forms> SubForms;
        Groups CurrentGroup;

        /// <summary>
        /// Module6是一个框，首先得有个forms结构，然后再有一个group绑定该forms结果。
        /// 在改group下创建的item都具备这个forms结构
        /// </summary>
        /// <param name="lngGroupID"></param>
        public Module4(long lngGroupID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                CurrentGroup = dc.Groups.FirstOrDefault(x => x.GroupID == lngGroupID);
                if (CurrentGroup == null)
                    IsCorrect = false;
                else
                {
                    int intFormID = (int)CurrentGroup.FormID;
                    MainForm = dc.Forms.FirstOrDefault(x => x.FormID == intFormID);
                    SubForms = dc.Forms.Where(x => x.ParentID == MainForm.FormID).ToList();
                }
            }//end of using
        }


        /// <summary>
        /// 给一个Item的实名，创建主Item和第一个子Item
        /// 老代码参考SubFlowFormNode的Create
        /// </summary>
        /// <param name="strMyName"></param>
        /// <returns></returns>
        public int CreateItem(string strMyName, UsersMD creator)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                Items mainItem = new Items();
                mainItem.GroupID =  (int)CurrentGroup.GroupID;
                mainItem.ParentID =  0;//OrigItem嘛
                mainItem.ModuleID =  4;
                mainItem.MyName =  strMyName;
                mainItem.FormID = MainForm.FormID;
                mainItem.MyStatus =  (int)BLL.ItemsBO.ItemStatus.EditStatus;
                mainItem.TotalStatus =  (int)BLL.ItemsBO.ItemStatus.EditStatus;
                mainItem.ApprovalStatus =  0;//未进入审批程序
                mainItem.TypeID = CurrentGroup.TypeID;
                mainItem.IsDeleted =  false;
                mainItem.CreatorID =  (int)creator.UserID;
                mainItem.CreateBy =  creator.FullName;
                //代码默认值会溢出
                EntityHelper<object>.SetInstanceDefaultValue(mainItem);
                dc.Items.InsertOnSubmit(mainItem);
                dc.SubmitChanges();
                mainItem.OrigID = (int)mainItem.ItemID;
                dc.SubmitChanges();

                //插入所有的子Item
                var linq = SubForms.Where(x => x.ParentID == MainForm.FormID);
                foreach (var objForm in linq)
                {
                    Items subItem = new Items();
                    subItem.GroupID = (int)CurrentGroup.GroupID;
                    subItem.ParentID = 0;//OrigItem嘛
                    subItem.ModuleID = 4;

                    var strTmp = objForm != null ? objForm.MyName : string.Empty;
                    subItem.MyName = mainItem.MyName + "(" + strTmp + ")";
                    subItem.FormID = objForm.FormID;
                    subItem.MyStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
                    subItem.TotalStatus = (int)BLL.ItemsBO.ItemStatus.EditStatus;
                    subItem.ApprovalStatus = 0;//未进入审批程序
                    subItem.TypeID = CurrentGroup.TypeID;
                    subItem.IsDeleted = false;
                    subItem.CreatorID = (int)creator.UserID;
                    subItem.CreateBy = creator.FullName;
                    subItem.OrigID = (int)mainItem.ItemID;
                    subItem.ParentID = (int)mainItem.ItemID;

                    //代码默认值会溢出
                    EntityHelper<object>.SetInstanceDefaultValue(subItem);
                    dc.Items.InsertOnSubmit(subItem);
                    dc.SubmitChanges();
                }
                   

                return (int)mainItem.OrigID;
            }//end of using            
        }//end of func
    }


    public class Module4Items
    {
        public ItemsMD MainItem { get; set; }
        public FormsMD MainForm { get; set; }
        /// <summary>
        /// 所有子Item都放内存里，如果你要查，可以通过lambda表达式查
        /// </summary>        
        public List<ItemsMD> LstItem { get; set; }
        /// <summary>
        /// 所有的子form都放在这
        /// </summary>
        public List<FormsMD> LstForm { get; set; }

        /// <summary>
        /// 推荐用法，传入一个主ItemID，获取所有的Item和form
        /// </summary>
        /// <param name="intOrigItemID"></param>
        public Module4Items(int intOrigItemID)
        {
            MainItem = new ItemsMD();
            MainForm = new FormsMD();
            LstItem = new List<ItemsMD>();
            LstForm = new List<FormsMD>();

            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                //主item和主form
                var _MainItemDb = dc.Items.FirstOrDefault(x => x.OrigID == intOrigItemID && x.ItemID == x.OrigID);
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(MainItem, _MainItemDb);
                var _MainFormDb = dc.Forms.FirstOrDefault(x => x.FormID == MainItem.FormID);
                BLL.Utility.EntityHelper<object>.SetInstanceProperties(MainItem, _MainFormDb);
                

                //找子item和对应的form
                var _LstItem = dc.Items.Where(x => x.OrigID == intOrigItemID && x.ItemID != x.OrigID).OrderBy(x => x.ItemID).ToList();
                foreach (var objDb in _LstItem)
                {
                    var newObj = new ItemsMD();
                    //EntityBO.SetProperties<Items, ItemsMD>(obj, newObj);
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(newObj, objDb);
                    LstItem.Add(newObj);
                }
                if (LstItem.Count >= 1 && LstItem[0].FormID > 0)
                {
                    var _LstForm = dc.Forms.Where(x => x.FormOrigID == MainItem.FormID && x.FormID != x.FormOrigID).ToList();
                    foreach (var objDb in _LstForm)
                    {
                        var newObj = new FormsMD();
                        BLL.Utility.EntityHelper<object>.SetInstanceProperties(newObj, objDb);
                        LstForm.Add(newObj);
                    }
                }//end if
            }//end of using
        }//end of func

    }//end of func

   


}