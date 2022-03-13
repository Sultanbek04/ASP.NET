using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSignUpDapper.Models
{
  [Table("User")]
  public class User
  {
    public int Id { get;set; }
    public string Login { get;set; }
    public string Password {  get; set; }

  }
}