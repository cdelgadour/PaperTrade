using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaperTradeAPI.Models
{
    public enum Currency
    {
        Bitcoin,
        Ethereum,
        Dollar
    }
    public class Wallet
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Balance { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [InverseProperty("Credit")]
        public List<Transaction> Credits { get; set; }
        [InverseProperty("Debit")]
        public List<Transaction> Debits { get; set; }
    }
}
