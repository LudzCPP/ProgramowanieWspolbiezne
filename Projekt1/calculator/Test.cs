using NUnit.Framework;
using System;

namespace calculator.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Dodaj_Test()
        {
            double a = 5;
            double b = 2;

            double result = Program.dodaj(a, b);

            Assert.AreEqual(7, result);
        }

        [Test]
        public void Odejmi_Test()
        {
            double a = 5;
            double b = 2;

            double result = Program.odejmi(a, b);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Pomnoz_Test()
        {
            double a = 5;
            double b = 2;

            double result = Program.pomnoz(a, b);

            Assert.AreEqual(10, result);
        }

        [Test]
        public void Podziel_Test()
        {
            double a = 5;
            double b = 2;

            double result = Program.podziel(a, b);

            Assert.AreEqual(2.5, result);
        }

        [Test]
        public void Podziel_Zero_Test()
        {
            double a = 5;
            double b = 0;

            Assert.Throws<DivideByZeroException>(() => Program.podziel(a, b));
        }
    }
}
