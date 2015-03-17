using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using KCZYLIMS.BLL;
using SqlDataAccess;
using System.Text;

namespace KCZYLIMS.Controllers
{
    public class SelectorController : Controller
    {
        //
        // GET: /Selector/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户选择器的View
        /// </summary>
        /// <param name="ReturnCtrl">javascript的回传值控件</param>
        /// <param name="CallBack">javascript的回调函数</param>
        /// <param name="MultiSelect">是否多选</param>
        /// <param name="Type">1:用户,2:组织机构;3:全部</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult UserSelector(string ReturnCtrl, string CallBack, string MultiSelect , string Type )
        {

            GroupsBO groupBO = new GroupsBO();
            string strJs = string.Empty;
            ViewData["GroupJavaScript"] = string.Empty;
            ViewData["InitGroupID"] = 1;
            if( Type.Equals("1") )//用户
            {
                List<long> lstTmp = new List<long>();
                lstTmp.Add(50);
                ViewData["GroupJavaScript"] = ConvertToJavaScriptArray(groupBO.GetSelfAndDescendantChildrenGroups(lstTmp), "");
                ViewData["InitGroupID"] = 50;
            }
            else if (Type.Equals("2")) // 组织机构
            {
                List<long> lstTmp = new List<long>();
                lstTmp.Add(51);
                ViewData["GroupJavaScript"] = ConvertToJavaScriptArray(groupBO.GetSelfAndDescendantChildrenGroups(lstTmp), "");
                ViewData["InitGroupID"] = 51;
            }
            else
            {
                ViewData["GroupJavaScript"] = ConvertToJavaScriptArray(groupBO.GetDescendantChildrenGroups(1), "");
            }
            ViewData["ReturnCtrl"] = ReturnCtrl;
            if (!string.IsNullOrEmpty(ReturnCtrl))
            { 
                strJs += "window.parent[0].$('#"+ReturnCtrl+"').val(retVal);";
            }
            if (!string.IsNullOrEmpty(CallBack))
            {
                strJs += "window.parent[0]." + CallBack;
            }

            ViewData["JS"] = strJs;

            return View();
        }//end of func


        /// <summary>
        /// 客户选择器的view
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ClientSelector(string ReturnCtrl, string CallBack, string MultiSelect)
        {
            string strJs = string.Empty;
            ViewData["ReturnCtrl"] = ReturnCtrl;
            if (!string.IsNullOrEmpty(ReturnCtrl))
            {
                strJs += "window.parent[0].$('#" + ReturnCtrl + "').val(retVal);";
            }
            if (!string.IsNullOrEmpty(CallBack))
            {
                strJs += "window.parent[0]." + CallBack;
            }

            ViewData["JS"] = strJs;
            return View();
        }//end of func

        /// <summary>
        /// 客户联系人选择器的view
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ClientContractSelector()
        {
            return View();
        }//end of func


        /// <summary>
        /// 仪器选择器的view
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult InstrumentSelector(string ReturnCtrl, string CallBack, string MultiSelect, string Type)
        {

            var instrumentBo = new InstrumentBaseInfoBO();
            string strJs = string.Empty;
            ViewData["InstrumentJavaScript"] = string.Empty;
            ViewData["InitInstrument"] = 1;
            ViewData["GroupJavaScript"] = instrumentBo.ConvertToJavaScriptArray(instrumentBo.GetDescendantChildrenGroups(0), "");
            ViewData["GroupJavaScript"] = "[{ id:0, pId:0, name:'实验仪器',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}]";
            /*if (Type.Equals("1"))//用户
            {
                List<long> lstTmp = new List<long>();
                lstTmp.Add(50);
                ViewData["GroupJavaScript"] = instrumentBo.ConvertToJavaScriptArray(instrumentBo.GetSelfAndDescendantChildrenGroups(lstTmp), "");
                ViewData["InitGroupID"] = 50;
            }
            else if (Type.Equals("2")) // 组织机构
            {
                List<long> lstTmp = new List<long>();
                lstTmp.Add(51);
                ViewData["GroupJavaScript"] = instrumentBo.ConvertToJavaScriptArray(instrumentBo.GetSelfAndDescendantChildrenGroups(lstTmp), "");
                ViewData["InitGroupID"] = 51;
            }
            else
            {
                ViewData["GroupJavaScript"] = instrumentBo.ConvertToJavaScriptArray(instrumentBo.GetDescendantChildrenGroups(1), "");
            }*/
            ViewData["ReturnCtrl"] = ReturnCtrl;
            if (!string.IsNullOrEmpty(ReturnCtrl))
            {
                strJs += "window.parent[0].$('#" + ReturnCtrl + "').val(retVal);";
            }
            if (!string.IsNullOrEmpty(CallBack))
            {
                strJs += "window.parent[0]." + CallBack;
            }

            ViewData["JS"] = strJs;

            return View();
        }//end of func

