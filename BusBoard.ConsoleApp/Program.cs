using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var api = new TflReader();
      
      Console.Write("Enter stop code: ");
      var code = Console.ReadLine();
      api.getPredictions("490008660N");
     // api.getPredictions(code);
    }
  }
}
