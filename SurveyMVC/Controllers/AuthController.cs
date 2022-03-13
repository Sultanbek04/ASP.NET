using SurveyMVC.Abstract;
using SurveyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyMVC.Controllers
{
  public class AuthController : Controller
  {
    IUser user;
 
    public AuthController() { }
    public AuthController(IUser user_)
    {
      user = user_;
    }
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public ActionResult GetName()
    {
      return View();
    }

    [HttpPost]
    public ActionResult GetName(User userResult)
    {
      user.CreateUser(userResult);
   
      

      return RedirectToAction("ShowQuestions", "Questions", userResult  );
    }
  }
}