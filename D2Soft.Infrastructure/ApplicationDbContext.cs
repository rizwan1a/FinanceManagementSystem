using D2Soft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Soft.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    Id = 1,
                    AccountName="Current"
                },
                 new AccountType
                 {
                     Id = 2,
                     AccountName = "Saving"
                 },
                 new AccountType
                 {
                     Id = 3,
                     AccountName = "Checking"
                 },
                  new AccountType
                  {
                      Id = 4,
                      AccountName = "Investment"
                  }
            );
        }
    }
}
