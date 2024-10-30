using Microsoft.EntityFrameworkCore;
using Savings.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savings.Migrations
{
    public  class SavingsDbContext:DbContext
    {
        public SavingsDbContext(DbContextOptions<SavingsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accountnumbers { get; set; }
        public DbSet<Model.Entity.Savings> Savingsss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Account>().ToTable("AccountNumbers");
            modelBuilder.Entity<Savings>().ToTable("Savingsss");
        }
    }
}
