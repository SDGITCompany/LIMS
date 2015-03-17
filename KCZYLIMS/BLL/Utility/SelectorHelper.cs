using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;

namespace KCZYLIMS.BLL.Utility
{
    public class SelectorHelper
    {
        public List<EntityMD> GetSelfAndDescendantChildrenGroups(List<long> lstInMyID)
        {
            return null;
        }


        public static string ConvertToJavaScriptArray(List<GroupsMD> lstAns, string strStates)
        {
            var strAns = string.Empty;

            List<string> lstOpenGroupIDs = new List<string>();
            if (!string.IsNullOrEmpty(strStates))
                lstOpenGroupIDs = strStates.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            GroupsBO gInfo = new GroupsBO();
            Dictionary<int, bool> dct = gInfo.GroupHasItems(lstAns);
            //看哪个group下已没有group
            //var linq = lstAns.Select(x => x.GroupID).Except(lstAns.Select(x => Gro );
            var linq = (from a in lstAns
                        select a.GroupID).Except(from b in lstAns
                                                 select (long)b.ParentGroupID).ToList();

            if (lstAns.Count > 0)
            {
                strAns = "[";
                foreach (var obj in lstAns)
                {
                    if (obj != null && obj.GroupID > 0 && !string.IsNullOrEmpty(obj.MyName))
                    {
                        if (lstOpenGroupIDs.Contains(obj.GroupID.ToString()))
                        {
                            if (!linq.Contains(obj.GroupID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }
                        else
                        {
                            if (!linq.Contains(obj.GroupID))
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                            else
                                strAns += string.Format("{{ id:{0}, pId:{1}, name:'{2}',icon:'/Scripts/Third/zTree_v3/css/zTreeStyle/img/diy/folder-close.png'}},", obj.GroupID, obj.ParentGroupID, obj.MyName);
                        }

                    }//end of if
                }
                if (strAns[strAns.Length - 1] == ',')
                    strAns = strAns.Substring(0, strAns.Length - 1);
                strAns += "]";
            }
            return strAns;
        }//end of func

    }//end of class
   
}