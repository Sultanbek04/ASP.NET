using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSignUpDapper.Abstract;
using MVCSignUpDapper.Implementations;
using MVCSignUpDapper.Models;

namespace MVCSignUpDapper.Controllers
{
  public class AccountController : Controller
  {
    // GET: Account
    IUser db;

    
    public AccountController()
    {
      db = new UserDapperService();
    }
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public ActionResult SignUp()
    {

      return View();
    }

    [HttpPost]
    public ActionResult SignUp(User user)
    {
      if (user.Login == null || user.Password == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
      }

      User userCheck = db.Get(user.Login);

      if (userCheck != null)
        return Content("Sorry, this login is unavaliable");

      db.Create(user);

     

      return RedirectToAction("Index", "Home");


    }
  }
}