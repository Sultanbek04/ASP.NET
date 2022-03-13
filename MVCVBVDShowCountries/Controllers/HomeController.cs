using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVBVDShowCountries.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult ShowCountries()
    {
      List<Country> countries=new List<Country>()
      {
        new Country { Id=1, Name="Kazakhstan"},
        new Country {Id=2, Name="Russia" },
        new Country {Id=3, Name="USA" },
      };

      ViewBag.Countries=countries;
      ViewData["country"]=countries;
      return View(countries);
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}