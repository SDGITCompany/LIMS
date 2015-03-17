//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using KCZYLIMS.Models;
//using SqlDataAccess;

//namespace KCZYLIMS.BLL
//{
//    public class MyRolesBO
//    {
//        public long Insert(EntityMD instance)
//        {
//            using (DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext())
//            {
//                SqlDataAccess.MyRoles objDb = new SqlDataAccess.MyRoles();
//                EntityBO.SetProperties(objDb, instance as KCZYLIMS.Models.MyRolesMD);
//                dc.MyRoles.InsertOnSubmit(objDb);
//                dc.SubmitChanges();
//                return objDb.RoleID;
//            }
//        }
//        public bool Update(EntityMD instance)
//        {
//            try
//            {
//                DataClassesKCZYSDataContext dc = new DataClassesKCZYSDataContext();
//                SqlDataAccess.MyRoles objDb = dc.MyRoles.FirstOrDefault(x => x.RoleID == ((KCZYLIMS.Models.MyRolesMD)instance).RoleID);
//                EntityBO.SetProperties(objDb, instance as KCZYLIMS.Models.MyRolesMD);
//                dc.SubmitChanges();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }
//    }
//}