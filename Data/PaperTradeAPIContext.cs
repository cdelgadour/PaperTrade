using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaperTradeAPI.Models;

namespace PaperTradeAPI.Data
{
    public class PaperTradeAPIContext : DbContext
    {
        public PaperTradeAPIContext (DbContextOptions<PaperTradeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PaperTradeAPI.Models.User> User { get; set; }

        public DbSet<PaperTradeAPI.Models.Wallet> Wallet { get; set; }

        public DbSet<PaperTradeAPI.Models.Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "test@test.com",
                    Password = "test"
                }
            );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet
                {
                    Id = 1,
                    Currency = (Currency)0,
                    Balance = 2000.00m,
                    UserId = 1
                },
                new Wallet
                {
                    Id = 2,
                    Currency = (Currency)1,
                    Balance = 2000.00m,
                    UserId = 1
                },
                new Wallet
                {
                    Id = 3,
                    Currency = (Currency)2,
                    Balance = 2000.00m,
                    UserId = 1
                }
            );


        }
    }
}
