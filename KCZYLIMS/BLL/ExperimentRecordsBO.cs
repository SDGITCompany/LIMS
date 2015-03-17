using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class ExperimentRecordsBO : EntityBO
    {
        public kczy_ExperimentRecordsMD GetExperimentRecordsMDByItemID(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_ExperimentRecordsMD();
                var objDb = dc.kczy_ExperimentRecords.FirstOrDefault(x => x.ItemID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
    }
}