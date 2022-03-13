using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationsMVC.Models;

namespace ValidationsMVC.Controllers
{
  public class PatientController : Controller
  {
    // GET: Patient
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient)
    {
      return View();
    }

    public ActionResult Edit()
    {
      return View();
    }

    public ActionResult CheckBalanceOfThePatient(decimal accountBalance)
    {
      if (accountBalance < 100)
      {
        return Json(false, JsonRequestBehavior.AllowGet);
      }
      return Json(true, JsonRequestBehavior.AllowGet);
    }

    public ActionResult IsAcceptableInsurance(string nameOfInsurance)
    {
      string[] acceptableInsurances = new string[]
      {
        "Sultanbek is The Best",
        "Sultanbek is The Smartest",
        "Sultanbek is a genius"
      };

      for (int i = 0; i < acceptableInsurances.Length; ++i)
      {
        if (nameOfInsurance == acceptableInsurances[i])
        {
          return Json(true, JsonRequestBehavior.AllowGet);
        }

      }
      return Json(false, JsonRequestBehavior.AllowGet);
    }
  }
}