using Logika;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTest
{
    [TestClass]
    public class BallTests
    {
        Punkt ball = new Punkt(1.0, 2.0, 3.0);

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(ball);
        }

        [TestMethod]
        public void CreateBallTest()
        {
            Assert.AreEqual(1.0, ball.X);
            Assert.AreEqual(2.0, ball.Y);
            Assert.AreEqual(3.0, ball.Radius);
        }

        [TestMethod]
        public void SetBallRadiusTest()
        {
            ball.Radius = 5.0;
            Assert.AreEqual(5.0, ball.Radius);
        }

    }
}