        /// <summary>
        /// 用户选择器使用的默认接口，可以传入treeid，刷新数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JsonResult GetUserDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;


            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                string strGroupID = index.EntityName.ToString();
                int intGroupID = int.Parse(strGroupID);

                List<UserContent> lstFinal = new List<UserContent>();
                UsersBO userBO = new UsersBO();
                GroupsBO groupBO = new GroupsBO();
                var currentGroup = groupBO.GetInstancesByGroupID(intGroupID) as GroupsMD;


                if (currentGroup.GroupID > 0 && currentGroup.TypeID == 2)//普通用户组
                {
                    List<UsersMD> lstAns = userBO.GetInstancesByGroupID(intGroupID);
                    foreach (UsersMD obj in lstAns)
                    {
                        var newObj = new UserContent
                        {
                            MyID = (int)obj.UserID,
                            MyName = obj.FullName,
                            MyTypeName = "用户",
                            MyType =1
                        };
                        lstFinal.Add(newObj);
                    }
                }
                else if (currentGroup.GroupID > 0 && currentGroup.TypeID == 6)//组织机构
                {
                    List<GroupsMD> lstAns = groupBO.GetChildrenGroups(intGroupID);
                    foreach (GroupsMD obj in lstAns)
                    {
                        var newObj = new UserContent
                        {
                            MyID = (int)obj.GroupID,
                            MyName = obj.MyName,
                            MyTypeName = "组织机构",
                            MyType = 6
                        };
                        lstFinal.Add(newObj);
                    }
                }

