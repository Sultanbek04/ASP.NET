using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAjaxMVC.Models
{
  [Table("City")]
  public class City
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
  }
}
