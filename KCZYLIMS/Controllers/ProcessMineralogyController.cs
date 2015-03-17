using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.Models;
using KCZYLIMS.BLL;

namespace KCZYLIMS.Controllers
{
    /// <summary>
    /// 工艺矿物学Controller
    /// </summary>
    public class ProcessMineralogyController : Controller
    {
        //
        // GET: /ProcessMineralogy/
        [Authorize]
        public ActionResult Index(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(++itemID);
            return View(model);
        }

        /// <summary>
        /// 所内的委托单
        /// </summary>
        /// <param name="id">子ItemID</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult ProjectAttorneyForSuo(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        /// 院外委托单
        /// </summary>
        /// <param name="id">子ItemID</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectAttorneyForYuanOutside(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        /// 院内的委托单
        /// </summary>
        /// <param name="id">子ItemID</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectAttorneyinternalPage(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        ///岩矿鉴定的委托单
        /// </summary>
        /// <param name="id">子ItemID</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectAttorneyForOre(int itemID)
        {
            ProjectAttorneyBO projectAttorneyBO = new ProjectAttorneyBO();
            kczy_ProjectAttorneyMD model = projectAttorneyBO.GetProjectAttorneyMDByItemID(itemID);
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ProjectPlan(int itemID)
        {
            ProjectPlanBaseInfoBo projectPlanBaseInfoBO = new ProjectPlanBaseInfoBo();
            kczy_ProjectPlanBaseInfoMD model = projectPlanBaseInfoBO.GetProjectPlanBaseInfoByItemID(itemID);
            return View(model);
        }
        public ActionResult PhaseAnalysis(int itemID,int type)
        {
            ExperimentStatusBaseInfoBO experimentStatusBaseInfoBO = new ExperimentStatusBaseInfoBO();
            kczy_ExperimentStatusBaseInfoMD model = experimentStatusBaseInfoBO.GetExperimentStatusBaseInfoMDByItemID(itemID,type);
            return View(model);
        }
        public ActionResult ChemicalPhaseAnalysis(int itemID, int type)
        {
            ExperimentStatusBaseInfoBO experimentStatusBaseInfoBO = new ExperimentStatusBaseInfoBO();
            kczy_ExperimentStatusBaseInfoMD model = experimentStatusBaseInfoBO.GetExperimentStatusBaseInfoMDByItemID(itemID, type);
            return View(model);
        }
        public ActionResult Characteristic(int itemID, int type)
        {
            ExperimentStatusBaseInfoBO experimentStatusBaseInfoBO = new ExperimentStatusBaseInfoBO();
            kczy_ExperimentStatusBaseInfoMD model = experimentStatusBaseInfoBO.GetExperimentStatusBaseInfoMDByItemID(itemID, type);
            return View(model);
        }
        public ActionResult ExperimentsRecord(int itemID)
        {
            KCZYExperimentsRecordBaseInfoBO experimentsRecordBaseInfoBO = new KCZYExperimentsRecordBaseInfoBO();
            kczy_ExperimentsRecordBaseInfoMD model = experimentsRecordBaseInfoBO.GetExperimentRecordBaseInfoMDByItemID(itemID);
            return View(model);
        }
        public ActionResult ProjectApproval(int itemID)
        {
            KCZYProjectApproveBO projectApproveBo = new KCZYProjectApproveBO();
            kczy_ProjectApproveMD model = projectApproveBo.GetProjectApprovalMDByItemID(itemID);
            return View(model);
        }

        
    }
}
