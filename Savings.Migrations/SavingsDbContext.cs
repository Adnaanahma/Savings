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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Model.Entity.Savingss> Savingsss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Savingss>().ToTable("Savingss");
        }
    }
}
