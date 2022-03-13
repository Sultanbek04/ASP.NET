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
  public class ServiceDapperUser : IUser
  {
    public int CreateUser(User user)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
       return db.Query<int>("InsertUser @FirstName, @LastName", new { user.FirstName, user.LastName }).FirstOrDefault();

      }
    }
  }
}