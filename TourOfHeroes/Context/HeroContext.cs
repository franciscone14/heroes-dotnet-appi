using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Models;

namespace TourOfHeroes.Context
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        
        //DbSet representa uma tupla na tabela do banco de dados
        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}