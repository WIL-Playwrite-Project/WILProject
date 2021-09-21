using System;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class PwUser
    {

       [Required]
      [Display(Name = "Email")]
      public String email {get; set;}

      [Required]
      [Display(Name = "Password")]
       public String password {get; set;}

      [Required]
      [Display(Name = "First Name")]
      public String fName {get; set;}

       [Required]
      [Display(Name = "Last Name")]
      public String lName {get;set;}

     [Required]
      [Display(Name = "Role")]
      public String role {get;set;}

    }
}