using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class MilestoneViewModel
    {
        [Required]
       [Display(Name = "Category")]
        public String category {get; set;}

         [Required]
         [Display(Name = "Title")]
        public String title {get; set;}

         [Required]
         [Display(Name = "Milestones")]
        public String milestones {get; set;}


         [Required]
         [Display(Name = "Keep an eye out for")]
        public String warnings {get; set;}

         
        [Display(Name = "Tips")]
        public String tips {get; set;}
        
        public String imageUrl {get; set; }
       
    }
}