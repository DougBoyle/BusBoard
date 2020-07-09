namespace BusBoard.Api {
    public class ArrivalPrediction {
        public string DestinationName { get; set; }
        public string StationName { get; set; }
        public int TimeToStation { get; set; }

        public override string ToString() {
            return $"Bus to {DestinationName} arrives in {TimeToStation/60} minutes";
        }
    }
}