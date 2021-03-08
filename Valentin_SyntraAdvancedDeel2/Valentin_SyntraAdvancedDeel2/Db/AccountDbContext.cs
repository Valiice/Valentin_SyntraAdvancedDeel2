using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Db
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<House> Houses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=account.db");
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Person>().HasData(
        //        new Person
        //        {
        //            Id = 1,
        //            FirstName = "Valentin",
        //            LastName = "Claes",
        //            Email = "valentinclaes@live.be",
        //            Password = "abc123",
        //        },
        //        new Person
        //        {
        //            Id = 2,
        //            FirstName = "Lucia",
        //            LastName = "Thomas",
        //            Email = "idklol",
        //            Password = "huh123",
        //        });
        //    builder.Entity<Pet>().HasData(
        //        new Pet
        //        {
        //            Id = 1,
        //            Name = "Jos",
        //            OwnerId = 1,
        //            PetType = "Cat"
        //        },
        //        new Pet
        //        {
        //            Id = 2,
        //            Name = "Richard",
        //            OwnerId = 1,
        //            PetType = "Cat"
        //        },
        //        new Pet
        //        {
        //            Id = 3,
        //            Name = "Soezie",
        //            OwnerId = 2,
        //            PetType = "Dog"
        //        });
        //}
    }
}
