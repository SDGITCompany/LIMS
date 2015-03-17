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
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CKW() {
            return View();
        }

        public ActionResult CKW2() {
            var tmp = System.Configuration.ConfigurationManager.AppSettings["Upload_Path"];
            return View();
        }

        public ActionResult PopWnd() {
            return View();
        }

        public JsonResult GetDataSet(IndexInfo index)
        {
            if (index.CurPage == 0)
            {
                index.CurPage = 1;
            }
            var indexStart = (index.CurPage-1)*index.PageSize;
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
            }
            
            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var projectAttorneys = (
                    from obj in db.kczy_ProjectAttorney
                    where obj.Specialty == val
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
                index.TotalCount = projectAttorneys.Count();
                return Json(new { IndexInfo=index , Data = projectAttorneys.ToList() });
            }
        }
        /// <summary>
        /// 条件搜索处理结构
        /// </summary>
        /// <param name="model">对应条件实体</param>
        /// <param name="index">wygrid页码参数</param>
        /// <returns>json结果</returns>
        public JsonResult AjaxHighSearch(kczy_ProjectAttorneyMD model,IndexInfo index)
        {
            var list =  ProjectAttorneyBO.GetAllProjectAttorneyMD();
            var entityList = new List<EntityMD>(list);
            var rslist = EntityMD.EntitySearch(model, entityList);
            index = new IndexInfo
            {
                CurPage = 1, 
                TotalCount = rslist.Count
            };
            return Json(new { IndexInfo = index, Data = rslist.ToList() });
        }
        public ActionResult TestAjaxGridData(kczy_ProjectAttorneyMD model)
        {
            using (DataClassesKCZYSDataContext db = new DataClassesKCZYSDataContext())
            {
                var projectAttorneys = from obj in db.kczy_ProjectAttorney
                                       orderby obj.CreateDate descending
                                       select obj;
                List<kczy_ProjectAttorneyMD> lstProjectAttorneys = new List<kczy_ProjectAttorneyMD>();
                foreach (var obj in projectAttorneys)
                {
                    lstProjectAttorneys.Add(
                        new kczy_ProjectAttorneyMD
                        {
                            MyID = obj.MyID,
                            MyName = obj.MyName,
                            MyCode = obj.MyCode,
                            Principal = obj.Principal,
                            Client = obj.Client
                        });
                }
            }
            return View(model);
        }
        [HttpPost]
        [MultiButton("action1")]
        public ActionResult Action1()
        {
            //
            return View();
        }
        [HttpPost]
        [MultiButton("action2")]
        public ActionResult Action2()
        {
            //
            return View();
        }

        public JsonResult TestGroupRight()
        {
            UserInfo user = CodeFileWY.GetCurrentUser();
            var rst = XMain.Code.CodeFileWL.SpecialRoleHasRight("50", "0", "1", "-2", user, true);
            return Json(rst);
        }


        public JsonResult TestForm(int FormID)
        {
            Random rnd = new Random(1000000);
            Dictionary<string, string> dctValue = new Dictionary<string, string>();
            if (FormID == 1)
            {                
                dctValue.Add("f1", rnd.Next().ToString());
                dctValue.Add("f2", rnd.Next().ToString());
                dctValue.Add("f3", rnd.Next().ToString());
                dctValue.Add("f4", rnd.Next().ToString());
                dctValue.Add("f5", rnd.Next().ToString());
                dctValue.Add("f6", rnd.Next().ToString());
                dctValue.Add("f7", rnd.Next().ToString());
                dctValue.Add("f8", rnd.Next().ToString());
                dctValue.Add("f9", rnd.Next().ToString());
                dctValue.Add("f10", rnd.Next().ToString());
            }
            else if (FormID == 2)
            {
                dctValue.Add("f1", rnd.Next().ToString());
            }


            return Json(new { Data=dctValue });
        }

    }


}
