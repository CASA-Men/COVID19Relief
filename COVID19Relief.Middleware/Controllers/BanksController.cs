using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COVID19Relief.Middleware.Model;

namespace COVID19Relief.Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly COVONENINEContext _context;

        public BanksController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banks>>> GetBanks()
        {
            return await _context.Banks.ToListAsync();
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banks>> GetBanks(byte id)
        {
            var banks = await _context.Banks.FindAsync(id);

            if (banks == null)
            {
                return NotFound();
            }

            return banks;
        }

        // PUT: api/Banks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanks(byte id, Banks banks)
        {
            if (id != banks.BankId)
            {
                return BadRequest();
            }

            _context.Entry(banks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanksExists(id))
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

        // POST: api/Banks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Banks>> PostBanks(Banks banks)
        {
            _context.Banks.Add(banks);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BanksExists(banks.BankId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBanks", new { id = banks.BankId }, banks);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banks>> DeleteBanks(byte id)
        {
            var banks = await _context.Banks.FindAsync(id);
            if (banks == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(banks);
            await _context.SaveChangesAsync();

            return banks;
        }

        private bool BanksExists(byte id)
        {
            return _context.Banks.Any(e => e.BankId == id);
        }
    }
}
