using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Medigenda.Person;
using Medigenda;

namespace MedigendaTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Person_Creation()
        {
            try
            {
                Person guy = new Person("Homer", "Simpson");
                Person guy2 = new Person("Ned", "Flanders");
                Person girl = new Person("Marge", "Simpson");
                Person kid = new Person("Milhouse", "Van Houten");
            }
            catch
            {
                Assert.Equals(0, 1);
            }

            
        }
        [TestMethod]
        public void Person_GoodName()
        {
            Person guy = new Person("Homer", "Simpson");
            Person guy2 = new Person("Ned", "Flanders");
            Person girl = new Person("Marge", "Simpson");
            Person kid = new Person("Milhouse", "Van Houten");
            Assert.IsTrue(guy.First_name.Equals("Homer"));
            Assert.IsTrue(guy.Last_name.Equals("Simpson"));
            Assert.IsFalse(kid.Last_name.Equals("Houten"));
            Assert.IsFalse(kid.Last_name.Equals("Milhouse"));
        }
        [TestMethod]
        public void Person_DifferentName()
        {
            Person girl = new Person("Marge", "Simpson");
            Person girl2 = new Person("Marge", "Flanders");
            Person girl3 = new Person("Marge", "Simpson");
            Assert.IsTrue(girl2.First_name.Equals(girl3.First_name));
            Assert.IsFalse(girl.First_name.Equals(girl3.First_name));
        }
    }
}
