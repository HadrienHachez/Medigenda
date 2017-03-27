using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medigenda;

namespace MedigendaTest
{
    [TestClass]
    public class ShiftTest
    {
        static DateTime dt1 = new DateTime(1993, 3, 9);
        static String startH1 = "08:30";
        static String endH1 = "12:00";
        static ServiceName s1 = new ServiceName("Service1");
        static DateTime dt2 = new DateTime(1993, 3, 9);
        static String startH2 = "16:00";
        static String endH2 = "13:00";
        static ServiceName s2 = new ServiceName("Service2");
        Shift sh1 = new Shift(dt1, startH1, endH1, 1, 2, s1);
        Shift sh2 = new Shift(dt2, startH2, endH2, 3, 4, s2);
        // TEST ATTRIBUTS
        [TestMethod]
        public void Shift_HasStartHour()
        {
            Assert.AreEqual(sh1.Start_hour,startH1);
            Assert.AreNotEqual(sh2.Start_hour, startH1);
            Assert.AreNotEqual(sh2.Start_hour, endH2);
        }
        [TestMethod]
        public void Shift_HasEndHour()
        {
            Assert.AreEqual(sh1.End_hour, endH1);
            Assert.AreNotEqual(sh2.End_hour, startH1);
            Assert.AreEqual(sh2.End_hour, endH2);
        }
        [TestMethod]
        public void Shift_HasListOfWorkersHours()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Shift_HasMinWorkers()
        {
            Assert.AreEqual("0", "1");
        }
        public void Shift_HasOptWorkers()
        {
            Assert.AreEqual("0", "1");
        }
        // TEST METHODES
        [TestMethod]
        public void Shift_addWorker()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Shift_delWorker()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Shift_updateWorker()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Shift_delShiftDetails()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Shift_getSpan()
        {
            Assert.AreEqual("0", "1");
        }
    }
}
