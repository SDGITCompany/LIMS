using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class ExperimentStatusBaseInfoBO : EntityBO
    {
        public kczy_ExperimentStatusBaseInfoMD GetExperimentStatusBaseInfoMDByItemID(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_ExperimentStatusBaseInfoMD();
                var objDb = dc.kczy_ExperimentStatusBaseInfo.FirstOrDefault(x => x.ItemID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
        public kczy_ExperimentStatusBaseInfoMD GetExperimentStatusBaseInfoMDByItemID(int intItemID,int type)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_ExperimentStatusBaseInfoMD();
                var objDb = dc.kczy_ExperimentStatusBaseInfo.FirstOrDefault(x => x.ItemID == intItemID&&x.Type==type);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func

        public int GetSubmitedCount(int itemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var lists = from obj in dc.kczy_ExperimentStatusBaseInfo
                    where obj.ItemID == itemID && obj.IsSubmit == true
                    select obj;
                var count = lists.Count();
                return count;
            }
        }
    }
}