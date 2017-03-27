using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medigenda;


namespace MedigendaTest
{
    [TestClass]
    public class PersonTest
    {
        Person Marcin = new Person("Marcin", "Krasowski", 1);
        Person Benoit = new Person("Benoit", "Wéry", 2);
        Person Tom = new Person("Tom", "Sell", 3);
        Person Hadrien = new Person("Hadrien", "Hachez", 4);
        [TestMethod]
        public void Person_HasName()
        {
            Assert.IsFalse(Marcin.First_name == "Krasowski");
            Assert.IsTrue(Benoit.First_name == "Benoit");
            Assert.IsFalse(Tom.First_name == Hadrien.First_name);
            Assert.IsTrue(Tom.Last_name == "Sell");
            Assert.IsFalse(Hadrien.Last_name == Marcin.First_name);
        }
        [TestMethod]
        public void Person_HasUniqueID()
        {
            Assert.IsFalse(Marcin.Id == 2);
            Assert.IsTrue(Benoit.Id == 2);
            Assert.IsTrue(Tom.Id != Hadrien.Id);
        }
    }
}