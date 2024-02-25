namespace M320_SmartHome {
    public class Jalousiensteuerung : ZimmerDecorator {
        private bool jalousieOffen;
        public Jalousiensteuerung(IZimmer zimmer) : base(zimmer) { }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur > TemperaturVorgabe) {
                if(jalousieOffen) {
                    if(PersonenImZimmer) {
                        Console.WriteLine("Jalousie kann nicht geschlossen werden weil Personen im Zimmer sind.");
                    } else {
                        Console.WriteLine($"Jalousie wird geschlossen.");
                        jalousieOffen = false;
                    }
                }
            } else {
                if(!jalousieOffen) {
                    Console.WriteLine("Jalousie wird geöffnet.");
                    jalousieOffen = true;
                }
            }
        }
    }
}