﻿using AuthenticationAuthorization.Domain.Core.Models;
using AuthenticationAuthorization.Infrastrucnure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Persistence.Contexts
{
    public class ApplicationContext:DbContext
    {
        private string CONNECTION_STRING = "User ID=postgres;Password=123;Host=localhost;Port=5432;Database=Auth;";
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
