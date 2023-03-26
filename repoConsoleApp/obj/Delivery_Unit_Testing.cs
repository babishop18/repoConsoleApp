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
        private readonly DeliveryRepo _DelRepo = new DeliveryRepo();

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
            private _DelRepo? _TestRepo = new _DelRepo();
            private Delivery? _delivery;

            [TestInitialize]
            public void Arrange()
            {
                _TestRepo = new _DelRepo();
                _delivery = new Delivery(1234, new DateTime(2023, 03, 25), DelStatus.Canceled, 123, 12, 12345);
                _TestRepo.AddDelivery(_delivery);

            }

        }
    }
}