using M320_SmartHome;
using M320_SmartHome.Tests;
using System.Reflection;

namespace SmartHome.Tests
{
    using M320_SmartHome;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SmartHome.Tests
    {
        [TestClass]
        public class JaoulisesteuerungTests
        {

            [TestMethod]
            public void TestAussentemptiefer()
            {
                // Arrange
                var wettersensor = new WettersensorMock(19,true, 35);
                var wohnung = new Wohnung(wettersensor);

                wohnung.SetTemperaturvorgabe("Kueche", 20);
                wohnung.SetPersonenImZimmer("Kueche", false);

                wohnung.GenerateWetterdaten();

                // Act
                var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

                // Assert
                Assert.IsTrue(kueche.JalousieOffen);
            }


            [TestMethod]
            public void TestAussenTempHoeher_flase()
            {
                // Arrange
                var wettersensor = new WettersensorMock(21, true, 35);
                var wohnung = new Wohnung(wettersensor);

                wohnung.SetTemperaturvorgabe("Kueche", 11);
                wohnung.SetPersonenImZimmer("Kueche", false);

                wohnung.GenerateWetterdaten();

                // Act
                var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

                // Assert
                Assert.IsFalse(kueche.JalousieOffen);
            }

            [TestMethod]
            public void HoehereMitPerson_True()
            {
                // Arrange
                var wettersensor = new WettersensorMock(25, true, 35);
                var wohnung = new Wohnung(wettersensor);

                wohnung.SetTemperaturvorgabe("Kueche", 20);
                wohnung.SetPersonenImZimmer("Kueche", true);

                wohnung.GenerateWetterdaten();

                // Act
                var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

                // Assert
                Assert.AreEqual(kueche.JalousieOffen, false);
            }
        }
    }
}
