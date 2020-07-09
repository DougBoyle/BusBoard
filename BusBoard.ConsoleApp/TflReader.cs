using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp {
    public class TflReader {
        RestClient Client = new RestClient("https://api.tfl.gov.uk");
        
        public void getPredictions(string stopCode) {
            var request = new RestRequest($"StopPoint/{stopCode}/Arrivals", Method.GET);
            var ar = Client.Execute<List<ArrivalPrediction>>(request).Data;
          
            ar = ar.OrderBy(x => x.timeToStation).ToList();
            var i = 0;
            foreach (var obj in ar) {
                i++;
                Console.WriteLine(obj);
                if (i == 5) {
                    break;
                }
            }
        }
    }
}