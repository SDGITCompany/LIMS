using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SqlDataAccess;
using KCZYLIMS.Models;
using System.Data;
using System.Data.Linq;
using XMain.Code;

namespace KCZYLIMS.BLL
{
    public class ProjectAttorneyBO : EntityBO
    {
        public kczy_ProjectAttorneyMD GetProjectAttorneyMDByItemID(int intItemID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_ProjectAttorneyMD();
                var objDb = dc.kczy_ProjectAttorney.FirstOrDefault(x => x.ItemID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func

        public static List<kczy_ProjectAttorneyMD> GetAllProjectAttorneyMD()
        {
            var list= new List<kczy_ProjectAttorneyMD>();
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_ProjectAttorneyMD();
                var objDb = dc.kczy_ProjectAttorney.OrderByDescending(a=>a.MyID);
                foreach (var kczyProjectAttorney in objDb)
                {
                    var tmp = new kczy_ProjectAttorneyMD();
                    Utility.EntityHelper<object>.SetInstanceProperties(tmp, kczyProjectAttorney);
                    list.Add(tmp);
                }
                return list;
            }//end of using     
        }
    }
}