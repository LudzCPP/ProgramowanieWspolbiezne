using System.Numerics;
using NUnit.Framework;
using Dane;

namespace Dane.Tests
{
    [TestFixture]
    public class BallTests
    {
        private Granica _granica;

        [SetUp]
        public void SetUp()
        {
            _granica = new Granica(100, 100);
        }

        [Test]
        public void CreateAPI_CreatesNewBallCorrectly()
        {
            // Arrange
            Vector2 position = new Vector2(50, 50);
            Vector2 velocity = new Vector2(1, 1);
            int radius = 10;
            int mass = 5;

            // Act
            Ball ball = Ball.CreateAPI(position, velocity, radius, mass, _granica);

            // Assert
            Assert.AreEqual(position, ball.Position);
            Assert.AreEqual(velocity, ball.Velocity);
            Assert.AreEqual(radius, ball.Radius);
            Assert.AreEqual(mass, ball.Mass);
            Assert.AreEqual(_granica, ball.Granica);
            Assert.AreEqual(radius * 2, ball.Diameter);
            //Assert.AreEqual((int)position.X, ball.X);
            //Assert.AreEqual((int)position.Y, ball.Y);
        }

        // Add more tests here to cover other scenarios and edge cases...
    }
}