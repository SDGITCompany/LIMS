using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
using XMain.Code;

namespace KCZYLIMS.Controllers
{
    public class ReporterController : Controller
    {
        // 
        // GET: /Reporter/

        public ActionResult Index(int myID)
        {
            var model = new kczy_WeekReportMD();
            model.MyID = myID;
            if (model.MyID == 0)
            {
                //新建部分
                var user = UsersBO.GetCurrentUser();
                model.CreateBy = user.FullName;
                model.CreatorID = (int) user.UserID;
                model.CreateDate = DateTime.Now;
                model.LastModified = model.CreateDate;
                model.ModifierID = model.CreatorID;
                model.ModifiedBy = model.CreateBy;
                model.WeekNum = WeekOfYear(DateTime.Now);
                model.WeekYear = DateTime.Now.Year;
            }
            else
            {
                //更新部分
                model.GetInstance<kczy_WeekReport, kczy_WeekReportMD>(model);
            }

            return View(model);
        }

        public ActionResult WeekReport()
        {
            return View();
        }
/*        public ActionResult Index()
        {
            return RedirectToAction("Error", "Shared");
        }*/
        public JsonResult CreateOrUpdate(kczy_WeekReportMD model)
        {
            model.LastModified = DateTime.Now;
            model.ModifiedBy = UsersBO.GetCurrentUser().FullName;
            if (model.MyID == 0)
            {
                model.CreateDate = model.LastModified;
                model.CreateBy = model.ModifiedBy;
                model.Insert<kczy_WeekReport, kczy_WeekReportMD>(model);
            }
            else
            {
                model.Update<kczy_WeekReport, kczy_WeekReportMD>(model);
            }
            return Json(new {Result = true});
        }

        public JsonResult GetSearchDataSet(IndexInfo index,int sYear,int sNum,int eYear,int eNum)
        {
            string sData = index.EntityName;
            List<kczy_WeekReport> data = null;
            var userKeys = sData.Split('#');
            if (userKeys.Length != 0)
            {
                var dic = new Dictionary<long, int>();
                foreach (string userKey in userKeys)
                {
                    
                    var tmpValues = userKey.Split('|');
                    if (tmpValues.Length == 3)
                    {
                        var tmpID = XConvert.ToInt64(tmpValues[0]);
                        var tmpType = XConvert.ToInt32(tmpValues[1]);
                        //var tmpName = tmpValues[3];
                        dic.Add(tmpID,tmpType);
                    }

                }
                DateTime startDateTime = DateTime.Now.AddDays(-100);
                DateTime endDateTime = DateTime.Now;
                data = KCZYWeekReportBO.GetOtherUsersDataList(dic, sYear,sNum,eYear,eNum,index);


                //var wpList = new List<kczy_WeekReportMD>();


            }

            return Json(new { Result = true, Data = data,Index =index });
        }
        ///

        /// 计算某年第一周的天数

        ///

        /// 某年中的一个时间

        ///

        public static int DaysInFirstweekInYear(DateTime dt)
        {

            DateTime FirstDate = Convert.ToDateTime(string.Format("{0}-1-1", dt.Year));

            int DayOfWeekInYear = DayOfWeek(FirstDate);

            int DaysInFirstWeek = 8 - DayOfWeekInYear;

            return DaysInFirstWeek;

        }

        ///

        /// 一年中的第几周

        ///

        ///

        ///

        public static int WeekOfYear(DateTime dt)
        {

            int days = DaysInFirstweekInYear(dt);

            int dayofyear = dt.DayOfYear;

            if (dayofyear < days) return 1;

            else
            {

                int week2 = (int)Math.Ceiling((double)(dayofyear - days) / (double)7);

                return week2 + 1;

            }

        }
        ///

        /// 计算星期几，转换为数字

        ///

        /// 某天的日期

        ///

        public static int DayOfWeek(DateTime dt)
        {

            string strDayOfWeek = dt.DayOfWeek.ToString().ToLower();

            int intDayOfWeek = 0;

            switch (strDayOfWeek)
            {

                case "monday":

                    intDayOfWeek = 1;

                    break;

                case "tuesday":

                    intDayOfWeek = 2;

                    break;

                case "wednesday":

                    intDayOfWeek = 3;

                    break;

                case "thursday":

                    intDayOfWeek = 4;

                    break;

                case "friday":

                    intDayOfWeek = 5;

                    break;

                case "saturday":

                    intDayOfWeek = 6;

                    break;

                case "sunday":

                    intDayOfWeek = 7;

                    break;

            }

            return intDayOfWeek;

        }
        public JsonResult DeleteItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_WeekReport.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
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
    }
}
