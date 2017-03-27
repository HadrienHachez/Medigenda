using System;
using Medigenda;
using static Medigenda.Worker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedigendaTest
{
    [TestClass]
    public class WorkerTest
    {
        Worker Marcin = new Worker("Marcin", "Krasowski", 1);
        Worker Hadrien = new Worker("Hadrien", "Hachez", 2);
        // TEST ATTRIBUTS
        [TestMethod]
        public void Worker_HasUniqueID()
        {
            try
            {
                Worker Tom = new Worker("Tom", "papa", 1);
                Assert.AreEqual("0", "1");
            }
            catch
            {
                Assert.AreEqual("1", "1");
            }
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
        // TEST METHODES
        [TestMethod]
        public void Worker_isWorking()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_canWork()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_getHours()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_switchBreak()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_addSkill()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_delSkill()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_genDictDays()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_updateScheldule()
        {
            Assert.AreEqual("0", "1");
        }
        [TestMethod]
        public void Worker_isFree()
        {
            Assert.AreEqual("0", "1");
        }
    }
}