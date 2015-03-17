using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.Models;

namespace KCZYLIMS.Controllers
{
    public class PhysicalDetectionController : Controller
    {
        //
        // GET: /PhysicalDetection/
        [Authorize]
        public ActionResult Index(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(++itemID);
            return View(model);

        }
        [Authorize]
        public ActionResult ProjectAttorneyForSuoInside(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult ProjectAttorneyForYuanInside(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult ProjectAttorneyForYuanOutside(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult ExperimentRecords(int itemID)
        {
            ExperimentRecordsBO experimentRecordsBO = new ExperimentRecordsBO();
            kczy_ExperimentRecordsMD model = experimentRecordsBO.GetExperimentRecordsMDByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult Registration(int itemID)
        {
            RegistrationBO registrationBO = new RegistrationBO();
            kczy_RegistrationMD model = registrationBO.GetRegistrationMDByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult AnalysisReport(int itemID)
        {
            AnalysisReportBO analysisReportBO = new AnalysisReportBO();
            kczy_AnalysisReportMD model = analysisReportBO.GetAnalysisReportMDByItemID(itemID);
            return View(model);
        }

    }
}
