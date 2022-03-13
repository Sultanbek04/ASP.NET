using StudentsDBMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsDBMVC.Context
{
  public class DB : DbContext
  {
    public DB() : base("name=connStr") { }

    public DbSet<Student> Student { get; set; }

  }
}