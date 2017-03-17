using System;
using Medigenda;
using static Medigenda.Worker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedigendaTest
{
    [TestClass]
    public class WorkerTest
    {
        Worker Homer = new Worker("Homer","Simpson");

        [TestMethod]
        public void Worker_HasListOfSkills()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_HasContractType()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_HasListOfNonWWorkingDays()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_HasDictOfSchedule()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_HasDictOfHours()
        {
            Assert.AreEqual("0", "1");
        }
    }
}
