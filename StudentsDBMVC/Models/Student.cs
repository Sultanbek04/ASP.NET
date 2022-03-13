using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDBMVC.Models
{
  [Table("Student")]
  public class Student
  {
    public int Id { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }

  }
}