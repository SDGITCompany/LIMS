using System;
using KCZYLIMS.BLL;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Controllers;
using KCZYLIMS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlDataAccess;

namespace KCZYLIMS.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pa = new ProcessMineralogyAPIController();
            var newObject = new kczy_ProjectAttorneyMD() {MyName = "test"};
            pa.CreateProjectAttorney(newObject);
            Assert.IsNotNull(newObject.MyID>0);
        }

        [TestMethod]
        public void TestMethod1CurrentUser()
        {
            KCZYLIMS.BLL.UsersBO bo = new UsersBO();
            var tmp = KCZYLIMS.BLL.UsersBO.GetCurrentUser();
            var mmm = "";
        }
        [TestMethod]
        public void TestMethod1Entity()
        {
            EntityMD md = new EntityMD();
            UsersMD  u = new UsersMD();
            u.MyNotes = "test";
            md.Insert<Users, UsersMD>(u);
        }
        [TestMethod]
        public void TestInsrumentEntity()
        {
            //EntityMD md = new EntityMD();
            //UsersMD u = new UsersMD();
            //u.MyNotes = "test";
            //md.Insert<Users, UsersMD>(u);
            IndexInfo index=new IndexInfo();
            index.PageSize = 5;
            SelectorController se=new SelectorController();
            se.GetCustomerDataSet(index);
        }
        [TestMethod]
        public void TestGroupRight()
        {
            //EntityMD md = new EntityMD();
            //UsersMD u = new UsersMD();
            //u.MyNotes = "test";
            //md.Insert<Users, UsersMD>(u);
            var demo = new DemoController();
            demo.TestGroupRight();
        }

        [TestMethod]
        public void TestSecurity()
        {
            DemoController d = new DemoController();
            d.Index();
        }
    }
}
