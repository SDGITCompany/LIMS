using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCZYLIMS.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/

        public ActionResult _Layout()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
