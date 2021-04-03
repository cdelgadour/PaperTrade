using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaperTradeAPI.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "No es un correo valido")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}
