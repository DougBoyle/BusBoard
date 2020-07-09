using System;

namespace BusBoard.ConsoleApp {
    public class ArrivalPrediction {
        public string DestinationName { get; set; }
        public string StationName { get; set; }
        public int TimeToStation { get; set; }

        public override string ToString() {
            var t = TimeSpan.FromSeconds(TimeToStation);
            return $"Bus to {DestinationName} arrives in {t.ToString("m':'ss")} minutes";
        }
    }
}