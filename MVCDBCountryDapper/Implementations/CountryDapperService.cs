using MVCDBCountryDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using MVCDBCountryDapper.Models;

namespace MVCDBCountryDapper.Implementations
{
  public class CountryDapperService : ICountry
  {

    public List<Country> GetCountries()
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        return db.Query<Country>("SELECT Id, Name, Capital FROM [Country]").ToList();

      }
    }

    public Country Get(int? id)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        return db.Query<Country>("SELECT * FROM Country WHERE Id = @id", new { id }).FirstOrDefault();
      }
    }

    public void Create(Country country)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "INSERT INTO Country (Name, Capital) VALUES(@Name, @Capital)";
        db.Execute(sqlQuery, country);
      }
    }

    public void Update(Country country)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "UPDATE Country SET Name = @Name, Capital = @Capital WHERE Id = @Id";
        db.Execute(sqlQuery, country);
      }
    }

    public void Delete(int id)
    {
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        var sqlQuery = "DELETE FROM Country WHERE Id = @id";
        db.Execute(sqlQuery, new { id });
      }
    }

  }
}