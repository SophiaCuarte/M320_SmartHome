using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace M320_SmartHome.Tests
{
    public class WettersensorMock : iWettersensor
    {
        private Wetterdaten Wetterdaten { get; set; }
        public WettersensorMock(double aussentemperatur, bool regen, double wind)
        {
            this.Wetterdaten = new Wetterdaten()
            {
                Aussentemperatur = aussentemperatur,
                Regen = regen, 
                Windgeschwindigkeit = wind
            };
        }
        public Wetterdaten GetWetterdaten()
        {
            return this.Wetterdaten;
        }
    }
}
