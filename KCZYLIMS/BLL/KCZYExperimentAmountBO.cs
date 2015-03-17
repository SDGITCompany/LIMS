using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCZYLIMS.BLL
{
    public class KCZYExperimentAmountBO : EntityBO
    {
        public List<kczy_ExperimentAmountMD> GetInstancesByItemID(int ItemID)
        {
            List<kczy_ExperimentAmountMD> lstAns = new List<kczy_ExperimentAmountMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.kczy_ExperimentAmount
                           where tb.ItemID == ItemID && tb.IsDeleted!=true
                           select tb;
                foreach (var objDb in linq)
                {
                    kczy_ExperimentAmountMD objMem = new kczy_ExperimentAmountMD();
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
        public bool UpdateInstances(List<kczy_ExperimentAmountMD> lstAns)
        {
            bool blnAns = false;
            try
            {
                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
                foreach (var objMem in lstAns)
                {
                    //MyID等于是数据库中还没有，要插入的
                    if (objMem.MyID == 0 && !string.IsNullOrEmpty(objMem.ExperimentName))
                    {
                        kczy_ExperimentAmount objDb = new kczy_ExperimentAmount();
                        EntityHelper<object>.SetInstanceDefaultValue(objMem);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.kczy_ExperimentAmount.InsertOnSubmit(objDb);
                        dc.SubmitChanges();
                    }
                    else if (objMem.MyID > 0) //更新的情况
                    {
                        kczy_ExperimentAmount objDb = dc.kczy_ExperimentAmount.FirstOrDefault(x => x.MyID == objMem.MyID);
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