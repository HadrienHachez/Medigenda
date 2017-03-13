using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Medigenda.Worker;
using Medigenda;

namespace MedigendaTest
{
    [TestClass]
    public class WorkerTest
    {
        [TestMethod]
        public void Worker_Creation()
        {
            try
            {
                Worker guy = new Worker("Homer", "Simpson");
                Worker guy2 = new Worker("Ned", "Flanders");
                Worker girl = new Worker("Marge", "Simpson");
                Worker kid = new Worker("Milhouse", "Van Houten");
            }
            catch
            {
                Assert.Equals(0, 1);
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
    }
}
