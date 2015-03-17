using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using KCZYLIMS.BLL;
using KCZYLIMS.Models;
using Newtonsoft.Json;
using SqlDataAccess;
using XMain.Controls;

namespace KCZYLIMS.Controllers
{
    public class InstrumentManagementController : Controller
    {
        //
        // GET: /InstrumentManagement/
        [Authorize]
        public ActionResult Index(int itemID)
        {
                        InstrumentBaseInfoBO obj = new InstrumentBaseInfoBO();
                        kczy_InstrumentBaseInfoMD model = obj.GetInstrumentByItemID(++itemID);
                        return View(model);
        }
        public ActionResult InstrumentAppointmentLists()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddAppointmentPage(int itemID)
        {
            InstrumentAppointmentBO obj = new InstrumentAppointmentBO();
            kczy_InstrumentAppointmentMD model = obj.GetInstrumentByItemID(itemID);
            return View(model);
        }
        [Authorize]
        public ActionResult InstrumentUsageRecordLists()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddUsagePage(int itemID)
        {
            InstrumentUsageBO obj = new InstrumentUsageBO();
            kczy_InstrumentUsageMD model = obj.GetInstrumentByMyID(itemID);
            return View(model);
        }
        public ActionResult InstrumentServiceLists()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddServicePage(int itemID)
        {
            InstrumentServiceBO obj = new InstrumentServiceBO();
            kczy_InstrumentServiceMD model = obj.GetInstrumentByItemID(itemID);
            return View(model);
        }
        public ActionResult InstrumentResourcesDisplay()
        {
            return View();
        }

        public string GetJsonResult(object data)
        {
/*            var meetingItemList =new List<MeetingItem>();
            var item = new MeetingItem();
            item.MeetingID = 123;
            item.RoomID = 1;
            item.Attendees = new[] {1, 2, 3};
            item.Title = "测试";
            item.Description = "描述";
            item.Start = new DateTime(2011,6,11);
            item.End = new DateTime(2011, 6, 11);
            item.IsAllDay = true;
            meetingItemList.Add(item);
            var ser = new JavaScriptSerializer();
            string json = ser.Serialize(meetingItemList);*/

            string json =
                @"{""MeetingID"":39,""RoomID"":null,""Attendees"":[1,2,3],""Title"":""No title"",""Description"":"""",""StartTimezone"":"""",""Start"":""\/Date(1370908800000)\/"",""End"":""\/Date(1370995200000)\/"",""EndTimezone"":"""",""RecurrenceRule"":"""",""RecurrenceID"":null,""RecurrenceException"":"""",""IsAllDay"":false}";
            return "callback(["+json+"])";
        }
    }

/*    public class MeetingItem
    {
        public int MeetingID { set; get; }
        public int RoomID { set; get; }
        public int[] Attendees { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string StartTimezone { set; get; }
        public DateTime Start { set; get; }
        public DateTime End { set; get; }
        public string EndTimezone { set; get; }
        public string RecurrenceRule { set; get; }
        public string RecurrenceException { set; get; }
        public bool IsAllDay { set; get; }



    }*/
}
