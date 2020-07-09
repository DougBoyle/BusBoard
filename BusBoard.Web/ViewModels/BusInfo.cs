using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, Dictionary<StopId, List<ArrivalPrediction>> stopData)
    {
      PostCode = postCode;
      StopData = stopData;
    }

    public string PostCode { get; set; }
    public Dictionary<StopId, List<ArrivalPrediction>> StopData { get; set; }

  }
}