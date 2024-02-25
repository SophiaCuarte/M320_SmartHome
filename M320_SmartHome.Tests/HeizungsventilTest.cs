using M320_SmartHome;
using M320_SmartHome.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartHome.Tests
{
    [TestClass]
    public class HeizungsventilTests
    {
        [TestMethod]
        public void Test18_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(18, true, 50);
            var wohnung = new Wohnung(wettersensor);
            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsTrue(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void Test20_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(20, false, 50);
            var wohnung = new Wohnung(wettersensor);
            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsFalse(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestMinus50_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(-50, true, 50);
            var wohnung = new Wohnung(wettersensor);
            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsTrue(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void Test35_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(35, true, 50);
            var wohnung = new Wohnung(wettersensor);
            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsFalse(wohnzimmer.HeizungsventilOffen);
        }
    }
}
