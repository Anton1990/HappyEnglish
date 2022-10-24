using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

using HappyEnglisgWebApi.Model;

namespace HappyEnglisgWebApi
{

    public class DBInteractor1 : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source = GameDB1.db;");
        }

        public DbSet<Gamer> Gamer { get; set; }
        public DbSet<Word> Word { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gamer>().HasData(

            new Gamer() { Id = 1, FirstName = "Anton1", LastName = "Lukyantsev1", Age = 321 }

            );

            modelBuilder.Entity<Word>().HasData(

            new Word() { Id = 1, Value = "Anton" }

            );





        }
    }
}