using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.Controllers
{
    public class CustomerAPIController : Controller
    {
        //
        // GET: /CustomerAPI/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CreateCustomer(kczy_CustomerMD model)
        {
            
            var currentUser = UsersBO.GetCurrentUser();
            //更新model的关联item
            var customerBo = new CustomerBO();
            //更新model的创建者
            model.CreateBy = currentUser.FullName;
            model.CreateDate = DateTime.Now;
            model.CreatorID = (int)currentUser.UserID;
            model.ModifiedBy = currentUser.FullName;
            model.LastModified = model.CreateDate;
            model.ModifierID = (int)currentUser.UserID;
            customerBo.Insert<kczy_Customer, kczy_CustomerMD>(model);
            if (model.MyID > 0)
                return Json(new { Result = true, Data = model });
            else
                return Json(new { Result = false });

        }//end of func
        public JsonResult UpdateCustomer(kczy_CustomerMD model)
        {
            //更新修改者
            var currentUser = UsersBO.GetCurrentUser();
            model.LastModified = System.DateTime.Now;
            model.ModifiedBy = currentUser.FullName;
            model.ModifierID = (int)currentUser.UserID;

            var helper = new EntityHelper<kczy_Customer>();
            var rst = helper.UpdateMDInstance(model);
            return Json(new { Result = rst });
        }//end of func
        public JsonResult DeleteItems(string myIDs)
        {
            bool isSuccess = false;
            string[] myId = myIDs.Split(',');
            using (var db = new DataClassesKCZYSDataContext())
            {
                foreach (var currentID in myId)
                {
                    var q = db.kczy_Customer.FirstOrDefault(o => o.MyID == Convert.ToInt32(currentID));
                    if (q != null)
                    {
                        q.IsDeleted = true;
                    }
                }
                try
                {
                    db.SubmitChanges();
                    isSuccess = true;
                }
                catch (Exception)
                {
                    isSuccess = false;
                }
            }
            var rst = isSuccess;
            return Json(new { Result = rst });


        }//end of func
    }
}
