using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShowStudents.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
  }
}