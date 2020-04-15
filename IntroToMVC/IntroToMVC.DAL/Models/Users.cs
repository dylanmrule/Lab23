using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToMVC.DAL.Models
{
    public class Users
    {
      
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Money { get; set; }

        public ICollection<Items> Items { get; set; }
    }
}
