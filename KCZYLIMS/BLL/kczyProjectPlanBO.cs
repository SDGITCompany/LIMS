using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using SqlDataAccess;
using KCZYLIMS.BLL.Utility;

namespace KCZYLIMS.BLL
{
    public class kczyProjectPlanBO : EntityBO
    {
        public List<kczy_ProjectPlanMD> GetInstancesByItemID(int ItemID)
        {
            List<kczy_ProjectPlanMD> lstAns = new List<kczy_ProjectPlanMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext()) 
            {
                var linq = from tb in dc.kczy_ProjectPlan
                           where tb.ItemID == ItemID
                           select tb;
                foreach (var objDb in linq)
                {
                    kczy_ProjectPlanMD objMem = new kczy_ProjectPlanMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
            }
            return lstAns;
        }//end of func

        /// <summary>
        /// 更新项目策划的list
        /// </summary>
        /// <param name="lstAns"></param>
        /// <returns></returns>
        public bool UpdateInstances( List<kczy_ProjectPlanMD> lstAns )
        {
            bool blnAns = false;
            try
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                foreach (var objMem in lstAns)
                {
                    //MyID等于是数据库中还没有，要插入的
                    if (objMem.MyID == 0 && !string.IsNullOrEmpty(objMem.ResearchContent) )
                    {
                        kczy_ProjectPlan objDb = new kczy_ProjectPlan();
                        EntityHelper<object>.SetInstanceDefaultValue(objMem);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.kczy_ProjectPlan.InsertOnSubmit(objDb);
                        dc.SubmitChanges();
                    }
                    else if (objMem.MyID > 0) //更新的情况
                    {
                        kczy_ProjectPlan objDb = dc.kczy_ProjectPlan.FirstOrDefault(x => x.MyID == objMem.MyID);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.SubmitChanges();
                    }
                }
                blnAns = true;
            }
            catch (Exception ex)
            {
                blnAns = false;
            }
            return blnAns;
        }//end of func


    }//end of class
}