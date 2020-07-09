using System;
namespace BusBoard.ConsoleApp
{
  class Program
  {
    // NW5 1TL
    // "490008660N
    static void Main(string[] args)
    {
      var tflApi = new TflReader();
      var coordsApi = new PostcodeApi();

      var postcode = Console.ReadLine();
      //var coords = coordsApi.getCoords("NW5 1TL");
      var coords = coordsApi.getCoords(postcode);

      var stops = tflApi.GetStopCodes(coords);
      
      foreach (var stop in stops) {
        Console.WriteLine($"At {stop.CommonName}:");
        tflApi.GetPredictions(stop.NaptanId);
        Console.WriteLine();
      }
    }
  }
}
