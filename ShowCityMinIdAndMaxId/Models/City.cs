using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowCityMinIdAndMaxId.Models
{
  [Table("City")]
  public class City
  {
    public int Id { get; set; }
    public string Name { get; set; }
     
  }
}