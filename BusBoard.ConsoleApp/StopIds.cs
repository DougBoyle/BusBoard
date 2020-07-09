using System.Collections.Generic;
namespace BusBoard.ConsoleApp {
    public class StopIds {
        public List<Stop> StopPoints { get; set; }
    }

    public class Stop {
        public string NaptanId { get; set; }
        public string CommonName { get; set; }
        public double Distance { get; set; }
    }
}