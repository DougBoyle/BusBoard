using System;
namespace BusBoard.ConsoleApp
{
  class Program
  {
    // NW5 1TL
    // "490008660N
    static void Main(string[] args)
    {
      var tflApi = new TflApi();
      var coordsApi = new PostcodeApi();

      var postcode = Console.ReadLine();
      var coords = coordsApi.GetCoordsIfExist(postcode);
      if (coords == null) {
        Console.WriteLine($"Postcode not recognised: {postcode}");
        return;
      }


      var stops = tflApi.GetStopCodes(coords);
      if (stops.Count == 0) {
        Console.WriteLine("No bus stops nearby");
      }
      foreach (var stop in stops) {
        Console.WriteLine($"At {stop.CommonName}:");
        tflApi.GetPredictions(stop.NaptanId);
        Console.WriteLine();
      }
    }
  }
}
