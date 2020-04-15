using IntroToMVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToMVC.DAL
{
    public class IntroToMVCContext : DbContext
    {
        public IntroToMVCContext()
        {

        }
        public IntroToMVCContext(DbContextOptions<IntroToMVCContext> options) : base(options)
        {

        }
        public DbSet<Users> Users {get; set;}
        public DbSet<Items> Items { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-2QC4EM5C\\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany<Items>(i => i.Items)
                .WithOne(u => u.Users);
                //.HasForeignKey(k => k.UsersId);


            Seed(modelBuilder);
        }


        public static void Seed (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasData((new Users[]
                {
                    new Users()
                    {
                        Id = 1,
                        Username = "dylanmrule",
                        Password = "hello",
                        Money= 150

                    }
                }));
            modelBuilder.Entity<Items>()
                .HasData((new Items[]
                {
                    new Items()
                    {
                        Id = 1,
                        Name = "Snickers",
                        Description = "Candy Bar",
                        Quantity = 4,
                        Price = .75
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Moxie",
                        Description = "12oz Can",
                        Quantity = 5,
                        Price = 1.00
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "Fluffernutter",
                        Description = "Peanut Butter and Marshmallow Fluff Sandwich",
                        Quantity = 6,
                        Price = 2.50
                    },
                       new Items()
                    {
                        Id = 4,
                        Name = "New England Fish Chowder",
                        Description = "Chowder with haddock and potatoes",
                        Quantity = 2,
                        Price = 7.45
                    },
                          new Items()
                    {
                        Id = 5,
                        Name = "French-Canadian Poutine",
                        Description = "French fries topped with cheese curds and brown gravy",
                        Quantity = 1,
                        Price = 8.99
                    }
                }));
        }
    }

    
}
