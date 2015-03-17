using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class KCZYPhaseAnalysisBO : EntityBO
    {
        public List<kczy_PhaseAnalysisMD> GetInstancesByItemID(int ItemID)
        {
            List<kczy_PhaseAnalysisMD> lstAns = new List<kczy_PhaseAnalysisMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.kczy_PhaseAnalysis
                           where tb.ItemID == ItemID
                           select tb;
                foreach (var objDb in linq)
                {
                    kczy_PhaseAnalysisMD objMem = new kczy_PhaseAnalysisMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
            }
            return lstAns;
        }//end of func

        /// <summary>
        /// 更新测试费用的list
        /// </summary>
        /// <param name="lstAns"></param>
        /// <returns></returns>
        public bool UpdateInstances(List<kczy_PhaseAnalysisMD> lstAns)
        {
            bool blnAns = false;
            try
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                foreach (var objMem in lstAns)
                {
                    //MyID等于是数据库中还没有，要插入的
                    if (objMem.MyID == 0 && !string.IsNullOrEmpty(objMem.Code))
                    {
                        kczy_PhaseAnalysis objDb = new kczy_PhaseAnalysis();
                        EntityHelper<object>.SetInstanceDefaultValue(objMem);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.kczy_PhaseAnalysis.InsertOnSubmit(objDb);
                        dc.SubmitChanges();
                        
                    }
                    else if (objMem.MyID > 0) //更新的情况
                    {
                        kczy_PhaseAnalysis objDb = dc.kczy_PhaseAnalysis.FirstOrDefault(x => x.MyID == objMem.MyID);
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
    }
}