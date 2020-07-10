using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;
using BusBoard.Api;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    TflApi tflApi = new TflApi();
    PostcodeApi coordsApi = new PostcodeApi();

    public ActionResult Index() {
      Session["stops"] = null;
      if (TempData["NoPostcode"] != null) {
        ViewBag.Message = "Postcode not recognised";
        TempData.Remove("NoPostcode");
      }
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection) {
      if (Session["stops"] == null) {
        var coords = coordsApi.GetCoordsIfExists(selection.Postcode);
        if (coords == null) {
          TempData["NoPostcode"] = true;
          return RedirectToAction("Index");
        }
        Session["stops"] = tflApi.GetStopCodes(coords);
      }

      var stopData = new Dictionary<StopId, List<Destination>>();
      foreach (var stop in (List<StopId>)Session["stops"]) {
        var destList = new List<Destination>();
        var predictions = tflApi.GetPredictions(stop.NaptanId);
        var a = predictions.GroupBy(arrival => arrival.DestinationName).ToList();
        foreach (var dest in a) {
          destList.Add(new Destination() {DestinationName = dest.Key, Arrivals = dest.ToList()});
        }
        stopData[stop] = destList;
      }
      
      
    //  var stopData = ((List<StopId>)Session["stops"]).ToDictionary(
     //   stop => stop, stop => tflApi.GetPredictions(stop.NaptanId));
      
      var info = new BusInfo(selection.Postcode, stopData);
      
      Response.AddHeader("Refresh", "30");
      return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}