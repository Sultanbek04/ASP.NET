using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayOutMVC.Controllers
{
    public class ShowLayoutController : Controller
    {
        // GET: ShowLayout
        public ActionResult Index()
        {
              
            return View();
        }
    }
}