using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCZYLIMS.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KCZYLIMS.BLL.Tests
{
    [TestClass()]
    public class MySecurity1Tests
    {
        [TestMethod()]
        public void CanShowItemTest()
        {
           MySecurity mySecurity = new MySecurity();

           mySecurity.CanShowItem("156", "0", "6", 259);
        }
    }
}
