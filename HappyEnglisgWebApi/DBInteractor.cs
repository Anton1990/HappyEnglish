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
//using HappyEnglishClassLibrary;
using HappyEnglisgWebApi.Model;
using System.Configuration;

namespace HappyEnglisgWebApi
{
    
       public class DBInteractor : DbContext
    {

        private IConfiguration Configuration;


        //Class constructor. Without this cinstructor don't correct work UseSqlite(Configuration.GetConnectionString("MyDb1"));
        public DBInteractor(DbContextOptions<DBInteractor> options, IConfiguration localconfiguration)
            : base(options)
        {
            Configuration = localconfiguration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder
            // .UseSqlite(@"Data Source = GameDB.db;");

            optionsBuilder.UseSqlite(Configuration.GetConnectionString("MyDb1"));
            


        }
      
        public DbSet<Gamer> Gamer { get; set; }
        public DbSet<Word> Word { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gamer>().HasData(

            new Gamer() { Id = 1, FirstName = "Anton", LastName = "Lukyantsev", Age = 32 }
          
            );

           modelBuilder.Entity<Word>().HasData(

           new Word() { Id = 1, Value = "Anton" }

           );





        }
    }
}