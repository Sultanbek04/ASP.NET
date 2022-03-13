using MVCDBCountryDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDBCountryDapper.Implementations;
using System.Net;
using MVCDBCountryDapper.Models;

namespace MVCDBCountryDapper.Controllers
{
  public class CountryController : Controller
  {
    ICountry db;
    public CountryController()
    {
      db = new CountryDapperService();
    }
    public ActionResult Index()
    {

      return View(db.GetCountries());
    }

    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Country country = db.Get(id);

      if (country == null)
      {
        return HttpNotFound();
      }
      return View(country);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Country country)
    {
      db.Create(country);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Country country = db.Get(id);
      if (country != null)
        return View(country);
      return HttpNotFound();
    }

    [HttpPost]
    public ActionResult Edit(Country country)
    {
      db.Update(country);
      return RedirectToAction("Index");
    }

    [HttpGet]
    [ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
      Country country = db.Get(id);
      if (country != null)
        return View(country);
      return HttpNotFound();
    }
    [HttpPost]
    public ActionResult Delete(int id)
    {
      db.Delete(id);
      return RedirectToAction("Index");
    }
  }
}