using Dapper;
using SurveyMVC.Abstract;
using SurveyMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyMVC.Implementation
{
  public class ServiceDapperResult : IResult
  {
    public int InsertResult(Result result)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {

      
        return db.Query<int>("InsertResult @AmountOfQuestions, @NumberOfCorrectAnswers, @TimeTaken, @CompletionRate",
           new { result.AmountOfQuestions, result.NumberOfCorrectAnswers, result.TimeTaken, result.CompletionRate }).FirstOrDefault();
       


      }
    }
  }
}