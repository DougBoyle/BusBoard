using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.Api {
    public class TflApi {
        RestClient Client = new RestClient("https://api.tfl.gov.uk");
        
        public List<ArrivalPrediction> GetPredictions(string stopCode) {
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", Method.GET);
            var arrivalList = Client.Execute<List<ArrivalPrediction>>(request).Data;

            return arrivalList.OrderBy(arrival => arrival.TimeToStation).Take(5).ToList();
        }

        public List<StopId> GetStopCodes(Coords coords, int r = 800, int maxStops = 2) {
            // NaptanOnstreetBusCoachStopPair, NaptanOnstreetBusCoachStopCluster, NaptanPublicBusCoachTram
            var request = new RestRequest($"StopPoint?stopTypes=NaptanPublicBusCoachTram&modes=bus", Method.GET);
            request.AddQueryParameter("lat", coords.Latitude.ToString());
            request.AddQueryParameter("lon", coords.Longitude.ToString());
            request.AddQueryParameter("radius", r.ToString());
            var result = Client.Execute<BusStopResults>(request).Data.StopPoints;
            return result.OrderBy(x => x.Distance).Take(maxStops).ToList();
        }
    }
}