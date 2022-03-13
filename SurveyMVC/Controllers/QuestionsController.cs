using SurveyMVC.Abstract;
using SurveyMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SurveyMVC.Controllers
{

  public class QuestionsController : Controller
  {
    // GET: Questions

    IResult db;

    public QuestionsController(IResult db_)
    {
      db = db_;
    }

    private Stopwatch timer = new Stopwatch();
    private Result result = new Result();
    private float percentage = 0;
    private int amountOfQuestions = 5;


    static UserReport userReport = new UserReport();
  

    private Questions rightAnswers = new Questions()
    {
      NameOfCreatorThisApp = "Sultanbek",
      AgeOfCreatorThisApp = 17,
      MyRoleModel = "Elon Musk",
      NumberOfApplesInTheWorld = 100,
      TheBestHumanEver = "Sultanbek"
    };
    public ActionResult Index()
    {
      return View();
    }
   
    public ActionResult ShowQuestions(User userResult) { 
   
      userReport.FirstName = userResult.FirstName;
      userReport.LastName = userResult.LastName;
      userReport.DateOfTheTest = DateTime.Now;

      timer.Start();


      return View();
    }
    [HttpPost]
    public ActionResult ShowQuestions(Questions questions)
    {
     
      float addPercents = 100 / amountOfQuestions;
      if (questions.TheBestHumanEver == rightAnswers.TheBestHumanEver)
      {
        percentage += addPercents;
      }
      if (questions.NumberOfApplesInTheWorld == rightAnswers.NumberOfApplesInTheWorld)
      {
        percentage += addPercents;
      }
      if (questions.NameOfCreatorThisApp == rightAnswers.NameOfCreatorThisApp)
      {
        percentage += addPercents;
      }
      if (questions.MyRoleModel == rightAnswers.MyRoleModel)
      {
        percentage += addPercents;
      }
      if (questions.AgeOfCreatorThisApp == rightAnswers.AgeOfCreatorThisApp)
      {
        percentage += addPercents;
      }
      timer.Stop();


      result.AmountOfQuestions = amountOfQuestions;
      result.CompletionRate = percentage;
      result.NumberOfCorrectAnswers = Convert.ToInt32((amountOfQuestions * (percentage / 100)));
      result.TimeTaken = timer.Elapsed;
      userReport.Percentage=percentage;
   
      db.InsertResult(result);
      return RedirectToAction("ShowReport");
    }

    public ActionResult ShowReport()
    {


      return View(userReport);
      
    }



  }
}