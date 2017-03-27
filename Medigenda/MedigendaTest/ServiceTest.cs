using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medigenda;

namespace MedigendaTest
{
    [TestClass]
    public class ServiceTest
    {
        static ServiceName s1 = new ServiceName("Service1");
        static ServiceName s2 = new ServiceName("Service2");
        Service S1 = new Service(s1);
        Service S2 = new Service(s2);
        // TEST ATTRIBUTS
        [TestMethod]
        public void Service_HasServiceName()
        {
            Assert.AreEqual(S1.Service_name, s1);
            Assert.AreNotEqual(S2.Service_name, s1);
        }
        [TestMethod]
        public void Service_HasListOfShift()
        {
            Assert.AreEqual("0", "1");
        }
        // TEST METHODES
        [TestMethod]
        public void Service_createShift()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Service_delShift()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Service_getWorkerShifts()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Service_getName()
        {
            Assert.AreEqual("0", "1");
        }
    }
}
