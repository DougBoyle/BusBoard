using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, Dictionary<StopId, List<Destination>> stopData)
    {
      PostCode = postCode;
      StopData = stopData;
    }

    public string PostCode { get; set; }
    public Dictionary<StopId, List<Destination>> StopData { get; set; }

  }
}