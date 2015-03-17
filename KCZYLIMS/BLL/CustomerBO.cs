using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class CustomerBO : EntityBO
    {
        public kczy_CustomerMD GetCustomerMDByMyID(int myID)
        {
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_CustomerMD();
                var objDb = dc.kczy_Customer.FirstOrDefault(x => x.MyID == myID);
                if (objDb != null && objDb.MyID > 0)
                {
                    BLL.Utility.EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
        public List<kczy_CustomerMD> GetInstances()
        {
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.kczy_Customer where tb.IsDeleted!=true
                            select tb).ToList();
                var lstAns = new List<kczy_CustomerMD>();
                foreach (var objDb in linq)
                {
                    var objMem = new kczy_CustomerMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }//end of using
        }//end of func
    }
}