using System;
using System.ComponentModel.DataAnnotations;

namespace IntroToMVC.DAL
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set;}

    }
}
