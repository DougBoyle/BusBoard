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
      Console.WriteLine("Reset");
      return View(new PostcodeSelection() {MaxStops = 2, Radius = 800});
    }
    
    public ActionResult IndexWithPrefs(PostcodeSelection selection) {
      Session["stops"] = null;
      if (TempData["NoPostcode"] != null) {
        ViewBag.Message = "Postcode not recognised";
        TempData.Remove("NoPostcode");
      }
      return View("Index", selection);
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection) {
      Console.WriteLine(selection.Radius);
      Console.WriteLine(selection.MaxStops);
      if (selection.Radius == 0) {
        selection.Radius = 800;
      }

      if (selection.MaxStops == 0) {
        selection.MaxStops = 2;
      }
      if (Session["stops"] == null) {
        var coords = coordsApi.GetCoordsIfExists(selection.Postcode);
        if (coords == null) {
          TempData["NoPostcode"] = true;
          return RedirectToAction("IndexWithPrefs", selection);
        }
        Session["stops"] = tflApi.GetStopCodes(coords, selection.Radius, selection.MaxStops);
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