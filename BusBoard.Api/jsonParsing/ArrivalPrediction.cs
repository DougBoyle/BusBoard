using System.Collections.Generic;

namespace BusBoard.Api {
    public class ArrivalPrediction : IEqualityComparer<ArrivalPrediction> {
        public string DestinationName { get; set; }
        public string StationName { get; set; }
        public int TimeToStation { get; set; }

        public override string ToString() {
            return $"Bus to {DestinationName} arrives in {TimeToStation/60} minutes";
        }

        public bool Equals(ArrivalPrediction x, ArrivalPrediction y) {
            if (x == null && y == null) return true;
            if (x == null) return false;
            return x.StationName == y.StationName && x.DestinationName == y.DestinationName &&
                   x.TimeToStation == y.TimeToStation;
        }

        public int GetHashCode(ArrivalPrediction obj) {
            return TimeToStation.GetHashCode();
        }
    }
}