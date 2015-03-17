using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.Models;

namespace KCZYLIMS.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddCustomerPage(int MyID)
        {
            CustomerBO customerBo = new CustomerBO();
            kczy_CustomerMD model = customerBo.GetCustomerMDByMyID(MyID);
            return View(model);
        }
    }
}
