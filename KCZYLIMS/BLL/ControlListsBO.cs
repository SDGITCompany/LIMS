using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.Models;
using KCZYLIMS.BLL.Utility;
using System.Data;
using SqlDataAccess;
using XMain.Code;
using Users = XData.LinqToSqlClass.Users;

namespace KCZYLIMS.BLL
{
    public class ControlListsBO
    {
        /// <summary>
        /// -2是提交人，-1是总负责人，-3是1级别审批人，-4是二级审批，-5是三级审批，-102是通知人(抄送者)
        /// </summary>
        /// <param name="intFormID"></param>
        /// <param name="intRoleID"></param>
        /// <returns></returns>
        public List<UsersMD> GetFormRoles(int intFormID, int intRoleID)
        {
            List<UsersMD> lstAns = new List<UsersMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.ControlLists
                           where tb.FormID == intFormID && tb.RoleID == intRoleID && tb.ListClass == 6 //listclass=6是负责人
                           select tb;

                List<XMain.Code.SelectUser> UserTable = new List<XMain.Code.SelectUser>();

                foreach (var obj in linq)
                {
                    var su = new XMain.Code.SelectUser
                    {
                        ID = obj.ControlID,
                        Name = obj.ControlFullName,
                        Type = obj.ControlType == (short)XMain.Code.GroupSystemObject.Type.GroupContent ? (long)XMain.Code.SelectUser.SelectUserType.User : (long)XMain.Code.SelectUser.SelectUserType.Organization
                    };
                    UserTable.Add(su);
                }//end foreach

                //获取接受者
                XMain.Code.XEvent xEvt = new XMain.Code.XEvent();
                string strError = string.Empty;
                DataTable dtblReceivers = xEvt.ResolveControlListToUsers(UserTable, "0", "0", "0", ref strError);
                List<int> lstUsersId = new List<int>();
                foreach (DataRow dr in dtblReceivers.Rows)
                {
                    lstUsersId.Add(Convert.ToInt32(dr["UserID"].ToString()));
                }
                var lstUsersDb = from tb in dc.Users
                           where lstUsersId.Contains((int)tb.UserID)
                           select tb;
                foreach (var objDb in lstUsersDb)
                {
                    UsersMD objMem = new UsersMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }               
            }
            return lstAns;
        }
        /// <summary>
        /// -2是提交人，-1是总负责人，-3是1级别审批人，-4是二级审批，-5是三级审批，-102是通知人(抄送者)
        /// </summary>
        /// <param name="origID"></param>
        /// <param name="intFormID"></param>
        /// <param name="intRoleID"></param>
        /// <returns></returns>
        public List<UsersMD> GetFormRoles(int origID,int intFormID, int intRoleID)
        {
            List<UsersMD> lstAns = new List<UsersMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.ControlLists
                           where tb.RelatedID==origID&&tb.FormID == intFormID && tb.RoleID == intRoleID && tb.ListClass == 6 //listclass=6是负责人
                           select tb;

                List<XMain.Code.SelectUser> UserTable = new List<XMain.Code.SelectUser>();

                foreach (var obj in linq)
                {
                    var su = new XMain.Code.SelectUser
                    {
                        ID = obj.ControlID,
                        Name = obj.ControlFullName,
                        Type = obj.ControlType == (short)XMain.Code.GroupSystemObject.Type.GroupContent ? (long)XMain.Code.SelectUser.SelectUserType.User : (long)XMain.Code.SelectUser.SelectUserType.Organization
                    };
                    UserTable.Add(su);
                }//end foreach

                //获取接受者
                XMain.Code.XEvent xEvt = new XMain.Code.XEvent();
                string strError = string.Empty;
                DataTable dtblReceivers = xEvt.ResolveControlListToUsers(UserTable, "0", "0", "0", ref strError);
                List<int> lstUsersId = new List<int>();
                foreach (DataRow dr in dtblReceivers.Rows)
                {
                    lstUsersId.Add(Convert.ToInt32(dr["UserID"].ToString()));
                }
                var lstUsersDb = from tb in dc.Users
                                 where lstUsersId.Contains((int)tb.UserID)
                                 select tb;
                foreach (var objDb in lstUsersDb)
                {
                    UsersMD objMem = new UsersMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
            }
            return lstAns;
        }
        /// <summary>
        /// -2是提交人，-1是总负责人，-3是1级别审批人，-4是二级审批，-5是三级审批，-102是通知人(抄送者)
        /// </summary>
        /// <param name="relatedID">主OrigID</param>
        /// <param name="roleID">-2</param>
        /// <param name="formID">项目策划=14、实验记录=16、项目审批=18</param>
        /// <returns></returns>
        public List<ControlListsMD> GetControlLists(int relatedID, int roleID, int formID)
        {
            List<ControlListsMD> lstAns = new List<ControlListsMD>();
            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var linq = from tb in dc.ControlLists
                    where tb.RelatedID == relatedID && tb.FormID == formID && tb.RoleID == roleID && tb.ListClass == 6
                    //listclass=6是负责人
                    select tb;

               // List<XMain.Code.SelectUser> UserTable = new List<XMain.Code.SelectUser>();
                if (linq.Count() >= 0)
                {
                    foreach (var obj in linq)
                    {
                        ControlListsMD temp = new ControlListsMD();

                        EntityHelper<object>.SetInstanceProperties(temp, obj);

                        lstAns.Add(temp);

                    } //end foreach
                }
                //获取接受者
            }
            return lstAns;
        }

        public int CreateControlList(int relatedID, int roleID, int formID,int controlID,string controlFullName,UsersMD currentUser)
        {
            
            using (DataClassesKCZYSDataContext context = new DataClassesKCZYSDataContext())
            {
                SqlDataAccess.ControlLists controllistInfo = new ControlLists();
                controllistInfo.RelatedID = relatedID;
                controllistInfo.RelatedType = 1;
                controllistInfo.ModuleID = 6;
                controllistInfo.FormID = formID;
                controllistInfo.ListClass = 6;
                controllistInfo.RoleID = roleID;
                controllistInfo.ControlID = controlID;
                controllistInfo.ControlType = (int)XMain.Code.SelectUser.SelectUserType.User;
                controllistInfo.ControlFullName = controlFullName;
                controllistInfo.CreateDate = DateTime.Now;
                controllistInfo.LastModified = DateTime.Now;

                controllistInfo.CreateBy = currentUser.FullName;
                controllistInfo.CreatorID = currentUser.UserID;
                controllistInfo.ModifiedBy = currentUser.FullName;
                controllistInfo.ModifierID = currentUser.UserID;
                context.ControlLists.InsertOnSubmit(controllistInfo);
                context.SubmitChanges();
            
            return controllistInfo.MyID;
            }
        }
    }
}