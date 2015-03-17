using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Controllers;
using KCZYLIMS.Models;
using SqlDataAccess;
using XMain.Code;
using XMain.install;

namespace KCZYLIMS.BLL
{
    public class KCZYWeekReportBO
    {
        /// <summary>
        /// 获取个人周报
        /// </summary>
        /// <param name="index">分页参数</param>
        /// <returns></returns>
        public static List<kczy_WeekReport> GetDataList(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            using (var db = new DataClassesKCZYSDataContext())
            {
                var projectAttorneys = (
                    from obj in db.kczy_WeekReport
                    where obj.IsDeleted != true
                    orderby obj.CreateDate descending
                    select obj)
                    .Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = db.kczy_WeekReport.Count();
                return projectAttorneys.ToList();
            }
        }

        /// <summary>
        /// 获取根据时间和用户范围的用户周报
        /// </summary>
        /// <param name="dic">用户(userID,userType)</param>
        /// <param name="sYear">开始年</param>
        /// <param name="sNum">开始周</param>
        /// <param name="eYear">结束年</param>
        /// <param name="eNum">结束周</param>
        /// <param name="index">分页参数</param>
        /// <returns></returns>
        public static List<kczy_WeekReport> GetOtherUsersDataList(Dictionary<long, int> dic, int sYear, int sNum, int eYear, int eNum, IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage - 1) * index.PageSize;
            var userIDList = new List<long>();
            foreach (KeyValuePair<long, int> keyValuePair in dic)
            {
                if (keyValuePair.Value == 6)
                {
                    var organization = new Organization(keyValuePair.Key);
                    var list = organization.GetAllGroupSubItemsList();
                    var q = list.Select(i => i.ID);
                    userIDList.AddRange(q);
                }
                else if (keyValuePair.Value == 1)
                {
                    userIDList.Add(keyValuePair.Key);
                }
            }

            using (var db = new DataClassesKCZYSDataContext())
            {
                var projectAttorneys = (
                    from obj in db.kczy_WeekReport
                    /*where obj.IsDeleted != true && userIDList.Contains(obj.CreatorID) && CompairDatetime(obj.WeekYear, obj.WeekNum, sYear, sNum, eYear, eNum)*/
                    where obj.IsDeleted != true && userIDList.Contains(obj.CreatorID) 
                    
                    orderby obj.CreateDate descending
                    select obj);
                var data = projectAttorneys.ToList().Where(obj => CompairDatetime(obj.WeekYear, obj.WeekNum, sYear, sNum, eYear, eNum))
                    .Skip(indexStart).
                    Take(index.PageSize);
                index.TotalCount = projectAttorneys.Count();
                return data.ToList();
            }
        }

        /// <summary>
        /// 判断时间函数
        /// </summary>
        /// <param name="weekYear">年份</param>
        /// <param name="weekNum">第几周</param>
        /// <param name="sYear">开始年份</param>
        /// <param name="sNum">周数</param>
        /// <param name="eYear">结束年份</param>
        /// <param name="eNum">周数</param>
        /// <returns></returns>
        private static bool CompairDatetime(int weekYear, int weekNum, int sYear, int sNum, int eYear, int eNum)
        {
            var curWeekNum = weekYear * 100 + weekNum;
            var startWeekNum = sYear * 100 + sNum;
            var endWeekNum = eYear * 100 + eNum;
            if (curWeekNum >= startWeekNum && curWeekNum <= endWeekNum)
            {
                return true;
            }
            return false;
        }
    }
}