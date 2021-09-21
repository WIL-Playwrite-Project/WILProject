using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Activity
    {

        [Required]
        [Display(Name = "Category")]
        public String category { get; set; }

        [Required]
        [Display(Name = "Title")]
        public String title { get; set; }

        [Required]
        [Display(Name = "Tips")]
        public String tips { get; set; }

        public string mediaUrl { get; set; }
        
    }
}