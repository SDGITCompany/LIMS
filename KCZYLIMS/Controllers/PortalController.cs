using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KCZYLIMS.Models;
using KCZYLIMS.BLL;
using SqlDataAccess;
using XMain.Code;
using System.IO;

namespace KCZYLIMS.Controllers
{
    public class PortalController : Controller
    {
        //
        // GET: /Portal/
        [Authorize]  
        public ActionResult Index()        
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( KCZYLIMS.Models.UsersMD model )
        {
            string strReturnUrl = string.Empty;
            if (model.LoginName.Equals("logout"))
            {
                FormsAuthentication.SignOut();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                strReturnUrl = Request.QueryString["ReturnUrl"];
            }

            UsersMD curUser = UsersBO.GetInstanceByLoginName(model.LoginName);
            //.XSecurity

            if (curUser != null &&
                curUser.PassWord.Equals(XMain.Code.XSecurity.EncodePassword(model.LoginName, model.PassWord)))
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, false);
                if (!string.IsNullOrEmpty(strReturnUrl))
                    return Redirect(strReturnUrl);
                else
                    return RedirectToAction("Index", "Portal");
            }
            else
            {
                ViewData["message"] = "您输入的密码或账号不正确!";
            }
            
            
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
        [Authorize]
        public ActionResult ProcessMineralogy()
        {
            using (DataClassesKCZYSDataContext db=new DataClassesKCZYSDataContext())
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
                            MyID = obj.OrigID,
                            MyName = obj.MyName,
                            MyCode = obj.MyCode,
                            Principal = obj.Principal,
                            Client = obj.Client
                        });
                }
           
           

            ViewData["ProjectAttorney"] = lstProjectAttorneys; }
            return View();
        }
        [Authorize]  
        public ActionResult ChemicalPhaseAnalysis()
        {
            return View();
        }
        [Authorize]
        public ActionResult WeekReport()
        {
            return View();
        }
        [Authorize]  
        public ActionResult PhysicalDetection()
        {
            return View();
        }
        [Authorize]  
        public ActionResult InstrumentManagement()
        {
            return View();
        }
        [Authorize]  
        public ActionResult ProjectSearch()
        {
            var currentUser = UsersBO.GetCurrentUser();
            int key = 0;
            string word = "gykwx";
            using (var db = new DataClassesKCZYSDataContext())
            {
                var q =
                    from code in db.SystemCode
                    where code.CodeType == word orderby code.Order
                    select new SelectListItem{
                        Text = code.MyName,
                        Value = code.Order.ToString()
                    };
                ViewData["dpMyType"] = q.ToList();
            }
            return View(currentUser);
        }
        [Authorize]
        public ActionResult YiBiaoPan()
        {
            var currentUser = UsersBO.GetCurrentUser();
            return View(currentUser);
        }

       

        /// <summary>
        /// 下载功能
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public FileResult DownloadPage(int AttachID,string OrigPath,string FileName)
        {
            AttachmentBO attBO = new AttachmentBO();
            AttachmentMD attMD = new AttachmentMD();
            string strDownloadFileName = FileName;
            byte[] fileContent = null;
            if (AttachID > 0 && !string.IsNullOrEmpty(strDownloadFileName))
            {
                attMD.AttachID = AttachID;
                fileContent = attBO.GetFileContent(AttachID, attMD);
                
            }
            else if( !string.IsNullOrEmpty(strDownloadFileName) )
            {
                FileStream fs = new FileStream(OrigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                fileContent = new byte[(int)fs.Length];
                fs.Read(fileContent, 0, fileContent.Length);
                fs.Dispose();
            }

            if (fileContent != null && fileContent.Length > 0)
            {
                return File(fileContent, "application/octet-stream",  strDownloadFileName );
            }
            else
                return null;

        }
        public FileResult ExportExcelPage(string path)
        {
            byte[] fileContent = null;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fileContent = new byte[(int)fs.Length];
            fs.Read(fileContent, 0, fileContent.Length);
            fs.Dispose();
            if (fileContent != null && fileContent.Length > 0)
            {
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "分析测试委托单");
            }
            else
            {
                return null;
            }
            

        }
        public JsonResult TestHero()
        {
            var item = new ItemInfo(23);
            var rst = item.HasOperateRight(123, CodeFileWY.GetCurrentUser());
            return Json(rst);
            

        }

    }
}