                var lstCurPageData = lstFinal.Skip(indexStart).
                   Take(index.PageSize);
                index.TotalCount = lstFinal.Count();
                return Json(new { IndexInfo = index, Data = lstCurPageData.ToList() });
            }
        }//end of func
         
        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JsonResult SearchUserDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;

            //存进来的数据是 GroupID,UserName
            System.Web.Script.Serialization.JavaScriptSerializer toObject = new System.Web.Script.Serialization.JavaScriptSerializer();
            UserQuery query = toObject.Deserialize<UserQuery>(index.EntityName.ToString());

            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                string strGroupID = query.GroupID;
                long intGroupID = long.Parse(strGroupID);
                List<long> lstGroupID = new List<long>();
                lstGroupID.Add(intGroupID);

                List<UserContent> lstFinal = new List<UserContent>();
                UsersBO userBO = new UsersBO();
                GroupsBO groupBO = new GroupsBO();
                var currentGroup = groupBO.GetInstancesByGroupID(intGroupID) as GroupsMD;

                if (currentGroup.GroupID > 0 && currentGroup.TypeID == 2)//普通用户组
                {
                    //List<UsersMD> lstAns = userBO.GetInstancesByGroupID(intGroupID);
                    List<UsersMD> lstAns = userBO.SearchDescendantUsers(intGroupID, query.UserName);

                    foreach (UsersMD obj in lstAns)
                    {
                        var newObj = new UserContent
                        {
                            MyID = (int)obj.UserID,
                            MyName = obj.FullName,
                            MyTypeName = "用户",
                            MyType = 1
                        };
                        lstFinal.Add(newObj);
                    }
                }
                else if (currentGroup.GroupID > 0 && currentGroup.TypeID == 6)//组织机构
                {                    
                    List<GroupsMD> lstAns = groupBO.GetSelfAndDescendantChildrenGroups(lstGroupID);                   
                    foreach (GroupsMD obj in lstAns)
                    {
                        if( obj.MyName.Contains(query.UserName) )
                        { 
                            var newObj = new UserContent
                            {
                                MyID = (int)obj.GroupID,
                                MyName = obj.MyName,
                                MyTypeName = "组织机构",
                                MyType = 6
                            };
                            lstFinal.Add(newObj);
                        }
                    }//end foreach
                }//end if

                var lstCurPageData = lstFinal.Skip(indexStart).
                   Take(index.PageSize);
                index.TotalCount = lstFinal.Count();
                return Json(new { IndexInfo = index, Data = lstCurPageData.ToList() });
            }
        }//end of func


        /// <summary>
        /// 客户选择器使用的默认接口，刷新数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JsonResult GetCustomerDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;


            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                //string strGroupID = index.EntityName.ToString();
                //int intGroupID = int.Parse(strGroupID);

                List<kczy_CustomerMD> lstFinal = new List<kczy_CustomerMD>();
                CustomerBO customerBO = new CustomerBO();

                lstFinal = customerBO.GetInstances();
                

                var lstCurPageData = lstFinal.Skip(indexStart).
                   Take(index.PageSize);
                index.TotalCount = lstFinal.Count();
                return Json(new { IndexInfo = index, Data = lstCurPageData.ToList() });
            }
        }//end of func
        /// <summary>
        /// 客户选择器使用的默认接口，刷新数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JsonResult GetInstrumentDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;      
            using (var db = new DataClassesKCZYSDataContext())
            {
/*                   if (!string.IsNullOrEmpty(index.EntityName))
                    {
                        var instrumentID = Convert.ToInt32(index.EntityName);
                        var q = from i in db.kczy_InstrumentBaseInfo
                            from p in db.kczy_InstrumentAppointment
                            where i.MyID == instrumentID && i.OrigID == p.OrigID
                            select p;
                        var lstCurPageData = q.Skip(indexStart).Take(index.PageSize);
                        index.TotalCount = q.Count();
                        
                        return Json(new { IndexInfo = index, Data = lstCurPageData.Select(i=>new
                        {
                            i.MyID,
                            i.MyName,
                            AppointType = i.AppointType==1?"上午":"下午",
                            AppointDate = i.AppointDate.ToShortDateString()
                        }).ToList() });
                    }*/

                var ibInfo = new InstrumentBaseInfoBO();
                if (index.EntityName == "0")
                {
                    var tmplist = ibInfo.GetInstances();
                    var data = tmplist.Skip(indexStart).Take(index.PageSize);
                    index.TotalCount = tmplist.Count();
                    return Json(new { IndexInfo = index, Data = data });
                }               
            }
            return Json(new {IndexInfo = index});
        }//end of func
        /// <summary>
        /// 生成树形菜单
        /// </summary>
        /// <param name="lstAns"></param>
        /// <param name="strStates"></param>
        /// <returns></returns>
        private string ConvertToJavaScriptArray(List<GroupsMD> lstAns, string strStates)
        {
            var strAns = string.Empty;

            List<string> lstOpenGroupIDs = new List<string>();
            if (!string.IsNullOrEmpty(strStates))
                lstOpenGroupIDs = strStates.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            GroupsBO gInfo = new GroupsBO();
            Dictionary<int, bool> dct = gInfo.GroupHasItems(lstAns);
            //看哪个group下已没有group
            //var linq = lstAns.Select(x => x.GroupID).Except(lstAns.Select(x => Gro );
            var linq = (from a in lstAns
                        select a.GroupID).Except(from b in lstAns
                                                 select (long)b.ParentGroupID).ToList();

            if (lstAns.Count > 0)
            {
                strAns = "[";
                foreach (var obj in lstAns)
                {
                    if (obj != null && obj.GroupID > 0 && !string.IsNullOrEmpty(obj.MyName))
                    {
                        if (lstOpenGroupIDs.Contains(obj.GroupID.ToString()))
                        {
                            if (!linq.Contains(obj.GroupID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }
                        else
                        {
                            if (!linq.Contains(obj.GroupID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }

                    }//end of if
                }
                if (strAns[strAns.Length - 1] == ',')
                    strAns = strAns.Substring(0, strAns.Length - 1);
                strAns += "]";
            }
            return strAns;
        }//end of func

    }//end of class

    [Serializable]
    class UserContent
    {
        public int MyID
        {
            get;
            set;
        }
        public string MyName
        {
            get;
            set;
        }
        public int MyType
        { get; set; }
        public string MyTypeName
        {
            get;
            set;
        }
        public UserContent()
        {

        }

    }//end of class

    [Serializable]
    class UserQuery
    {
        public string UserName { get; set; }
        public string GroupID { get; set; }
    }

}
