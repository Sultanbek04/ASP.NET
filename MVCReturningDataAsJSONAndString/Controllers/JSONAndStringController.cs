using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCReturningDataAsJSONAndString.Context;
using MVCReturningDataAsJSONAndString.Models;

namespace MVCReturningDataAsJSONAndString.Controllers
{
  public class JSONAndStringController : Controller
  {
    // GET: JSONAndString
    private DB db = new DB();

    // GET: Student
    public JsonResult Index()
    {
      return Json(db.Student.ToList(), JsonRequestBehavior.AllowGet);
    }

    public string GetAreaFormulaOfCircle()
    {
      return "π*r^2";
    }

  }
}