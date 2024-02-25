
namespace M320_SmartHome {
    public class Heizungsventil : ZimmerDecorator {
        private bool heizungsventilOffen;
        public Heizungsventil(IZimmer zimmer) : base(zimmer) { }
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur < TemperaturVorgabe) {
                if(!heizungsventilOffen) {
                    Console.WriteLine($"Heizungsventil wird geöffnet.");
                    heizungsventilOffen = true;
                }
            } else {
                if(heizungsventilOffen) {
                    Console.WriteLine($"Heizungsventil wird geschlossen.");
                    heizungsventilOffen = false;
                }
            }
        }
    }
}
