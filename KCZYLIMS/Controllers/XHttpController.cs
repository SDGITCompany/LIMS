using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlDataAccess;
using XMain.Code;

namespace KCZYLIMS.Controllers
{
    public class XHttpController : Controller
    {
        //
        // GET: /XHttp/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 读取查询字符串中的一个参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <returns>参数值</returns>
        public JsonResult LoadUrlQueryParam(string name, string code)
        {
            string strNameParam = "";
            string strCodeParam = "";
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    //字符串加密
                    string strNameEncode = XSecurity.DecodeUrlParam(name);
                    string strCodeEncode = XSecurity.DecodeUrlParam(code);
                    strNameParam = strNameEncode;
                    strCodeParam = strCodeEncode;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //  释放资源
            }

            return Json(new { Result = true, Name = strNameParam, Code = strCodeParam });
        }
        public JsonResult LoadDateQueryParam(string date, string name)
        {
            string strNameParam = "";
            string strCodeParam = "";
            try
            {
            DateTime startDate = DateTime.Parse(date);
            if (startDate < DateTime.Now)
            {
                startDate = DateTime.Now.Date;
            }
            DateTime endDate = startDate.AddDays(7);
            using (var db = new DataClassesKCZYSDataContext())
            {
                var rst = new List<kczy_InstrumentAppointment>();
                for (int ii = 0; ii < 7; ii++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        var tmp = new kczy_InstrumentAppointment();
                        tmp.CreateDate = startDate.AddDays(ii);
                        tmp.AppointType = j;
                        var q =
                            db.kczy_InstrumentAppointment.Where(
                                i =>
                                    i.MyName == name && i.AppointDate >= tmp.CreateDate &&
                                    i.AppointDate < tmp.CreateDate.AddDays(1)&&i.AppointType==j);
                        if (q.Any())
                        {
                            //记录是否已经预定
                            tmp.Isdeleted = false;
                        }
                        else
                        {
                            tmp.Isdeleted = true;
                        }
                        rst.Add(tmp);
                    }
                }
                return Json(new { Result = true, Data = rst.Select(r=>new{Date =r.CreateDate.ToShortDateString(),Type =r.AppointType,NotCheck =r.Isdeleted}) });
            }


            }
            catch (Exception ex)
            {
                return Json(new { Result = false,Error=ex });
            }
        }
        public JsonResult SetUrlQueryParam(string name,string code)
        {
            string strNameParam = "";
            string strCodeParam = "";
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    //字符串加密
                    string strNameEncode = HttpUtility.UrlEncode(XSecurity.EncodeUrlParam(name));
                    string strCodeEncode = HttpUtility.UrlEncode(XSecurity.EncodeUrlParam(code));
                    strNameParam = strNameEncode;
                    strCodeParam = strCodeEncode;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //  释放资源
            }

            return Json(new { Result = true, Name = strNameParam, Code = strCodeParam });
        }
    }
}
