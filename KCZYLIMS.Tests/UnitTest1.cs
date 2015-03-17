using System;
using System.Reflection;
using KCZYLIMS.BLL.Utility;
using KCZYLIMS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KCZYLIMS.Models;
using SqlDataAccess;


namespace KCZYLIMS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEntityUpdate()
        {
            var helper = new EntityHelper<Groups>();
            var md = new GroupsMD {GroupID = 1165};
            helper.GetMDInstance(md);
            md.MyName = "test1";
            var rst = helper.UpdateMDInstance(md);
            Assert.IsTrue(rst);
        }//end of func
        [TestMethod]
        public void TestEntityInsert()
        {
            var helper = new EntityHelper<Groups>();
            var md = new GroupsMD();
            md.ParentGroupID = 2;
            helper.AddMDInstance(md);
            Assert.IsTrue(md.GroupID> 0);
        }//end of func
        [TestMethod]
        public void TestEntityDelete()
        {
            var helper = new EntityHelper<Groups>();
            var md = new GroupsMD();
            md.GroupID = 1165;
            var rst = helper.DeleteMDInstance(md);
            Assert.IsTrue(rst);
        }//end of func

        [TestMethod]        
        public void TestEntityGet()
        {           
            var helper = new EntityHelper<Groups>();
            var md = new GroupsMD();
            md.GroupID = 51;
            var groupMD = helper.GetMDInstance(md);
            Assert.IsTrue(md.MyName.Length > 0); ;
        }//end of func

        [TestMethod]
        public void TestHasRight()
        {
            var c = new PortalController();
            c.TestHero();
            Assert.IsTrue(true); 
        }//end of func

        [TestMethod]
        public void TestXMain()
        {
            TestController tc = new TestController();
            tc.TestXMain();
        }


    }
}
