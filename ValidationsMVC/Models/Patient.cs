using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationsMVC.Models
{
  [Table("Patient")]
  public class Patient
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is mandatory")]
    [StringLength(100)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is necessary")]
    [StringLength(100)]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Age is obligatory")]
    [Range(0, 300)]
    public int Age { get; set; }
    [Required(ErrorMessage = "Please choose a gender")]
    public bool IsMan { get; set; }
    [Required(ErrorMessage = "Please let us know is patient ill")]
    public bool IsIll { get; set; }

    public string TypeOfDisease { get; set; }
    [Remote(action: "CheckBalanceOfThePatient", controller: "Patient", ErrorMessage = "Sorry minimum required balance is 100")]
    public decimal AccountBalance { get; set; }

    [Remote(action: "IsAcceptableInsurance", controller: "Patient", ErrorMessage ="We don't accept your Insurance")]
    public string NameOfInsurance { get; set; }

    [EmailAddress]
    public string Email { get; set; }


  
  }
}