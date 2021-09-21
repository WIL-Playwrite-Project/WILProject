using System;
using System.Collections.Generic;

namespace MvcDemo.Models
{
    public class Phase
    {
        
        public String title {get; set;}
        public List<String> milestones {get; set;}
        public List<String> warnings {get; set;}
        public String tips {get; set;}

        public String imageUrl {get; set; }
       
      
    }
}