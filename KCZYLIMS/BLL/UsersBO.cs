using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Models;
using SqlDataAccess;
namespace KCZYLIMS.BLL
{
    public class UsersBO : EntityBO
    {
        public static UsersMD GetInstanceByLoginName(string strLoginName)
        {
            var tmpUser = new UsersMD {LoginName = strLoginName};
            return tmpUser.GetMDInstance<Users,UsersMD>(tmpUser, "LoginName", strLoginName);
/*            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
            {
                var objDb = dc.Users.FirstOrDefault(x => x.LoginName.Trim().Equals(strLoginName));
                var objMem = new UsersMD();
                EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                return objMem;
            }*/
        }

        public static UsersMD GetCurrentUser()
        {
            try
            {
                string name = HttpContext.Current.User.Identity.Name;
                var user = GetInstanceByLoginName(name);
                return user;
            }
            catch (Exception)
            {

                var user = GetDefaultUser();
                return user;
            }
            finally
            {
                Console.WriteLine("test");
            }

        }

        private static UsersMD GetDefaultUser()
        {
            var user = new UsersMD();
            user.UserID = 2;
            user.GetInstance<Users, UsersMD>(user);
            return user;
        }

        public List<UsersMD> GetInstancesByGroupID(int intGroupID)
        {
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.Users
                            where tb.GroupID == intGroupID
                            select tb).ToList();
                var lstAns = new List<UsersMD>();
                foreach (var objDb in linq)
                {
                    var objMem = new UsersMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }//end of using
        }//end of func

        public List<UsersMD> GetInstancesByUserIDs(List<long> lstUserID)
        {
            using (var dc = new DataClassesKCZYSDataContext())
            {
                var linq = (from tb in dc.Users
                            where lstUserID.Contains(tb.UserID)
                            select tb).ToList();
                var lstAns = new List<UsersMD>();
                foreach (var objDb in linq)
                {
                    var objMem = new UsersMD();
                    EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                    lstAns.Add(objMem);
                }
                return lstAns;
            }//end of using
        }//end of func
        public List<UsersMD> SearchDescendantUsers(long intCurGroupID, string strMyName)
        {
            List<UsersMD> lstAns = new List<UsersMD>();
            if (intCurGroupID > 0)
            {
                List<long> lstCurGroupID = new List<long>();
                lstCurGroupID.Add(intCurGroupID);
                using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
                {
                    GroupsBO groupBO = new GroupsBO();
                    List<GroupsMD> lstGroup = groupBO.GetSelfAndDescendantChildrenGroups(lstCurGroupID);
                    List<long> lstGroupIDs = lstGroup.Select(x => x.GroupID).ToList();
                    lstGroupIDs.Add(intCurGroupID);
                    var linq = from tb in dc.Users
                               where tb.FullName.Contains(strMyName) && lstGroupIDs.Contains(tb.GroupID)
                               select tb;

                    foreach (var objDb in linq)
                    {
                        UsersMD objMem = new UsersMD();
                        EntityHelper<object>.SetInstanceProperties(objMem, objDb);
                        lstAns.Add(objMem);
                    }//end foreach
                }//end using
            }//end if
            return lstAns;
        }//end of func

        public static void TestForEntity()
        {
            var newUser = new UsersMD
            {
                MyNotes = "wwww", 
                LastName = "Let it go"
            };
            //newUser.Insert(newUser);
        }
    }
}