using System.Reflection;

namespace M320_SmartHome.Tests
{
    [TestClass]
    public class HeizungsventilTests

    {
        private List<IZimmer> zimmerList = new List<IZimmer>();
        [TestMethod]
        public void HeizungsventilOffenZimmer19_Aussen18()
        {
            // TODO:
            //ARRANGE
            // 1) Klasse WettersensorMock erstellen, welche die fixe Aussentemperatur 18�C als Wetterdaten generiert (Neue KLasse im Testprojekt)
            // 2) Wohnung instanzieren und WettersensorMock as Wettersensor im Konstruktor �bergeben.
            // 3) Temperaturvorgabe f�r Wohnzimmer: 19�C
            // ACT
            // 4) Wohnung.GenerateWetterdaten() aufrufen
            // ASSERT
            // 5) Wohnzimmer �berpr�fen, ob Heizungsventil offen


            var wettersensorMock = new WettersensorMock(18, false, 45);
            var wohnung = new Wohnung(wettersensorMock);
            var wetterdaten = new Wetterdaten();
            

            wohnung.GetZimmer();
            wohnung.GenerateWetterdaten();

            // Assert.AreEqual(true, );

            Zimmer.VerarbeiteWetterdaten(wetterdaten);
        }

        public IZimmer GetZimmer(string zimmername)
        {
            return this.zimmerList.FirstOrDefault(x => x.Name == zimmername);
        }

        private static T GetZimmer<T>(Wohnung wohnung, string zimmername)
        {
            var zimmer = wohnung.GetZimmer(zimmername);

            var fi = typeof(ZimmerDecorator).GetField("zimmer", BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                if (zimmer is T)
                {
                    return (T)zimmer;
                }
                zimmer = (IZimmer)fi.GetValue(zimmer);
            }
        }
    }
}