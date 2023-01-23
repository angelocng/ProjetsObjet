using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotequeJeu421;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotequeJeu421.Tests
{
    [TestClass()]
    public class AleaTests
    {
        [TestMethod()]
        public void InstanceTest()
        {
            // Arrange
            Alea alea = Alea.Instance();
            // Act
            // Assert
            Assert.IsInstanceOfType(alea, typeof(Alea));
        }

        [TestMethod()]
        public void NouveauTest()
        {
            // Arrange
            Alea alea = Alea.Instance();
            byte m = 0;
            byte M = 7;
            // Act
            byte valeur = (byte)alea.Next((int)m, (int)M);
            bool b;
            b = (valeur > m) & (valeur < M);
            // Assert
            Assert.IsTrue(b);
        }
    }
}