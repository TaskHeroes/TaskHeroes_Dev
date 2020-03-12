using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.Data
{
    public class TaskHeroesDbContext : DbContext
    {
        public TaskHeroesDbContext(DbContextOptions<TaskHeroesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Posting> Postings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Posting>().ToTable("Postings");
        }
    }
}
