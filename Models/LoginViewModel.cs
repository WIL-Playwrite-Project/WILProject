using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class LoginViewModel
    {

      [Required]
      [Display(Name = "Email")]
      public String email {get; set;}

      [Required]
      [Display(Name = "Password")]
      public String password {get;set;}

    }
}