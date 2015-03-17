using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMain.Code;
using SqlDataAccess;

namespace KCZYLIMS.BLL
{
    public class MySecurity
    {
        /// <summary>
        /// 判断在当前Item上有没有角色或负责人的权限
        /// </summary>
        /// <param name="OrigID"></param>
        /// <param name="ModuleID"></param>
        /// <param name="strListClass"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public  bool CanShowItem(string OrigID, string ModuleID, string strListClass, int UserID)
        {
            try
            {
                bool blnResult = false;
                string strOrganizationID = GetOrignization(UserID, out blnResult);
                if (blnResult)
                {
                    return blnResult;
                }
                string strSQL = "";
                //如果是角色，直接判断；如果是负责人，则只有提交人，查勘人和已到达的审批人可以查看
                if (strListClass == XData.Global.roleListClass)
                {
                    strSQL = "Select MyID from ControlLists  where RelatedID = " + OrigID
                                + " And RelatedType = 1 And ModuleID = " + ModuleID
                                + " And ListClass = " + strListClass
                                + " And ( (ControlID = " + UserID
                                + " And ControlType = 1) Or (ControlID In (" + strOrganizationID + ") And ControlType = 6))";
                }
                else
                {
                    //获取已经审批完成的Item
                    string strGetCompletedFormID = "select FormID from Items where OrigID = " + OrigID
                                                    + " And ItemID > " + OrigID
                                                    + "  And MyStatus = " + ((int)MyStatus.Complete).ToString();
                    List<FormIDClass> lstFormID = GetDataBase<FormIDClass>(strGetCompletedFormID);
                    string strCompletedFormID = "";
                    if (lstFormID != null)
                    {
                        foreach (var formID in lstFormID)
                        {
                            if (strCompletedFormID == "")
                            {
                                strCompletedFormID = formID.FormID.ToString();
                            }
                            else
                            {
                                strCompletedFormID += "," + formID.FormID.ToString();
                            }
                        }
                    }
                    //获取正在审批的Item
                    string strGetUnCompletedFormID = "select FormID,ApprovalStatus from Items where OrigID = " + OrigID
                                                    + " And ItemID > " + OrigID
                                                    + " And MyStatus > " + ((int)MyStatus.Complete).ToString();
                    List<FormApprovalIDClass> lstFormApparoval =
                        GetDataBase<FormApprovalIDClass>(strGetUnCompletedFormID);
                    string strUnCompletedFormID = "";
                    string strApproval = "";
                    if (lstFormApparoval != null)
                    {
                        if (lstFormApparoval.Count > 0)
                        {
                            strUnCompletedFormID = lstFormApparoval[0].FormID.ToString();
                            strApproval = lstFormApparoval[0].ApprovalStatus.ToString();
                        }
                    }
                    //开始拼接查询负责人的SQL语句
                    strSQL = "Select MyID from ControlLists Items  where RelatedID = " + OrigID
                             + " And RelatedType = 1 And ModuleID = " + ModuleID
                             + " And ListClass = " + strListClass;
                    //加入最外围的括号
                    //if ((strCompletedFormID != "") || (strUnCompletedFormID != ""))
                    {
                        strSQL += " And ( ";
                    }
                    //加入已经审批完成的
                    if (strCompletedFormID != "")
                    {
                        strSQL += " ( (FormID In (" + strCompletedFormID + "))" + " And ( (ControlID = " +
                                  UserID
                                  + " And ControlType = 1) Or (ControlID In (" + strOrganizationID
                                  + ") And ControlType = 6)))";
                    }
                    if ((strCompletedFormID != "") && (strUnCompletedFormID != ""))
                    {
                        strSQL += " Or ";
                    }
                    //加入未审批完的
                    if (strUnCompletedFormID != "")
                    {
                        string strRoleID = "-1,-100,-101,-102";
                        int intApproval = Convert.ToInt32(strApproval);
                        for (int i = 0; i <= intApproval; i++)
                        {
                            strRoleID += "," + (-i - 2).ToString();
                        }
                        strSQL += " ( (FormID In (" + strUnCompletedFormID + "))" + " And ( (ControlID = " +
                                  UserID
                                  + " And ControlType = 1) Or (ControlID In (" + strOrganizationID
                                  + ") And ControlType = 6)) And (RoleID In (" + strRoleID + ")))";
                    }
                    //补上括号
                    //if ((strCompletedFormID != "") || (strUnCompletedFormID != ""))
                    {
                        strSQL += " ) ";
                    }

                }

                List<MyIDClass> lstMyID = GetDataBase<MyIDClass>(strSQL);

                if (lstMyID.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CanShowGroup(string GroupID, string ModuleID, int UserID)
        {
            try
            {
                bool blnResult = false;
                string strOrganizationID = GetOrignization(UserID, out blnResult);
                if (blnResult)
                {
                    return blnResult;
                }
                //开始拼接查询负责人的SQL语句
                string strSQL = "Select MyID from ControlLists Items  where RelatedID = " + GroupID
                                + " And RelatedType = 0 And ModuleID = " + ModuleID
                                + " And ListClass = " + XData.Global.specialRoleListClass
                                + " And ( (ControlID = " + UserID
                                + " And ControlType = 1) Or (ControlID In (" + strOrganizationID
                                + ") And ControlType = 6))";
                List<MyIDClass> lstMyID = GetDataBase<MyIDClass>(strSQL);

                if (lstMyID.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public static List<T> GetDataBase<T>(string strSQL)
        {
            using (DataClassesKCZYSDataContext dataClassesKczysDataContext = new DataClassesKCZYSDataContext())
            {
                IEnumerable<T> ie = dataClassesKczysDataContext.ExecuteQuery<T>(strSQL);
                List<T> lstResult = ie.ToList<T>();
                return lstResult;
            }
        }

        public string GetOrignization(int UserID,out bool blnResult)
        {
            blnResult = false;
            string strOrganizationID = "";
                //List<long> lisOrignization = new List<long>();
                using (DataClassesKCZYSDataContext dataClassesKczysDataContext = new DataClassesKCZYSDataContext())
                {
                    var getUser = from dUser in dataClassesKczysDataContext.Users
                        where dUser.UserID == UserID
                        select new {dUser.ModuleSet};
                    var getModuleSet = getUser.FirstOrDefault();
                    if (getModuleSet != null)
                    {
                        string str = getModuleSet.ModuleSet;
                        if (str.IndexOf("999|1") > 0)
                        {
                            blnResult = true;
                        }
                    }
                    var getOrignization = from dCtrolLists in dataClassesKczysDataContext.ControlLists
                        where dCtrolLists.ControlID == UserID &&
                              dCtrolLists.ControlType == 1 &&
                              dCtrolLists.ListClass == 1 &&
                              dCtrolLists.RelatedType == 0
                                          select new { dCtrolLists.RelatedID };
                    List<long> lstInGroupID = new List<long>();
                    foreach (var subControlID in getOrignization)
                    {
                        lstInGroupID.Add(subControlID.RelatedID);
                    }
                    GroupsBO groupsBo = new GroupsBO();
                    List<Groups> lstGroup = groupsBo.GetSelfAndAncestorGroups(lstInGroupID);
                    for (int i = 0; i < lstGroup.Count; i++)
                    {
                        if (i == 0)
                        {
                            strOrganizationID = lstGroup[i].GroupID.ToString();
                        }
                        else
                        {
                            strOrganizationID += ",";
                            strOrganizationID += lstGroup[i].GroupID.ToString();
                        }
                    }
                    if (strOrganizationID == "")
                    {
                        strOrganizationID = "0";
                    }
                }
            return strOrganizationID;
        }
    }
    class MyIDClass
    {
        private int _MyID;
        public int MyID
        {
            set { _MyID = value; }
            get { return _MyID; }
        }
    }
}