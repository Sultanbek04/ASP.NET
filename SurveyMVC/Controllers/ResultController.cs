using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyMVC.Controllers
{
  public class ResultController : Controller
  {
    // GET: Result
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult ShowResult()
    {
      return View();
    }
  }
}