using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperTradeAPI.Data;
using PaperTradeAPI.Models;

namespace PaperTradeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly PaperTradeAPIContext _context;

        public WalletsController(PaperTradeAPIContext context)
        {
            _context = context;
        }

        // GET: api/Wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallet()
        {
            return await _context.Wallet.ToListAsync();
        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
            var wallet = await _context.Wallet.FindAsync(id);

            if (wallet == null)
            {
                return NotFound();
            }

            return wallet;
        }

        // PUT: api/Wallets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallet(int id, Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Wallets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
            _context.Wallet.Add(wallet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallet", new { id = wallet.Id }, wallet);
        }

        // DELETE: api/Wallets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wallet>> DeleteWallet(int id)
        {
            var wallet = await _context.Wallet.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }

            _context.Wallet.Remove(wallet);
            await _context.SaveChangesAsync();

            return wallet;
        }

        private bool WalletExists(int id)
        {
            return _context.Wallet.Any(e => e.Id == id);
        }

        // GET: api/Wallets/5/Transactions
        [HttpGet("{id}/Transactions")]
        public async Task<ActionResult<List<Models.Transaction>>> GetWalletTransactions(int id)
        {
            var wallet = await _context.Wallet.FindAsync(id);

            if (wallet == null)
            {
                return NotFound();
            }
            List<Models.Transaction> transactions = new List<Models.Transaction>();
            try
            {
                transactions = await _context.Transaction.Where(x => x.CreditWalletId == wallet.Id).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Print(e.InnerException.ToString());
                throw;
            }

            return transactions;
        }
    }
}
