using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaperTradeAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public int DebitWalletId { get; set; }
        public Wallet Debit { get; set; }
        public int CreditWalletId { get; set; }
        public Wallet Credit { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal BuyingPrice { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal TransactionTotal { get; set; }
    }
}
