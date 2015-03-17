using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCZYLIMS.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveData(TmpModel md)
        {
            return Json(new { result = true });
        }


        public void TestXMain()
        {
            XMain.Code.ItemInfo item = new XMain.Code.ItemInfo(1);
        }

    }


    public class TmpModel
    {
        public string myname { get; set; }
        public string mysex { get; set; }
    }
}
