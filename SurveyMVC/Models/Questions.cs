using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurveyMVC.Models
{
  [Table("Questions")]
  public class Questions
  {
    public string NameOfCreatorThisApp { get; set; }
    public int NumberOfApplesInTheWorld { get; set; }
    public string MyRoleModel { get; set; }
    public string TheBestHumanEver { get; set; }
    public int AgeOfCreatorThisApp { get; set; }


  }
}