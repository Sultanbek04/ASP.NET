using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MyAjaxMVC.Models;

namespace MyAjaxMVC.Controllers
{
  public class CityController : Controller
  {
    // GET: City
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult CityFindBySymbol(string symbol)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var list = db.Query<City>("GetAllCities");


        return PartialView(list.Where(s => s.Name.Contains(symbol)));
      }
    }

  }
}
