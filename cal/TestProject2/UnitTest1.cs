using ClassLibrary1;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Kalkulator.sumuj(1, 3), 1 + 3);
        }
    }
}