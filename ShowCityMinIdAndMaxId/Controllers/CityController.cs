using ShowCityMinIdAndMaxId.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowCityMinIdAndMaxId.Models;

namespace ShowCityMinIdAndMaxId.Controllers
{
  public class CityController : Controller
  {
    // GET: City
    private DB db = new DB();
    public ActionResult Index()
    {
      return View(db.City.ToList());
    }
  }
}