﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().ToTable("Skills");
        }
    }
}
