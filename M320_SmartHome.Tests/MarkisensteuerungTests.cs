using Microsoft.VisualStudio.TestTools.UnitTesting;
using M320_SmartHome;
using M320_SmartHome.Tests;

namespace SmartHome.Tests
{
    [TestClass]
    public class MarkisensteuerungTests
    {
        [TestMethod]
        public void Test25Grad_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(25, true, 19.5);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false); 

            // Act
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsTrue(wintergarten.markiseEingefahren);
        }

        [TestMethod]
        public void Test22GradRegen_True()
        {
            var wettersensor = new WettersensorMock(22, true, 19.5);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            
            Assert.IsTrue(wintergarten.markiseEingefahren);
        }

        [TestMethod]
        public void Test1Grad_True()
        {
            var wettersensor = new WettersensorMock(1, true, 35);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 10);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

           
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");


            Assert.IsTrue(wintergarten.markiseEingefahren);
        }

        [TestMethod]
        public void TestMinus88GradRegen_True()
        {
            var wettersensor = new WettersensorMock(-88, true, 35);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 10);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            
            Assert.IsTrue(wintergarten.markiseEingefahren);
        }

        [TestMethod]
        public void Test100Grad_True()
        {
            var wettersensor = new WettersensorMock(100, true, 35);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 10);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            
            Assert.IsTrue(wintergarten.markiseEingefahren);
        }
    }
}
