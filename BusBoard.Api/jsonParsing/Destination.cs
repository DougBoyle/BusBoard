using System.Collections.Generic;

namespace BusBoard.Api {
    public class Destination {
        public string DestinationName { get; set; }
        public List<ArrivalPrediction> Arrivals { get; set; }

        public override string ToString() {
            if (Arrivals.Count == 1) {
                return $"Bus to <b>{DestinationName}</b> arrives in {Arrivals[0].TimeToStation / 60} minutes.";
            }
            var s = $"Buses to <b>{DestinationName}</b> arrive in ";
            for (var i = 0; i < Arrivals.Count; i++) {
                s += Arrivals[i].TimeToStation / 60;
                if (i == Arrivals.Count - 1) {
                    s += " minutes.";
                }
                else if (i == Arrivals.Count - 2) {
                    s += " and ";
                } else {
                    s += ", ";
                }
            }
            return s;
        }
    }
}