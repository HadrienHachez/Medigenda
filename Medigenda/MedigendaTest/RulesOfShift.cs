using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medigenda;

namespace MedigendaTest
{
    // Test si les règles de travail appliqués aux travailleurs
    [TestClass]
    public class RulesOfShift
    {
        [TestMethod]
        // Vérifie si travailleur ne travaille pas trop sur une journée (<=11h30)
        public void rulesWorker_maxHperDay()
        {
            Assert.Equals("0", "1");
        }
        [TestMethod]
        // Vérifie si travailleur ne travaille pas trop sur une semaine (<=50h)
        public void rulesWorker_maxHperWeek()
        {
            Assert.Equals("0", "1");
        }
        [TestMethod]
        // Vérifie si travailleur se repose assez (min 11H)
        public void rulesWorker_enoughSleepTime()
        {
            Assert.Equals("0", "1");
        }
        // Vérifie si travailleur disponible (pas 2jobs à la fois)
        public void rulesWorker_oneWorkoneTime()
        {
            Assert.Equals("0", "1");
        }
        [TestMethod]
        // Vérifie si travailleur bon nombre d'heure à la fin d'un semestre (-8h/+8h)
        public void rulesWorker_endQuarter()
        {
            Assert.Equals("0", "1");
        }
        [TestMethod]
        // Vérifie si travailleur a les aptitudes pour travailler à ce poste
        public void rulesWorker_goodQualification()
        {
            Assert.Equals("0", "1");
        }
        [TestMethod]
        // Vérifie si Shift n'a pas trop de travailleur
        public void rulesShift_notTomuchWorker()
        {
            Assert.Equals("0", "1");
        }

    }
}