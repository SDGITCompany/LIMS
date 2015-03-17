using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
using XData.PublicAssetDAL;
using XMain.Code;

namespace KCZYLIMS.Controllers
{
    public class InstrumentManagementAPIController : Controller
    {
        //
        // GET: /InstrumentManagementAPI/

        public ActionResult Index()
        {
            return View();
        }//end of func
        /// <summary>
        /// 创建仪器管理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateInstrumentManagement(kczy_InstrumentBaseInfoMD model)
        {

            var sysInfo = new SystemSettingsBO();

            var groupID = Convert.ToInt64(sysInfo["KCZYS_InstrumentManagement"].Value1);
            var m4 = new Module4(groupID);
            var currentUser = UsersBO.GetCurrentUser();
            var origItemID = m4.CreateItem(model.MyName, currentUser);
            var m4Item = new Module4Items(origItemID);
            //m4Item.MainItem
            var subItem = m4Item.LstItem.FirstOrDefault(x => x.FormID == 45);
            //更新model的关联item
            var instrumentBase = new InstrumentBaseInfoBO();
            if (subItem != null)
            {
                model.OrigID = subItem.OrigID;
                model.ItemID = (int)subItem.ItemID;
            }
            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            instrumentBase.Insert<kczy_InstrumentBaseInfo, kczy_InstrumentBaseInfoMD>(model);
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult UpdateInstrumentManagement(kczy_InstrumentBaseInfoMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_InstrumentBaseInfo>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst,Data = model});
        }//end of func
        /// <summary>
        /// 创建仪器预约
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateInstrumentAppointment(kczy_InstrumentAppointmentMD model, string sitemid)
        {
            //查询数据库中是否有与该仪器相同的预约时间
            var instrumentBase = new InstrumentAppointmentBO();
            if (instrumentBase.IsAppointExisted(model.MyName, model.AppointDate, model.AppointType) == true)
            {
                return Json(new { Result = false ,Error=model.MyName+"这段时间已被预约，请您重新选择预约时间"});
            }

            int itemid = XConvert.ToInt32(sitemid);
            //更新model的关联item
            
                model.OrigID = itemid-2;
                model.ItemID = itemid;
                var currentUser = UsersBO.GetCurrentUser();
            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            instrumentBase.Insert<kczy_InstrumentAppointment, kczy_InstrumentAppointmentMD>(model);
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult UpdateInstrumentAppointment(kczy_InstrumentAppointmentMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_InstrumentAppointment>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        /// <summary>
        /// 创建仪器检修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateInstrumentService(kczy_InstrumentServiceMD model, string sitemid)
        {
            int itemid = XConvert.ToInt32(sitemid);
            //更新model的关联item
            var instrumentBase = new InstrumentServiceBO();
            model.OrigID = itemid - 4;
            model.ItemID = itemid;
            var currentUser = UsersBO.GetCurrentUser();
            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            instrumentBase.Insert<kczy_InstrumentService, kczy_InstrumentServiceMD>(model);
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult UpdateInstrumentService(kczy_InstrumentServiceMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_InstrumentService>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        /// <summary>
        /// 创建仪器检修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateInstrumentUsage(kczy_InstrumentUsageMD model, string sitemid)
        {
            int itemid = XConvert.ToInt32(sitemid);
            //更新model的关联item
            var instrumentBase = new InstrumentUsageBO();
            model.OrigID = itemid - 3;
            model.ItemID = itemid;
            var currentUser = UsersBO.GetCurrentUser();
            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            instrumentBase.Insert<kczy_InstrumentUsage, kczy_InstrumentUsageMD>(model);
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult UpdateInstrumentUsage(kczy_InstrumentUsageMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_InstrumentUsage>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        public JsonResult GetInstrumentAppointmentDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            int origid = XConvert.ToInt32(index.EntityName);
            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var instrument = (
                    from obj in db.kczy_InstrumentAppointment
                    where obj.OrigID == origid && obj.Isdeleted!=true
                    orderby obj.MyID descending
                    select new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.OrigID
                    });
                var data =instrument
                    .Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = instrument.Count();
                return Json(new { IndexInfo = index, Data = data.ToList() });
            }
        }
        public JsonResult GetInstrumentUsageDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            int origid = XConvert.ToInt32(index.EntityName);
            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var instrument = (
                    from obj in db.kczy_InstrumentUsage
                    where obj.OrigID == origid && obj.Isdeleted != true
                    orderby obj.MyID descending
                    select new
                    {
                        obj.MyID,
                        obj.ProjectName,
                       BeginTime= obj.BeginTime.ToShortDateString(),
                        EndTime = obj.EndTime.ToShortDateString(),
                        obj.Operater
                    });
                var data=instrument.Skip(indexStart).Take(index.PageSize);
                index.TotalCount = instrument.Count();
                return Json(new { IndexInfo = index, Data = data.ToList() });
            }
        }
        public JsonResult GetInstrumentServiceDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            int origid = XConvert.ToInt32(index.EntityName);
            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var instrument = (
                    from obj in db.kczy_InstrumentService
                    where obj.OrigID == origid && obj.Isdeleted != true
                    orderby obj.MyID descending
                    select new
                    {
                        obj.MyID,
                        obj.MyName,
                        obj.MyCode,
                        obj.Operater,
                        obj.Date,
                        obj.Result
                    });
                var data=instrument.Skip(indexStart).Take(index.PageSize);
                
                index.TotalCount = instrument.Count();
                return Json(new { IndexInfo = index, Data = data.ToList() });
            }
        }
        public JsonResult DeleteItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_InstrumentBaseInfo.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
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
        public JsonResult DeleteAppointmentItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_InstrumentAppointment.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
                    if (q != null)
                    {
                        q.Isdeleted = true;
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
        public JsonResult DeleteUsageItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_InstrumentUsage.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
                    if (q != null)
                    {
                        q.Isdeleted = true;
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
        public JsonResult DeleteServiceItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_InstrumentService.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
                    if (q != null)
                    {
                        q.Isdeleted = true;
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
    }

    public class TestMD    
    {        
        public string MyID { get; set; }
        public string MyName { get; set; }
    }
}
