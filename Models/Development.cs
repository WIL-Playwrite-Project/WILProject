using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Development
    {
        
      [Required]
      [Display(Name = "Category")]  
      public String category {get; set;}

      public List<Phase> catMilestones {get; set; }
       
      
    }
}