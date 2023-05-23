using System.Numerics;
using NUnit.Framework;
using Dane;
using Logika;

namespace Logika.Tests
{
    [TestFixture]
    public class ILogikaAPIBaseTests
    {
        private DataAPI _dataAPI;

        [SetUp]
        public void SetUp()
        {
            _dataAPI = DataAPI.CreateAPI(300, 150);
        }

        [Test]
        public void CreateApi_CreatesNewInstanceCorrectly()
        {
            // Act
            ILogikaAPIBase logikaAPI = ILogikaAPIBase.CreateApi(_dataAPI);

            // Assert
            Assert.IsNotNull(logikaAPI);
            Assert.IsEmpty(logikaAPI.punkty);
        }

        [Test]
        public void StworzPilke_AddsNewBallToCollection()
        {
            // Arrange
            ILogikaAPIBase logikaAPI = ILogikaAPIBase.CreateApi(_dataAPI);

            // Act
            logikaAPI.StworzPilke();

            // Assert
            Assert.AreEqual(1, logikaAPI.punkty.Count);
        }

        // Add more tests here to cover other scenarios and edge cases...
    }
}