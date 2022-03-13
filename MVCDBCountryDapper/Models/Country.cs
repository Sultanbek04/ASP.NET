using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDBCountryDapper.Models
{
  [Table("Country")]
  public class Country
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public string Capital { get; set; }

  }
}