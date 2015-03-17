using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlDataAccess;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL
{
    public class SystemSettingsBO
    {

        public PairValue this[string strKey]
        {
            get
            {
                PairValue pv = new PairValue();
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    var obj = dc.SystemSettings.Where(x => x.XFKey.Equals(strKey)).FirstOrDefault();
                    if (obj != null)
                    {
                        pv.Key = obj.XFKey;
                        pv.Value1 = obj.Value1;
                        pv.Value2 = obj.Value2;
                    }
                }
                return pv;
            }
        }

    }

    public class PairValue
    {
        public string Key { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }

}