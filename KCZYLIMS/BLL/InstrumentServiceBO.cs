using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class InstrumentServiceBO : EntityBO
    {
        public kczy_InstrumentServiceMD GetInstrumentByItemID(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_InstrumentServiceMD();
                var objDb = dc.kczy_InstrumentService.FirstOrDefault(x => x.MyID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
    }
}