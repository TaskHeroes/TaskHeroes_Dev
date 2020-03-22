﻿using Microsoft.EntityFrameworkCore;

namespace TaskHeroes.Data
{
    public class TaskHeroesDbContext : DbContext
    {
        public TaskHeroesDbContext(DbContextOptions<TaskHeroesDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Task>().ToTable("Tasks");
        }
    }
}
