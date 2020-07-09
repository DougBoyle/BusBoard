using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp {
    public class TflReader {
        RestClient Client = new RestClient("https://api.tfl.gov.uk");
        
        public void GetPredictions(string stopCode) {
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", Method.GET);
            var arrivalList = Client.Execute<List<ArrivalPrediction>>(request).Data;

            arrivalList.OrderBy(arrival => arrival.TimeToStation).Take(5).ToList()
                .ForEach(arrival => Console.WriteLine(arrival));
        }
    }
}