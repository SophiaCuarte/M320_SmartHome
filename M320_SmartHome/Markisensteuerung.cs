namespace M320_SmartHome {
    public class Markisensteuerung : ZimmerDecorator {
        private bool markiseEingefahren;
        public Markisensteuerung(IZimmer zimmer) : base(zimmer) { }
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur > TemperaturVorgabe) {
                if(markiseEingefahren) {
                    if(wetterdaten.Regen) {
                        Console.WriteLine("Markise kann nicht ausgefahren werden weils regnet.");
                    } else {
                        Console.WriteLine("Markise wird ausgefahren.");
                        markiseEingefahren = false;
                    }
                } else if(wetterdaten.Regen && !markiseEingefahren) {
                    Console.WriteLine("Markise wird eingefahren weils regnet.");
                    markiseEingefahren = true;
                }
            } else {
                if(!markiseEingefahren) {
                    Console.WriteLine("Markise wird eingefahren.");
                    markiseEingefahren = true;
                }
            }
        }
    }
}
