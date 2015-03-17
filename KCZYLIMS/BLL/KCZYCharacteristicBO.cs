using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class KCZYCharacteristicBO : EntityBO
    {
        public List<kczy_MicroscopeMD> GetInstancesByItemID(int ItemID)
        {
            List<kczy_MicroscopeMD> lstAns = new List<kczy_MicroscopeMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.kczy_Microscope
                           where tb.ItemID == ItemID
                           select tb;
                foreach (var objDb in linq)
                {
                    kczy_MicroscopeMD objMem = new kczy_MicroscopeMD();
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
        public bool UpdateInstances(List<kczy_MicroscopeMD> lstAns)
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
                        kczy_Microscope objDb = new kczy_Microscope();
                        EntityHelper<object>.SetInstanceDefaultValue(objMem);
                        EntityHelper<object>.SetInstanceProperties(objDb, objMem);
                        dc.kczy_Microscope.InsertOnSubmit(objDb);
                        dc.SubmitChanges();
                        objMem.MyID = objDb.MyID;
                    }
                    else if (objMem.MyID > 0) //更新的情况
                    {
                        kczy_Microscope objDb = dc.kczy_Microscope.FirstOrDefault(x => x.MyID == objMem.MyID);
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

        /// <summary>
        /// 删除这些ids的记录
        /// </summary>
        /// <param name="strMyIds"></param>
        public void DeleteRecords(string strMyIds)
        {
            if (string.IsNullOrEmpty(strMyIds))
                return;

            string[] strIds = strMyIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> lstIds = new List<int>();
            foreach (var id in strIds)
            {
                lstIds.Add(int.Parse(id));
            }
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.kczy_Microscope
                           where lstIds.Contains(tb.MyID)
                           select tb;
                dc.kczy_Microscope.DeleteAllOnSubmit(linq);
                dc.SubmitChanges();
            }
        }//end of func


    }
}