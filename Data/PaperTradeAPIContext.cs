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
    }
}
