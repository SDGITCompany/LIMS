using System;
using System.Collections.Generic;
using System.Linq;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class InstrumentBaseInfoBO : EntityBO,ISelector
    {
        public kczy_InstrumentBaseInfoMD GetInstrumentByItemID(int intItemID)
        {
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var objMem = new kczy_InstrumentBaseInfoMD();
                var objDb = dc.kczy_InstrumentBaseInfo.FirstOrDefault(x => x.ItemID == intItemID);
                if (objDb != null && objDb.MyID > 0)
                {
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                }
                return objMem;
            }//end of using        
        }//end of func
        public List<kczy_InstrumentBaseInfoMD> GetInstances()
        {
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.kczy_InstrumentBaseInfo
                            where tb.IsDeleted!=true
                            select tb).ToList();
                var lstAns = new List<kczy_InstrumentBaseInfoMD>();
                foreach (var objDb in linq)
                {
                    var objMem = new kczy_InstrumentBaseInfoMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }//end of using
        }//end of func

        public string ConvertToJavaScriptArray(List<EntityMD> lstAns, string strStates)
        {
            var strAns = string.Empty;
            var instruList = new List<kczy_InstrumentBaseInfoMD>(lstAns.OfType<kczy_InstrumentBaseInfoMD>());
/*            var lstOpenGroupIDs = new List<string>();
            if (!string.IsNullOrEmpty(strStates))
                lstOpenGroupIDs = strStates.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();*/
            //看哪个group下已没有group
            //var linq = lstAns.Select(x => x.GroupID).Except(lstAns.Select(x => Gro );
            if (lstAns.Count > 0)
            {
                strAns = "[";
                foreach (var obj in instruList)
                {
                    strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.MyID, 0, obj.MyName);

                    /*if (obj != null && obj.MyID > 0 && !string.IsNullOrEmpty(obj.MyName))
                    {
                        if (lstOpenGroupIDs.Contains(obj.MyID.ToString()))
                        {
                            if (!linq.Contains(obj.MyID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }
                        else
                        {
                            if (!linq.Contains(obj.MyID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }

                    }//end of if*/
                }
                if (strAns[strAns.Length - 1] == ',')
                    strAns = strAns.Substring(0, strAns.Length - 1);
                strAns += "]";
            }
            return strAns;
        }

        public List<EntityMD> GetSelfAndDescendantChildrenGroups(List<long> lstInGroupID)
        {
            return null;
        }

        public List<EntityMD> GetDescendantChildrenGroups(int myID)
        {
            if (myID == 0)
            {
                var tmplist =GetInstances();
                if (tmplist != null) 
                    return new List<EntityMD>(tmplist);
            }
            return null;
        }
    }
}