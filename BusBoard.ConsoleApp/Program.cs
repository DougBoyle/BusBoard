using System;
namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var api = new TflReader();
      
      Console.Write("Enter stop code: ");
      var code = Console.ReadLine(); 
      //api.GetPredictions("490008660N");
      api.GetPredictions(code);
    }
  }
}
