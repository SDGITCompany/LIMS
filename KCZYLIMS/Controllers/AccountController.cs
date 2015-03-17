using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;


namespace KCZYLIMS.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Manage()
        {
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }
        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Portal");
        }
       

        
    }
}
