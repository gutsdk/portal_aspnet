﻿using Microsoft.EntityFrameworkCore;
using BackendProj.Models;


namespace BackendProj.Controllers
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb2;Username=postgres;Password=password");
        }
    }
}