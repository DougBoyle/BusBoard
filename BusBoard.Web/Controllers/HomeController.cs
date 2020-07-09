using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;
using BusBoard.Api;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    TflReader tflApi = new TflReader();
    PostcodeApi coordsApi = new PostcodeApi();
    
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
      // Add some properties to the BusInfo view model with the data you want to render on the page.
      // Write code here to populate the view model with info from the APIs.
      // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
      var coords = coordsApi.getCoords(selection.Postcode);
      var stops = tflApi.GetStopCodes(coords);
      var stopData = stops.ToDictionary(
        stop => stop, stop => tflApi.GetPredictions(stop.NaptanId));
      
      var info = new BusInfo(selection.Postcode, stopData);
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