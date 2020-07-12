using System.Collections.Generic;

namespace BusBoard.Api {
    public class StopId : IEqualityComparer<StopId> {
        public string NaptanId { get; set; }
        public string CommonName { get; set; }
        public double Distance { get; set; }

        public override bool Equals(object obj) {
            if (obj != null && obj is StopId id) {
                return NaptanId == id.NaptanId;
            }
            return false;
        }

        public override int GetHashCode() {
            return NaptanId.GetHashCode();
        }

        public bool Equals(StopId x, StopId y) {
            if (x == null && y == null) return true;
            if (x == null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(StopId obj) {
            return obj.GetHashCode();
        }
    }
}