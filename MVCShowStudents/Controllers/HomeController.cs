using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCShowStudents.Models;

namespace MVCShowStudents.Controllers
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

    public ActionResult ShowStundets()
    {
      CultureInfo provider = CultureInfo.InvariantCulture;
      List<Student> list = new List<Student>()
      {
        new Student{ Id=1, LastName="Myrzakhmet", Birthday=DateTime.Parse("04/26/2004") },
        new Student {Id=2, LastName="Nurimov", Birthday=DateTime.Parse("10/21/2001")},
        new Student {Id=3, LastName="Baibatyrov", Birthday=DateTime.Parse("10/21/1976")}

    };
      return View(list);
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}