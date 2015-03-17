using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.Models;

namespace KCZYLIMS.Controllers
{
    /// <summary>
    /// 化学物象分析Controller
    /// </summary>
    public class ChemicalPhaseAnalysisController : Controller
    {
        //
        // GET: /ChemicalPhaseAnalysis/
        [Authorize]
        public ActionResult Index(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(++itemID);
            return View(model);
            
        }
        /// <summary>
        /// 所内委托单
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
         [Authorize]
        public ActionResult ProjectAttorneyForSuo(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        /// 院外委托单
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectAttorneyinternalPage(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        /// 院内委托单
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectAttorneyForYuanInside(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        public ActionResult ExperimentRecords(int itemID)
        {
            ExperimentRecordsBO experimentRecordsBO = new ExperimentRecordsBO();
            kczy_ExperimentRecordsMD model = experimentRecordsBO.GetExperimentRecordsMDByItemID(itemID);
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
