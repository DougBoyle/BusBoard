using System;

namespace BusBoard.ConsoleApp {
    public class ArrivalPrediction {
        public string destinationName { get; set; }
        public string stationName { get; set; }
        public int timeToStation { get; set; }

        public override string ToString() {
            var t = TimeSpan.FromSeconds(timeToStation);
            return $"Bus to {destinationName} arrives in {t.ToString("m':'ss")} minutes";
        }
    }
}