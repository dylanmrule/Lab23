using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToMVC.DAL.Models
{
    public class Items : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
      
        public virtual Users Users { get; set; }
    }
}
