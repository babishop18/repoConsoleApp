using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace repoConsoleApp.obj
{
    [TestClass]
    public class Delivery_Unit_Testing
    {
        [TestClass]
        public class DeliveryTest
        {
            [TestMethod]
            public void TestMethod1()
            {
                Delivery delivery = new Delivery();
                delivery.DelID = 1133;
                int expected = 1133;
                int actual = delivery.delID;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public void DelRepoTest
        {
            
        }
    }
}