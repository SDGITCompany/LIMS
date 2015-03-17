using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using SqlDataAccess;
using KCZYLIMS.Models;
using System.Data;
using System.Data.Linq;

namespace KCZYLIMS.BLL
{
    public class ItemsBO : EntityBO
    {
        /// <summary>
        /// item完成状态，对应items表中的TotalStatus字段
        /// </summary>
        public enum ItemStatus
        {
            NoStatus = 99,
            Approval = 5,
            EditStatus = 2,
            CompletedStatus = 0,
            Wait = 1,
            Disable = -2
        }

        public List<ItemsMD> GetInstancesByGroupID(int intGroupID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.Items
                            where tb.GroupID == intGroupID
                            select tb);
                List<ItemsMD> lstAns = new List<ItemsMD>();
                foreach (var objDb in linq)
                {
                    ItemsMD objMem = new ItemsMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }//end foreach
                
                return lstAns;
            }//end of using
        }//end of func


        public List<ItemsMD> GetItemsByOrigID(int intOrigID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.Items
                            from tc in dc.Forms
                            where tb.ItemID == intOrigID && tb.FormID==tc.FormOrigID && tc.FormType==2
                            select tc);
                List<ItemsMD> lstAns = new List<ItemsMD>();
                foreach (var objDb in linq)
                {
                    ItemsMD objMem = new ItemsMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }//end foreach

                return lstAns;
            }//end of using
            
        }


       
    }//end of func
}