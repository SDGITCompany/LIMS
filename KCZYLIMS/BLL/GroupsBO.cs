using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
namespace KCZYLIMS.BLL
{
    public class GroupsBO : EntityBO
    {
        public GroupsMD GetInstancesByGroupID(long GroupID)
        {
            var group = new GroupsMD {GroupID = GroupID};
            return group.GetInstance<Groups,GroupsMD>(group);
        }//end of func


        /// <summary>
        /// 取得当前group底下的子group
        /// </summary>
        /// <returns></returns>
        public List<GroupsMD> GetChildrenGroups(long GroupID)
        {
            List<GroupsMD> lstAns = new List<GroupsMD>();
            if (GroupID > 0)
            {
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {                    
                    var linq = from tb in dc.Groups
                               where tb.ParentGroupID == GroupID
                               select tb;
                    foreach (var objDb in linq)
                    {
                        var objMem = new GroupsMD();
                        EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                        lstAns.Add(objMem);
                    }
                }//end of using
            }//end if
            return lstAns;
        }//end of func


        /// <summary>
        /// 递归地获取所有子孙group
        /// </summary>
        /// <returns></returns>
        public List<GroupsMD> GetDescendantChildrenGroups(long GroupID)
        {
            List<GroupsMD> lstAns = new List<GroupsMD>();
            if (GroupID > 0)
            {
                List<long> lstCurGroupID = new List<long>();
                lstCurGroupID.Add(GroupID);
                using ( DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext() )
                {
                    var dataDB = GetGroupsRecursive(lstCurGroupID, dc);
                    foreach (var objDb in dataDB)
                    {
                        var objMem = new GroupsMD();
                        EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                        lstAns.Add(objMem);
                    }
                }
            }
            return lstAns;
        }//end of func

        /// <summary>
        /// 获取哪些group下有文件
        /// </summary>
        /// <param name="lstGroup"></param>
        /// <returns></returns>
        public Dictionary<int, bool> GroupHasItems(List<GroupsMD> lstGroup)
        {
            Dictionary<int, bool> dct = new Dictionary<int, bool>();
            List<int?> lstIntGid = lstGroup.Select(x => (int?)x.GroupID).ToList();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.Items
                           where lstIntGid.Contains(tb.GroupID)
                           group tb by tb.GroupID into g
                           select new { GroupID = g.Key, ItemCnt = g.Count() };
                foreach (var obj in linq)
                {
                    if (obj.ItemCnt > 0)
                        dct.Add((int)obj.GroupID, true);
                    else
                        dct.Add((int)obj.GroupID, false);
                }
            }
            return dct;
        }//end of func




        /// <summary>
        /// 递归地搜索子Group
        /// </summary>
        /// <returns></returns>
        public List<GroupsMD> SearchDescendantChildrenGroups(string strMyName, long GroupID)
        {
            List<GroupsMD> lstAns = new List<GroupsMD>();
            if (GroupID > 0)
            {
                List<long> lstCurGroupID = new List<long>();
                lstCurGroupID.Add(GroupID);
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    var dataDB = GetGroupsRecursive(lstCurGroupID, dc);
                    foreach (var objDb in dataDB)
                    {
                        var objMem = new GroupsMD();
                        EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                        lstAns.Add(objMem);
                    }
                }
            }//end if
            return lstAns;
        }//end of func

        /// <summary>
        /// 所有子孙节点+自己
        /// </summary>
        /// <param name="lstInGroupID"></param>
        /// <returns></returns>
        public List<GroupsMD> GetSelfAndDescendantChildrenGroups(List<long> lstInGroupID)
        {
            List<Groups> lstAns = new List<Groups>();
            List<GroupsMD> lstFinal = new List<GroupsMD>();
            if (lstInGroupID != null && lstInGroupID.Count > 0)
            {
                List<long> lstCurGroupID = lstInGroupID;
                using ( DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext() )
                {
                    var dataSelf = from tb in dc.Groups
                                   where lstCurGroupID.Contains(tb.GroupID)
                                   select tb;
                    lstAns.AddRange(dataSelf.ToList());
                    //传入一个父节点的id，获取所有的子孙节点
                    var dataDB = GetGroupsRecursive(lstCurGroupID, dc);
                    lstAns.AddRange(dataDB.ToList());

                }//end using
            }//end if
            foreach (var obj in lstAns)
            {
                GroupsMD objMem = new GroupsMD();
                EntityHelper<object>.SetInstanceProperties(objMem, obj);
                lstFinal.Add(objMem);
            }
            return lstFinal;
        }//end func

        /// <summary>
        /// 获取自己以及所有的祖先节点
        /// </summary>
        /// <param name="lstInGroupID"></param>
        /// <returns></returns>
        public List<Groups> GetSelfAndAncestorGroups(List<long> lstInGroupID)
        {
            List<Groups> lstAns = new List<Groups>();
            if (lstInGroupID != null && lstInGroupID.Count > 0)
            {
                List<long> lstCurGroupID = lstInGroupID;
                using ( DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext() )
                {
                    var dataSelf = from tb in dc.Groups
                                   where lstCurGroupID.Contains(tb.GroupID)
                                   select tb;
                    List<int> lstCurParentID = dataSelf.Select(x => (int)x.ParentGroupID).ToList();
                    lstAns.AddRange(dataSelf.ToList());


                    var dataDB = GetGroupsParentRecursive(lstCurParentID, dc);
                    lstAns.AddRange(dataDB.ToList());

                }//end using
            }//end if
            return lstAns;
        }//end of func


        /// <summary>
        /// 传入一个父节点的id，获取所有的子孙节点
        /// </summary>
        /// <param name="lstPids"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static IEnumerable<Groups> GetGroupsRecursive(List<long> lstPids, DataClassesKCZYSDataContext dc)
        {
            List<long> lstIntPids = lstPids.Select(x => (long)x).ToList();

            var query = from tb in dc.Groups
                        where lstIntPids.Contains(tb.ParentGroupID)
                        select tb;
            if (query.Count() > 0)
            {
                List<long> lstCurrent = query.Select(x => (long)x.GroupID).ToList();
                return query.ToList().Concat(GetGroupsRecursive(lstCurrent, dc));
            }
            else
            {
                return query.ToList();
            }
        }//end of func

        /// <summary>
        /// 传入入口层的group的parentid集合，获取所有祖先节点
        /// </summary>
        /// <param name="lstPids"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static IEnumerable<Groups> GetGroupsParentRecursive(List<int> lstPids, DataClassesKCZYSDataContext dc)
        {
            var query = from tb in dc.Groups
                        where lstPids.Contains(Convert.ToInt32(tb.GroupID))
                        select tb;//第一层父亲节点
            if (query.Count() > 0)
            {
                List<int> lstNewParent = query.Select(x => (int)x.ParentGroupID).ToList();
                return query.ToList().Concat(GetGroupsParentRecursive(lstNewParent, dc));
            }
            else
            {
                return query.ToList();
            }
        }


    }//end of class
}//end of space