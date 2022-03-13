using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyMVC.Models
{
  public class Result
  {
    public int AmountOfQuestions { get; set; }
    public int NumberOfCorrectAnswers { get; set; }
    public TimeSpan TimeTaken { get; set; }
    public float CompletionRate { get; set; }

  }
}