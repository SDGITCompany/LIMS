using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class InstrumentAppointmentBO : EntityBO
    {
        public kczy_InstrumentAppointmentMD GetInstrumentByItemID(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_InstrumentAppointmentMD();
                var objDb = dc.kczy_InstrumentAppointment.FirstOrDefault(x => x.MyID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
        public kczy_InstrumentAppointmentMD GetInstrumentByRelatedID(int relatedID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_InstrumentAppointmentMD();
                var objDb = dc.kczy_InstrumentAppointment.FirstOrDefault(x => x.MyID == relatedID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
        public bool IsAppointExisted(string myName,DateTime appointDate,int appointType)
        {
            var rst = false;
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                
                var appoint = from obj in dc.kczy_InstrumentAppointment
                    where
                        obj.MyName == myName && obj.AppointDate == appointDate && obj.AppointType == appointType &&
                        obj.Isdeleted != true
                    select obj;
                if (appoint != null && appoint.Count() > 0)
                {
                    rst = true;
                }
                
            }//end of using   
            return rst;
        }//end of func
    }
}