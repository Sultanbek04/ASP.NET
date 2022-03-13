using ShowCityMinIdAndMaxId.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShowCityMinIdAndMaxId.Context
{
  public class DB : DbContext
  {
    public DB() : base("name=connStr") { }

    public DbSet<City> City { get; set; }
  }
}