﻿
using HappyEnglishWebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HappyEnglishWebApi.DAL
{

    public class ApplicationDbContext : DbContext
    {
        private IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration localconfiguration)
            : base(options)
        {
            Configuration = localconfiguration;
        }
        public DbSet<Gamer> Gamer { get; set; }
        public DbSet<Word> Word { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gamer>().HasData(new Gamer() { Id = 1, FirstName = "Anton", LastName = "Lukyantsev", Age = 32 });
            modelBuilder.Entity<Word>().HasData(new Word() { Id = 1, Value = "Anton" });
        }
    }

}