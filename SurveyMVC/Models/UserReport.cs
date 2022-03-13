using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyMVC.Models
{
  public class UserReport
  {
    public DateTime DateOfTheTest { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Percentage { get; set; }

  }
}