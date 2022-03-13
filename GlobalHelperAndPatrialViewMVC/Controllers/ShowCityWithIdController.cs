using GlobalHelperAndPatrialViewMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalHelperAndPatrialViewMVC.Controllers
{
  public class ShowCityWithIdController : Controller
  {
    // GET: ShowCityWithId
    public ActionResult Index()
    {
      List<City> cities = new List<City>()
      {
        new City {Id=1, Name="Astana" , Population=1200000 },
        new City {Id=2, Name="Almaty", Population=200000 }
      };
      return View(cities);
    }

    public ActionResult GetCities()
    {
      return PartialView();
    }
  }
}