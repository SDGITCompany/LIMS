using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SqlDataAccess;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using XData;
using XMain.Code;

namespace KCZYLIMS.Controllers
{
    public class PortalAPIController : Controller
    {
        //
        // GET: /PortalAPI/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            int val = 0;
            switch (index.EntityName)
            {
                case "1":
                    val = 1;
                    break;
                case "2":
                    val = 2;
                    break;
                case "3":
                    val = 3;
                    break;
                case "5":
                    //工作周报
                    var dataList = KCZYWeekReportBO.GetDataList(index);
                    var user = UsersBO.GetCurrentUser();
                    long userID = user != null ? user.UserID : 0;
                    var data = dataList.Where(d => d.CreatorID == userID).Select(obj => new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.WeekYear,
                        obj.WeekNum,
                        obj.ModifiedBy,
                        LastModified = obj.LastModified.ToString("yyyy-M-d dddd h:m:s")
                    });
                    return Json(new { IndexInfo = index, Data = data});
            }
            var currentUser = CodeFileWY.GetCurrentUser();

            using (var db = new DataClassesKCZYSDataContext())
            {

/*                var projectAttorneys = (
                    from obj in db.kczy_ProjectAttorney
                    where obj.Specialty == val && obj.IsDeleted != true
                    orderby obj.CreateDate descending
                    select new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.Principal,
                        obj.Client,
                        obj.OrigID
                    })
                    .Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = db.kczy_ProjectAttorney.Count(o => o.Specialty == val);
                return Json(new { IndexInfo = index, Data = projectAttorneys.ToList() });*/

                var projectAttorneys =
                    from obj in db.kczy_ProjectAttorney
                    where obj.Specialty == val && obj.IsDeleted != true
                    orderby obj.CreateDate descending
                    select obj;
                var q = new List<kczy_ProjectAttorney>();
                if (projectAttorneys != null)
                {
                    foreach (var projectAttorney in projectAttorneys)
                    {
                        if (CodeFileWL.CanShowItem(projectAttorney.OrigID.ToString(), "6", "6", currentUser))
                        {
                            q.Add(projectAttorney);
                        }
                    }
                }
                var data = q.Select(obj => new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.Principal,
                        obj.Client,
                        obj.OrigID
                    }).Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = q.Count();
                return Json(new { IndexInfo = index, Data = data.ToList() });

                
            }
        }
        public JsonResult GetInstrumentDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;

            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var instrument = (
                    from obj in db.kczy_InstrumentBaseInfo
                    where obj.IsDeleted!=true
                    orderby obj.MyID descending
                    select new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.OrigID
                    })

                    .Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = instrument.Count();
                return Json(new { IndexInfo = index, Data = instrument.ToList() });
            }
        }


        /////////////////////////////////////////
        //任务中心用的
        public JsonResult TaskCenterAPI(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;

            string strType = index.EntityName.ToString();
            UsersMD user= UsersBO.GetCurrentUser();
            ItemApprovalBO itemAppBo = new ItemApprovalBO();
            List<UserCenterMD> lstAns = itemAppBo.GetUserCenter(user, strType);

            var lstCurPageData = lstAns.Skip(indexStart).
                Take(index.PageSize);
            index.TotalCount = lstAns.Count();
            return Json(new { IndexInfo = index, Data = lstCurPageData.ToList()});
        }//end of func
        //通知用户代办任务的数量
        public JsonResult NoticeCount()
        {
            var rst = false;
            string strType = "current";
            UsersMD user = UsersBO.GetCurrentUser();
            ItemApprovalBO itemAppBo = new ItemApprovalBO();
            List<UserCenterMD> lstAns = itemAppBo.GetUserCenter(user, strType);
            if (lstAns != null && lstAns.Count() >= 0)
            {
                rst = true;
            }
            return Json(new { Result = rst, Count = lstAns.Count() });
        }//end of func
        //通知用户代办任务的数量
        public JsonResult ChangePassWord(ChangeUsersMD model)
        {
            var rst = false;
            string error = "";
            var user = UsersBO.GetCurrentUser() ;

            var confirmOldpassword = XSecurity.EncodePassword(user.LoginName, model.ConfirmOldPassword.Trim());
            if (confirmOldpassword == user.PassWord)
            {
               
                if (model.NewPassword == model.ConfirmPassword)
                {
                    if (model.NewPassword.Count() < 6)
                    {
                        error = "密码位数必须大于6位！";
                    }
                    else
                    {
                        using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                        {
                            var objUser = dc.Users.FirstOrDefault(x => x.UserID == user.UserID);
                            if (objUser != null)
                            {
                                var newPswd = XSecurity.EncodePassword(user.LoginName, model.NewPassword.Trim());
                                objUser.PassWord = newPswd;
                                dc.SubmitChanges();
                                rst = true;
                            }
                        }
                    }

                }
                else
                {
                    error = "新密码和确认密码不匹配。";
                }
            }
            else
            {
                error = "您输入的旧密码不正确。";
            }
             

            return Json(new { Result = rst, Error= error });
        }//end of func
        public JsonResult GetMyTypeDropDownList(int key)
        {
            string word = "";
            string rst = "";
            switch (key)
            {
                case 1:
                    word = "gykwx";break;
                case 2:
                    word = "hxwx";break;
                case 3:
                    word = "wljc"; break;
            }
            if (word=="")
            {
                return Json(rst);
            }
            else
            {
                using (var db = new DataClassesKCZYSDataContext())
                {
                var q = 
                        from code in db.SystemCode
                        where code.CodeType == word orderby code.Order
                        select code;
                
                foreach (var systemCode in q)
                {
                    rst += "<option value=" + systemCode.Order + ">" + systemCode.MyName + "</option>";
                }
                return Json(rst);
                }
            }
        }
        /// <summary>
        /// 条件搜索处理结构
        /// </summary>
        /// <param name="model">对应条件实体</param>
        /// <param name="index">wygrid页码参数</param>
        /// <returns>json结果</returns>
        public JsonResult AjaxProjectSearch(kczy_ProjectAttorneyMD model, IndexInfo index)
        {
            var list = ProjectAttorneyBO.GetAllProjectAttorneyMD();
            var entityList = new List<EntityMD>(list);
            var rslist = EntityMD.EntitySearch(model, entityList);
            index = new IndexInfo
            {
                CurPage = 1,
                TotalCount = rslist.Count
            };
            return Json(new { IndexInfo = index, Data = rslist.ToList() });
        }

        public JsonResult ProjectSearchGetDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            using (var db = new DataClassesKCZYSDataContext())
            {
                var project = (
                    from obj in db.kczy_ProjectAttorney
                    where obj.IsDeleted != true 
                    orderby obj.MyID descending
                    select new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.Principal,
                        obj.Client
                    });
                var data = project
                    .Skip(indexStart)
                    .Take(index.PageSize);
                index.TotalCount = project.Count();
                return Json(new { IndexInfo = index, Data = data.ToList() });
            }
        }
        public JsonResult GetChartData(string key)
        {
            var list = new List<float>();
            //data: ['工艺矿物学'],
            if (key == "gykwx")
            {
                //data: ["项目委托", "项目策划", "实验过程", "项目审批" ]
                using (var dc = new DataClassesKCZYSDataContext())
                {
                    var wt = dc.kczy_ProjectAttorney.Count(a => a.Specialty == 1);
                    var ch = dc.kczy_ProjectPlan.Count();
                    var gc = dc.kczy_ExperimentsRecordBaseInfo.Count();
                    var sp = dc.kczy_ProjectApprove.Count();
                    list.Add(wt);
                    list.Add(ch);
                    list.Add(gc);
                    list.Add(sp);
                }//end of using   

            }
            //data: ['化学物相分析']
            else if (key == "hxwx")
            {
                //data: ["项目委托", "实验过程", "出分析报告"]
                using (var dc = new DataClassesKCZYSDataContext())
                {
                    var wt = dc.kczy_ProjectAttorney.Count(a => a.Specialty == 2);
                    var ch = dc.kczy_ExperimentRecords.Count(a => a.Specialty == 1);
                    var sp = dc.kczy_AnalysisReport.Count(a => a.Specialty == 1);
                    list.Add(wt);
                    list.Add(ch);
                    list.Add(sp);
                }//end of using   
            }
            //data: ['物理检测']
            else if (key == "wljc")
            {
                // data: ["项目委托", "实验过程", "登记收费"]
                using (var dc = new DataClassesKCZYSDataContext())
                {
                    var wt = dc.kczy_ProjectAttorney.Count(a => a.Specialty == 3);
                    var ch = dc.kczy_ExperimentRecords.Count(a => a.Specialty == 2);
                    var gc = dc.kczy_Registration.Count();
                    var sp = dc.kczy_AnalysisReport.Count(a => a.Specialty == 2);
                    list.Add(wt);
                    list.Add(ch);
                    list.Add(gc);
                    list.Add(sp);
                }//end of using   
            }
            //data: ['月度收入(万元)']
            else if (key == "income")
            {
                //data: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"],
                float[] data = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 59, 63 };
                list.AddRange(data);
            }
            return Json(new { Result = true, Data = list });
        }

        public JsonResult GetDepbyUserID(int userID)
        {
            var dep = "";
            var wljc = false;
            var gykwx = false;
            using (var db = new DataClassesKCZYSDataContext())
            {
                var controlist = from c in db.ControlLists
                    where c.ControlID == userID
                    select c;
                    db.ControlLists.FirstOrDefault(obj => obj.ControlID == userID && obj.RelatedType==0);
                if (controlist.Count()>0)
                {
                    foreach (var controlListse in controlist)
                    {
                        var group = db.Groups.FirstOrDefault(c => c.GroupID == controlListse.RelatedID);
                        if (group != null)
                        {
                            if (group.MyName.Contains("物理检测研究室"))
                            {
                               wljc = true;
                            }
                            if (group.MyName.Contains("矿产资源评价研究室"))
                            {
                                gykwx = true;
                            }
                        }
                    }
                    
                }
                
                return Json(new { wljcResult = wljc,gykwxResult=gykwx });
            }
        }
    }
}
