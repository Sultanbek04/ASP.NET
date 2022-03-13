using Dapper;
using MVCSignUpDapper.Abstract;
using MVCSignUpDapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCSignUpDapper.Implementations
{
  public class UserDapperService : IUser
  {
    public User Get(string login)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        return db.Query<User>("SELECT * FROM [User] WHERE Login = @login", new { login }).FirstOrDefault();
      }
    }

    public void Create(User user)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "INSERT INTO [User] (Login, Password) VALUES(@Login, @Password)";
        db.Execute(sqlQuery, user);
      }
    }

    public void Update(User user)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "UPDATE [User] SET Login = @Login, Password = @Password WHERE Id = @Id";
        db.Execute(sqlQuery, user);
      }
    }

    public void Delete(int id)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "DELETE FROM [User] WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
      }
    }
  }
}