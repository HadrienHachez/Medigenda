using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medigenda;

namespace MedigendaTest
{
    [TestClass]
    public class DayTest
    {
        static DateTime j1 = new DateTime(1993, 9, 3);
        static DateTime j2 = new DateTime(1994, 9, 3);
        Day J1 = new Day(j1);
        Day J2 = new Day(j2);

        // TEST ATTRIBUTS
        [TestMethod]
        public void Day_HasDate()
        {
            Assert.AreEqual(J1.Date_time.ToString(), j1.ToString());
            Assert.AreNotEqual(J1.Date_time.ToString(), j2.ToString());
        }
        [TestMethod]
        public void Day_HasListOfServices()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Day_DictOfPresentWorkers()
        {
            Assert.AreEqual("0", "1");
        }
        // TEST METHODES
        [TestMethod]
        public void Day_isPresent()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Day_addService()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Day_delService()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Day_getWorkingDay()
        {
            Assert.AreEqual("0", "1");
        }

    }
}
