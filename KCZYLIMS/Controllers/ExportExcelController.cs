using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.ExtendedProperties;
using KCZYLIMS.BLL;
using KCZYLIMS.Models;
using SqlDataAccess;
using XMain.Code;
using OpenXmlHelper = KCZYLIMS.BLL.Utility.OpenXmlHelper;

namespace KCZYLIMS.Controllers
{
    public class ExportExcelController : Controller
    {
        //
        // GET: /ExportExcel/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ProjectAttorney(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();

            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);

           string path= OpenXmlHelper.ProjectAttorney(model);

            if (path == "")
            {
                return Json(new { Result = false});
            }
            else
            {
                return Json(new { Result = true,Path=path });
            }

           
        }
    }
}
